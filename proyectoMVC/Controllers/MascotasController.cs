using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyectoMVC.Mapper.DTO;
using proyectoMVC.Services;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyectoMVC.Controllers
{


    public class MascotasController : Controller
    {
        private readonly MascotaService mascotaService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MascotasController(MascotaService mascotaService, IWebHostEnvironment webHostEnvironment)
        {
            this.mascotaService = mascotaService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [Authorize()]
        [HttpGet()]
        public async Task<IActionResult> Get() {


            return View(await mascotaService.GetMascotas());
        }
        [Authorize(Roles = "dador")]
        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }
        [Authorize(Roles = "dador")]
        [HttpPost("[controller]/Post")]
        public async Task<IActionResult> Post(MascotaCreateDTO mascotaCreateDTO)
        {

            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                ViewBag.Message = messages;
                return View(mascotaCreateDTO);
            }
            var userId = (User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            await mascotaService.Create(mascotaCreateDTO, webHostEnvironment, int.Parse(userId.Value));
            return RedirectToAction("Home","Home");

        }
     
       
      
    }
}
