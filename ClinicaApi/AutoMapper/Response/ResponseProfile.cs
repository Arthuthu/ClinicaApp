using AutoMapper;
using ClinicaApi.Response;
using ClinicaRepository.Models;

namespace ClinicaApi.AutoMapper.Response;

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
		CreateMap<ClinicaResponse, ClinicaModel>()
			.IgnoreAllPropertiesWithAnInaccessibleSetter()
			.ReverseMap();

		CreateMap<PacienteResponse, PacienteModel>()
			.IgnoreAllPropertiesWithAnInaccessibleSetter()
			.ReverseMap();

        CreateMap<ConsultaResponse, ConsultaModel>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter()
            .ReverseMap();
    }
}
