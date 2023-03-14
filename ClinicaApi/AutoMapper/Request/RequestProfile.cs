using AutoMapper;
using ClinicaApi.Request;
using ClinicaRepository.Models;

namespace ClinicaApi.AutoMapper.Request;

public class RequestProfile : Profile
{
    public RequestProfile()
    {
		CreateMap<ClinicaModel, ClinicaRequest>()
			.IgnoreAllPropertiesWithAnInaccessibleSetter()
			.ReverseMap();

		CreateMap<ClinicaModel, RegisterRequest>()
			.IgnoreAllPropertiesWithAnInaccessibleSetter()
			.ReverseMap();

		CreateMap<ClinicaModel, LoginRequest>()
			.IgnoreAllPropertiesWithAnInaccessibleSetter()
			.ReverseMap();
	}
}
