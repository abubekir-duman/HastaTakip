using DataAccess.Enums;
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
    public class Hasta:Record
    {
        [Required]
        [StringLength(50)]

        public string Adi { get; set; }

        [Required]
        [StringLength(50)]

        public string Soyadi { get; set; }

        [Required]
        [StringLength(11)]

        public string KimlikNo { get; set; }

        public DateTime DogumTarihi { get; set; }

        public Cinsiyetler Cinsiyeti { get; set; }

        public decimal? Boyu { get; set; }

        public double? Kilosu { get; set; }

        public List<DoktorHasta> DoktorHastalar { get; set; }//many to many relation
    }
}
