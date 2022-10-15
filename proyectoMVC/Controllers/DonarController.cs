using Microsoft.AspNetCore.Mvc;

namespace proyectoMVC.Controllers
{
    public class DonarController : Controller
    {
        public IActionResult Donar()
        {
            return View();
        }
    }
}
