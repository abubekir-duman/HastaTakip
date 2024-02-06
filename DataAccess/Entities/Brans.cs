#nullable disable

using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Brans:Record
    {
        [Required]
        [StringLength(150)]

        public string Adi { get; set; }

        //public ICollection<Doktor> Doktorlar { get; set; }

        public List<Doktor> Doktorlar { get; set; }
    }
}
