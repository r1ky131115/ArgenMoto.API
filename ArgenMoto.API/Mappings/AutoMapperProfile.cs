using ArgenMoto.Core.DTOs.Articulo;
using ArgenMoto.Core.DTOs.Carrito;
using ArgenMoto.Core.DTOs.Cliente;
using ArgenMoto.Core.DTOs.OrdenCompra;
using ArgenMoto.Core.DTOs.OrdenCompraDetalle;
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
            CreateMap<Cliente, UpdateClienteDTO>();
            CreateMap<UpdateClienteDTO, Cliente>();


            //Mapeo de Articulos
            CreateMap<Articulo, ReadArticuloDTO>();
            CreateMap<ReadArticuloDTO, Articulo>();
            CreateMap<Articulo, ReadBasicArticuloDTO>();

            //Mapeo de usuarios
            CreateMap<Usuario, ReadUsuarioDTO>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src =>
                src.Cliente != null ? $"{src.Cliente.Nombre} {src.Cliente.Apellido}" : string.Empty))
            .ForMember(dest => dest.Cliente_Id, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente.Id : 0));


            CreateMap<ReadUsuarioDTO, Usuario>();
            CreateMap<UpdateUsuarioDTO, Usuario>();

            //Mapeo de facturas


            //Mapeo de proveedores
            CreateMap<Proveedor, ReadProveedorDTO>();

            // Mapeos de tecnico
            CreateMap<Tecnico, ReadTecnicoDTO>();

            // Mapeos de TurnosPreventa a ReadTurnoDTO
            CreateMap<TurnosPreventa, ReadTurnoDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente : null))
            .ForMember(dest => dest.Articulo, opt => opt.MapFrom(src => src.Articulo != null ? src.Articulo : null))
            .ForMember(dest => dest.Tecnico, opt => opt.MapFrom(src => src.Tecnico != null ? src.Tecnico : null))
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
            .ForMember(dest => dest.Hora, opt => opt.MapFrom(src => src.Hora))
            .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado));

            CreateMap<UpdateTurnoDTO, TurnosPreventa>();
            CreateMap<CreateTurnoDTO, TurnosPreventa>();

            //Mapeos de Carrito
            CreateMap<Carrito, CarritoDto>()
            .ForMember(dest => dest.Detalles, opt => opt.MapFrom(src => src.CarritoDetalles));

            CreateMap<CarritoDetalle, CarritoDetalleDto>()
                .ForMember(dest => dest.Articulo, opt => opt.MapFrom(src => new ArticuloDto
                {
                    Id = src.IdArticulo,
                    Descripcion = src.Articulo.Descripcion, 
                    Precio = src.Articulo.Precio,
                    Marca = src.Articulo.Marca,
                    Modelo = src.Articulo.Modelo,
                    Año = src.Articulo.Año,
                    Cilindrada = src.Articulo.Cilindrada
                }));

            //Mapeo orden de compra y detalle orden de compra
            CreateMap<OrdenCompraCreateDto, OrdenesCompra>()
            .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => DateOnly.FromDateTime(DateTime.Now)))
            .ForMember(dest => dest.Numero, opt => opt.Ignore());

            CreateMap<OrdenCompraDetalleCreateDto, OrdenCompraDetalle>();

            CreateMap<OrdenesCompra, OrdenCompraResponseDto>();
            CreateMap<OrdenCompraDetalle, OrdenCompraDetalleResponseDto>()
                .ForMember(dest => dest.CodigoArticulo, opt => opt.MapFrom(src => src.Articulo.Codigo))
                .ForMember(dest => dest.DescripcionArticulo, opt => opt.MapFrom(src => src.Articulo.Descripcion))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Precio * src.Cantidad));
        }
    }
}
