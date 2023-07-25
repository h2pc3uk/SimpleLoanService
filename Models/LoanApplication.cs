namespace SimpleLoanService.Models;

public class LoanApplication
{
    public Applicant Applicant { get; set; }
    public PersonalLoan PersonalLoan { get; set; }
    public EmploymentInformation EmploymentInformation { get; set; }
}