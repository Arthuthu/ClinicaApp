using AutoMapper;
using ClinicaApi.Request;
using ClinicaApi.Response;
using ClinicaRepository.Models;
using ClinicaService.Interfaces;
using ClinicaService.Validators.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers.V1;

[Route("api/v1/[controller]")]
[ApiController]
public class PacienteController : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly IPacienteService _pacienteService;
	private readonly IMessageHandler _messageHandler;

	public PacienteController(IMapper mapper,
		IPacienteService pacienteService,
		IMessageHandler messageHandler)
	{
		_mapper = mapper;
		_pacienteService = pacienteService;
		_messageHandler = messageHandler;
	}

	[Route("/registerpaciente")]
	[HttpPost]
	public async Task<ActionResult<List<PacienteResponse>>> RegisterPaciente([FromForm] PacienteRequest paciente)
	{
		var requestPaciente = _mapper.Map<PacienteModel>(paciente);
		var roadmapCreationMessages = await _pacienteService.Addpaciente(requestPaciente);
		var cleanResponses = await _messageHandler.ConcatRegistrationMessages(roadmapCreationMessages);

		return Ok(cleanResponses);
	}
}
