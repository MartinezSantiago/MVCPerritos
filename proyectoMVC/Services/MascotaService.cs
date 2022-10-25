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
            var path= imageToDirectory.UploadImageToDirectoy(mascotaCreateDTO.Imagen, webHostEnvironment);

           var mascota= automapper.MascotaCreateDTOToMascota(mascotaCreateDTO, path, userId);
            await appContext.AddAsync(mascota);
            await appContext.SaveChangesAsync();
        }
        public async Task Edit(MascotaEditDTO mascotaEditDTO, IWebHostEnvironment webHostEnvironment)
        {
           string path;
            if (mascotaEditDTO.Imagen != null)
            {
               path =  imageToDirectory.UploadImageToDirectoy(mascotaEditDTO.Imagen,webHostEnvironment);
            }
            else
            {
                path = mascotaEditDTO.Path;
            }
            var mascota = automapper.MascotaEditDTOToMascota(mascotaEditDTO, path);
            appContext.Update(mascota);
            await appContext.SaveChangesAsync();

        }
        public async Task<List<MascotaViewDTO>> GetMisAnimalitos(int userId)
        {
            var mascotas = await appContext.mascotas.Where(x => x.UserId==userId && x.IsDeleted==false).ToListAsync();
            List<MascotaViewDTO> mascotasView = new List<MascotaViewDTO>();
            foreach (var mascota in mascotas)
            {
                mascotasView.Add(automapper.MascotaToMascotaViewDTO(mascota));
            }
            return mascotasView;
        }

        public async Task<MascotaEditDTO> GetMascotaEditDTOById(int id)
        {
            var mascota = await appContext.mascotas.Where(x => x.Id==id).FirstOrDefaultAsync();
           
           
         
            return automapper.MascotaToMascotaEditDTO(mascota);
        }
        public async Task<MascotaDetailsDTO> GetMascotaDetailsDTOById(int id)
        {
            var mascota = await appContext.mascotas.Where(x => x.Id == id).FirstOrDefaultAsync();



            return automapper.MascotaToMascotaDetailsDTO(mascota);
        }
        public async Task Delete(int id)
        {
            var mascota = await appContext.mascotas.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (mascota != null)
            {
                mascota.IsDeleted = true;
                mascota.LastUpdate = DateTime.Now;

               await appContext.SaveChangesAsync();
            }
        
        }
    }
}
