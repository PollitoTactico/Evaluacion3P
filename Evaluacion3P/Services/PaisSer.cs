using Evaluacion3P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Evaluacion3P.Services
{
    public class PaisSer : PaisService
    {
        private string urlApi = "https://restcountries.com/v3.1/all";
        public async Task<List<Paises>> Obtener()
        {
            var cliente = new HttpClient();
            var response = await cliente.GetAsync(urlApi);
            var reponseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(reponseBody);
            JsonNode results = nodos["results"];

            var paisesData = JsonSerializer.Deserialize<List<Paises>>(results.ToString());

            var tasks = paisesData.Select(async pais =>
            {
                var paisResponse = await cliente.GetAsync(pais.Name);
                var paisResponseBody = await paisResponse.Content.ReadAsStringAsync();
                JsonNode paisNode = JsonNode.Parse(paisResponseBody);


                var status = paisNode["status"].AsArray();
                var statusList = status.Select(statusNode => statusNode["status"] ["Name"].ToString()).ToList();
                pais.Status = string.Join(",", statusList);

                var subregion = paisNode["subregion"].AsArray();
                var subregionList = subregion.Select(subregionNode => subregionNode["subregion"] ["Name"].ToString()).ToList();
                pais.Subregion = string.Join(",", subregionList);

               
            });

            await Task.WhenAll(tasks);
            return paisesData;
        }
        
    }
}
