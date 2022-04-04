using Entities;

namespace WebUI.ViewModels
{
    public class IndexVM
    {
        public List<Slider> Sliders { get; set; }

        public List<Service> Services { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public List<News> News { get; set; }
    }
}
