using Microsoft.AspNetCore.Mvc;
using SimpleLoanService.DTOs;
using SimpleLoanService.Models;
using SimpleLoanService.Interfaces;
using System.Threading.Tasks;

namespace SimpleLoanService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpPost]
    [Route("api/Loan/AddApplicantWithLoan")]
    public async Task<IActionResult> AddApplicantWithLoan(ApplicantLoanDTO applicantLoan)
    {
        var result = await _loanService.AddApplicantWithLoan(applicantLoan.Applicant, applicantLoan.Loan);

        return CreatedAtAction(nameof(AddApplicantWithLoan), new
        {
            applicationId = result.Item1, loanId = result.Item2
        });
    }

    [HttpPost]
    [Route("api/Loan/AddLoan")]
    public async Task<ActionResult<(int, int)>> AddLoan(ApplicantLoanDTO  applicatLoan)
    {
        var (applicantId, loanId) =
            await _loanService.AddApplicantWithLoan(applicatLoan.Applicant, applicatLoan.Loan);
        
        // if the loanId is -1, it means there was a foreign key violation
        if (loanId == -1)
        {
            return BadRequest("Invalid foreign key.");
        }

        return Ok(new { applicantId, loanId });
    }
}