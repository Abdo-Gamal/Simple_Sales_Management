using AspNetCore.Reporting;
using AutoMapper;
using EnvDTE;
using FastReport.Export.Html;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Imaging;
using sales_management.Models;
using sales_management.ModelView;
using sales_management.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Drawing.Imaging;


namespace sales_management.Controllers
{
    //invoices.rdlc
    public class invoiceController : Controller
    {
        private readonly IServices<invoice> invoiceService;
        private readonly IServices<Customer> CustomerService;
        private readonly IServices<products> productsService;
        private readonly IServices<Company_info> Company_infoService;

        private readonly IServices<Car> carService;

        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;

        public invoiceController(IServices<invoice> _invoiceService,
            IServices<Customer> _CustomerService,
            IServices<products> _productsService,
            IWebHostEnvironment _webHostEnvironment,
            IServices<Company_info> _Company_infoService,
            IServices<Car> _carService,
        IMapper _mapper)
        {
            Company_infoService = _Company_infoService;
            productsService = _productsService;
            CustomerService = _CustomerService;
            webHostEnvironment = _webHostEnvironment;
            mapper = _mapper;
            invoiceService = _invoiceService;
            carService = _carService;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        }

        public IActionResult Index()
        {
            var model = invoiceService.GetAll();
            List<DisplayInvoicsModelView> data = new List<DisplayInvoicsModelView>();
            foreach ( var item in model) 
            {
                data.Add(new DisplayInvoicsModelView()
                {
                    Date = item.Date,
                    Id = item.Id,
                    totale = item.Total,
                    customerName = CustomerService.GetAll().Where(
                        c => c.Id == item.customerId).FirstOrDefault().Customer_name
                   
                }); 
            }
            return View(data);
        }
        public IActionResult print(int Id)
        {

            string mimetype = "";
            int extsion = 1;
            var path = $"{webHostEnvironment.WebRootPath}\\Reports\\invoicesRepo.rdlc";
            Dictionary<string, string> primters = new Dictionary<string, string>();
            var com = Company_infoService.GetAll().
                Select(s => new CompanyInfoRepoModelView()
                {

                    Company_name = s.Company_name,
                    address = s.address,
                    note = s.note,
                    phone_number = s.phone_number,
                    Whatsapp = s.Whatsapp.ToString(),
                }).FirstOrDefault();
            var invo = invoiceService.GetDeatails(Id);
            string cusName = CustomerService.GetAll().Where(c=>c.Id==invo.customerId).SingleOrDefault().Customer_name;
            primters.Add("Company_name", com.Company_name);
            primters.Add("address", com.address);
            primters.Add("note", com.note);
            primters.Add("phone_number", com.phone_number.ToString());
            primters.Add("whatsapp", com.Whatsapp);
            primters.Add("Id", invo.Id.ToString());
            primters.Add("Date", invo.Date.ToString("dd/MM/yyyy"));
            primters.Add("Time", invo.Date.ToString("h:m:s"));
            primters.Add("Total", invo.Total.ToString());
            primters.Add("pure", invo.Total.ToString());
            primters.Add("paid", invo.Total.ToString());
            primters.Add("Discount", "0.0");
            primters.Add("Residual", "0.0");
            primters.Add("cusName", cusName);
            var carProd = carService.GetAll().Where(c=>c.invoiceId==Id).
                Select(s => new ProductCarRepoModelView()
                {
                    Id=s.Id,
                    prices = s.price,
                    quantity = s.quantity,
                    ProductName = productsService.GetDeatails
                    (s.productsId).Name,
                }) ;

            /////////////////////report size 
   
            ////////////////////////////////////////////////imge 
            string imagePrm = "";
            var imgeName = Company_infoService.GetAll().FirstOrDefault().logo;
            var imagePath = $"{webHostEnvironment.WebRootPath}\\img\\27066886_10215764255445700_5623433962692202715_n220959967.jpg" ;
            using(var b=new Bitmap(imagePath)){

                using(var ms=new MemoryStream())
                {
                    b.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    imagePrm = Convert.ToBase64String(ms.ToArray());
                }
            }
           // primters.Add("image", imagePrm);

            ////////////////////////////////////////////////

            LocalReport localReport = new LocalReport(path);
             localReport.AddDataSource("DataSet1", carProd);
            
            var reslt = localReport.Execute(RenderType.Pdf, extsion, primters, mimetype);
          
            return File(reslt.MainStream, "application/pdf");
        }

        public IActionResult create()//add user in invoice and data only
        {
            List<Customer> Customers = CustomerService.GetAll();
            ViewBag.CustomerLsit = Customers;
            var data = new invoicesModelView() { Date=DateTime.Now};
            return View(data);
        }
        [HttpPost]
        public IActionResult create(invoicesModelView inv)//invoicesModelView have custmoerId,Date
        {
            List<Customer> Customers = CustomerService.GetAll();
            ViewBag.CustomerLsit = Customers;

            if (!ModelState.IsValid)
                return View(inv);
            try
            {
                invoice res = mapper.Map<invoice>(inv);
                invoiceService.Add(res);
                int invoiceId = invoiceService.GetAll().Where(s=>s.customerId==inv.customerId&&s.iscofirm==false)
                    .SingleOrDefault().Id;
                return RedirectToAction("addProductToinvoice", "invoice", new { invoiceId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(inv);
            }
        }

        public IActionResult addProductToinvoice( int invoiceId)//invoicesModelView have custmoerId,Date
        {

            List<products> products = productsService.GetAll();
            ViewBag.productsLsit = products;
            ViewBag.invoiceId = invoiceId;
            return View();
        }
        [HttpPost]
        public IActionResult addProductToinvoice(int invoiceId,ProductToinvoiceModelView car)//
        {

            List<products> products = productsService.GetAll();
            ViewBag.productsLsit = products;

            if (!ModelState.IsValid)
                return View(car);
            try
            {
                car.invoiceId = invoiceId;
                Car res = mapper.Map<Car>(car);
                carService.Add(res);
                return RedirectToAction("addProductToinvoice", "invoice", new { invoiceId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(car);
            }
        }
        public IActionResult colseOrder(int invoiceId)
        {
            var order = invoiceService.GetDeatails(invoiceId);
            List<Car> cars=carService.GetAll().Where(c=>c.invoiceId== invoiceId).ToList();
            order.Total = 0;
            foreach (Car car in cars)
                order.Total += car.quantity * car.price;

            
            if(order!=null)
            order.iscofirm = true;
            else 

            if (!ModelState.IsValid)
                return View(order);
            try
            {
                invoiceService.Update(invoiceId,order);
                return RedirectToAction("index", "invoice", new { invoiceId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(order);
            }
        }


    }
}
