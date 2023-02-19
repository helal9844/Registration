using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmailConfirm
    {
        public int Id { get; set; }
        [StringLength(4)]
        public string Code { get; set; } = "";

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    
    }
}
