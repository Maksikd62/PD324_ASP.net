﻿using Microsoft.AspNetCore.Mvc;
using PD324_01.Data;
using PD324_01.Models;
using PD324_01.Repositories;

namespace PD324_01.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(AppDbContext context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAll();

            return View(categories);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Update(int? id)
        {
            if (id != null)
            {
                var model = _categoryRepository.GetById((int)id);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var model = _categoryRepository.GetById((int)id);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category model)
        {
            _context.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}