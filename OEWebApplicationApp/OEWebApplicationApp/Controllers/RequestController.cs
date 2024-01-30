using Microsoft.AspNetCore.Mvc;
using OEWebApplicationApp.Models;
using System.Data;

namespace OEWebApplicationApp.Controllers
{
    public class RequestController : Controller
    {
        public string NewUserName()
        {
            string value;
            value = HttpContext.User.Identity.Name.Remove(0, 14);
            //value = "cpitre";
            //value = "edoucett";
            //value = "sladd";

            return value.ToLower();
        }
        //instace of helper classes======================================================
        private ClassFunctions function = new();
        private ClassConfig configclass = new();
        private ManagerTblCgyoe tblCgyoeManager = new();
        private ManagerApmMasterVendor apmMasterVendorManager = new();
        private ManagerViewGLaccount viewGLaccountManager = new();
        private ManagerImage managerImage = new();

        // GET: =========================================================================
        [Route("RequestedItemUser")]
        public ActionResult Index(string id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();

            try
            {
                var OElist = tblCgyoeManager.GetViewOERequest(id, NewUserName());
                if (!OElist.Any())
                {
                    TempData["Info Message"] = "-- Message Center: You do not have any request --";
                    OElist = tblCgyoeManager.GetViewOERequest(id, NewUserName()).OrderByDescending(x => x.RequestId).ToList();
                    return View(OElist);
                }
                else
                {
                    OElist = tblCgyoeManager.GetViewOERequest(id, NewUserName()).OrderByDescending(x => x.RequestId).ToList();
                    return View(OElist);
                }
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }
        }//Index


        // Details: =====================================================================
        [Route("DetailsItem/{id}")]
        public ActionResult Details(int id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();
            try
            {
                var OElist = tblCgyoeManager.GetViewOERequestById(id, NewUserName());
                return View(OElist);
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }
            //var OElist = tblCgyoeManager.GetViewOERequestById(id);
            //return View(OElist);
        }

        public ActionResult Print2(int id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();
            try
            {
                var OElist = tblCgyoeManager.GetViewOERequestById(id, NewUserName());
                return View(OElist);
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }
            //var OElist = tblCgyoeManager.GetViewOERequestById(id);
            //return View(OElist);
        }

        // Create: =====================================================================
        //[Route("CreateItem")]
        public ActionResult Create()
        {
            string userName = NewUserName();
            //values from file==================================================
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = userName;
            ViewBag.DateTime = function.dateTime();
            ViewBag.GstValue = configclass.ConfigGST();
            //dropdown list==================================================
            ViewBag.Budgeted = tblCgyoeManager.BudgetList();
            ViewBag.autoApproved = tblCgyoeManager.AutoApproveList();
            ViewBag.status = tblCgyoeManager.StatusList();
            ViewBag.gstInc = tblCgyoeManager.GstList();
            //total var======================================================
            ViewBag.ttlamt = 0;
            ViewBag.amount = 0;
            ViewBag.newthreshold = 0;
            ViewBag.gstamt = 0;
            //select database lists==========================================
            TblCgyoeModel tblCgyoeModel = new TblCgyoeModel();
            string? name = tblCgyoeModel.GetVendorName();
            string? threashold = tblCgyoeModel.GetGlAccount();
            ViewBag.vendors = apmMasterVendorManager.GetViewVendor(NewUserName()).ToList();
            ViewBag.glAccounts = viewGLaccountManager.GetAllGlAccounts(userName);
            ViewBag.vendName = apmMasterVendorManager.GetViewVendor(NewUserName()).ToList().Where(x => x.Vendor == name);
            ViewBag.approverGK = viewGLaccountManager.GetAllGlAccounts(userName).ToList().Where(x => x.AccountCustomField == threashold);


            return View();
        }

