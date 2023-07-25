using SimpleLoanService.Models;

namespace SimpleLoanService.Interfaces;

public interface ILoanRepository
{
    Task<IEnumerable<PersonalLoan>> GetLoans();
    Task<int> AddLoan(PersonalLoan loan);
}