using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using proyectoMVC.Helper;
using proyectoMVC.Mapper;
using proyectoMVC.Mapper.DTO;
using AppContext = proyectoMVC.Context.AppContext;
namespace proyectoMVC.Services
{
    public class DadorService
    {
        private readonly AppContext context;
        private readonly AutoMapper autoMapper;
        private readonly ImageToDirectory imageToDirectory;
        public DadorService(AppContext context, AutoMapper autoMapper, ImageToDirectory imageToDirectory)
        {
            this.context = context;
            this.autoMapper = autoMapper;

            this.imageToDirectory = imageToDirectory;
        }

        public async Task Post(DadorPostDTO dadorInfoPostDTO, IWebHostEnvironment webHostEnvironment, int UserId)
        {
            var pathImagenUsuario = imageToDirectory.UploadImageToDirectoy(dadorInfoPostDTO.ImagenPersona, webHostEnvironment);
            var pathFrenteDNI = imageToDirectory.UploadImageToDirectoy(dadorInfoPostDTO.FrenteDNI, webHostEnvironment);
            var pathDorsoDNI = imageToDirectory.UploadImageToDirectoy(dadorInfoPostDTO.DorsoDNI, webHostEnvironment);


            var dador = autoMapper.DadorInfoPostDTOToDadorInfo(dadorInfoPostDTO, pathFrenteDNI, pathDorsoDNI, pathImagenUsuario, UserId);
            context.dadores.Add(dador);
            await context.SaveChangesAsync();
        }
        public async Task<List<DadorGetDTO>> Get()
        {
            var dadores = await context.dadores.Where(x => x.Revisado != true && x.IsDeleted == false).ToListAsync();
            List<DadorGetDTO> dadorGetDTOs = new List<DadorGetDTO>();
            foreach (var dador in dadores)
            {
                dadorGetDTOs.Add(autoMapper.DadorToDadorGetDTO(dador));

            }
            return dadorGetDTOs;
        }
        public async Task<bool> Autorizar(int Id)
        {
            var dador = await context.dadores.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (dador != null)
            {




                try
                {
                    var user = await context.users.Where(x => x.Id == dador.UserId).FirstOrDefaultAsync();
                    dador.Revisado = true;
                    dador.EsCorrecto = true; 
                    dador.LastUpdate = DateTime.Now;
                    user.role = "dador";
                    context.dadores.Update(dador);
                    context.users.Update(user);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            return false;

        }
        public async Task<bool> Denegar(int Id)
        {
            var dador = await context.dadores.Where(x => x.Id == Id).FirstOrDefaultAsync();
            if (dador != null)
            { 
                dador.Revisado = true;
                dador.EsCorrecto = false;
                context.dadores.Update(dador);
                await context.SaveChangesAsync();
            }
            return false;

        }
    }
  
}
