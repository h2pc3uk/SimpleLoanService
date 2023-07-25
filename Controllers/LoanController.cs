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
    [Route("SubmitApplication")]
    public async Task<IActionResult> SubmitApplication([FromBody] LoanApplication loanApplication)
    {
        // Extract individual data elements from the incoming loanApplication object
        // Convert them into the format expcted by _loanService.AddApplicantWithLoan method
        var applicant = loanApplication.Applicant;
        var loan = loanApplication.PersonalLoan;
        var employmentInfo = loanApplication.EmploymentInformation;
        
        // Handle the incoming data
        // This could involve calling a service method to insert the data into the database
        var result = await _loanService.AddApplicantWithLoanAndEmploymentInfo(applicant, loan, employmentInfo);
        
        // Return an appropriate HTTP response
        // For example, if the data was inserted successfully, you could return a 201 created status code
        return CreatedAtAction(nameof(SubmitApplication), new
        {
            applicantionId = result.Item1, loanId = result.Item2
        });
    }
}