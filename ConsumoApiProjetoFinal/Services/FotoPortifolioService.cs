using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;

namespace ConsumoApiProjetoFinal.Services
{
    public class FotoPortifolioService
    {
        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<FotoPortifolio>> GetAllAsync()
        {
            List<FotoPortifolio>? list = new List<FotoPortifolio>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/fotoportifolio");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<FotoPortifolio>>(dados);
            }
            return list;
        }

        public async Task<FotoPortifolio> GetByIdAsync(int id)
        {
            FotoPortifolio? fotoPortifolio = new FotoPortifolio();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/fotoportifolio/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                fotoPortifolio = JsonConvert.DeserializeObject<FotoPortifolio>(dados);
            }

            return fotoPortifolio;
        }

        public async Task CreateAsync(FotoPortifolio fotoPortifolio)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/fotoportifolio", fotoPortifolio);

        }

        public async Task UpdateAsync(FotoPortifolio fotoPortifolio)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/fotoportifolio/" + fotoPortifolio.Id, fotoPortifolio);

        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/fotoportifolio/" + id);
        }
    }
}
