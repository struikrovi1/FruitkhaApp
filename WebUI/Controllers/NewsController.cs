using Business.Abstract;
using Core.Helper;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{

    public class NewsController : Controller
    {
        private readonly INewsManager _newsManager;
        private readonly ICommentManager _commentManager;
        private readonly UserManager<MyUser> _userManager;

        public NewsController(INewsManager newsManager, ICommentManager commentManager, UserManager<MyUser> userManager)
        {
            _newsManager = newsManager;
            _commentManager = commentManager;
            _userManager = userManager;
        }

        // GET: NewsController
        [ResponseCache(Duration =0,Location =ResponseCacheLocation.None)]
        public ActionResult Index(int? recordSize = 2, int? pageNo = 1)
        {

            
            AllNewsVM vm = new()
            {
                News = _newsManager.GetAll(pageNo, recordSize.Value)
            };
             vm.Pager = new Pager(_newsManager.GetAllCount(), pageNo, 2,3);



            return View(vm);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int? id)
        {
            var NewId = _newsManager.GetById(id);
            var comments = _commentManager.GetAllComment(NewId.Id);
            ViewBag.Comments = comments.Count;
            NewDetailVM vm = new()
            {
                SingleNews = NewId,
                SameNew = _newsManager.LastNews(NewId.MyUserId, NewId.Id),
                Comments = comments,

            };
            return View(vm);
           
        }

        [HttpPost]
        public IActionResult AddBlogComment(Comment comment, int newsId)
        {
            comment.NewsId = newsId;    
            _commentManager.AddComment(comment);

            return RedirectToAction("Details", "News", new { id = newsId });


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
