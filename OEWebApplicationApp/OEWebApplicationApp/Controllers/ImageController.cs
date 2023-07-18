using Microsoft.AspNetCore.Mvc;
using OEWebApplicationApp.Models;

namespace OEWebApplicationApp.Controllers
{
    public class ImageController : Controller
    {
        private ClassFunctions function = new();
        private ClassConfig configclass = new();
        private ManagerImage ManagerImage = new();

        //IMAGE pull by request id================================================================================================
        public ActionResult Index(string id, string page)
        {

            ClassFunctions function = new();
            ClassConfig configclass = new();
            ViewBag.UserName = configclass.username();
            ViewBag.DateTime = function.dateTime();
            try
            {
                var OElist = ManagerImage.GetImages(id);
                if (!OElist.Any())
                {
                    TempData["Info Message"] = "-- Message Center: There are no attachments uploaded for document " + id + " --";
                    OElist = ManagerImage.GetImages(id);
                    ViewData["Page"] = page;
                    ViewData["MyRequestId"] = id;
                    return View(OElist);
                }
                else
                {
                    OElist = ManagerImage.GetImages(id);
                    ViewData["Page"] = page;
                    ViewData["MyRequestId"] = id;
                    return View(OElist);
                }
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                ViewData["Page"] = page;
                ViewData["MyRequestId"] = id;
                return View();
            }
        }//Index

        //create image by id=====================================================================================================
        public IActionResult Create(string id, string page)
        {
            ViewData["Page"] = page;
            ViewData["MyRequestId"] = id;
            ImageModel model = new();
            return View(model);
        }//Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ImageModel model, string page)
        {
            ViewData["MyRequestId"] = page;
            model.IsResponse = true;
            //File Path============================================================================
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files");

            //create directory if not exist========================================================
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileInfo fileInfo = new FileInfo(model.File.FileName);

            if (!fileInfo.Exists)
            {
            //create a file name: requestid location (CGY EDM) DDMMYYYYHHMM=========================
                string dateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");
                string extentsion = fileInfo.Extension;
                string fileName = model.RequestId + model.Location + dateTime  + fileInfo.Extension;
                string fileNameWithPath = Path.Combine(path, fileName);
                ViewData["Page"] = page;
                ViewData["MyPath"] = fileNameWithPath;
            //Copy file to the local system and check for pdf=======================================
                if(extentsion.ToLower() == ".pdf")
                    {
                        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                        {
                            model.File.CopyTo(stream);
                            TempData["Info Message"] = "-- Message Center: File upload successfull --";
                        }
                        model.IsSuccess = true;
                        //update the database with location=================================================
                        ManagerImage.UpdateImageTbl(fileName, fileNameWithPath, model);
                        return RedirectToAction("Index", new { id = model.RequestId, page = ViewData["MyRequestId"] });
                    }
                    else
                    {
                        TempData["Info Message"] = "-- Message Center: Upload Failed - PDF only --";
                        return RedirectToAction("Index", new { id = model.RequestId, page = ViewData["MyRequestId"] });
                    }
            }
            else
            {
                TempData["Info Message"] = "-- Message Center: File upload NOT successfull --";
                return View("Index", new { id = model.RequestId, page = ViewData["MyRequestId"] });
            }
        }//Create

        //DELETE====================================================================================
        public IActionResult Delete(string id, string page)
        {
            var OElist = ManagerImage.GetImage(id).FirstOrDefault();
            ViewData["Page"] = page;
            return View(OElist);
        }//Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id, ImageModel imageModel, string page)
        {
            ViewData["Page"] = page;
            try
            {
                string result = ManagerImage.DeleteImage(id, imageModel);
                if (result == "Success")
                {
                    TempData["Info Message"] = "-- Message Center: Image delete was Success --";
                    return RedirectToAction("Index", "Request", new { id = imageModel.RequestId, page = ViewData["MyRequestId"] });
                }
                else
                {
                    TempData["Info Message"] = "-- Message Center: Image Delete was NOT success --";
                    return RedirectToAction("Index","Request", new { id = imageModel.RequestId, page = ViewData["MyRequestId"] });
                }
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }


        }//Delete

    }//class
}//namespace
