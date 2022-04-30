using Entities;

namespace WebUI.ViewModels
{
    public class NewDetailVM
    {

        public News SingleNews { get; set; }

        public List <News> SameNew { get; set; }

        public MyUser MyUser { get; set; }
       

        public List<Comment> Comments { get; set; }

 

        public Comment Comment { get; set; }
    }
}
