using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IHastaService
    {
        IQueryable<HastaModel> Query();
		Result Add(HastaModel model);
	}


    public class HastaService : IHastaService
    {

        private readonly Db _db;

        public HastaService(Db db)
        {
            _db = db;
        }

      

        public IQueryable<HastaModel> Query()
        {
            return _db.Hastalar.OrderByDescending(h => h.DogumTarihi).ThenBy(h => h.Adi).ThenBy(h => h.Soyadi)
                .Select(h => new HastaModel()
                {
                    //entity özellikleri
                    #region
                    Adi = h.Adi,
                    Boyu = h.Boyu,
                    Cinsiyeti = h.Cinsiyeti,
                    DogumTarihi = h.DogumTarihi,
                    Guid = h.Guid,
                    Id = h.Id,
                    Kilosu = h.Kilosu,
                    KimlikNo = h.KimlikNo,
                    Soyadi = h.Soyadi,
                    #endregion

                    #region ekstra özellikler

                    AdiSoyadiOutput = h.Adi + " " + h.Soyadi,

					//program.cs altında localization region'ında uygulamanın bölgesel ayarını belirlediğimiz için 
					//formatlama işlemlerinde CultureInfo kullnamaya artık gerek kalmadı
					// BoyuOutput=h.Boyu.HasValue ? h.Boyu.Value.ToString("N2",new CultureInfo("tr-TR")) + "metre":"0",
					BoyuOutput = (h.Boyu.HasValue ? h.Boyu.Value.ToString("N2"):"0")+"metre",

					KilosuOutput =(h.Kilosu ?? 0).ToString("N2")+"kilogram",
                    DogumTarihiOutput=h.DogumTarihi.ToString("dd.MM.yyyy"),
                    DoktorlarOutput=string.Join(", ",h.DoktorHastalar.OrderBy(dh=>dh.Doktor.Adi).ThenBy(dh=>dh.Doktor.Soyadi)
                    .Select(dh=> dh.Doktor.Adi +" "+dh.Doktor.Soyadi+(dh.Doktor.UzmanMi ? " (uzman)": ""))),

                    DoktorIdleriInput=h.DoktorHastalar.Select(dh=>dh.DoktorId).ToList()
                    #endregion
                });
        }

        public Result Add(HastaModel model)
        {
            if (_db.Hastalar.Any(h => h.Adi.ToLower() == model.Adi.ToLower().Trim()&& h.Soyadi.ToLower()==model.Soyadi.ToLower().Trim()
            && h.DogumTarihi==model.DogumTarihi))
                return new ErrorResult("Girilen hasta adına soyadına ve doğum tarihine sahip hasta bulunmaktadır!");
            Hasta entity = new Hasta()
            {
                Adi = model.Adi.Trim(),
                Soyadi = model.Soyadi.Trim(),
                Boyu = model.Boyu,
                Kilosu = model.Kilosu,
                DogumTarihi = model.DogumTarihi,
                Cinsiyeti = model.Cinsiyeti,
                KimlikNo = model.KimlikNo,

                DoktorHastalar = model.DoktorIdleriInput?.Select(doktorId => new DoktorHasta()
                {
                    DoktorId = doktorId

                }).ToList()

            };
            _db.Hastalar.Add(entity);
            _db.SaveChanges();

            model.Id = entity.Id;

            return new SuccessResult("Klinik başarı ile eklendi.");
        }
    }
}

