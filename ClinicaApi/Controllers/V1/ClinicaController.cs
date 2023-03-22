using AutoMapper;
using ClinicaApi.Request;
using ClinicaApi.Response;
using ClinicaRepository.Models;
using ClinicaService.Interfaces;
using ClinicaService.Validators.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers.V1;

[Route("api/v1/[controller]")]
[ApiController]
public class ClinicaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IClinicaClassService _clinicaService;
    private readonly IMessageHandler _messageHandler;

    public ClinicaController(IMapper mapper,
        IClinicaClassService clinicaService,
        IMessageHandler messageHandler)
    {
        _mapper = mapper;
        _clinicaService = clinicaService;
        _messageHandler = messageHandler;
    }

    [Route("/getclinicabyid/{id}")]
    [HttpGet]
    public async Task<ActionResult<ClinicaResponse>> GetClinicaById(Guid id)
    {
        var clinica = await _clinicaService.GetClinicaById(id);
        var responseClinica = _mapper.Map<ClinicaResponse>(clinica);

        return Ok(responseClinica);
    }

    [Route("/updateclinica")]
    [HttpPut]
    public async Task<ActionResult<List<ClinicaResponse>>> UpdateRoadmap([FromForm] ClinicaRequest clinica)
    {
        var requestClinica = _mapper.Map<ClinicaModel>(clinica);
        await _clinicaService.UpdateClinica(requestClinica);

        return Ok(requestClinica);
    }
}
