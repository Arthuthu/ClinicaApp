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
public class ConsultaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IConsultaService _consultaService;
    private readonly IMessageHandler _messageHandler;

    public ConsultaController(IMapper mapper,
        IConsultaService consultaService,
        IMessageHandler messageHandler)
    {
        _mapper = mapper;
        _consultaService = consultaService;
        _messageHandler = messageHandler;
    }

    [HttpGet]
    [Route("/getallconsultas/{clinicaid}")]
    public async Task<ActionResult<List<ConsultaResponse>>> GetAllConsultas(Guid clinicaId)
    {
        var consultas = await _consultaService.GetAllConsultas(clinicaId);
        var responseConsultas = consultas.Select(consulta => _mapper.Map<ConsultaResponse>(consulta));

        return Ok(responseConsultas);
    }

    [Route("/getconsultabyid/{id}")]
    [HttpGet]
    public async Task<ActionResult<ConsultaResponse>> GetConsultaById(Guid id)
    {
        var consulta = await _consultaService.GetConsultaById(id);
        var responseConsulta = _mapper.Map<ConsultaResponse>(consulta);

        return Ok(responseConsulta);
    }

	[Route("/getconsultasbypacienteid/{clinicaid}/{pacienteId}")]
	[HttpGet]
	public async Task<ActionResult<ConsultaResponse>> GetConsultasByPacienteId(Guid clinicaId, Guid pacienteId)
	{
		var consultas = await _consultaService.GetConsultasByPacienteId(clinicaId, pacienteId);
		var responseConsultas = consultas.Select(consulta => _mapper.Map<ConsultaResponse>(consulta));


		return Ok(responseConsultas);
	}

	[Route("/createconsulta")]
    [HttpPost]
    public async Task<ActionResult<List<ConsultaResponse>>> CreateConsulta([FromForm] ConsultaRequest consulta)
    {
        var requestConsulta = _mapper.Map<ConsultaModel>(consulta);
        var consultaCreationMessages = await _consultaService.CreateConsulta(requestConsulta);
        var cleanResponses = await _messageHandler.ConcatRegistrationMessages(consultaCreationMessages);

        return Ok(cleanResponses);
    }

    [Route("/updateconsulta")]
    [HttpPut]
    public async Task<ActionResult<List<ConsultaResponse>>> UpdateConsulta([FromForm] ConsultaRequest consulta)
    {
        var requestConsulta = _mapper.Map<ConsultaModel>(consulta);
        await _consultaService.UpdateConsulta(requestConsulta);

        return Ok(requestConsulta);
    }

    [Route("/deleteconsulta/{consultaId}")]
    [HttpDelete]
    public async Task<ActionResult<ConsultaResponse>> DeleteConsulta(Guid consultaId)
    {
        try
        {
            await _consultaService.DeleteConsulta(consultaId);
            return Ok("Consulta deletada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
