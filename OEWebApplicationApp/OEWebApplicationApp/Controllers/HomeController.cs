using Microsoft.AspNetCore.Mvc;
using OEWebApplicationApp.Models;
using System.Diagnostics;

namespace OEWebApplicationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*calls username*/
            ManagerViewGLaccount viewGLaccountManager = new ManagerViewGLaccount();
            ClassFunctions function = new();
            ClassConfig configclass = new();
            ViewBag.UserName = configclass.username();
            ViewBag.DateTime = function.dateTime();
            try
            {
                ViewBag.UserName = configclass.username();
                ViewBag.ApproverBool = viewGLaccountManager.GetApprovalBool();
                ViewBag.RequesterBool = viewGLaccountManager.GetRequestBool();
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }

            return View();
        }

        public IActionResult UnderConstruction()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}