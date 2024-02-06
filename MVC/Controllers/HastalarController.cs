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
using Business.Services;
using Business.Models;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class HastalarController : Controller
    {
        // TODO: Add service injections here
        private readonly IHastaService _hastaService;
       private readonly IDoktorService _doktorService;

        public HastalarController(IHastaService hastaService, IDoktorService doktorService)
        {
            _hastaService = hastaService;
            _doktorService = doktorService;
        }

        // GET: Hastalar
        public IActionResult Index()
        {
            List<HastaModel> hastaList = _hastaService.Query().ToList(); // TODO: Add get collection service logic here
            return View(hastaList);
        }

        // GET: Hastalar/Details/5
        public IActionResult Details(int id)
        {
            HastaModel hasta = _hastaService.Query().SingleOrDefault(h=>h.Id==id); // TODO: Add get item service logic here
            if (hasta == null)
            {
                //return NotFound();
                return View("_Error","Hasta bulunamadı!");
            }
            return View(hasta);
        }

        // GET: Hastalar/Create
        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary
            //ViewBag.Doktorlar = new SelectList(_doktorService.Query().ToList(),"Id","AdiSoyadiOutput");//drop down list: tek bir seçim
            ViewBag.Doktorlar = new MultiSelectList(_doktorService.Query().ToList(), "Id", "AdiSoyadiOutput");// list box:birden çok seçim
            //ViewData["Hastalar"] = new MultiSelectList(_hastaService.Query().ToList());
            return View();
        }

        // POST: Hastalar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HastaModel hasta)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert service logic here

                var result = _hastaService.Add(hasta);
                if (result.IsSuccessful)
                {
                    TempData["Mesaj"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            ViewBag.Doktorlar = new MultiSelectList(_doktorService.Query().ToList(), "Id", "AdiSoyadiOutput");


            return View(hasta);
        }

        // GET: Hastalar/Edit/5
        public IActionResult Edit(int id)
        {
            HastaModel hasta = null; // TODO: Add get item service logic here
            if (hasta == null)
            {
                return NotFound();
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(hasta);
        }

        // POST: Hastalar/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HastaModel hasta)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Index));
            }
            // TODO: Add get related items service logic here to set ViewData if necessary
            return View(hasta);
        }

        // GET: Hastalar/Delete/5
        public IActionResult Delete(int id)
        {
            HastaModel hasta = null; // TODO: Add get item service logic here
            if (hasta == null)
            {
                return NotFound();
            }
            return View(hasta);
        }

        // POST: Hastalar/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
