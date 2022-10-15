using proyectoMVC.Mapper.DTO;
using proyectoMVC.Models;

namespace proyectoMVC.Mapper
{
    public class AutoMapper
    {
     
        public User userRegisterDTOToUser(UserRegisterDTO userRegisterDTO)
        {
            return new User()
            {
                email = userRegisterDTO.email,
                password = userRegisterDTO.password,
                IsDeleted = false,
                LastUpdate = DateTime.Now,
                lastName = userRegisterDTO.lastName,
                name = userRegisterDTO.name
            };
        }
        public MascotaViewDTO MascotaToMascotaViewDTO(Mascota mascota)
        {
            return new MascotaViewDTO()
            {
                Id=mascota.Id,
                Edad=mascota.Edad,
                Imagen=mascota.Imagen,
                Name=mascota.Name,
                Tamaño=mascota.Tamaño
                
            };

        }
        public Mascota MascotaCreateDTOToMascota(MascotaCreateDTO mascotaCreateDTO,string Path,int Id)
        {
            return new Mascota()
            {
                Sexo=mascotaCreateDTO.Sexo,
                Descripción=mascotaCreateDTO.Descripcion,
                Edad=mascotaCreateDTO.Edad,
                Imagen=Path,
                IsDeleted=false,
                LastUpdate=DateTime.Now,
                LastName=mascotaCreateDTO.LastName,
                Provincia = mascotaCreateDTO.Provincia,
                Name=mascotaCreateDTO.Name,
                Peso=mascotaCreateDTO.Peso,
                Raza=mascotaCreateDTO.Raza,
                Tamaño=mascotaCreateDTO.Tamaño,Tipo=mascotaCreateDTO.Tipo,Contacto=mascotaCreateDTO.Contacto,
  UserId=Id

            };
        }
        public Dador DadorInfoPostDTOToDadorInfo(DadorPostDTO dadorInfoPostDTO,string FrenteDni,string DorsoDni, string ImagenUsuario, int Id)
        {
            return new Dador()
            {
                Direccion = dadorInfoPostDTO.Direccion,
                DorsoDNI = DorsoDni,
                FrenteDNI = FrenteDni,
                ImagenPersona = ImagenUsuario,
                Localidad = dadorInfoPostDTO.Localidad,
                UserId = Id,
                IsDeleted = false,
                LastUpdate = DateTime.Now,
                Revisado=false,
                EsCorrecto=false
            };
        }
    }
}
    
