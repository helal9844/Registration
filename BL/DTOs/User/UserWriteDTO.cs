using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserWriteDTO
    {
        public int Id { get; set; }
        public byte[]? ProfilePhoto { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public  CountryDTO Country { get; set; } 

        public string Phone { get; set; } = "";

        public string Email { get; set; } = "";

        
    }
}
