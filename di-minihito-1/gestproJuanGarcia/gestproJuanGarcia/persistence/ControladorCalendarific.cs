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

          foreach (var diaFestivoJson in documentoJson.RootElement.GetProperty("response").GetProperty("holidays").EnumerateArray())
          {
            diasFestivos.Add(new DiaFestivo
            {
              Nombre = diaFestivoJson.GetProperty("name").GetString(),
              Descripcion = diaFestivoJson.GetProperty("description").GetString(),
              Fecha = DateTime.Parse(diaFestivoJson.GetProperty("date").GetProperty("iso").GetString()),
              Pais = pais,
              Tipo = diaFestivoJson.GetProperty("type")[0].GetString(),
              Localidad = diaFestivoJson.GetProperty("locations").GetString()
            });
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
