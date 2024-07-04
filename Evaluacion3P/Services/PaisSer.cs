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
            var paisesData = JsonSerializer.Deserialize<List<JsonNode>>(reponseBody);

            var paises = new List<Paises>();

            foreach (var nodo in paisesData)
            {
                var pais = new Paises
                {
                    Name = nodo["name"]["official"].ToString(),
                    
                    Subregion = nodo["subregion"]?.ToString(),
                    Status = nodo["status"]?.ToString(),
                    JoseSanchez = GenerateCode("JS")
                };

                paises.Add(pais);
            }

            return paises;
        }

        private string GenerateCode(string initials)
        {
            Random random = new Random();
            int number = random.Next(1000, 2001);
            return $"{initials}{number}";
        }
    }

    
}
