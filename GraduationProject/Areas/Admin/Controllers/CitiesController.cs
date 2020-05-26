using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Models;
using GraduationProject.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CitiesController : Controller
    {
        public ICitiesRepositry CitiesRepositry { get; }

        public CitiesController(ICitiesRepositry citiesRepositry)
        {
            CitiesRepositry = citiesRepositry;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetCities(int start =0, int length=10)
        {
            string search = HttpContext.Request.Query["search[value]"];
           
            return Json(CitiesRepositry.GetDataTable(start,length,a=>a.CityName.Contains(search),a=>a.ID));
        }

        // GET: Cities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cities/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}