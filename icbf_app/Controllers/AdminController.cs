using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace icbf_app.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles="admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
