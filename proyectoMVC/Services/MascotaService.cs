using Microsoft.EntityFrameworkCore;
using proyectoMVC.Helper;
using proyectoMVC.Mapper;
using proyectoMVC.Mapper.DTO;
using proyectoMVC.Models;
using AppContext = proyectoMVC.Context.AppContext;
namespace proyectoMVC.Services
{
    public class MascotaService
    {
        private readonly AppContext appContext;
        private readonly AutoMapper automapper;
        private readonly ImageToDirectory imageToDirectory;
        
        public MascotaService(AppContext appContext, AutoMapper automapper, ImageToDirectory imageToDirectory)
        {
        this.appContext = appContext;
            this.automapper = automapper;
            this.imageToDirectory = imageToDirectory;
        }
        public async Task<List<MascotaViewDTO>> GetMascotas()
        {
           var mascotas=await appContext.mascotas.Where(x => x.IsDeleted == false).ToListAsync();
            List<MascotaViewDTO> mascotasView = new List<MascotaViewDTO>();
            foreach (var mascota in mascotas)
            {
                mascotasView.Add(automapper.MascotaToMascotaViewDTO(mascota));
            }
            return mascotasView;
        }

       
        public async Task Create(MascotaCreateDTO mascotaCreateDTO,IWebHostEnvironment webHostEnvironment,int userId)
        {
            var path=imageToDirectory.UploadImageToDirectory(mascotaCreateDTO.Imagen,webHostEnvironment);

           var mascota= automapper.MascotaCreateDTOToMascota(mascotaCreateDTO, path, userId);
            await appContext.AddAsync(mascota);
            await appContext.SaveChangesAsync();
        }
    }
}
