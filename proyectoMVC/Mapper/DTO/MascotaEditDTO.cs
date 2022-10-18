using proyectoMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace proyectoMVC.Mapper.DTO
{
    public class MascotaEditDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
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
        
     
        public bool IsDeleted { get; set; }
     
        public IFormFile? Imagen { get; set; }
        public int UserId { get; set; }
        public  string Path { get; set; }
    }
}
