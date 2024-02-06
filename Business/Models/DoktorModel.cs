using DataAccess.Entities;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class DoktorModel:Record
    {
        #region entity özellikleri

        [Required]
        [StringLength(50)]

        public string Adi { get; set; }

        [Required]
        [StringLength(50)]

        public string Soyadi { get; set; }

        public bool UzmanMi { get; set; }

        public int? KlinikId { get; set; }

        public int BransId { get; set; }

        #endregion

        #region ekstra özellikler

        public string AdiSoyodiOutput { get; set; }

        #endregion

    }
}
