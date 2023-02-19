using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserCountry
    {
        [Key]
        public int UserCountryId { get; set; }
        [Required]
        public string Country { get; set; }
        public int DailCode { get; set; }


        public ICollection<User> Users { get; set; }
        public UserCountry()
        {
           this.Users = new HashSet<User>();

        }

    }
}
