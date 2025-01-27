using Newtonsoft.Json;
using proyectoAPI.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static proyectoAPI.MainWindow;

namespace proyectoAPI.controlador
{
  internal class Controlador
  {
    private List<ApiObject> listaObjetosGeneral;
    private readonly string ApiUrl = "https://api.restful-api.dev/objects";
    private readonly HttpClient _client = new HttpClient();
    public Controlador() {
      listaObjetosGeneral = new List<ApiObject>();
    }

    public async Task<List<ApiObject>> ListarObjetosAsync()
    {

      HttpClient cliente = new HttpClient();
      HttpResponseMessage respuesta = await cliente.GetAsync(ApiUrl);

      if (respuesta.IsSuccessStatusCode)
      {
        string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<ApiObject>>(jsonRespuesta);
      }
      else
      {
        throw new Exception($"Error: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
      }
    }

    public async Task agregarNuevo ()
    {
      string body = "{\"name\": \"Prueba\", \"data\": { \"Generation\": \"4th\", \"Price\": \"519.99\" }}";
      HttpClient cliente = new HttpClient();
      HttpContent contenido = new StringContent(body, Encoding.UTF8, "application/json");
      HttpResponseMessage respuesta = await cliente.PostAsync(ApiUrl, contenido);

      if (respuesta.IsSuccessStatusCode)
      {
        string jsonRespuest = await respuesta.Content.ReadAsStringAsync();
      }
      else
      {
        throw new Exception($"Error al añadir objeto: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
      }
    }

    public async Task BorrarObjecto (int inputId)
    {
      HttpClient cliente = new HttpClient();
      HttpResponseMessage respuesta = await cliente.DeleteAsync($"{ApiUrl}/{inputId}");
      if (!respuesta.IsSuccessStatusCode)
      {
        throw new Exception($"Error al borrar el objeto: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
      }
    }
  }
}
