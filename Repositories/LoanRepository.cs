using System.Data;
using Dapper;
using SimpleLoanService.Interfaces;
using SimpleLoanService.Models;

namespace SimpleLoanService.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly IDbConnection _db;

    public LoanRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PersonalLoan>> GetLoans()
    {
        return await _db.QueryAsync<PersonalLoan>("SELECT * FROM PersonalLoans");
    }

    public async Task<int> AddLoan(PersonalLoan loan)
    {
        const string sql = @"
            INSERT INTO PersonalLoans(ApplicantID, LoanTypeID, LoanStatusID, LoanAmount, LoanPurpose, DateApplied, DateApproved, RepaymentTermMonths, InterestRate)
            VALUES(@ApplicantID, @LoanTypeID, @LoanStatusID, @LoanAmount, @LoanPurpose, @DateApplied, @DateApproved, @RepaymentTermMonths, @InterestRate);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

        var id = await _db.QuerySingleAsync<int>(sql, loan);
        return id;
    }
}