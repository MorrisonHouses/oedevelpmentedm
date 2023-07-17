using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace OEWebApplicationApp.Models
{

    public class ViewGlaccountModel
    {
        [Key]
        public string? Account { get; set; }

        //[Column("Account_Custom_Field")]
        //[StringLength(25)]
        //[Unicode(false)]
        public string? AccountCustomField { get; set; }

        //[Column("Gate_Keeper")]
        //[StringLength(15)]
        //[Unicode(false)]
        public string? GateKeeper { get; set; }
        //[Column("Approval_Threshold")]
        public double? ApprovalThreshold { get; set; }
        public string? ApprovalGateKeeper { get; set; }
        public string? AccountTitle { get; set; }


    }//class
}//namespace
