using ClinicaRepository.Classes;
using ClinicaRepository.Interfaces;
using ClinicaRepository.Models;
using ClinicaRepository.SqlDataAccess;
using ClinicaService.Classes;
using ClinicaService.Interfaces;
using ClinicaService.Validators;
using ClinicaService.Validators.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Cors
builder.Services.AddCors(policy =>
{
	policy.AddPolicy("OpenCorsPolicy", opt =>
		opt
		.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod());
});

//Dependency Injection
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

//Repositories
builder.Services.AddSingleton<IClinicaClassRepository, ClinicaClassRepository>();
builder.Services.AddSingleton<IPacienteRepository, PacienteRepository>();
builder.Services.AddSingleton<IConsultaRepository, ConsultaRepository>();


//Services
builder.Services.AddSingleton<IClinicaClassService, ClinicaClassService>();
builder.Services.AddSingleton<IPacienteService, PacienteService>();
builder.Services.AddSingleton<IConsultaService, ConsultaService>();


//Validators / MessageHandler
builder.Services.AddSingleton<IMessageHandler, MessageHandler>();
builder.Services.AddSingleton<IValidator<ClinicaModel>, ClinicaValidator>();
builder.Services.AddSingleton<IValidator<PacienteModel>, PacienteValidator>();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//SwaggerGen
builder.Services.AddSwaggerGen(x =>
{
	x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the bearer scheme",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey
	});
	x.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{new OpenApiSecurityScheme{Reference = new OpenApiReference
		{
			Id = "Bearer",
			Type = ReferenceType.SecurityScheme
		}}, new List<string>()}
	});
});

//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(
		options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
					.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
				ValidateIssuer = false,
				ValidateAudience = false
			};
		});

// Authorization
builder.Services.AddAuthorization(options =>
{
	options.FallbackPolicy = new AuthorizationPolicyBuilder()
	.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
	.RequireAuthenticatedUser()
	.Build();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure
app.UseHttpsRedirection();
app.UseCors("OpenCorsPolicy");

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

