using CODE.Framework.Wpf.Mvvm;
using MyBusinessApplication.Models.Home;

namespace MyBusinessApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Start()
        {
            return Shell(new StartViewModel(), "Business Application");
        }
    }
}
