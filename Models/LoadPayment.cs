namespace SimpleLoanService.Models;

public class LoadPayment
{
    public int ID { get; set; }
    public int LoanID { get; set; }
    public DateTime DatePaid { get; set; }
    public decimal AmountPaid { get; set; }
}