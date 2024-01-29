namespace CrudNovedad.Models
{
    public class ListaDeVariables
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string UnidadDeMedida { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Descripcion { get; set; }

    }
}
