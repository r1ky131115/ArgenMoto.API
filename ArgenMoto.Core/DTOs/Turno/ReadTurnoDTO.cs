namespace ArgenMoto.Core.DTOs.Turno
{
    public class ReadTurnoDTO
    {
        public ReadBasicClienteDTO Cliente { get; set; }
        public ReadBasicArticuloDTO Articulo { get; set; }
        public ReadBasicTecnicoDTO Tecnico { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Hora { get; set; }
    }

    public class ReadBasicClienteDTO
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string? Apellido { get; set; }
        public string Nombre { get; set; }
    }

    public class ReadBasicArticuloDTO
    {
        public int Id { get; set; }
        public string CodigoArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }

    public class ReadBasicTecnicoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Especialidad { get; set; }
    }
}
