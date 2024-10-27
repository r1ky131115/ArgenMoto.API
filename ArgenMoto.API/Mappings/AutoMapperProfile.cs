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
            CreateMap<Cliente, ClienteReadDTO>();
            CreateMap<ClienteReadDTO, Cliente>();

            //Mapeo de Articulo
            CreateMap<Articulo, ArticuloReadDTO>();
            CreateMap<ArticuloReadDTO, Articulo>();
        }
    }
}
