using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Asegúrate de tener esta referencia para serializar el payload

namespace EMTMADRID.Controllers
{
    public class TimeController
    {
        // Método para realizar la petición POST a la API de EMT Madrid
        public async Task<string> GetBusArrivalsAsync(string accessToken, string stopId, string lineArrive)
        {
            // URL del endpoint para la solicitud POST con stop_id y line_arrive
            string url = $"https://openapi.emtmadrid.es/v2/transport/busemtmad/stops/{stopId}/arrives/{lineArrive}/";

            using (HttpClient client = new HttpClient())
            {
                // Añadir el token como header de autenticación
                client.DefaultRequestHeaders.Add("accessToken", accessToken);

                // Crear el cuerpo de la solicitud (payload)
                var payload = new
                {
                    cultureInfo = "ES",
                    Text_StopRequired_YN = "Y",
                    Text_EstimationsRequired_YN = "Y",
                    Text_IncidencesRequired_YN = "N",
                    DateTime_Referenced_Incidencies_YYYYMMDD = "20240923"
                };

                // Serializar el payload a formato JSON
                var jsonPayload = JsonConvert.SerializeObject(payload);

                // Crear el contenido con el payload serializado y establecer el Content-Type a 'application/json'
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                try
                {
                    // Realizar la solicitud POST
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // Verificar si la respuesta fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena
                        string responseData = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Datos recibidos correctamente:");
                        Console.WriteLine(responseData);
                        return responseData;
                    }
                    else
                    {
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine($"Error al hacer la solicitud: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
