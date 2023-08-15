using GmfView.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<IFuncionarioService, FuncionarioService>(x => {
    x.BaseAddress = new Uri(@"https://localhost:7044");
    x.DefaultRequestHeaders.Add("Accept", "application/+json");

});
builder.Services.AddHttpClient<IFuncionarioObraService, FuncionarioObraService>(x => {
    x.BaseAddress = new Uri(@"https://localhost:7044");
    x.DefaultRequestHeaders.Add("Accept", "application/+json");

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
