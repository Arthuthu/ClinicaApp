using AutoMapper;
using ClinicaApi.Request;
using ClinicaApi.Response;
using ClinicaRepository.Models;
using ClinicaService.Interfaces;
using ClinicaService.Validators.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers.V1;

[Route("api/v1/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly IClinicaClassService _clinicaService;
	private readonly IMessageHandler _messageHandler;

	public AuthController(IMapper mapper,
		IClinicaClassService clinicaService,
		IMessageHandler messageHandler)
	{
		_clinicaService = clinicaService;
		_mapper = mapper;
		_messageHandler = messageHandler;
	}

	[Route("/login")]
	[HttpPost]
	public async Task<ActionResult> Login([FromForm] LoginRequest loginUser)
	{
		var requestUser = _mapper.Map<ClinicaModel>(loginUser);
		string token = await _clinicaService.Login(requestUser);

		var output = new
		{
			Access_Token = token,
			Username = loginUser.Username
		};

		return Ok(output);
	}


	[Route("/register")]
	[HttpPost]
	public async Task<ActionResult<List<ClinicaResponse>>> Register([FromForm] RegisterRequest registerRequest)
	{
		var requestUser = _mapper.Map<ClinicaModel>(registerRequest);
		var registrationMessages = await _clinicaService.CreateClinica(requestUser);
		var cleanResponses = await _messageHandler.ConcatRegistrationMessages(registrationMessages);

		return Ok(cleanResponses);
	}
}