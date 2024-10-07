using EMTMADRID.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EMTMADRID.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Método GET para mostrar el formulario
        public IActionResult Index()
        {
            return View(new BusInputModel());  // Enviar un modelo vacío para capturar los datos
        }

        // Método POST para procesar los datos del formulario
        [HttpPost]
        public async Task<IActionResult> Index(BusInputModel inputModel)
        {
           
                // Aquí recibimos los valores introducidos por el usuario
                string stopId = inputModel.StopId;
                string lineArrive = inputModel.LineArrive;

                // Instanciar el controlador que contiene la lógica de la API
                var dataController = new DataController();

                // Llamar al método para hacer la petición GET
                string resultToken = await dataController.GetApiDataAsync();
                Console.WriteLine(resultToken);

                if (!string.IsNullOrEmpty(resultToken))
                {
                    var timeController = new TimeController();
                    string responseTime = await timeController.GetBusArrivalsAsync(resultToken, stopId, lineArrive);

                    if (!string.IsNullOrEmpty(responseTime))
                    {
                        var model = JsonConvert.DeserializeObject<BusArrivalResponse>(responseTime);

                        // Pasar los resultados de llegada de autobús a la vista para mostrarlo
                        inputModel.Arrive = model.Data[0].Arrive;
                    }
                    else
                    {
                        ViewBag.Message = "No se pudo obtener la información de llegadas.";
                    }
           
            }

            return View(inputModel);  // Devuelve la misma vista con los datos actualizados
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
