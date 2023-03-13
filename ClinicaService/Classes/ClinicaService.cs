using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaService.Interfaces;
using ClinicaService.Validators.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ClinicaService.Classes;

public class ClinicaClassService : IClinicaClassService
{
	private readonly IClinicaClassRepository _clinicaRepository;
	private readonly IConfiguration _configuration;
	private readonly IMessageHandler _messageHandler;

	public ClinicaClassService(IClinicaClassRepository comentarioRepository,
		IConfiguration configuration,
		IMessageHandler messageHandler)
	{
		_clinicaRepository = comentarioRepository;
		_configuration = configuration;
		_messageHandler = messageHandler;
	}

	public Task<IEnumerable<ClinicaModel>> GetAllClinicas()
	{
		return _clinicaRepository.GetAllClinicas();
	}

	public async Task<ClinicaModel?> GetClinicaById(Guid id)
	{
		return await _clinicaRepository.GetClinicaById(id);
	}

	public async Task<IList<string>> CreateClinica(ClinicaModel clinica)
	{
		IList<string> registrationMessages = new List<string>();

		bool verifyClinica = await VerifyIfClinicaAlreadyExists(clinica);

		if (verifyClinica is true)
		{
			registrationMessages.Add("Nome ja esta cadastrado");
			return registrationMessages;
		}

		registrationMessages = await _messageHandler.ValidateClinicaRegistration(clinica);

		if (registrationMessages.Count != 0)
		{
			return registrationMessages;
		}

		var createdUser = await InsertClinicaIdPasswordHashSaltAndCreatedTime(clinica);

		try
		{
			await _clinicaRepository.CreateClinica(createdUser);
			registrationMessages.Add("Usuario registrado com sucesso");
		}
		catch (Exception ex)
		{
			registrationMessages.Add($"Ocorreu um erro durante o registro de usuario {ex.Message}");
		}

		return registrationMessages;
	}

	public Task UpdateClinica(ClinicaModel comentario)
	{
		comentario.UpdatedDate = DateTime.UtcNow.AddHours(-3);
		return _clinicaRepository.UpdateClinica(comentario);
	}

	public Task DeleteClinica(Guid id)
	{
		return _clinicaRepository.DeleteClinica(id);
	}
	public async Task<string> Login(ClinicaModel clinica)
	{
		bool verifyClinica = await VerifyIfClinicaAlreadyExists(clinica);

		if (verifyClinica is false)
		{
			throw new Exception("Usuario ou senha incorretos");
		}

		bool verifyPassword = await VerifyIfPasswordIsCorrect(clinica);

		if (verifyPassword is false)
		{
			throw new Exception("Usuario ou senha incorretos");
		}

		var requestedLogInUser = await _clinicaRepository.GetClinicaByName(clinica);

		bool verifyPasswordHash = await VerifyPasswordHash(
			requestedLogInUser.Password,
			requestedLogInUser.PasswordHash,
			requestedLogInUser.PasswordSalt);

		if (verifyPasswordHash is false)
		{
			throw new Exception("Ocorreu um erro durante o login");
		}

		string token = await CreateToken(requestedLogInUser);

		return token;
	}


	private async Task<bool> VerifyIfClinicaAlreadyExists(ClinicaModel clinica)
	{
		var clinicas = await _clinicaRepository.GetAllClinicas();

		foreach (var c in clinicas)
		{
			if (c.Username == clinica.Username)
			{
				return true;
			}
		}

		return false;
	}

	private async Task<bool> VerifyIfPasswordIsCorrect(ClinicaModel clinica)
	{
		var requestedClinica = await _clinicaRepository.GetClinicaByName(clinica);

		if (requestedClinica.Password == clinica.Password)
		{
			return true;
		}

		return false;
	}

	private async Task<bool> VerifyPasswordHash(
		string password,
		byte[] passwordHash,
		byte[] passwordSalt)
	{
		using (var hmac = new HMACSHA512(passwordSalt))
		{
			var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
			return computedHash.SequenceEqual(passwordHash);
		};
	}

	private void CreatePasswordHash(
		string password,
		out byte[] passwordHash,
		out byte[] passwordSalt)
	{
		using (var hmac = new HMACSHA512())
		{
			passwordSalt = hmac.Key;
			passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
		}
	}

	private async Task<ClinicaModel> InsertClinicaIdPasswordHashSaltAndCreatedTime(ClinicaModel clinica)
	{
		CreatePasswordHash(clinica.Password, out byte[] passwordHash, out byte[] passwordSalt);

		clinica.Id = Guid.NewGuid();
		clinica.PasswordHash = passwordHash;
		clinica.PasswordSalt = passwordSalt;
		clinica.CreatedDate = DateTime.UtcNow.AddHours(-3);

		return clinica;
	}

	private async Task<string> CreateToken(ClinicaModel clinica)
	{
		List<Claim> claims = new List<Claim>
		{
			new Claim(ClaimTypes.Name, clinica.Username),
			new Claim(ClaimTypes.NameIdentifier, clinica.Id.ToString()),
			new Claim(ClaimTypes.Role, "User")
		};


		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
			_configuration.GetSection("AppSettings:Token").Value));

		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

		var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddDays(1),
			signingCredentials: credentials);

		var jwt = new JwtSecurityTokenHandler().WriteToken(token);

		return jwt;
	}
}
