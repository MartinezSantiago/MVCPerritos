namespace proyectoMVC.Models
{
    public class User:Base
    {
        public string email { get; set; }
        public string password { get; set; }

        public string name { get; set; }
        public string lastName { get; set; }
        public string role { get; set; } 

    }
}
