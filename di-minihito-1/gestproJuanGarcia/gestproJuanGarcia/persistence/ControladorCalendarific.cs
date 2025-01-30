using gestproJuanGarcia.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gestproJuanGarcia.persistence
{
  public class ControladorCalendarific
  {
    private readonly string claveApi = "XF4ogYCKIIBd6SPKPtkXDTQMLVvUeWkS";
    private readonly string urlBase = "https://calendarific.com/api/v2/holidays";

    public async Task<RespuestaCalendarific> ObtenerDiasFestivos(string pais, int anio)
    {
      using (HttpClient clienteHttp = new HttpClient())
      {
        try
        {
          string url = $"{urlBase}?api_key={claveApi}&country={pais}&year={anio}";

          HttpResponseMessage respuesta = await clienteHttp.GetAsync(url);
          respuesta.EnsureSuccessStatusCode();

          string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();

          var opcionesJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
          var documentoJson = JsonDocument.Parse(cuerpoRespuesta);

          // Crear lista de DiasFestivos desde el JSON
          List<DiaFestivo> diasFestivos = new List<DiaFestivo>();

          if (!documentoJson.RootElement.TryGetProperty("response", out JsonElement response) ||
            response.TryGetProperty("holidays", out JsonElement holidays))
          {
            Console.WriteLine("No se encontraron días festivos en la respuesta.");
            return new RespuestaCalendarific { DiasFestivos = new List<DiaFestivo>() };
          }

          return new RespuestaCalendarific
          {
            DiasFestivos = diasFestivos,
            Pais = pais,
            Anio = anio.ToString()
          };
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Error al obtener días festivos: {ex.Message}");
          return null;
        }
      }
    }
  }
}
