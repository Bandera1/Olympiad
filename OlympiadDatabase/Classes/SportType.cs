using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Classes
{
    public class SportType : EntityBase
    {
        [StringLength(60)]
        [Required]
        public string Name { get; set; }
    }
}
