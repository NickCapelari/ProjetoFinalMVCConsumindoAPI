using ConsumoApiProjetoFinal.Models;
using Newtonsoft.Json;

namespace ConsumoApiProjetoFinal.Services
{
    public class PessoaService
    {

        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<Pessoa>> GetAllAsync()
        {
            List<Pessoa>? list = new List<Pessoa>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/pessoa");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<Pessoa>>(dados);
            }
            return list;
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            Pessoa? pessoa = new Pessoa();

            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/pessoa/" + id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                pessoa = JsonConvert.DeserializeObject<Pessoa>(dados);
            }

            return pessoa;
        }

        public async Task CreateAsync(Pessoa obj, Contato contato)
        {
            obj.Contatos = new List<Contato>();
            obj.Contatos.Add(contato);
            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/pessoa", obj);

        }

        public async Task UpdateAsync(Pessoa obj)
        {
           
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/pessoa/" + obj.Id, obj);

        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/pessoa/" + id);
        }
    }
}
