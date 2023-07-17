using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.Serialization;

namespace OEWebApplicationApp.Models
{
    [Table("tblCGYOE")]
    public class TblCgyoeModel
    {
        [Key]
        [Column("RequestID")]
        [DisplayName("OE")]
        public int? RequestId { get; set; }

        [Required(ErrorMessage = "Please select a Vendor Id")]
        [DisplayName("Vendor ID")]
        public string? Vendor { get; set; }

        [DisplayName("Vendor")]
        public string? VendorName { get; set; }

        [DisplayName("Created By")]
        public string? RequestedBy { get; set; }

        [Required(ErrorMessage = "Please select a GL")]
        [DisplayName("GL")]
        public string? Glaccount { get; set; }
        public int? AutoApproveThreshold { get; set; }

        [DisplayName("Amount")]
        [Required(ErrorMessage ="Please enter a value")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(1,100000, ErrorMessage ="Enter a number between 1 and 100000")]
        public double? Amount { get; set; }

        [DisplayName("GST %")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        public double? Gstvalue{get; set;}
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DisplayName("GST Amt")]
        public double? Gstamount { get; set; }

        [DataType(DataType.Currency)]
        [DisplayName("Total Amt")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? TotalAmount { get; set; }

        [DisplayName("GST Included")]
        public bool? Gstincluded { get; set; }
        public bool? Budgeted { get; set; }
        public bool? AutoApproved { get; set; }

        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Please remove all special characters: !@#$%^&*(),.<>?/:;")]
        [StringLength(1000)]
        public string? Request { get; set; }

        [Required(ErrorMessage = "Please enter a Purchase Date")]
        [DisplayName("Purchase Date")]
        
        public DateTime? PurchaseDate { get; set; }
        [DisplayName("Approver")]
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Status { get; set; }

        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Please remove all special characters: !@#$%^&*(),.<>?/:;")]
        [StringLength(1000)]
        public string? Reason { get; set; }

        public byte[]? Attachment { get; set; }
        public DateTime? Timestamp { get; set; }

        [NotMapped]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Please remove all special characters: !@#$%^&*(),.<>?/:;")]
        [DisplayName("Reject Reason")]
        [StringLength(150)]
        public string ? RejectReason { get; set; }

        //Create page var's =================================================================
        //get vendor name 
        public string? GetVendorName()
        {
            if (Vendor == null)
            {
                return "null";
            }
            else
            {
                return Vendor;
            }
        }//GetVendorName
        //get gl account
        public string? GetGlAccount()
        {
            if (Glaccount == null)
            {
                return "null";
            }
            else
            {
                return Glaccount;
            }
        }//GetGlAccount
        public int? GetThreashold()
        {
            if (AutoApproveThreshold == null)
            {
                return 0;
            }
            else
            {
                return AutoApproveThreshold;
            }
        }//GetGlAccount
        public string? GetStatus()
        {
            string value;
            if (Status == "Approved")
            {
                value = "hidden";
                return value;
            }
            else
            {
                value = "visible";
                return value;
            }
        }//GetGlAccount


        //calculation on the create page GST/AMOUNT/TOTAL AMOUNT========================================================
        public decimal? CalculateTotalValue()
        {
            if (Gstincluded == false )
            {
                decimal? totalAmount = Math.Round((decimal)((Amount * (Gstvalue / 100)) + Amount),2);
                return totalAmount;
            }
            else
            {
                decimal? totalAmount = Math.Round((decimal)((Amount / (Gstvalue + 100) * 100) + (Amount - (Amount / (Gstvalue + 100) * 100))),2);
                return totalAmount; 
            }
        }//CalculateTotalValue
        public decimal? CalculateGST()
        {
            if (Gstincluded == false)
            {
               decimal? gstAmount = Math.Round((decimal)((Amount * Gstvalue) / 100)   ,2) ;

                return gstAmount;
            }
            else 
            {
                decimal? gstAmount = Math.Round((decimal)(Amount-(Amount / (Gstvalue + 100)*100) ),2);
                return gstAmount;
            }
        }//CalculateGST
        public decimal? CalculateAmount()
        {
            if (Gstincluded == false)
            {
                decimal? newAmount = Math.Round((decimal)Amount,2);
                return newAmount;
            }
            else
            {
                decimal? newAmount = Math.Round((decimal)((Amount / (Gstvalue + 100) * 100)), 2);
                return newAmount;
            }

        }//CalculateAmount

    }//class
}//namespace
