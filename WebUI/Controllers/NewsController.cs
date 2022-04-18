using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{

    public class NewsController : Controller
    {
        private readonly INewsManager _newsManager;

        public NewsController(INewsManager newsManager)
        {
            _newsManager = newsManager;
        }

        // GET: NewsController
        [ResponseCache(Duration =0,Location =ResponseCacheLocation.None)]
        public ActionResult Index()
        {
            AllNewsVM vm = new()
            {
                News = _newsManager.GetAll()
            };
            return View(vm);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int? id)
        {
            NewDetailVM vm = new()
            {
                SingleNews = _newsManager.GetById(id),
            };
            return View(vm);
           
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
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

        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsController/Edit/5
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

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
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
