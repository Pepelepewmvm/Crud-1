namespace CrudNovedad.Models
{
    public class Etiqueta
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public Guid ConjuntoDatosId { get; set; }
    }
}
