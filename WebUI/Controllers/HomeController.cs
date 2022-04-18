using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderManager _sliderManager;
        private readonly IProductManager _productManager;
        private readonly IServiceManager _serviceManager;
        private readonly INewsManager _newsManager;
        private readonly ICountdownManager _countdownManager;


        public HomeController(ILogger<HomeController> logger, ISliderManager sliderManager, IProductManager productManager, IServiceManager serviceManager, INewsManager newsManager, ICountdownManager countdownManager)
        {
            _logger = logger;
            _sliderManager = sliderManager;
            _productManager = productManager;
            _serviceManager = serviceManager;
            _newsManager = newsManager;
            _countdownManager = countdownManager;
        }

        public IActionResult Index()
        {
            IndexVM vm = new()
            {
                Products = _productManager.GetFeatured(),
                Sliders = _sliderManager.GetAll(),
                Services = _serviceManager.HomeServices(),
                News = _newsManager.GetAll(),
                Countdown = _countdownManager.GetAll().FirstOrDefault(),
                DiscProduct = _productManager.GetDiscount()


            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}