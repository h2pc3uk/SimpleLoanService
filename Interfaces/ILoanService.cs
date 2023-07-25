using SimpleLoanService.Models;
using System.Threading.Tasks;

namespace SimpleLoanService.Interfaces;

public interface ILoanService
{
    // Task<(int, int)> AddApplicantWithLoan(Applicant applicant, PersonalLoan loan);

    Task<(int, int, int)> AddApplicantWithLoanAndEmploymentInfo(Applicant applicant, PersonalLoan loan,
        EmploymentInformation employmentInformation);
}