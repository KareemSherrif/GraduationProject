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
    public class BrandsController : Controller
    {
        private IBrandRepository BrandRepository { get; }

        public BrandsController(IBrandRepository brandRepository)
        {
            BrandRepository = brandRepository;
        }

        // GET: Brand
        public ActionResult Index()
        {
            return View(BrandRepository.GetAll());
        }

        [HttpGet]
        public ActionResult GetBrands(int start=0, int lenght=10)
        {
            return Json(BrandRepository.GetDataTable(start, lenght, a => a.Name.Contains(""), a => a.Id));
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            return View(BrandRepository.Get(id));
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brandd/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            try
            {
                BrandRepository.Add(brand);
                BrandRepository.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Brandd/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return BadRequest("The ID is not Found");
            }
            Brand brand = this.BrandRepository.Get(id.Value);
            if (brand == null)
            {
                return NotFound("The Brand is not found");
            }

            return PartialView("Edit", brand);
        }

        // POST: Brandd/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Brand brand)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.BrandRepository.Edit(brand);
                    this.BrandRepository.SaveAll();
                    Ok("The Brand Data has Changed");
                    return RedirectToAction("Index");

                }
                return BadRequest("The Brand data is not valid");

            }
            catch
            {
                return BadRequest("The Brand Data is Locked now Try again later");
            }
        }

        // GET: Brandd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Brandd/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Brand brand)
        {
            try
            {
                BrandRepository.Delete(brand);
                BrandRepository.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}