using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Classes
{
    public class Persons : EntityBase
    {
        [StringLength(70)]
        public string FirstName { get; set; }
        [StringLength(70)]
        public string SecondName { get; set; }
        [StringLength(70)]
        public string ThirdName { get; set; }
        public int CountryID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhotoPathh { get; set; }
    }
}
