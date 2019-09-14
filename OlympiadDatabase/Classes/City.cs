using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Classes
{
    public class City : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Country")]
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
    }
}
