using Microsoft.AspNetCore.Mvc;
using OEWebApplicationApp.Models;
using System.Data;

namespace OEWebApplicationApp.Controllers
{
    public class ApprovalController : Controller
    {

        private IHttpContextAccessor Accessor;
        public string NewUserName()
        {
            string value;
            value = HttpContext.User.Identity.Name.Remove(0, 14);
            //value = "dwyton";
            //value = "edoucett";

            return value.ToLower();
        }
        //instace of helper classes======================================================
        private ManagerTblCgyoe tblCgyoeManager = new();
        private ClassFunctions function = new();
        private ClassConfig configclass = new();

        // GET: =========================================================================
        public ActionResult Index(string id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName().ToLower();
            ViewBag.DateTime = function.dateTime();
            try
            {
                var OElist = tblCgyoeManager.GetViewApproverOERequest(id, NewUserName());
                if (!OElist.Any())
                {
                    OElist = tblCgyoeManager.GetViewApproverOERequest(id, NewUserName()).OrderByDescending(x => x.RequestId).ToList();
                    TempData["Info Message"] = "-- Message Center: You do not have any approvals --";
                    return View(OElist);
                }
                else
                {
                    OElist = tblCgyoeManager.GetViewApproverOERequest(id, NewUserName()).OrderByDescending(x => x.RequestId).ToList();
                    return View(OElist);
                }
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }
            // var OElist = tblCgyoeManager.GetViewApproverOERequest(id);
            //return View(OElist);
        }

        // DETAILS: =========================================================================
        public ActionResult Details(int id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();
            try
            {
                var OElist = tblCgyoeManager.GetViewOEById(id, NewUserName());
                return View(OElist);
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }
            //var OElist = tblCgyoeManager.GetViewOEById(id);
            //return View(OElist);
        }

        // EDIT: =========================================================================
        public ActionResult Edit(int id)
        {
            ClassFunctions function = new();
            ClassConfig configclass = new();
            //ViewBag.UserName = configclass.username();
            ViewBag.UserName = NewUserName();
            ViewBag.DateTime = function.dateTime();
            ViewBag.status = tblCgyoeManager.StatusList();
            try
            {
                var OElist = tblCgyoeManager.GetViewOEById(id, NewUserName()).FirstOrDefault();
                return View(OElist);
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }

        }

        // POST: ApprovalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult Edit(int id, TblCgyoeModel TblCgyoeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = tblCgyoeManager.ApproveRequest(id, TblCgyoeModel, NewUserName());
                    if (IsUpdated)
                    {
                        ViewData["SendToName"] = TblCgyoeModel.RequestedBy + "@morrisonhomes.ca";
                        string? reason = TblCgyoeModel.Reason;
                        string? request = TblCgyoeModel.Request;
                        double gst = Math.Round((double)TblCgyoeModel.Gstamount, 2);
                        double totalAmount = Math.Round((double)TblCgyoeModel.TotalAmount, 2);
                        string? vendor = TblCgyoeModel.Vendor;
                        function.WriteToFile(id, vendor, reason, request, gst, totalAmount);
                        TempData["Info Message"] = "--Message Center: Approval Notification Sent to " + ViewData["SendToName"] + " --";
                        //TODO change email to approver
                        string email1 = TblCgyoeModel.RequestedBy + "@morrisonhomes.ca";
                        string email = "evan.doucett@morrisonhomes.ca";
                        string body = "Dear Recipient, \n \n Please be advised that your OE " + TblCgyoeModel.RequestId + " has been approved. ";
                        string subject = "-- OE Approval Notification.";
                        function.SendEmail(email1, body, subject);
                        return RedirectToAction("Index", new { id = "notApproved" });
                    }
                    else
                    {
                        TempData["Info Message"] = "--Message Center: Approval was NOT Success--";
                        return RedirectToAction("Index", new { id = "notApproved" });
                    }
                }
                return RedirectToAction("Index", new { id = "notApproved" });
            }
            catch (Exception ex)
            {

                TempData["Info Message"] = ex.Message;
                return RedirectToAction("Index", new { id = "notApproved" });
            }
        }

        // DELETE/REJECT: =========================================================================
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApprovalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TempData["Info Message"] = "--Message Center: Delete was success--";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Info Message"] = "--Message Center: Delete was NOT success--";
                return View();
            }
        }

        public ActionResult Reject(int id, string requestedby)
        {
            ViewData["Id"] = id;
            ViewData["RequestedBy"] = requestedby;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(int id, string RequestedBy, TblCgyoeModel tblCgyoeModel)
        {
            try
            {
                //TODO change email to requested
                string email1 = RequestedBy + "@morrisonhomes.ca";
                string email = "evan.doucett@morrisonhomes.ca";
                string body = "Dear Recipient, \n \n Please be advised that your OE request " + id + " has been REJECTED.\n Reason for rejection: " + tblCgyoeModel.RejectReason;
                string subject = "-- OE Rejection Notification.";
                TempData["Info Message"] = "--Message Center: Approval Rejection Sent to " + email1 + " --";
                function.SendEmail(email1, body, subject);
                RejectDelete(id, tblCgyoeModel);
                return RedirectToAction("Index", new { id = "notApproved" });
            }
            catch
            {
                TempData["Info Message"] = "--Message Center: Reject was NOT success--";
                return View();
            }
        }
        public ActionResult RejectDelete(int id, TblCgyoeModel tblCgyoe)
        {
            ManagerImage managerImage = new ManagerImage();
            try
            {
                //remove oe request from db
                string result = tblCgyoeManager.Delete(id, NewUserName());
                //remove oe scanned images from db and file
                managerImage.DeleteAllImages(id, tblCgyoe);
                return RedirectToAction("Index", new { id = "notApproved" });
            }
            catch (Exception ex)
            {
                TempData["Info Message"] = ex.Message;
                return View();
            }

        }//Delete

    }//CLASS
}//NAMESPACE
