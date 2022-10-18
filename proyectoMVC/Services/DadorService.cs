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
            var pathImagenUsuario = imageToDirectory.UploadImageToDirectory(dadorInfoPostDTO.ImagenPersona, webHostEnvironment);
            var pathFrenteDNI = imageToDirectory.UploadImageToDirectory(dadorInfoPostDTO.FrenteDNI, webHostEnvironment);
            var pathDorsoDNI = imageToDirectory.UploadImageToDirectory(dadorInfoPostDTO.DorsoDNI, webHostEnvironment);


            var dador = autoMapper.DadorInfoPostDTOToDadorInfo(dadorInfoPostDTO, pathFrenteDNI, pathDorsoDNI, pathImagenUsuario, UserId);
            context.dadores.Add(dador);
            await context.SaveChangesAsync();
        }

    }
}
