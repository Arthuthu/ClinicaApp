using Blazored.LocalStorage;
using ClinicaSite;
using ClinicaSite.Services.ConsultaService.Interfaces;
using ClinicaSite.Services.LoginService.Classes;
using ClinicaSite.Services.LoginService.Interfaces;
using ClinicaSite.Services.PacienteService.Classes;
using ClinicaSite.Services.PacienteService.Interfaces;
using ClinicaSite.Services.RegistrationService.Classes;
using ClinicaSite.Services.RegistrationService.Interfaces;
using ClinicaSite.Services.UserDataService.Classes;
using ClinicaSite.Services.UserDataService.Interfaces;
using ConsultaSite.Services.ConsultaService.Classes;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Dependency Injection
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>();


builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
