using System.ComponentModel.DataAnnotations;

namespace RazorPagesContact.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CompanyName { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
