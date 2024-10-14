using EMTMADRID.Controllers;
using EMTMADRID.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace EMTMADRID.Controllers
{
    [HttpGet]
    public async Task<JsonResult> GenerateMapController()
    {
        // Aquí obtendremos la latitud y longitud de los parámetros de la solicitud
        double latitude = Convert.ToDouble(Request.Query["latitude"]);
        double longitude = Convert.ToDouble(Request.Query["longitude"]);
        Console.WriteLine("Latitud: " + latitude);
        string accessToken = await _dataController.GetApiDataAsync();
        string url = $"https://api.emtmadrid.es/v1/estaciones/nearby?lat={latitude}&lon={longitude}";

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var nearbyStations = JsonConvert.DeserializeObject<List<Station>>(jsonResponse);
                return Json(nearbyStations); // Devuelve la lista de estaciones en formato JSON
            }
        }

        return Json(new List<Station>()); // Devuelve una lista vacía si no hay estaciones
    }
}
