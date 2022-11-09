using AspNetCore.Reporting;
using AutoMapper;
using FastReport.Data;
using FastReport.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.WebForms;
using sales_management.Models;
using sales_management.ModelView;
using sales_management.Services;
using System.Collections.Generic;
using LocalReport = AspNetCore.Reporting.LocalReport;

namespace sales_management.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IServices<Customer> customerService;
        private readonly IServices<CustomerType> customerTypeService;
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly IMapper mapper;

        public CustomerController(IServices<Customer> _customerService,
            IServices<CustomerType> _customerTypeService,
            IMapper _mapper,
           IWebHostEnvironment _webHostEnvironment)
        {
            mapper = _mapper;
            customerService = _customerService;
             customerTypeService= _customerTypeService;
            webHostEnvironment = _webHostEnvironment;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
        public IActionResult Index()
        {
            var data = customerService.GetAll();
           var rest=  mapper.Map<IEnumerable<CustomerModelView>>(data);
            return View(rest);
        }

        public IActionResult print()
        {
            string mimetype = "";
            int extsion = 1;
            var path = $"{webHostEnvironment.WebRootPath}\\Reports\\report2.rdlc";
            Dictionary<string, string> primters = new Dictionary<string, string>();
            //  primters.Add("rp1","RDLC first report");
            var cus =  customerService.GetAll().
                Select(s => new CustomerRepoModelView()
            {
                Id = s.Id,
                Customer_name = s.Customer_name,
                Trade_Name = s.Trade_Name
            ,
                address = s.address
            }).ToList();
            
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet1", cus);
            var reslt = localReport.Execute(RenderType.Pdf, extsion, primters, mimetype);

            return File(reslt.MainStream,"application/pdf");
        }
        
        public IActionResult create ()
        {
            List<CustomerType> CustomerType = customerTypeService.GetAll();
            ViewBag.CustomerTypes = CustomerType;
            return View();
        }
        [HttpPost]
        public IActionResult create(CustomerModelView ctm)
        {
            List<CustomerType> CustomerType = customerTypeService.GetAll();
            ViewBag.CustomerTypes = CustomerType;

            if (!ModelState.IsValid)
                return View(ctm);
            try
            {
               var res= mapper.Map<Customer>(ctm);
                customerService.Add(res);
                return RedirectToAction("index", "Customer");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(ctm);
            }
        }

        public ActionResult Delete(int id)
        {
            Customer ctm = customerService.GetDeatails(id);
          var ret=  mapper.Map<CustomerModelView>(ctm);
            return View(ret);
        }
        [HttpPost]
        public ActionResult DeleteConfig(int id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Delete", new { id = id });

            try
            {
                customerService.Delete(id);
                return RedirectToAction("Index", "Customer");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Delete", new { id = id });
            }
        }


        public ActionResult Edit(int id)
        {
            List<CustomerType> CustomerType = customerTypeService.GetAll();
            ViewBag.CustomerTypes = CustomerType;
            Customer ctm = customerService.GetDeatails(id);
               var res=mapper.Map<CustomerModelView>(ctm);
            return View(res);
        }
        [HttpPost]
        public ActionResult Edit(CustomerModelView cust)
        {
            List<CustomerType> CustomerType = customerTypeService.GetAll();
            ViewBag.CustomerTypes = CustomerType;

            if (!ModelState.IsValid)
                return View(cust);
            try
            {
                var res=mapper.Map<Customer>(cust);
                customerService.Update(cust.Id, res);
                        return RedirectToAction("index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cust);
            }
        }


    }
}
