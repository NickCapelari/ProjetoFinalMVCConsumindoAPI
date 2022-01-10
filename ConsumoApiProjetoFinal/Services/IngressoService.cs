using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;

namespace ConsumoApiProjetoFinal.Services
{
    public class IngressoService
    {
        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<Ingresso>> GetAllAsync()
        {
            List<Ingresso>? list = new List<Ingresso>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/ingresso");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Ingresso>>(dados);
            }
            return list;
        }

        public async Task<Ingresso> GetByIdAsync(int id)
        {
            Ingresso? ingresso = new Ingresso();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/ingresso/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                ingresso = JsonConvert.DeserializeObject<Ingresso>(dados);
            }

            return ingresso;
        }

        public async Task CreateAsync(Ingresso ingresso)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/ingresso", ingresso);

        }

        public async Task UpdateAsync(Ingresso ingresso)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/ingresso/" + ingresso.Id, ingresso);

        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/ingresso/" + id);
        }
    }
}
