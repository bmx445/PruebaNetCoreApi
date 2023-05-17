using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TablaDeClentes.Models;

namespace TablaDeClentes.Controllers
{
	public class TablaController : Controller
	{
        public async Task<IActionResult> Index()
		{
			var url = "https://localhost:7243/cliente/List";
			using (var httpclient = new HttpClient())
			{
				var respuesta = await httpclient.GetAsync(url);
				var repuestaString = await respuesta.Content.ReadAsStringAsync();

                var listadoPersonas = JsonSerializer.Deserialize<List<Cliente>>(repuestaString);

				 return View(listadoPersonas);
			}

		}
	}
}
