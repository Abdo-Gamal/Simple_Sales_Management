using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using sales_management.Models;
using sales_management.ModelView;
using sales_management.Services;

namespace sales_management.Controllers
{
    public class Company_infoController : Controller
    {

       
        private readonly IServices<Company_info> Company_infoService;
        IWebHostEnvironment env;
        private readonly IMapper mapper;
        public Company_infoController(IServices<Company_info> _Company_infoService,
            IWebHostEnvironment _env,
            IMapper _mapper)
        {
            env = _env;
            Company_infoService = _Company_infoService;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            if (Company_infoService.GetAll().Count > 0)
            {
                var data = Company_infoService.GetAll();
                var rest = mapper.Map<Company_infoModelView>(data[0]);
                return View(rest);
            }
            else
            {
                var rest = new Company_infoModelView()
                {
                    logo = "27066886_10215764255445700_5623433962692202715_n220959967.jpg",
                    address = "Assuit",
                    Whatsapp = 01063310906,
                    Cloud_type = "1",
                    Company_name = "Logeen",
                    E_mail = "bgmail917@gmail.com",
                    Facebook = "",
                    Id = 1,
                    note = "SW company",
                    Tax_Number = 1,
                };
                return View(rest);
            }
        }


        public IActionResult create()
        {
         
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> create(Company_infoModelView cpny)
        {
         
            if (!ModelState.IsValid)
                return View(cpny);
            try
            {

                if (cpny.imagefile != null)
                {
                    string wwwRootPath = env.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(cpny.imagefile.FileName);
                    string extention = Path.GetExtension(cpny.imagefile.FileName);

                    cpny.logo = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;

                    string path = Path.Combine(wwwRootPath + "/img/" + fileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await cpny.imagefile.CopyToAsync(filestream);
                    }
                }

                var res = mapper.Map<Company_info>(cpny);
                Company_infoService.Add(res);
                return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cpny);
            }
        }


        public ActionResult Edit(int id)
        {
            var cpny = Company_infoService.GetDeatails(id);
            var res = mapper.Map<Company_infoModelView>(cpny);
            return View(res);
        }
        [HttpPost]
        public async Task<ActionResult> EditAsync( Company_infoModelView cpny, int id )
        {
            if (!ModelState.IsValid)
                return View(cpny);
            try
            {
                if (cpny.imagefile != null ) 
                { 
                string wwwRootPath = env.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(cpny.imagefile.FileName);
                string extention = Path.GetExtension(cpny.imagefile.FileName);
                
                    cpny.logo = fileName = fileName + DateTime.Now.ToString("yymmssfff")+ extention;

                    string path = Path.Combine(wwwRootPath + "/img/" + fileName);
                    using (var filestream = new FileStream(path, FileMode.Create))
                    {
                        await cpny.imagefile.CopyToAsync(filestream);
                    }
                }

                var res = mapper.Map<Company_info>(cpny);
                Company_infoService.Update(id, res);
                return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cpny);
            }
        }

    }
}
