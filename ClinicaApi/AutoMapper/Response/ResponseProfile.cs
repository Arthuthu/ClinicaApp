using ClinicaRepository.Models;
using AutoMapper;
using ClinicaApi.Request;
using ClinicaApi.Response;

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
	}
}
