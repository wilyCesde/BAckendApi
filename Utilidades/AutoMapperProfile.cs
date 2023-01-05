using AutoMapper;
using BAckendApi.DTOs;
using BAckendApi.Models;
using System.Globalization;

namespace BAckendApi.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            #endregion


            //tenemospropiedades nuevas -debemos especificar como se van a trabajar 
            //especificar las columnas y demas 

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(destino =>
                destino.NombreDepartamento,
                opt => opt.MapFrom(origen => origen.IdDepartamentoNavigation.Nombre)
                )
                 .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => origen.FechaContrato.Value.ToString("dd/MM/yyyy"))
                );
            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(destino =>
                destino.IdDepartamentoNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.FechaContrato,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaContrato, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                );
            #endregion


        }
    }
}
