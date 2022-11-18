using proyectoMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace proyectoMVC.Mapper.DTO
{
    public class DadorGetDTO
    {
        public int Id { get; set; }
 
        public string Localidad { get; set; }
     
        public string Direccion { get; set; }
        
        public string ImagenPersona { get; set; }
     

        public string FrenteDNI { get; set; }
       

        public string DorsoDNI { get; set; }
    }
}
