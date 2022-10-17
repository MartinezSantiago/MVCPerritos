using Microsoft.AspNetCore.Mvc;
using proyectoMVC.Services;
using Microsoft.AspNetCore.Authorization;
using proyectoMVC.Mapper.DTO;

namespace proyectoMVC.Controllers
{
    public class DonarController : Controller
    {

        private readonly DonarService donarService;

        public DonarController(DonarService donarService)
        {
            this.donarService = donarService;
        }

        [HttpGet]
        public IActionResult Donar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Donar(int montoADonar)
        {
            var preferenciaId =await donarService.CreatePreference(montoADonar);
            Console.WriteLine("Preferencia: " + preferenciaId);
            ViewBag.PreferenceId = preferenciaId;
            ViewBag.Action = 1;


            return View("Donar");
        }
    }
}
