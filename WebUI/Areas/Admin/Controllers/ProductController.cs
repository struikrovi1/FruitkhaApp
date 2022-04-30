using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly IWebHostEnvironment _environment;
        private readonly ICategoryManager _categoryManager;


        public ProductController(IProductManager productManager, IWebHostEnvironment environment, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _environment = environment;
            _categoryManager = categoryManager;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productManager.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create(int id)
        {
            var pr = _productManager.GetById(id);
          
            ViewBag.CategoryList = _categoryManager.GetAll();
            return View(pr);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product product, IFormFile Image)
        {
            string path = "/files" + Guid.NewGuid() + Image.FileName;

            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            };


            product.PhotoUrl = path;

            _productManager.Create(product);
            return RedirectToAction(nameof(Index));

            
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = _categoryManager.GetAll();
            return View(_productManager.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product product, string OldPhoto, IFormFile Image)
        {
            if (Image != null)
            {
                string path = "/files" + Guid.NewGuid() + Image.FileName;

                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    Image.CopyToAsync(fileStream);

                };
                product.PhotoUrl = path;
            }
            else
            {
                product.PhotoUrl = OldPhoto;
            }


            try
            {
                _productManager.Update(product);
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
        public ActionResult Delete(int id, Product product)
        {
            if (id == null) return NotFound();
            if (product == null) return NotFound();
            try
            {
                _productManager.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
