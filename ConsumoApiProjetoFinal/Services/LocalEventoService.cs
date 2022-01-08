using ConsumoApiProjetoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace ConsumoApiProjetoFinal.Services
{
    public class LocalEventoService
    {
        string BaseUrl = "http://localhost:5190/";
        HttpClient client = new HttpClient();

        public async Task<List<LocalEvento>> GetAllAsync()
        {
            List<LocalEvento>? list = new List<LocalEvento>();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/localevento");

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<LocalEvento>>(dados);
            }
            return list;
        }

        public async Task <LocalEvento> GetByIdAsync(int id)
        {
            LocalEvento? localEvento= new LocalEvento();
                     
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/localevento/"+id);

            if (response.IsSuccessStatusCode)
            {
                var dados = response.Content.ReadAsStringAsync().Result;
                localEvento = JsonConvert.DeserializeObject<LocalEvento>(dados);
            }
           
            return localEvento;
        }

        public async Task CreateAsync(LocalEvento localEvento)
        {
            
            HttpResponseMessage response = await client.PostAsJsonAsync(
                BaseUrl + "api/localevento", localEvento);
            
        }

        public async Task UpdateAsync(LocalEvento localEvento)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(BaseUrl + "api/localevento/" + localEvento.Id, localEvento);
            
        }

        public async Task DeleteAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(BaseUrl + "api/localevento/" + id);
        }
    }
}
