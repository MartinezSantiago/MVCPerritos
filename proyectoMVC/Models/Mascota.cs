namespace proyectoMVC.Models
{
    public class Mascota:Base
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Provincia { get; set; }
        public string Sexo { get; set; }
        public float Edad { get; set; }
        
        public string Tipo { get; set; }
        public string Raza { get; set; }
        public float Peso { get; set; }
        public string Tamaño { get; set; }
        public string Descripción { get; set; }
        public string Imagen { get; set; }
        public string Contacto { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
