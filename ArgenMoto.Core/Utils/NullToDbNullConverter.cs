using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArgenMoto.Core.Utils
{
    public class NullToDbNullConverter : ValueConverter<string, string>
    {
        public NullToDbNullConverter()
            : base(
                v => v ?? DBNull.Value.ToString(), // Convierte null a DBNull.Value
                v => v) // Sin transformación al leer de la base de datos
        {
        }
    }
}
