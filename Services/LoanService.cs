using SimpleLoanService.Repositories;
using SimpleLoanService.Models;
using SimpleLoanService.Interfaces;
using System.Threading.Tasks;

namespace SimpleLoanService.Services;

public class LoanService : ILoanService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly ILoanRepository _loanRepository;

    public LoanService(IApplicantRepository applicantRepository, ILoanRepository loanRepository)
    {
        _applicantRepository = applicantRepository;
        _loanRepository = loanRepository;
    }

    public async Task<(int, int)> AddApplicantWithLoan(Applicant applicant, PersonalLoan loan)
    {
        // First, add the applicant
        var applicantId = await _applicantRepository.AddApplicant(applicant);
        
        // Add the applicant ID to the loan
        loan.ApplicantID = applicantId;
        
        // Then, add the loan
        var loanId = await _loanRepository.AddLoan(loan);
        
        // Return the IDs of the new applicant and loan
        return (applicantId, loanId);
    }
}