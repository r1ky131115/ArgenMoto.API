using ArgenMoto.Core.DTOs.Articulo;
using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.DTOs.Proveedor;
using ArgenMoto.Core.DTOs.Tecnico;
using ArgenMoto.Core.DTOs.Turno;
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
            CreateMap<Cliente, ReadBasicClienteDTO>();

            //Mapeo de Articulos
            CreateMap<Articulo, ReadArticuloDTO>();
            CreateMap<ReadArticuloDTO, Articulo>();
            CreateMap<Articulo, ReadBasicArticuloDTO>();

            //Mapeo de usuarios
            CreateMap<Usuario, ReadUsuarioDTO>(); 
            CreateMap<ReadUsuarioDTO, Usuario>();
            CreateMap<UpdateUsuarioDTO, Usuario>();

            //Mapeo de facturas


            //Mapeo de proveedores
            CreateMap<Proveedor, ReadProveedorDTO>();

            // Mapeos de tecnico
            CreateMap<Tecnico, ReadTecnicoDTO>();

            // Mapea de TurnosPreventa a ReadTurnoDTO
            CreateMap<TurnosPreventa, ReadTurnoDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente : null))
            .ForMember(dest => dest.Articulo, opt => opt.MapFrom(src => src.Articulo != null ? src.Articulo : null))
            .ForMember(dest => dest.Tecnico, opt => opt.MapFrom(src => src.Tecnico != null ? src.Tecnico : null))
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
            .ForMember(dest => dest.Hora, opt => opt.MapFrom(src => src.Hora))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado == 0 ? "Pendiente" : "Finalizado"));

            CreateMap<UpdateTurnoDTO, TurnosPreventa>();
            CreateMap<CreateTurnoDTO, TurnosPreventa>();
        }
    }
}
