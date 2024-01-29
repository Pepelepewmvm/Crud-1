namespace CrudNovedad.Models
{
    public class Novedad
    {
        public Guid Id { get; set; }

        public required string Titulo { get; set; }

        public required string SubTitulo { get; set; }

        public required string Descripcion { get; set; }

        public DateTime? Fecha { get; set; }

        public string Contenido { get; set; }

        public string Imagenes { get; set; }

        // Nuevo campo para el Id de TipoNov
        public  Guid? TipoNovId { get; set; }
        public required TipoNov TipoNov { get; set; }
    }
}
