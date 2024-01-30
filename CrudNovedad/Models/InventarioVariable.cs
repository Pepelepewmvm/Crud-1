namespace CrudNovedad.Models
{
    public class InventarioVariable
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public Guid ProcesoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Guid EtiquetasId { get; set; }
        public string Descripcion { get; set; }
    }
}
