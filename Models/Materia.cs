namespace MicroservicioMateria.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }
        public string Prerequisito { get; set; }
        public string Area { get; set; }
        public int Nivel { get; set; }
        public bool Activa { get; set; } = true;
    }
}
