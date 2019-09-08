using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Classes
{
    public class Person : EntityBase
    {
        [StringLength(70)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(70)]
        [Required]
        public string SecondName { get; set; }
        [StringLength(70)]
        [Required]
        public string ThirdName { get; set; }
        [ForeignKey("Country")]
        public int? CountryID { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string PhotoPath { get; set; }


        public virtual Country Country { get; set; }
    }
}
