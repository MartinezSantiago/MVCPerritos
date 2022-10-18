using proyectoMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace proyectoMVC.Mapper.DTO
{
    public class MascotaCreateDTO
    {
        [Required]
        public string Name { get; set; }
    
        public string LastName { get; set; }

        [Required]
        public string Tipo { get; set; }
        public string Raza { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Sexo { get; set; }

     
        [Required]
        public float Edad { get; set; }
        [Required]
        public string Tamaño { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public float Peso { get; set; }
        [Required]
        public string Contacto { get; set; }
        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile Imagen { get; set; }
    }
}
