using ConsumoApiProjetoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LocalEventoService>();
builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<TipoIngressoService>();
builder.Services.AddScoped<PortifolioService>();
builder.Services.AddScoped<FotoPortifolioService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
