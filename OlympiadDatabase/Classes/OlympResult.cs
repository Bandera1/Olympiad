using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Classes
{
    public class OlympResult : EntityBase
    {
        [Required]
        [ForeignKey("Olympiad")]
        public int OlympID { get; set; }
        [Required]
        [ForeignKey("SportType")]
        public int SportTypeID { get; set; }
        //[Required]
        //[ForeignKey("City")]
        //public int CityID { get; set; }
        [Required]
        [ForeignKey("Person")]
        public int PersonID { get; set; }
        [Required]
        public int Place { get; set; }


        public virtual Olympiad Olympiad { get; set; }
        public virtual OlympType OlympiadType { get; set; }
        public virtual SportType SportType { get; set; }
        //public virtual City City { get; set; }
        public virtual Person Person { get; set; }
    }
}
