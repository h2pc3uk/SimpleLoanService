namespace SimpleLoanService.Models;

public class CreditReport
{
    public int ID { get; set; }
    public int ApplicantID { get; set; }
    public int CreditScore { get; set; }
    public DateTime DateChecked { get; set; }
}