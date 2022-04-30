﻿using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ICountdownManager _countdownManager;

        public ProductController(IProductManager productManager, ICategoryManager categoryManager, ICountdownManager countdownManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _countdownManager = countdownManager;
        }

        // GET: ProductController
        public ActionResult Index(int? id)
        {
  
            ProductVM vm = new()
            {
                Products = _productManager.GetAll(),
                Categories = _categoryManager.GetAll(),
                Countdown = _countdownManager.GetAll().FirstOrDefault(),
               

            };
            return View(vm);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var pros = _productManager.GetById(id);
            var disc = _productManager.GetByDisc(id);


            if (disc is not null && pros.Id == disc.Id)
            {
                ViewBag.Countdown = _countdownManager.GetAll().FirstOrDefault();
            }
            else
            {
                
            }

            SingleProductVM vm = new()
            {
                OneProduct = pros,
                SimilarProducts = _productManager.Similar(pros.CategoryId, pros.Id),

            };

            return View(vm);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
