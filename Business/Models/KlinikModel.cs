#nullable disable

using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class KlinikModel:Record
    {
        #region entity özellikleri
        [Required(ErrorMessage="{0} zorunludur!")]
        [StringLength(200,ErrorMessage ="{0} maksimum {1} karakter olmalıdır!")]
        [DisplayName("Adı")]

        public string Adi { get; set; }

        [DisplayName("Açıklaması")]
        public string Aciklamasi { get; set; }
        #endregion

        #region ekstra özellikler
        [DisplayName("Doktor Sayısı")]
        public int DoktorSayisiOutput { get; set; }

        [DisplayName("Doktorlar")]
        public string DoktorlarOutput { get; set; }
        #endregion
    }
}