        //Calculations: ===============================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public IActionResult Createcalc(TblCgyoeModel tblCgyoeModel)
        {
            //values from file==================================================
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();
            ViewBag.GstValue = configclass.ConfigGST();
            //dropdown list=====================================================
            ViewBag.Budgeted = tblCgyoeManager.BudgetList();
            ViewBag.autoApproved = tblCgyoeManager.AutoApproveList();
            ViewBag.status = tblCgyoeManager.StatusList();
            ViewBag.gstInc = tblCgyoeManager.GstList();
            string userName = NewUserName();
            string? name = tblCgyoeModel.GetVendorName();
            string? threashold = tblCgyoeModel.GetGlAccount();

            if (ModelState.IsValid)
            {
                ViewBag.vendors = apmMasterVendorManager.GetViewVendor(NewUserName()).ToList();
                ViewBag.glAccounts = viewGLaccountManager.GetAllGlAccounts(userName);
                ViewBag.vendName = apmMasterVendorManager.GetViewVendor(NewUserName()).ToList().Where(x => x.Vendor == name);
                ViewBag.threashold = viewGLaccountManager.GetAllGlAccounts(userName).ToList().Where(x => x.AccountCustomField == threashold);
                ViewBag.approverGK = viewGLaccountManager.GetAllGlAccounts(userName).ToList().Where(x => x.AccountCustomField == threashold);
                ViewBag.gstamt = tblCgyoeModel.CalculateGST();
                ViewBag.ttlamt = tblCgyoeModel.CalculateTotalValue();
                ViewBag.newAmt = tblCgyoeModel.CalculateAmount();
                ViewBag.newthreshold = ((double)viewGLaccountManager.GetThreshold(tblCgyoeModel.Glaccount, userName) - (double)tblCgyoeModel.CalculateTotalValue());
            }
            else
            {
                ViewBag.ttlamt = 0;
                ViewBag.gstamt = 0;
                ViewBag.newAmt = 0;
                ViewBag.vendors = apmMasterVendorManager.GetViewVendor(NewUserName()).ToList();
                ViewBag.glAccounts = viewGLaccountManager.GetAllGlAccounts(userName);
                ViewBag.vendName = "";
                ViewBag.approverGK = "";
                ViewBag.newthreshold = 0;
            }

            return View(tblCgyoeModel);
        }

