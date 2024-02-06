using Business.Models;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Services
{
    public interface IDoktorService
    {
        IQueryable<DoktorModel> Query();
    }



    public class DoktorService : IDoktorService
    {

        private readonly Db _db;

        public DoktorService(Db db)
        {
            _db = db;
        }

        public IQueryable<DoktorModel> Query()
        {
            return _db.Doktorlar.OrderBy(d => d.Adi).ThenBy(d => d.Soyadi).Select(d => new DoktorModel()
            {
                // entity özellikleri
                Adi = d.Adi,
                Soyadi = d.Soyadi,
                UzmanMi = d.UzmanMi,
                KlinikId = d.KlinikId,
                BransId = d.BransId,
                Id = d.Id,
                Guid = d.Guid,

                //ekstra özellikleri
                AdiSoyodiOutput = d.Adi + " " + d.Soyadi
                
            }) ;
        }
    }
}
