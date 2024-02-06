using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
#nullable disable


using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Doktor:Record
    {
        [Required]
        [StringLength(50)]

        public string Adi { get; set; }

        [Required]
        [StringLength(50)]

        public string Soyadi { get; set; }

        public bool UzmanMi { get; set; }

        public int? KlinikId { get; set; }

        public Klinik Klinik { get; set; }

        public int BransId { get; set; }

        public Brans Brans { get; set; }

        public List<DoktorHasta> DoktorHastalar { get; set; }

    }
}
