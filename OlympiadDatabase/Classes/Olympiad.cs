using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Classes
{
    public class Olympiad : EntityBase
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [ForeignKey("Type")]
        public int TypeID { get; set; }
        [Required]
        public int CountryID { get; set; }

        public virtual OlympType Type { get; set; }
        public virtual Country Country { get; set; }
    }
}
