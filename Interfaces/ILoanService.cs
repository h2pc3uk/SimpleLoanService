using SimpleLoanService.Models;
using System.Threading.Tasks;

namespace SimpleLoanService.Interfaces;

public interface ILoanService
{
    Task<(int, int)> AddApplicantWithLoan(Applicant applicant, PersonalLoan loan);
}