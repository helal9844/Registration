using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        public int Id { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Phone { get; set; } = "";
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+@([a-zA-Z]+\\.)+[a-zA-Z]{2,6}]&", ErrorMessage = "Email Not Corrict")]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string ConfirmPassword { get; set; } = "";
        [ForeignKey("UserCountryId")]
        [Required]
        public int UserCountryId { get; set; }
        public UserCountry Country { get; set; }
        public EmailConfirm EmailConfirm { get; set; }
    }
}
