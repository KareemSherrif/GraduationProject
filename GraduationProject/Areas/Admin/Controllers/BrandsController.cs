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
            return View();
        }

        [HttpGet]
        public ActionResult GetBrands(int start = 0, int lenght = 10)
        {

            string search = HttpContext.Request.Query["search[value]"];
            return Json(BrandRepository.GetDataTable(start, lenght, a => a.Name.Contains(search), a => a.Id));
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            return View(BrandRepository.Get(id));
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: Brand/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                BrandRepository.Add(brand);
                BrandRepository.SaveAll();
                return Ok("The Brand has been Added");
            }
            else
            {
                return BadRequest("The Model isn't Valid");
            }
        }

        // GET: Brand/Edit/5
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

        // POST: Brand/Edit/5
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
                    return Ok("The Brand Data has Changed");

                }
                return BadRequest("The Brand data is not valid");
            }
            catch
            {
                return BadRequest("The Brand Data is Locked now Try again later");
            }
        }

        // POST: Brand/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                Brand brand = BrandRepository.Get(id);
                BrandRepository.Delete(brand);
                BrandRepository.SaveAll();
                return Ok("The Brand has been Deleted");
            }
            catch
            {
                return BadRequest("The Brand is in use, couldn't be Deleted");
            }
        }
    }
}