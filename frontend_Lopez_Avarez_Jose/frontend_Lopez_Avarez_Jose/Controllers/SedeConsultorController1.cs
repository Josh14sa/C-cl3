using Microsoft.AspNetCore.Http;
using frontend_Lopez_Avarez_Jose.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Net.Http;

namespace frontend_Lopez_Avarez_Jose.Controllers
{
    public class SedeConsultorController1 : Controller
    {
        public async Task<IActionResult> listarSedes()
        {
            List<Sede> lista;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7226/api/Sede/");

                HttpResponseMessage response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    lista = JsonConvert.DeserializeObject<List<Sede>>(apiResponse);
                }
                else
                {
                    lista = new List<Sede>();
                }
            }
            return View(await Task.Run(() => lista));
        }

        public async Task<IActionResult> CrearSede()
        {
            return View(await Task.Run(() => new Sede()));
        }

        [HttpPost]
        public async Task<IActionResult> CrearSede(Sede reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7226/api/Sede/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("", content);
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return View(await Task.Run(() => reg));
        }

        [HttpGet]
        public async Task<IActionResult> EditarSede(Guid id)
        {
            if (id == Guid.Empty) // Verificar que el Guid no esté vacío
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7226/api/Sede/");
                HttpResponseMessage response = await client.GetAsync(id.ToString()); // Convertir el Guid a cadena para la solicitud
                if (response.IsSuccessStatusCode)
                {
                    var sedeJson = await response.Content.ReadAsStringAsync();
                    var sede = JsonConvert.DeserializeObject<Sede>(sedeJson);
                    return View(sede);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditarSede(Sede reg)
        {
            string mensaje = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7226/api/Sede/");
                StringContent content = new StringContent(JsonConvert.SerializeObject(reg), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(reg.idSede.ToString(), content); // Usar el Guid como parte de la URL
                string apiResponse = await response.Content.ReadAsStringAsync();
                mensaje = apiResponse;
            }
            ViewBag.mensaje = mensaje;
            return RedirectToAction("ListarSedes");
        }


        

    







        [HttpDelete]
        public async Task<IActionResult> EliminarSede(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7226/api/Sede/");

                HttpResponseMessage response = await client.DeleteAsync(id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    // Redireccionar al usuario después de la eliminación
                    return RedirectToAction("ListarSedes");
                }
                else
                {
                    // Manejar el caso en que la eliminación no sea exitosa
                    // Puedes mostrar un mensaje de error o realizar alguna otra acción
                    return View("Error");
                }
            }
        }





    }
}


