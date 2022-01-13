using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ConsumoApiProjetoFinal.Services
{
    public class EventoService
    {

        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();
        
   

        public async Task<List<Evento>> GetAllAsync(string token)
        {
           
            List<Evento>? list = new List<Evento>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("api/evento");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Evento>>(dados);
            }
            return list;
        }

        public async Task<Evento> GetByIdAsync(int id, string token)
        {
            Evento? evento = new Evento();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("api/evento/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                evento = JsonConvert.DeserializeObject<Evento>(dados);
            }

            return evento;
        }

        public async Task CreateAsync(Evento evento, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/evento", evento);

        }

        public async Task UpdateAsync(Evento evento, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/evento/" + evento.Id, evento);

        }

        public async Task DeleteAsync(int id, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/evento/" + id);
        }

        public async Task<List<Evento>> GetByDateAsync()
        {
            List<Evento>? list = new List<Evento>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await client.GetAsync("api/evento/date");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Evento>>(dados);
            }
            return list;
        }
    }
}
