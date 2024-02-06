#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;
using Business.Models;
using Business.Services;
using DataAccess.Results.Bases;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class KliniklerController : Controller
    {
        // TODO: Add service injections here
        private readonly IKlinikService _klinikService;

        public KliniklerController(IKlinikService klinikService)
        {
            _klinikService = klinikService;
        }

        // GET: Klinikler
        public IActionResult Index()
        {
            IEnumerable<KlinikModel> klinikler;
            klinikler = _klinikService.Query().ToList();

            //1. yöntem
            //List<KlinikModel> klinikList = _klinikService.Query().ToList(); // TODO: Add get collection service logic here
            //2. yöntem
            List<KlinikModel> klinikList = _klinikService.GetList();
            return View(klinikList);
        }


        //GET:Klinikler/GetJson
        public JsonResult GetJson()
        {
            var klinikler = _klinikService.Query().ToList();
            return Json(klinikler);
        }



        // GET: Klinikler/Details/5
        public IActionResult Details(int id)
        {
            //koşula göre bulduğu ilk kaydı döner,eğer kaydı bulamazsa exception fırlatır.
            //KlinikModel klinik = _klinikService.Query().First(k=>k.Id==id);
            //koşula göre bulduğu ilk kaydı döner,eğer kaydı bulamazsa null döner.
            //KlinikModel klinik = _klinikService.Query().FirstOrDefault(k => k.Id == id);
            //koşula göre bulduğu son kaydı döner,eğer kaydı bulamazsa exception fırlatır.
            //KlinikModel klinik = _klinikService.Query().Last(k => k.Id == id);
            //koşula göre bulduğu son kaydı döner,eğer kaydı bulamazsa null döner.
            //KlinikModel klinik = _klinikService.Query().LastOrDefault(k => k.Id == id);
            //koşula göre bulduğu tek kaydı döner,eğer kaydı bulamazsa exception fırlatır,birden çok kayıt bulursa exception fırlatır.
            //KlinikModel klinik = _klinikService.Query().Single(k => k.Id == id);

            //önce kayıtlar where ile filtrelenir , dönen koleksiyon sonucu üzerinden tek bir kayıt çekilir.
            //KlinikModel klinik = _klinikService.Query().Where(k => k.Id == id).SingleOrDefault();

            //1. yöntem
            KlinikModel klinik = _klinikService.GetItem(id);

            //2.yöntem
            //koşula göre bulduğu tek kaydı döner,eğer kaydı bulamazsa null döner,birden çok kayıt bulursa exception fırlatır.
            //KlinikModel klinik = _klinikService.Query().SingleOrDefault(k=>k.Id==id); // TODO: Add get item service logic here
            if (klinik == null)
            {
                return NotFound();//404(not faund) http status code
            }
            return View(klinik);// 200(ok) http status code
        }

        public IActionResult GetItemJson(int id)
        {
            var klinik = _klinikService.Query().SingleOrDefault(k => k.Id == id);
            return Json(klinik);
        }





        // GET: Klinikler/Create
        //[HttpGet] default get
        public IActionResult Create(string Adi,string Aciklamasi)
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View();
        }

        // POST: Klinikler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KlinikModel klinik)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here
                Result result = _klinikService.Add(klinik);
                if (result.IsSuccessful)
                {
                    TempData["Mesaj"] = result.Message;

                    //1. yöntem
                    //return RedirectToAction("Index");
                    //2. yöntem
                    //return RedirectToAction(nameof(Index));
                    //3. yöntem
                    return RedirectToAction(nameof(Details),new {id=klinik.Id});
				}

                //1. yöntem
                //ViewData["mesaj"] = result.Message;
                //2. YÖNTEM
                //ViewBag.Mesaj = result.Message;
                //3. YÖNTEM
                ModelState.AddModelError("",result.Message);//view -> validation summary
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(klinik);
           
        }

        // GET: Klinikler/Edit/5
        public IActionResult Edit(int id)
        {
            KlinikModel klinik = _klinikService.Query().SingleOrDefault(k=>k.Id==id); // TODO: Add get item service logic here
            if (klinik == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(klinik);
        }

        // POST: Klinikler/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KlinikModel klinik)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                Result result = _klinikService.Update(klinik);
                if (result.IsSuccessful)
                {
                    TempData["Mesaj"] = result.Message;
                    return RedirectToAction(nameof(Details),new {id=klinik.Id} );
                }
                ModelState.AddModelError("", result.Message);//view-> validation summary
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(klinik);
        }

        // GET: Klinikler/Delete/5
        public IActionResult Delete(int id)
        {
            KlinikModel klinik = _klinikService.GetItem(id); // TODO: Add get item service logic here
            if (klinik == null)
            {
                return NotFound();
            }
            return View(klinik);
        }

        // POST: Klinikler/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            Result result=_klinikService.Delete(id);
            TempData["Mesaj"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
