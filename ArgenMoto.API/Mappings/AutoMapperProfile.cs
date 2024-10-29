using ArgenMoto.Core.DTOs.Articulo;
using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.Entities;
using AutoMapper;

namespace ArgenMoto.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Mapeo de cliente
            CreateMap<Cliente, Core.DTOs.Cliente.ReadDTO>();
            CreateMap<Core.DTOs.Cliente.ReadDTO, Cliente>();

            //Mapeo de Articulo
            CreateMap<Articulo, Core.DTOs.Articulo.ReadDTO>();
            CreateMap<Core.DTOs.Articulo.ReadDTO, Articulo>();
        }
    }
}
