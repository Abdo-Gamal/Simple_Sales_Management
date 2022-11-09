using AutoMapper;
using FastReport.Data;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using sales_management.Models;
using sales_management.Services;

namespace sales_management.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IServices<Customer> CustomerTypeService;
        private readonly IConfiguration configuration;

        private readonly IMapper mapper;

        public ReportController(IWebHostEnvironment _webHostEnvironment,
           IServices<Customer> _CustomerService,
            IMapper _mapper,IConfiguration _configuration)
        {
            mapper = _mapper;
            this.CustomerTypeService = _CustomerService;
            this.configuration = _configuration;
            this.webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetCustomerListByType(int id)
        {
            WebReport web = new WebReport();
            var path=$"{webHostEnvironment.WebRootPath}\\Reports\\GetCustomerListByType.frx";
            web.Report.Load(path);
            //passing connstring
            var mssqlDataConnection = new MsSqlDataConnection();
            mssqlDataConnection.ConnectionString = configuration.GetConnectionString("DefaultConnection");
         
            var conn = mssqlDataConnection;
            web.Report.SetParameterValue("CONN", conn);
            web.Report.SetParameterValue("TblCatagroyID", id);

            return View(web);
        }
    }
}
