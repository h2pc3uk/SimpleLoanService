namespace SimpleLoanService.Models;

public class Address
{
    public int ID { get; set; }
    public int ApplicantID { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
}