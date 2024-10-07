using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json; // Para parsear el JSON

namespace EMTMADRID.Controllers
{
    public class DataController
    {
        private readonly string url = "https://openapi.emtmadrid.es/v2/mobilitylabs/user/login/";
        private readonly string clientId = "862e2b64-548a-4d89-ad78-a6b5f3f68f20";
        private readonly string passKey = "7E30E937BAC90C79954C9160834A281551AB876082B4ECED9D6AE2E81809A8AFB6ED5B0C274BDBF72DD8ABB7B8D3FF6ED664ADE472B6638DDF6E17A6FCFDD7D9";

        public async Task<string> GetApiDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-ClientId", clientId);
                client.DefaultRequestHeaders.Add("passKey", passKey);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Datos recibidos correctamente:");

                        // Parsear el JSON para obtener el accessToken
                        using (JsonDocument jsonDoc = JsonDocument.Parse(responseData))
                        {
                            // Acceder al campo "accessToken"
                            string accessToken = jsonDoc.RootElement
                                .GetProperty("data")[0] // Accede al array "data" y toma el primer objeto
                                .GetProperty("accessToken") // Extrae el campo "accessToken"
                                .GetString(); // Obtiene el valor como string

                            // Imprimir el token
                            Console.WriteLine("Access Token: " + accessToken);

                            return accessToken; // Devolver el token si lo necesitas
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al hacer la solicitud: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
