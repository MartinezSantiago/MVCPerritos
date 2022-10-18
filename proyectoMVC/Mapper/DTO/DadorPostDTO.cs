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
        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile ImagenPersona { get; set; }
        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile FrenteDNI { get; set; }
        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile DorsoDNI { get; set; }
    }
}
