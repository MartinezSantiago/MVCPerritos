using proyectoMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace proyectoMVC.Mapper.DTO
{
    public class DadorPostDTO
    {
        [Required]
        public string Localidad { get; set; }
        [Required]
        public string Direccion { get; set; }
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [Required]
    
        public IFormFile ImagenPersona { get; set; }
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [Required]
        
        public IFormFile FrenteDNI { get; set; }
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [Required]
     
        public IFormFile DorsoDNI { get; set; }
    }
}
