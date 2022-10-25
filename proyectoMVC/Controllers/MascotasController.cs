using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyectoMVC.Mapper;
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
        [Authorize(Roles = "dador")]
        [HttpGet("[controller]/GetMisAnimalitos")]
        public async Task<IActionResult> GetMisAnimalitos()
        {

            var userId = (User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            if (userId != null)
            {
                return View( await mascotaService.GetMisAnimalitos(int.Parse(userId.Value)));
            }
           return View();
        }
        [Authorize(Roles = "dador")]
        [HttpGet("[controller]/Edit")]
        public async Task<IActionResult> Edit(int Id)
        {
            return View(await mascotaService.GetMascotaEditDTOById(Id));
        }
        [Authorize(Roles ="dador")]
        [HttpPost("[controller]/Edit")]
        public async Task<IActionResult> Edit(MascotaEditDTO mascotaEditDTO)
        {
         
            string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            Console.WriteLine(messages);
            ViewBag.Message=messages;
          
            if (ModelState.IsValid)
            {
                await mascotaService.Edit(mascotaEditDTO,webHostEnvironment);
                return RedirectToAction("GetMisAnimalitos");
            }
            return View(mascotaEditDTO);
          
        }
        [Authorize()]
        [HttpGet("[controller]/Details")]
        public async Task<IActionResult> Details(int Id)
        {
            return View(await mascotaService.GetMascotaDetailsDTOById(Id));
        }
        [Authorize(Roles = "dador")]
        [HttpGet("[controller]/Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
           
           await mascotaService.Delete(Id);
            return RedirectToAction("GetMisAnimalitos");

        }
    }
}
