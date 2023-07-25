using System.Data;
using Dapper;
using SimpleLoanService.Interfaces;
using SimpleLoanService.Models;

namespace SimpleLoanService.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly IDbConnection _db;
    private readonly ILogger<LoanRepository> _logger;

    public LoanRepository(IDbConnection db, ILogger<LoanRepository> logger)
    {
        _db = db;
        _logger = logger;
    }

    public async Task<IEnumerable<PersonalLoan>> GetLoans()
    {
        return await _db.QueryAsync<PersonalLoan>("SELECT * FROM PersonalLoans");
    }

    public async Task<int> AddLoan(PersonalLoan loan)
    {
        _logger.LogInformation($"Adding loan with LoanTypeID: {loan.LoanTypeID}");
        
        // Check if LoanTypeID exists in LoanTypes table
        const string checkLoanTypeSql = @"
            SELECT COUNT(1) FROM LoanTypes WHERE ID = @LoanTypeID
        ";

        var loanTypeExists = await _db.ExecuteScalarAsync<bool>(checkLoanTypeSql, new
        {
            LoanTypeID = loan.LoanTypeID
        });

        if (!loanTypeExists)
        {
            throw new ArgumentException($"Invalid LoanTypeID: {loan.LoanTypeID}", nameof(loan.LoanTypeID));
        }
        
        const string sql = @"
            INSERT INTO PersonalLoans(ApplicantID, LoanTypeID, LoanStatusID, LoanAmount, LoanPurpose, DateApplied, DateApproved, RepaymentTermMonths, InterestRate)
            VALUES(@ApplicantID, @LoanTypeID, @LoanStatusID, @LoanAmount, @LoanPurpose, @DateApplied, @DateApproved, @RepaymentTermMonths, @InterestRate);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

        var id = await _db.QuerySingleAsync<int>(sql, loan);
        return id;
    }
}