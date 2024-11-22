using System.ComponentModel.DataAnnotations;

namespace CMCS.Models
{
    public class Lecturer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string ContactNumber { get; set; }
    }
}
