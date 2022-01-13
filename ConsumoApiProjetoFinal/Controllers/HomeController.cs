using ConsumoApiProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ConsumoApiProjetoFinal.Models.ViewModels;
using ConsumoApiProjetoFinal.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace ConsumoApiProjetoFinal.Controllers
{

    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Eventos()
        {

            EventoService eventoService = new EventoService();
            var list = await eventoService.GetByDateAsync();
            return View(list);
        }

        public async Task<IActionResult> Index()
        {
            
            PortifolioService portifolioService = new PortifolioService();
            var list = await portifolioService.GetAllAsync();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult LoginPage()
        {
           
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginPage(Usuario usuario)
        {
            UsuarioService usuarioService = new UsuarioService();
            string token = usuarioService.pegarToken(usuario);
            Usuario obj = new Usuario();
            obj = await usuarioService.GetByNameAsync(usuario.User);
            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.User == obj.User && usuario.Password == obj.Password)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, usuario.User),
                            new Claim(ClaimTypes.Sid, token.ToString())
                        };

                        var identidade = new ClaimsIdentity(claims, "Login");

                        ClaimsPrincipal principal = new ClaimsPrincipal(identidade);
                        var regrasAutenticacao = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(4),
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            principal, regrasAutenticacao
                            );

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Erro = "Login ou senha Errado";
                    }
                }
            }
            catch (Exception ex)
            {

                ViewBag.Erro = "Ocorreu um problema ao Logar " + ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }


    }
}