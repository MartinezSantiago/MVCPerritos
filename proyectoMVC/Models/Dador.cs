using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoMVC.Models
{
    public class Dador : Base
    {

        public string Localidad { get; set; }

        public string Direccion { get; set; }
        public string ImagenPersona { get; set; }
        public string FrenteDNI { get; set; }
        public string DorsoDNI { get; set; }
        public bool Revisado{ get; set; }
        public bool EsCorrecto { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
