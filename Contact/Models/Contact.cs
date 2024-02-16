using System.ComponentModel.DataAnnotations;

namespace Contact.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Workplace { get; set; }
    }
}
