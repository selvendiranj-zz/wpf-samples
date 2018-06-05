using CODE.Framework.Wpf.Mvvm;
using MyBusinessApplication.Models.User;

namespace MyBusinessApplication.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return ViewModal(new LoginViewModel(), ViewLevel.Popup);
        }
    }
}
