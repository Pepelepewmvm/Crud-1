namespace CrudNovedad.Models
{
    public class Novedad
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string ConjuntoDatos { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Etiquetas { get; set; }
        public string Contenido { get; set; }
        public string[] Imagenes { get; set; }
    }
}
