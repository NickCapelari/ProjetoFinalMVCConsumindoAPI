using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;

namespace ConsumoApiProjetoFinal.Services
{
    public class EventoService
    {

        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<Evento>> GetAllAsync()
        {
            List<Evento>? list = new List<Evento>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/evento");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Evento>>(dados);
            }
            return list;
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            Evento? evento = new Evento();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/evento/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                evento = JsonConvert.DeserializeObject<Evento>(dados);
            }

            return evento;
        }

        public async Task CreateAsync(Evento evento)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/evento", evento);

        }

        public async Task UpdateAsync(Evento evento)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/evento/" + evento.Id, evento);

        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/evento/" + id);
        }
    }
}
