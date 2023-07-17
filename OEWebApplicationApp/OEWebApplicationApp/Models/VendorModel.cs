using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OEWebApplicationApp.Models
{
    public class VendorModel
    {
        [Key]
        [StringLength(10)]
        [Unicode(false)]
        [Required(ErrorMessage = "Please select a Vendor Id")]
        public string? Vendor { get; set; }

        [StringLength(30)]
        [Unicode(false)]
        public string ? Name { get; set; } = null!;

        //public List<SelectListItem>? vendorsList { get; set; }

        //[Column("Address_1")]
        //[StringLength(33)]
        //[Unicode(false)]
        //public string? Address1 { get; set; }

        //[Column("Address_2")]
        //[StringLength(33)]
        //[Unicode(false)]
        //public string? Address2 { get; set; }

        //[StringLength(30)]
        //[Unicode(false)]
        //public string? City { get; set; }

        //[StringLength(4)]
        //[Unicode(false)]
        //public string? State { get; set; }

        //[Column("ZIP")]
        //[StringLength(10)]
        //[Unicode(false)]
        //public string? Zip { get; set; }

        //[StringLength(15)]
        //[Unicode(false)]
        //public string? Telephone { get; set; }

        //[Column("Fax_Number")]
        //[StringLength(15)]
        //[Unicode(false)]
        //public string? FaxNumber { get; set; }

        //[Column("Contact_1_Name")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? Contact1Name { get; set; }

        //[Column("Contact_1_Telephone")]
        //[StringLength(15)]
        //[Unicode(false)]
        //public string? Contact1Telephone { get; set; }

        //[Column("Contact_1_Extension")]
        //[StringLength(5)]
        //[Unicode(false)]
        //public string? Contact1Extension { get; set; }

        //[Column("Contact_2_Name")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? Contact2Name { get; set; }

        //[Column("Contact_2_Telephone")]
        //[StringLength(15)]
        //[Unicode(false)]
        //public string? Contact2Telephone { get; set; }

        //[Column("Contact_2_Extension")]
        //[StringLength(5)]
        //[Unicode(false)]
        //public string? Contact2Extension { get; set; }

        //[StringLength(20)]
        //[Unicode(false)]
        //public string? Type { get; set; }

        //[Column("Customer_Number")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? CustomerNumber { get; set; }

        //[Column("Discount_Percent")]
        //public double? DiscountPercent { get; set; }

        //[Column("Discount_Days", TypeName = "numeric(5, 0)")]
        //public decimal? DiscountDays { get; set; }

        //[Column("Payment_Days", TypeName = "numeric(5, 0)")]
        //public decimal? PaymentDays { get; set; }

        //[Column("Pmt_Days_Type")]
        //[StringLength(20)]
        //[Unicode(false)]
        //public string? PmtDaysType { get; set; }

        //[Column("Misc_Deduction_Rate")]
        //public double? MiscDeductionRate { get; set; }

        //[Column("Misc_Deduction2_Rate")]
        //public double? MiscDeduction2Rate { get; set; }

        //[Column("Expense_Account")]
        //[StringLength(25)]
        //[Unicode(false)]
        //public string? ExpenseAccount { get; set; }

        //[Column("Cost_Code")]
        //[StringLength(12)]
        //[Unicode(false)]
        //public string? CostCode { get; set; }

        //[StringLength(3)]
        //[Unicode(false)]
        //public string? Category { get; set; }

        //[Column("Vendor_Tax_Group")]
        //[StringLength(6)]
        //[Unicode(false)]
        //public string? VendorTaxGroup { get; set; }

        //[Column("Prefilled_Tax_Amount")]
        //[StringLength(20)]
        //[Unicode(false)]
        //public string? PrefilledTaxAmount { get; set; }

        //[Column("Invoice_Code_1_Default")]
        //[StringLength(10)]
        //[Unicode(false)]
        //public string? InvoiceCode1Default { get; set; }

        //[Column("Invoice_Code_2_Default")]
        //[StringLength(10)]
        //[Unicode(false)]
        //public string? InvoiceCode2Default { get; set; }

        //[Column("Dist_Code_Default")]
        //[StringLength(10)]
        //[Unicode(false)]
        //public string? DistCodeDefault { get; set; }

        //[Column("Check_Stub_Detail")]
        //[StringLength(20)]
        //[Unicode(false)]
        //public string? CheckStubDetail { get; set; }

        //[Column("One_Invoice_per_Check")]
        //public bool OneInvoicePerCheck { get; set; }

        //[Column("Receives_Lien_Waiver")]
        //public bool ReceivesLienWaiver { get; set; }

        //[Column("Receives_Form_1099")]
        //public bool ReceivesForm1099 { get; set; }

        //[Column("Recipient_ID")]
        //[StringLength(15)]
        //[Unicode(false)]
        //public string? RecipientId { get; set; }

        //[Column("Recipient_Tax_ID_Name")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? RecipientTaxIdName { get; set; }

        //[Column("Second_TIN_Notice")]
        //public bool SecondTinNotice { get; set; }

        //[Column("Form_Type_1099")]
        //[StringLength(20)]
        //[Unicode(false)]
        //public string? FormType1099 { get; set; }

        //[Column("Gross_proceeds_to_atty")]
        //public bool GrossProceedsToAtty { get; set; }

        //[Column("Gross_revenue")]
        //public double? GrossRevenue { get; set; }

        //[Column("Amt_Paid_This_Yr_1099")]
        //public double? AmtPaidThisYr1099 { get; set; }

        //[Column("Misc_Deduction2_Amt_Deducted_This_Yr")]
        //public double? MiscDeduction2AmtDeductedThisYr { get; set; }

        //[Column("Amt_Paid_Last_Yr_1099")]
        //public double? AmtPaidLastYr1099 { get; set; }

        //[Column("Misc_Deduction2_Amt_Deducted_Last_Yr")]
        //public double? MiscDeduction2AmtDeductedLastYr { get; set; }

        //[Column("Amt_Paid_Next_Yr_1099")]
        //public double? AmtPaidNextYr1099 { get; set; }

        //[Column("Misc_Deduction2_Amt_Deducted_Next_Yr")]
        //public double? MiscDeduction2AmtDeductedNextYr { get; set; }

        //[Column("Receives_Form_T5018")]
        //public bool ReceivesFormT5018 { get; set; }

        //[Column("Recipient_Type")]
        //[StringLength(20)]
        //[Unicode(false)]
        //public string? RecipientType { get; set; }

        //[Column("Business_Name_Line_1")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? BusinessNameLine1 { get; set; }

        //[Column("Business_Name_Line_2")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? BusinessNameLine2 { get; set; }

        //[Column("First_Name")]
        //[StringLength(12)]
        //[Unicode(false)]
        //public string? FirstName { get; set; }

        //[Column("Middle_Initial")]
        //[StringLength(1)]
        //[Unicode(false)]
        //public string? MiddleInitial { get; set; }

        //[Column("Last_Name")]
        //[StringLength(20)]
        //[Unicode(false)]
        //public string? LastName { get; set; }

        //[Column("Recipient_Account_Number")]
        //[StringLength(15)]
        //[Unicode(false)]
        //public string? RecipientAccountNumber { get; set; }

        //[Column("Social_Insurance_Number", TypeName = "numeric(10, 0)")]
        //public decimal? SocialInsuranceNumber { get; set; }

        //[Column("Outstndg_Amount")]
        //public double? OutstndgAmount { get; set; }

        //[Column("Outstndg_Discount")]
        //public double? OutstndgDiscount { get; set; }

        //[Column("Retainage_Being_Held")]
        //public double? RetainageBeingHeld { get; set; }

        //[Column("Misc_Deduction_Withheld")]
        //public double? MiscDeductionWithheld { get; set; }

        //[Column("Last_Auto_Number_Used", TypeName = "numeric(10, 0)")]
        //public decimal? LastAutoNumberUsed { get; set; }

        //[Column("Last_Invoice")]
        //[StringLength(15)]
        //[Unicode(false)]
        //public string? LastInvoice { get; set; }

        //[Column("Last_Inv_Date", TypeName = "date")]
        //public DateTime? LastInvDate { get; set; }

        //[Column("Last_Inv_Amount")]
        //public double? LastInvAmount { get; set; }

        //[Column("Last_Check_Bank_Acct")]
        //[StringLength(10)]
        //[Unicode(false)]
        //public string? LastCheckBankAcct { get; set; }

        //[Column("Last_Check", TypeName = "numeric(10, 0)")]
        //public decimal? LastCheck { get; set; }

        //[Column("Last_Check_Date", TypeName = "date")]
        //public DateTime? LastCheckDate { get; set; }

        //[Column("Last_Check_Amount")]
        //public double? LastCheckAmount { get; set; }

        //[Column("YTD_Amount")]
        //public double? YtdAmount { get; set; }

        //[Column("YTD_Discount_Offered")]
        //public double? YtdDiscountOffered { get; set; }

        //[Column("YTD_Discount_Taken")]
        //public double? YtdDiscountTaken { get; set; }

        //[Column("YTD_Discount_Lost")]
        //public double? YtdDiscountLost { get; set; }

        //[Column("YTD_Misc_Deduction")]
        //public double? YtdMiscDeduction { get; set; }

        //[Column("YTD_Paid")]
        //public double? YtdPaid { get; set; }

        //[Column("Last_Yr_Amount")]
        //public double? LastYrAmount { get; set; }

        //[Column("Last_Yr_Disc_Ofrd")]
        //public double? LastYrDiscOfrd { get; set; }

        //[Column("Last_Yr_Disc_Takn")]
        //public double? LastYrDiscTakn { get; set; }

        //[Column("Last_Yr_Disc_Lost")]
        //public double? LastYrDiscLost { get; set; }

        //[Column("Last_Yr_Misc_Deduction")]
        //public double? LastYrMiscDeduction { get; set; }

        //[Column("Last_Yr_Amt_Paid")]
        //public double? LastYrAmtPaid { get; set; }

        //[Column("Next_Yr_Amount")]
        //public double? NextYrAmount { get; set; }

        //[Column("Next_Yr_Disc_Ofrd")]
        //public double? NextYrDiscOfrd { get; set; }

        //[Column("Next_Yr_Disc_Takn")]
        //public double? NextYrDiscTakn { get; set; }

        //[Column("Next_Yr_Disc_Lost")]
        //public double? NextYrDiscLost { get; set; }

        //[Column("Next_Yr_Misc_Deduction")]
        //public double? NextYrMiscDeduction { get; set; }

        //[Column("Next_Yr_Amt_Paid")]
        //public double? NextYrAmtPaid { get; set; }

        //[Column("Gen_Liab_Ins_Proof_Req")]
        //public bool GenLiabInsProofReq { get; set; }

        //[Column("GL_Ins_Company")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? GlInsCompany { get; set; }

        //[Column("GL_Ins_Policy_Number")]
        //[StringLength(25)]
        //[Unicode(false)]
        //public string? GlInsPolicyNumber { get; set; }

        //[Column("GL_Ins_Effective_Dt", TypeName = "date")]
        //public DateTime? GlInsEffectiveDt { get; set; }

        //[Column("GL_Ins_Expiration_Dt", TypeName = "date")]
        //public DateTime? GlInsExpirationDt { get; set; }

        //[Column("GL_Ins_Limit")]
        //public double? GlInsLimit { get; set; }

        //[Column("Auto_Ins_Proof_Req")]
        //public bool AutoInsProofReq { get; set; }

        //[Column("Auto_Ins_Company")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? AutoInsCompany { get; set; }

        //[Column("Auto_Ins_Policy_Num")]
        //[StringLength(25)]
        //[Unicode(false)]
        //public string? AutoInsPolicyNum { get; set; }

        //[Column("Auto_Ins_Effect_Dt", TypeName = "date")]
        //public DateTime? AutoInsEffectDt { get; set; }

        //[Column("Auto_Ins_Expir_Dt", TypeName = "date")]
        //public DateTime? AutoInsExpirDt { get; set; }

        //[Column("Auto_Ins_Limit")]
        //public double? AutoInsLimit { get; set; }

        //[Column("Work_Comp_Ins_Proof_Req")]
        //public bool WorkCompInsProofReq { get; set; }

        //[Column("Work_Comp_Ins_Cmpany")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? WorkCompInsCmpany { get; set; }

        //[Column("Work_Comp_Policy_Num")]
        //[StringLength(25)]
        //[Unicode(false)]
        //public string? WorkCompPolicyNum { get; set; }

        //[Column("Work_Comp_Effect_Dt", TypeName = "date")]
        //public DateTime? WorkCompEffectDt { get; set; }

        //[Column("Work_Comp_Expir_Dt", TypeName = "date")]
        //public DateTime? WorkCompExpirDt { get; set; }

        //[Column("Work_Comp_Ins_Limit")]
        //public double? WorkCompInsLimit { get; set; }

        //[Column("Umbrella_Ins_Proof_Req")]
        //public bool UmbrellaInsProofReq { get; set; }

        //[Column("Umbrella_Ins_Company")]
        //[StringLength(30)]
        //[Unicode(false)]
        //public string? UmbrellaInsCompany { get; set; }

        //[Column("Umb_Ins_Policy_Num")]
        //[StringLength(25)]
        //[Unicode(false)]
        //public string? UmbInsPolicyNum { get; set; }

        //[Column("Umb_Ins_Effective_Dt", TypeName = "date")]
        //public DateTime? UmbInsEffectiveDt { get; set; }

        //[Column("Umb_Ins_Expir_Dt", TypeName = "date")]
        //public DateTime? UmbInsExpirDt { get; set; }

        //[Column("Umbrella_Ins_Limit")]
        //public double? UmbrellaInsLimit { get; set; }

        //[Column("Onhold_Status")]
        //public byte? OnholdStatus { get; set; }

        //[Column("Included_for_Pmt")]
        //public bool IncludedForPmt { get; set; }

        //[Column("Pmt_Amount")]
        //public double? PmtAmount { get; set; }

        //[Column("Pmt_Retainage_to_Pay")]
        //public double? PmtRetainageToPay { get; set; }

        //[Column("Pmt_Discount")]
        //public double? PmtDiscount { get; set; }

        //[Column("Pmt_Retainage_to_Hold")]
        //public double? PmtRetainageToHold { get; set; }

        //[Column("Pmt_Misc_Deduction")]
        //public double? PmtMiscDeduction { get; set; }

        //[Column("AB_Company_ID")]
        //[StringLength(36)]
        //[Unicode(false)]
        //public string? AbCompanyId { get; set; }

        //[Column("Operator_Stamp")]
        //[StringLength(20)]
        //[Unicode(false)]
        //public string? OperatorStamp { get; set; }

        //[Column("Date_Stamp", TypeName = "date")]
        //public DateTime? DateStamp { get; set; }

        //[Column("Time_Stamp")]
        //[Precision(0)]
        //public TimeSpan? TimeStamp { get; set; }

    }
}
