namespace SimpleLoanService.Models;

public class EmploymentInformation
{
    public int ID { get; set; }
    public int ApplicantID { get; set; }
    public string JobTitle { get; set; }
    public decimal Income { get; set; }
    public int YearsEmployed { get; set; }
}