using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace MVC.Controllers
{
    public class DbController : Controller
    {

        //DbContext db = new Db(); Db Context tipindeki objeler new'lenmez, sınıfa enjekte edilir.

        private readonly Db _db;

        public DbController(Db db)
        {
            _db = db;
        }



        //Db/seed
        public IActionResult Seed()
        {


            #region verilerin silinmesi
            _db.DoktorHastalar.RemoveRange(_db.DoktorHastalar.ToList());
            _db.Hastalar.RemoveRange(_db.Hastalar.ToList());
            _db.Doktorlar.RemoveRange(_db.Doktorlar.ToList());
            _db.Klinikler.RemoveRange(_db.Klinikler.ToList());
            


            var branslar =_db.Branslar.ToList();

            _db.Branslar.RemoveRange(_db.Branslar.ToList());
            #endregion

            #region verilerin eklenmesi

            _db.Branslar.Add(new Brans()
            {
                Adi = "Cerrahi",
                Guid = Guid.NewGuid().ToString()
               
            }) ;

            _db.Branslar.Add(new Brans()
            {
                Adi = "Psikiyatri",
                Guid = Guid.NewGuid().ToString()

            });

            _db.Hastalar.Add(new Hasta()
            {
                Adi="Çağıl",
                Soyadi="Alsaç",
                Guid=Guid.NewGuid().ToString(),
                Cinsiyeti=Cinsiyetler.Erkek,
                DogumTarihi=DateTime.Parse("01.05.1980", new CultureInfo("tr-Tr")),
                Boyu=1.75m,
                Kilosu=55,
                KimlikNo="12345678901"

            });

            _db.Hastalar.Add(new Hasta()
            {
                Adi = "Leo",
                Soyadi = "Alsaç",
                Guid = Guid.NewGuid().ToString(),
                Cinsiyeti = Cinsiyetler.Erkek,
                DogumTarihi = new DateTime(2014,5,29),
                Boyu = 0.4M,
                Kilosu = 10,
                KimlikNo = "12369678901"

            });

            _db.Hastalar.Add(new Hasta()
            {
                Adi = "Luna",
                Soyadi = "Alsaç",
                Guid = Guid.NewGuid().ToString(),
                Cinsiyeti = Cinsiyetler.Kadin,
                DogumTarihi = DateTime.Parse("09/20/2022", new CultureInfo("en-Us")),
                Boyu = 0.5M,
                Kilosu = 11,
                KimlikNo = "12345675901"

            });

            _db.SaveChanges();// unit of work

            _db.Klinikler.Add(new Klinik()
            {
                 Aciklamasi="Ankara Çankaya'da Özel Bir Poliklinik",
                 Adi="Özel Çankaya Polikliniği",
                 Guid=Guid.NewGuid().ToString(),
                 Doktorlar=new List<Doktor>()
                 {
                     new Doktor()
                     {
                         Guid=Guid.NewGuid().ToString(),
                         Adi="Ali",
                         Soyadi="Vefa",
                        // UzmanMi=false,//default false

                         //1.yöntem
                       // Brans=_db.Branslar.SingleOrDefault(brans=>brans.Adi=="Cerrahi")


                         //2.yöntem
                         BransId=_db.Branslar.SingleOrDefault(brans=>brans.Adi=="Cerrahi").Id,

                        DoktorHastalar=new List<DoktorHasta>()
                        {
                            new DoktorHasta()
                            {
                                HastaId=_db.Hastalar.SingleOrDefault(Hasta=>Hasta.Adi=="Çağıl"&& Hasta.Soyadi=="Alsaç").Id
                            },
                             new DoktorHasta()
                             {
                                HastaId=_db.Hastalar.SingleOrDefault(Hasta=>Hasta.Adi=="Leo"&& Hasta.Soyadi=="Alsaç").Id
                             }
                        }
                            
                        
                     },
                     new Doktor()
                     {
                         Guid=Guid.NewGuid().ToString(),
                         Adi="Ferman",
                         Soyadi="Eryiğit",
                         UzmanMi=true,
                          BransId=_db.Branslar.SingleOrDefault(brans=>brans.Adi=="Cerrahi").Id,

                           DoktorHastalar=new List<DoktorHasta>()
                        {
                            new DoktorHasta()
                            {
                                HastaId=_db.Hastalar.SingleOrDefault(Hasta=>Hasta.Adi=="Luna"&& Hasta.Soyadi=="Alsaç").Id
                            },
                            new DoktorHasta()
                            {
                                HastaId=_db.Hastalar.SingleOrDefault(Hasta=>Hasta.Adi=="Leo"&& Hasta.Soyadi=="Alsaç").Id
                            }
                        }
                     },

                      new Doktor()
                     {
                         Guid=Guid.NewGuid().ToString(),
                         Adi="Gülseren",
                         Soyadi="Budayıcıoğlu",
                         UzmanMi=true,
                          BransId=_db.Branslar.SingleOrDefault(brans=>brans.Adi=="Psikiyatri").Id
                     }
                 }
            });


            _db.SaveChanges();
            #endregion

            return Content("<label style=\"color:red;\">Database seed successful.</label>","text/html");
        }
    }
}
