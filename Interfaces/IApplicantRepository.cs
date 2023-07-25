using SimpleLoanService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleLoanService.Interfaces;

public interface IApplicantRepository
{
    Task<IEnumerable<Applicant>> GetApplicants();
    Task<int> AddApplicant(Applicant applicant);
    Task UpdateApplicant(Applicant applicant);
    Task DeleteApplicant(int id);
}