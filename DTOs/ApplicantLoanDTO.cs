using SimpleLoanService.Models;

namespace SimpleLoanService.DTOs;

public class ApplicantLoanDTO
{
    public Applicant Applicant { get; set; }
    public PersonalLoan Loan { get; set; }
}