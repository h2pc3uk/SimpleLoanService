using SimpleLoanService.Interfaces;
using System.Data;
using SimpleLoanService.Models;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoanService.Repositories;

public class ApplicantRepository : IApplicantRepository
{
    private readonly IDbConnection _db;

    public ApplicantRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Applicant>> GetApplicants()
    {
        return await _db.QueryAsync<Applicant>("SELECT * FROM Applicants");
    }

    public async Task<int> AddApplicant(Applicant applicant)
    {
        const string sql = @"
            INSERT INTO Applicants(FirstName, LastName, Email, Phone, DPB)
            VALUES(@FirstName, @LastName, @Email, @Phone, @DOB);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";

        var id = await _db.QuerySingleAsync<int>(sql, applicant);
        return id;
    }

    public async Task UpdateApplicant(Applicant applicant)
    {
        const string sql = @"
            UPDATE Applicants
            SET FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email,
                Phone = @Phone,
                DOB = @DOB
            WHERE ID = @ID;
        ";

        await _db.ExecuteAsync(sql, applicant);
    }

    public async Task DeleteApplicant(int id)
    {
        const string sql = @"
            DELETE FROM Applicants
            WHERE ID = @ID;
        ";

        await _db.ExecuteAsync(sql, new { ID = id });
    }
}