using SimpleLoanService.Repositories;
using SimpleLoanService.Models;
using SimpleLoanService.Interfaces;
using System.Threading.Tasks;

namespace SimpleLoanService.Services;

public class LoanService : ILoanService
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly ILoanRepository _loanRepository;
    private readonly IEmploymentInformationRepository _employmentInformationRepository;

    public LoanService(IApplicantRepository applicantRepository, ILoanRepository loanRepository, IEmploymentInformationRepository employmentInformationRepository)
    {
        _applicantRepository = applicantRepository;
        _loanRepository = loanRepository;
        _employmentInformationRepository = employmentInformationRepository;
    }

    public async Task<(int, int, int)> AddApplicantWithLoanAndEmploymentInfo(Applicant applicant, PersonalLoan loan, EmploymentInformation employmentInformation)
    {
        // First, add the applicant
        var applicantId = await _applicantRepository.AddApplicant(applicant);
        
        // Add the applicant ID to the loan
        loan.ApplicantID = applicantId;
        
        // Then, add the loan
        var loanId = await _loanRepository.AddLoan(loan);

        // Add the applicant ID to the employment information
        employmentInformation.ApplicantID = applicantId;
        
        // then, add the employment information
        var employmentInformationId =
            await _employmentInformationRepository.AddEmploymentInformation(employmentInformation);
        
        // Return the IDs of the new applicant and loan
        return (applicantId, loanId, employmentInformationId);
    }
}