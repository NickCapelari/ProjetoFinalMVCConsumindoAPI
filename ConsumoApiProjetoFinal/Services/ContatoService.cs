using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;

namespace ConsumoApiProjetoFinal.Services
{
    public class ContatoService
    {
        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<Contato>> GetAllAsync()
        {
            List<Contato>? list = new List<Contato>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/contato");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Contato>>(dados);
            }
            return list;
        }

        public async Task<Contato> GetByIdAsync(int id)
        {
            Contato? contato = new Contato();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/contato/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                contato = JsonConvert.DeserializeObject<Contato>(dados);
            }

            return contato;
        }

        public async Task CreateAsync(Contato contato)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/contato", contato);

        }

        public async Task UpdateAsync(Contato contato)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/contato/" + contato.Id, contato);

        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/contato/" + id);
        }
    }
}
