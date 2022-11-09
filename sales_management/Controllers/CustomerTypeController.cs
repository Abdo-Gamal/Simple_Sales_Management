using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sales_management.Models;
using sales_management.ModelView;
using sales_management.Services;

namespace sales_management.Controllers
{
    public class CustomerTypeController : Controller
    {
        private readonly IServices<CustomerType> CustomerTypeService;
        private readonly IMapper mapper;

        public CustomerTypeController(IServices<CustomerType> _CustomerTypeService,
            IMapper _mapper)
        {
            mapper = _mapper;
            this.CustomerTypeService = _CustomerTypeService;
        }

        public IActionResult Index()
        {
           var Type = CustomerTypeService.GetAll();
            var data = mapper.Map<IEnumerable<CustomerTypeModelView>>(Type);
            return View(data);
        }
        //[AcceptVerbs("Get","Post")]
        //public IActionResult CheackType(string type, int Id = 0)
        //{
        //    var cat = CustomerTypeService.GetAll().FirstOrDefault(c => c.type == type && c.Id != Id);
        //    if (cat != null)
        //        return Json(false);
        //    else
        //        return Json(true);
        //}

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(CustomerTypeModelView model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                var cat = CustomerTypeService.GetAll().FirstOrDefault(c => c.type == model.type );
                if(cat != null)
                {
                    ModelState.AddModelError("", "type already exists");
                    return View(model);
                }
                var t= mapper.Map<CustomerType>(model);
                CustomerTypeService.Add(t);
                return RedirectToAction("index", "CustomerType");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {

            CustomerType ctm = CustomerTypeService.GetDeatails(id);
            return View(ctm);
        }
        [HttpPost]
        public ActionResult DeleteConfig(int id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Delete", new { id = id });

            try
            {
                CustomerTypeService.Delete(id);
                return RedirectToAction("Index", "CustomerType");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Delete", new { id = id });
            }
        }

        public ActionResult Edit(int id)
        {
            CustomerType type = CustomerTypeService.GetDeatails(id);
            return View(type);
        }
        [HttpPost]
        public ActionResult Edit(int id,CustomerTypeModelView updateType)
        {
            if (!ModelState.IsValid)
                return View(updateType);
            //CustomerType Type = new CustomerType() { type = updateType.type };
            CustomerType Type = mapper.Map<CustomerType>(updateType);
            try
            {

                CustomerTypeService.Update(id, Type);
                return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(Type);
            }
        }


    }
}
