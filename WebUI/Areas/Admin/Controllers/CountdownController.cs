using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{

    [Area(nameof(Admin))]
    public class CountdownController : Controller
    {
        private readonly ICountdownManager _countdownManager;
        private readonly IProductManager _productManager;

        public CountdownController(ICountdownManager countdownManager, IProductManager productManager)
        {
            _countdownManager = countdownManager;
            _productManager = productManager;
        }

        // GET: CountdownController
        public ActionResult Index()
        {
            var discount = _countdownManager.GetAll();
            if (discount.Count > 0)
            {
                ViewBag.Sayi = 1;
            }
            else
            {
                ViewBag.Sayi = 0;
            }
            return View(_countdownManager.GetAll());
        }

        // GET: CountdownController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountdownController/Create
        public ActionResult Create()
        {
            ViewBag.ProductList = _productManager.GetDiscount();
            var discount = _countdownManager.GetAll();
            if (discount.Count > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: CountdownController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Countdown countdown)
        {
            try
            {
                _countdownManager.Create(countdown);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountdownController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ProductList = _productManager.GetDiscount();
            return View(_countdownManager.GetById(id));
        }

        // POST: CountdownController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Countdown countdown)
        {
            try
            {
                _countdownManager.Update(countdown);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountdownController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountdownController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Countdown countdown)
        {
            if (id == null) return NotFound();
            if (countdown == null) return NotFound();
            try
            {
                _countdownManager.Delete(countdown);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
