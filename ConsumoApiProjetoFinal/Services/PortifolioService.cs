using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;

namespace ConsumoApiProjetoFinal.Services
{
    public class PortifolioService
    {
        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<Portifolio>> GetAllAsync()
        {
            List<Portifolio>? list = new List<Portifolio>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/portifolio");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Portifolio>>(dados);
            }
            return list;
        }

        public async Task<Portifolio> GetByIdAsync(int id)
        {
            Portifolio? portifolio = new Portifolio();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/portifolio/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                portifolio = JsonConvert.DeserializeObject<Portifolio>(dados);
            }

            return portifolio;
        }

        public async Task CreateAsync(Portifolio portifolio)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/portifolio", portifolio);

        }

        public async Task UpdateAsync(Portifolio portifolio)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/portifolio/" + portifolio.Id, portifolio);

        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/portifolio/" + id);
        }
    }
}
