using ArgenMoto.Core.DTOs.Tecnico;

namespace ArgenMoto.Core.DTOs.Turno
{
    public class ReadTurnoDTO
    {
        public int Id { get; set; }
        public ReadBasicClienteDTO Cliente { get; set; }
        public ReadBasicArticuloDTO Articulo { get; set; }
        public ReadTecnicoDTO Tecnico { get; set; }
        public DateTime Fecha { get; set; }
        public string? Hora { get; set; }
        public string NumeroTurno { get; set; }
        public string? Estado { get; set; }
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
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}
