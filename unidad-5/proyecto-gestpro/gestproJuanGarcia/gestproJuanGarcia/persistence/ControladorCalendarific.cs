using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using gestproJuanGarcia.domain;
using System.Text.Json;

namespace gestproJuanGarcia.controllers
{
  public class ControladorCalendarific
  {
    private readonly string claveApi = "YOUR_API_KEY"; // Sustituye con tu clave de API de Calendarific
    private readonly string urlBase = "https://calendarific.com/api/v2/holidays";

    // Método para obtener días festivos por país y año
    public async Task<RespuestaCalendarific> ObtenerDiasFestivos(string pais, int anio)
    {
      using (HttpClient clienteHttp = new HttpClient())
      {
        try
        {
          // Construir la URL con los parámetros
          string url = $"{urlBase}?api_key={claveApi}&country={pais}&year={anio}";

          // Realizar la solicitud GET
          HttpResponseMessage respuesta = await clienteHttp.GetAsync(url);
          respuesta.EnsureSuccessStatusCode();

          // Leer la respuesta como string
          string cuerpoRespuesta = await respuesta.Content.ReadAsStringAsync();

          // Parsear el JSON a un objeto
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
