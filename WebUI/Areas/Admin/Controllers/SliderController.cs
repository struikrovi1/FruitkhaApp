using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class SliderController : Controller
    {
        private readonly ISliderManager _sliderManager;
        private readonly IWebHostEnvironment _environment;
        

        public SliderController(ISliderManager sliderManager, IWebHostEnvironment environment)
        {
            _sliderManager = sliderManager;
            _environment = environment;
        }

        // GET: SliderController
        public ActionResult Index()
        {
            return View(_sliderManager.GetAll());
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Slider slider, IFormFile Image)
        {

            string path = "/files" + Guid.NewGuid() + Image.FileName;

            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            };


            slider.PhotoUrl = path;
  
            _sliderManager.Create(slider);
            return RedirectToAction(nameof(Index));

           
          
        }

        // GET: SliderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_sliderManager.GetById(id));
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id, Slider slider, string OldPhoto, IFormFile Image)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;

                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    Image.CopyToAsync(fileStream);

                };
                slider.PhotoUrl = path;
            }
            else
            {
                slider.PhotoUrl = OldPhoto;
            }


            try
            {
                _sliderManager.Update(slider);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
          
        }

        // GET: SliderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Slider slider)
        {
            if (id == null) return NotFound();
            if (slider == null) return NotFound();
            try
            {
                _sliderManager.Delete(slider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
