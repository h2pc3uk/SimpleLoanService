using System.Data;
using Dapper;
using SimpleLoanService.Interfaces;
using SimpleLoanService.Models;
using System.Threading.Tasks;

namespace SimpleLoanService.Repositories;

public class EmploymentInformationRepository : IEmploymentInformationRepository
{
    private readonly IDbConnection _db;

    public EmploymentInformationRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<int> AddEmploymentInformation(EmploymentInformation employmentInformation)
    {
        const string sql = @"
            INSERT INTO EmploymentInformation(ApplicantID, Company, JobTitle, YearsEmployed, Income)
            VALUES (@ApplicantID, @Company, @JobTitle, @YearsEmployed, @Income);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

        var id = await _db.QuerySingleAsync<int>(sql, employmentInformation);
        return id;
    }
}