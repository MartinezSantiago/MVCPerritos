using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyectoMVC.Mapper.DTO;
using proyectoMVC.Services;
using System.Security.Claims;

namespace proyectoMVC.Controllers
{
    public class DadorController : Controller
    {
        private readonly DadorService dadorService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public DadorController(DadorService dadorService, IWebHostEnvironment webHostEnvironment)
        {
            this.dadorService = dadorService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "usuario")]
        [HttpGet]
        public IActionResult Post()
        {
            return View();
        }

        [Authorize(Roles = "usuario")]
        [HttpPost]
        public async Task<IActionResult>Post(DadorPostDTO dadorInfoPostDTO)
        {
            if (!ModelState.IsValid)
            {
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                ViewBag.Message = messages;
               
            }
            if (dadorInfoPostDTO == null)
            {
                return View(dadorInfoPostDTO);
            }
            if (!ModelState.IsValid)
            {
                return View(dadorInfoPostDTO);
            }
           
            var userId = (User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            await dadorService.Post(dadorInfoPostDTO, webHostEnvironment, int.Parse(userId.Value));
            return RedirectToAction("Home", "Home");
        }
    }
}
