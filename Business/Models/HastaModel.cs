#nullable disable

using DataAccess.Enums;
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
    public class HastaModel:Record
    {
        #region Entity özellikleri

       
        [Required(ErrorMessage = "{0} zorunludur!")]
        [MaxLength(50,ErrorMessage ="{0} en çok {1} karakter olmalıdır!")]
        [MinLength(50, ErrorMessage = "{0} en çok {1} karakter olmalıdır!")]
        [DisplayName("Adı")]

        public string Adi { get; set; }

        [Required(ErrorMessage = "{0} zorunludur!")]
        [StringLength(50,MinimumLength =2,ErrorMessage= "{0} en az {2} en çok karakter {1} karakter olmalıdır!")]
        [DisplayName("Soyadı")]

        public string Soyadi { get; set; }

        [Required(ErrorMessage = "{0} zorunludur!")]
        [StringLength(11,MinimumLength =11,ErrorMessage ="{0}{1} karakter olmalıdır!")]
        [DisplayName("T.C. Kimlik No")]

        public string KimlikNo { get; set; }

        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "{0} zorunludur!")]

        public DateTime DogumTarihi { get; set; }

        public Cinsiyetler Cinsiyeti { get; set; }

        [Range(0.3,3,ErrorMessage ="{0}{1} ile {2} metre aralığında olmalıdır!")]

        public decimal? Boyu { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} {1} kilodan büyük olmalıdır!")]

        public double? Kilosu { get; set; }

        #endregion

        #region ekstra özellikler
        [DisplayName("Tam Adı")]

        public string AdiSoyadiOutput { get; set; }

        [DisplayName("Tam Adı Test1")]
        public string AdiSoyadiTestOutput => Adi + " " + Soyadi;

        /*
         public string AdiSoyadiTestOutput
        {
         get{return Ad+" "+ Soyadi;}
        }
         */

        [DisplayName("Doğum Tarihi")]

        public string DogumTarihiOutput { get; set; }

        [DisplayName("Boyu")]

        public string BoyuOutput { get; set; }

        [DisplayName("Kilosu")]

        public string KilosuOutput { get; set; }

        [DisplayName("Doktorlar")]

        public string DoktorlarOutput { get; set; }

        [DisplayName("Doktorlar")]
        //[Required] //hastanın en az bir doktoru olmalı

        public List<int> DoktorIdleriInput { get; set; } 


        #endregion

    }
}