        //Create: ==================================================================
        [HttpPost]
        [ActionName("CreateNew")]
        [ValidateAntiForgeryToken]
        public ActionResult Createupdate(TblCgyoeModel tblCgyoe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = tblCgyoeManager.createProduct(tblCgyoe, NewUserName());
                    if (IsUpdated)
                    {
                        ViewData["SendToName"] = tblCgyoe.ApprovedBy + "@morrisonhomes.ca";
                        TempData["Info Message"] = "--Message Center: Creation Successfully send to " + ViewData["SendToName"] + " --";
                        //TODO: change email to approver
                        string email1 = tblCgyoe.ApprovedBy + "@morrisonhomes.ca";
                        string email = "evan.doucett@morrisonhomes.ca";
                        string body = "Dear Recipient, \n \n Please be advised that you have an OE approval. ";
                        string subject = "-- OE Request Notification.";
                        function.SendEmail(email1, body, subject);
                        string lastEntry = tblCgyoeManager.GetLastEntryByUser(NewUserName());
                        return RedirectToAction("Create", "Image", new { id = lastEntry, page = "request" });
                        //return RedirectToAction("Index", new { id = "notApproved" });
                    }
                    else
                    {
                        TempData["Info Message"] = "--Message Center: Creation NOT Successful--";
                        return RedirectToAction("Index", new { id = "notApproved" });
                    }
                }
                return RedirectToAction("Index", new { id = "notApproved" });
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }

        }//Createupdate

        // edit: =====================================================================
        //[Route("EditItem/{id}")]

        public ActionResult Edit(int id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();
            var OElist = tblCgyoeManager.GetViewOERequestById(id, NewUserName()).FirstOrDefault();
            return View(OElist);
        }//Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult Edit(int id, TblCgyoeModel tblCgyoeModel)
        {
            string username1 = NewUserName();
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = tblCgyoeManager.UpdateRequest(id, tblCgyoeModel, username1);
                    if (IsUpdated)
                    {
                        TempData["Info Message"] = "--Message Center: Edit successful--";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Info Message"] = "--Message Center: Edit was NOT successful, remove all special characters--";
                        return RedirectToAction("Edit");
                    }
                }
                else
                {
                    TempData["Info Message"] = "--Message Center: Edit was NOT successful, remove all special characters--";
                    return RedirectToAction("Edit");
                }
                //return RedirectToAction("Index", new { id = "notApproved" });
            }
            catch (Exception ex)
            {

                TempData["Info Message"] = ex.Message;
                return View();
            }
        }//Edit

        // Delete: REMOVE REQUEST AND IMAGES=====================================================================
        // [Route("DeleteItem/{id}")]
        public ActionResult Delete(int id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();

            TblCgyoeModel model = new TblCgyoeModel();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();
            var OElist = tblCgyoeManager.GetViewOERequestById(id, NewUserName()).FirstOrDefault();
            return View(OElist);
        }//Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, TblCgyoeModel tblCgyoe)
        {
            try
            {
                //remove oe request from db
                string result = tblCgyoeManager.Delete(id, NewUserName());
                //remove oe scanned images from db and file
                managerImage.DeleteAllImages(id, tblCgyoe);
                TempData["Info Message"] = "--Message Center: Deleting of OE and Images was Successful--";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }

        }//Delete


        // PRINT OE: INVOKE WORD FILE AND CREATE PDF FOR VIEWING=====================================================================
        public IActionResult Print(string requestid, string vendor, string purchaseDate, string glAccount, string request, double amountAmt, double taxAmt, double totalAmt, string vendorName, string page)
        {
            ViewData["Page"] = page;
            string RequestId = requestid;
            string VendorId = vendor;
            string PurchaseDate = purchaseDate;
            string GlAccount = glAccount;
            string Request = request;
            string Amount = amountAmt.ToString("c");
            string GstAmt = taxAmt.ToString("c");
            string TotalAmt = totalAmt.ToString("c");
            string VendorName = vendorName;
            try
            {
                function.CreateWordDocument(RequestId, VendorId, PurchaseDate, GlAccount, Request, Amount, GstAmt, TotalAmt, vendorName);
                return View();
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }

        }

        // AutoApprove =====================================================================
        [HttpPost]
        [ActionName("AutoApprove")]
        [ValidateAntiForgeryToken]
        public ActionResult AutoApprove(TblCgyoeModel tblCgyoe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = tblCgyoeManager.createProduct(tblCgyoe, NewUserName());
                    if (IsUpdated)
                    {
                        //approval request
                        string idLastEntry = tblCgyoeManager.GetLastEntryByUser(NewUserName());
                        tblCgyoeManager.AutoApproveRequest(Convert.ToInt32(idLastEntry), NewUserName());
                        //table values
                        int requestId = Convert.ToInt32(idLastEntry);
                        string? reason = tblCgyoe.Reason;
                        string? request = tblCgyoe.Request;
                        double gst = Math.Round((double)tblCgyoe.Gstamount, 2);
                        double totalAmount = Math.Round((double)tblCgyoe.TotalAmount, 2);
                        string? vendor = tblCgyoe.Vendor;
                        //write to file
                        function.WriteToFile(requestId, vendor, reason, request, gst, totalAmount);
                        //message to user
                        TempData["Info Message"] = "--Message Center: Approval has been approved --";
                        //string lastEntry = tblCgyoeManager.GetLastEntryByUser(NewUserName());
                        //return RedirectToAction("Create", "Image", new { id = lastEntry, page = "request" });
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Info Message"] = "--Message Center: Auto Approval not Successfull--";
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }

        }//Createupdate
    }//class
}//namespace
