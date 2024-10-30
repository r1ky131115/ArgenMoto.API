using ArgenMoto.Core.DTOs.Articulo;
using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.DTOs.Usuario;
using ArgenMoto.Core.Entities;
using AutoMapper;

namespace ArgenMoto.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Mapeo de clientes
            CreateMap<Cliente, ReadClienteDTO>();
            CreateMap<ReadClienteDTO, Cliente>();

            //Mapeo de Articulos
            CreateMap<Articulo, ReadArticuloDTO>();
            CreateMap<ReadArticuloDTO, Articulo>();

            //Mapeo de usuarios
            CreateMap<Usuario, ReadUsuarioDTO>(); 
            CreateMap<ReadUsuarioDTO, Usuario>();
            CreateMap<UpdateUsuarioDTO, Usuario>();

            //Mapeo de facturas

        }
    }
}
