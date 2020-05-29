using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Areas.Admin.ViewModels;

using GraduationProject.Models;
using GraduationProject.Repositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GraduationProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepositry category;

        public IAttributeRepositry Attribute { get; }
      

        public CategoriesController(IAttributeRepositry attribute, ICategoryRepositry category)
        {
            Attribute = attribute;
            this.category = category;
        }
        // GET: Categories
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCategories(int start = 0, int length = 10)
        {
           
            string search = HttpContext.Request.Query["search[value]"];

            return Json(category.GetDataTable(start, length, a => a.Name.Contains(search), a => a.Id));
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
         
            ViewBag.GetAttributes = new SelectList(Attribute.GetAll(),"Id","Name");
            return PartialView("Create");
        }

        // POST: Categories/Create
        [HttpPost]
       
        public ActionResult Create([FromBody]CategoryCreateViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category newCategory = new Category()
                    {
                        Name = collection.CategoryName,

                    };
                    foreach (var item in collection.AttributesID)
                    {
                        newCategory.CategoryAttributes.Add(new CategoryAttributes() { 
                            CategoryAttributeId =item

                        });
                    }


                    category.Add(newCategory);
                    category.SaveAll();
                    
                    return Ok("Category has been Add");
                }

                return BadRequest("Categoty Data is not valid");
            }
            catch
            {
                return BadRequest("Categoty Data is not valid");
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
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

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
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