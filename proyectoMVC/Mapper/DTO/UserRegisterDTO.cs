using System.ComponentModel.DataAnnotations;

namespace proyectoMVC.Mapper.DTO
{
    public class UserRegisterDTO
    {
        [DataType(DataType.EmailAddress)]
        
        [Required]
        public string email { get; set; }

        [Required]
        public string name { get; set; }


        [Required]
        public string lastName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
    }
}
