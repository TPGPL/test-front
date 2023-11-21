using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OrderManagementApp;
using OrderManagementApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient() { BaseAddress = new Uri("http://localhost:8080/") });
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IClientService, ClientService>();


await builder.Build().RunAsync();
