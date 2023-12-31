﻿namespace SimpleLoanService.Models;

public class PersonalLoan
{
    public int ID { get; set; }
    public int ApplicantID { get; set; } 
    public int LoanTypeID { get; set; } = 1;
    public int LoanStatusID { get; set; } = 2;
    public decimal LoanAmount { get; set; }
    public string LoanPurpose { get; set; }
    public DateTime? DateApplied { get; set; }
    public DateTime? DateApproved { get; set; }
    public int RepaymentTermMonths { get; set; }
    public decimal InterestRate { get; set; }
}