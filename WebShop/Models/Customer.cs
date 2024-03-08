namespace WebShop.Models
{
    public class Customer
    {
        int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int PhoneNumber { get; set; }
    }
}
