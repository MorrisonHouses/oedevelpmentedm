using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OEWebApplicationApp.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            /*calls username, GST, CONFIG FILE LOCATION, USER ADDRESS*/
            ClassFunctions function = new();
            ClassConfig configclass = new();
            ViewBag.Address = configclass.Address();
            ViewBag.UserName = configclass.username();
            ViewBag.GST = configclass.ConfigGST();
            ViewBag.CONFLOC = configclass.ConfigLocation();
            ViewBag.EXPLOC = configclass.ExportLocation();
            ViewBag.MorSQL = configclass.MorSQLConnections();
            ViewBag.DateTime = function.dateTime();
            ViewBag.Vmortl = configclass.vMortlSQLConnections();
            ViewBag.SMTP = configclass.EmailSMTP();
            ViewBag.PORT = configclass.EmailPort();
            ViewBag.FROM = configclass.EmailFrom();
            ViewBag.test = configclass.MorSQLConnections();

            return View();
        }
    }
}
