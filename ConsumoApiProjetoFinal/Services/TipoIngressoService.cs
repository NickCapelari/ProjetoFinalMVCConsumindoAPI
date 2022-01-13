using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ConsumoApiProjetoFinal.Services
{
    public class TipoIngressoService
    {
        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<TipoIngresso>> GetAllAsync(string token)
        {
            List<TipoIngresso>? list = new List<TipoIngresso>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("api/tipoingresso");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<TipoIngresso>>(dados);
            }
            return list;
        }

        public async Task<TipoIngresso> GetByIdAsync(int id, string token)
        {
            TipoIngresso? tipoIngresso = new TipoIngresso();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("api/tipoingresso/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                tipoIngresso = JsonConvert.DeserializeObject<TipoIngresso>(dados);
            }

            return tipoIngresso;
        }

        public async Task CreateAsync(TipoIngresso tipoIngresso, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/tipoingresso", tipoIngresso);

        }

        public async Task UpdateAsync(TipoIngresso tipoIngresso, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/tipoingresso/" + tipoIngresso.Id, tipoIngresso);

        }

        public async Task DeleteAsync(int id, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/tipoingresso/" + id);
        }
    }
}
