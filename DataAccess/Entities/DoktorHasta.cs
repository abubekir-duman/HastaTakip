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

    //1.yöntem

    //[PrimaryKey(nameof(DoktorId),nameof(HastaId))]

    //public class DoktorHasta
    //{
    //    [Key]

    //    public int DoktorId { get; set; }

    //    public Doktor Doktor { get; set; }

    //    [Key] 

    //    public int HastaId { get; set; }

    //    public Hasta hasta { get; set; }
    //}


    //2.yöntem

    public class DoktorHasta:Record
    {
        

        public int DoktorId { get; set; }

        public Doktor Doktor { get; set; }

        

        public int HastaId { get; set; }

        public Hasta hasta { get; set; }
    }
}
