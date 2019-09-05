using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympiadDatabase.Classes
{
    public class Countries : EntityBase
    {
        [StringLength(30)]
        public string Name { get; set; }
    }
}
