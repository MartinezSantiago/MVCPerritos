using System.ComponentModel.DataAnnotations;

namespace proyectoMVC.Mapper.DTO
{
    public class UserLoginDTO
    {
        [DataType(DataType.EmailAddress)]

        [Required]
        public string email { get; set; }




        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }
    }
}
