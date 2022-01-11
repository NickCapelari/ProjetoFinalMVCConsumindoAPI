using ConsumoApiProjetoFinal.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LocalEventoService>();
builder.Services.AddScoped<EventoService>();
builder.Services.AddScoped<TipoIngressoService>();
builder.Services.AddScoped<PortifolioService>();
builder.Services.AddScoped<FotoPortifolioService>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<ContatoService>();
builder.Services.AddScoped<IngressoService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Home/LoginPage");
   
    

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();
app.UseAuthorization();
app.UseCookiePolicy();

app.Run();
