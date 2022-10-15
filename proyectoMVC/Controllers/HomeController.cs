using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyectoMVC.Models;
using proyectoMVC.Services;
using System.Diagnostics;
using System.Security.Claims;

namespace proyectoMVC.Controllers
{

    public class HomeController : Controller
    {
        private readonly MascotaService mascotaService;
        public HomeController(MascotaService mascotaService)
        {
            this.mascotaService = mascotaService;
     
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
           
         
        
            return View(await mascotaService.GetMascotas());
        }

    }
}