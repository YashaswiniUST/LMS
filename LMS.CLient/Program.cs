using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LMS.CLient.Services;
using LMS.CLient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ✅ HTTP BASE ADDRESS (MUST MATCH API)
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5273/")
    });

builder.Services.AddScoped<AdminAuthService>();
builder.Services.AddScoped<StudentAuthService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<AdminClientService>();

await builder.Build().RunAsync();
