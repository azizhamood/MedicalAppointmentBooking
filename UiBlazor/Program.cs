using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using UiBlazor;
using UiBlazor.Helpers;
using UiBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IPeriodeService, PeriodeService>();
builder.Services.AddScoped<IMedicalService, MedicalService>();
builder.Services.AddScoped(sp => new HttpClient(new CustomHttpMessageHandler()) { BaseAddress = new Uri(builder.Configuration["ApiUri"], UriKind.Absolute) });

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
