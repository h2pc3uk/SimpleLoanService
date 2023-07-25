using SimpleLoanService.Models;
using System.Threading.Tasks;

namespace SimpleLoanService.Interfaces;

public interface IEmploymentInformationRepository
{
    Task<int> AddEmploymentInformation(EmploymentInformation employmentInformation);
}