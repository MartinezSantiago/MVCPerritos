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
        public MascotaEditDTO MascotaToMascotaEditDTO(Mascota mascota)
        {
             return new MascotaEditDTO()
            {
                 Sexo = mascota.Sexo,
                 Descripcion = mascota.Descripción,
                 Edad = mascota.Edad,

                 Id = mascota.Id,
                 LastName = mascota.LastName,
                 Provincia = mascota.Provincia,
                 Name = mascota.Name,
                 Peso = mascota.Peso,
                 Raza = mascota.Raza,
                 Tamaño = mascota.Tamaño,
                 Tipo = mascota.Tipo,
                 Contacto = mascota.Contacto,
                 UserId = mascota.UserId,
                 Path = mascota.Imagen,
                 IsDeleted = false
             };
        }
        public Mascota MascotaEditDTOToMascota(MascotaEditDTO mascotaEditDTO,string path)
        {
            return new Mascota()
            {
                Sexo = mascotaEditDTO.Sexo,
                Descripción = mascotaEditDTO.Descripcion,
                Edad = mascotaEditDTO.Edad,
                Imagen = path,
                Id=mascotaEditDTO.Id,
                IsDeleted = mascotaEditDTO.IsDeleted,
                LastUpdate = DateTime.Now,
                LastName = mascotaEditDTO.LastName,
                Provincia = mascotaEditDTO.Provincia,
          
          
                Name = mascotaEditDTO.Name,
                Peso = mascotaEditDTO.Peso,
                Raza = mascotaEditDTO.Raza,
                Tamaño = mascotaEditDTO.Tamaño,
                Tipo = mascotaEditDTO.Tipo,
                Contacto = mascotaEditDTO.Contacto,
                UserId = mascotaEditDTO.UserId

            };
        }
        public MascotaDetailsDTO MascotaToMascotaDetailsDTO(Mascota mascota)
        {
            return new MascotaDetailsDTO()
            {
               Contacto = mascota.Contacto,
               Descripcion=mascota.Descripción,
               Edad=mascota.Edad,
               Sexo=mascota.Sexo,
               Id=mascota.Id,
               Imagen=mascota.Imagen,
               LastName=mascota.LastName,
               Name=mascota.Name,
               Peso=mascota.Peso,
               Provincia=mascota.Provincia,
               Raza=mascota.Raza,
               Tamaño=mascota.Tamaño,
               Tipo=mascota.Tipo
            };
        }
    }
}
    
