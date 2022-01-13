using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace ConsumoApiProjetoFinal.Services
{
    public class UsuarioService
    {
        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();
        public async Task<Usuario> GetByNameAsync(string login)
        {
          
            Usuario? user = new Usuario();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/usuario/" + login);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<Usuario>(dados);
            }

            return user;
        }

        public string pegarToken(Usuario user)
        {
            string BaseUrl = "http://localhost:5190/";
            string token = "";
            HttpClient clientToken = new HttpClient();
            clientToken.DefaultRequestHeaders.Accept.Clear();
            clientToken.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage respToken = clientToken.PostAsJsonAsync(BaseUrl + "api/autenticar", user).Result;

            if (respToken.StatusCode == HttpStatusCode.OK)
            {
                return token = respToken.Content.ReadAsStringAsync().Result;

            }
            else
            {
                return "";
            }

        }

    }

    
}
