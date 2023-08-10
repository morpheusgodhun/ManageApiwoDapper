using Microsoft.AspNetCore.Mvc;

namespace ManageApiwoDapper_UI.Controllers {
    public class ProfileController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
