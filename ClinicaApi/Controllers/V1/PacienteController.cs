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

    [HttpGet]
    [Route("/getallpacientes/{clinicaId}")]
    public async Task<ActionResult<List<PacienteResponse>>> GetAllPacientes(Guid clinicaId)
    {
        var pacientes = await _pacienteService.GetAllPacientes(clinicaId);
        var responsePacientes = pacientes.Select(paciente => _mapper.Map<PacienteResponse>(paciente));

        return Ok(responsePacientes);
    }

	[Route("/getpacientebyid/{id}")]
	[HttpGet]
	public async Task<ActionResult<PacienteResponse>> GetPacienteById(Guid id)
	{
		var paciente = await _pacienteService.GetPacienteById(id);
		var responsePaciente = _mapper.Map<PacienteResponse>(paciente);

		return Ok(responsePaciente);
	}

	[Route("/registerpaciente")]
	[HttpPost]
	public async Task<ActionResult<List<PacienteResponse>>> RegisterPaciente([FromForm] PacienteRequest paciente)
	{
		var requestPaciente = _mapper.Map<PacienteModel>(paciente);
		var roadmapCreationMessages = await _pacienteService.AddPaciente(requestPaciente);
		var cleanResponses = await _messageHandler.ConcatRegistrationMessages(roadmapCreationMessages);

		return Ok(cleanResponses);
	}
}
