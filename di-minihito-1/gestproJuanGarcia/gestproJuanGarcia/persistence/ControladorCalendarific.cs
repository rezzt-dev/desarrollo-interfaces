using gestproJuanGarcia.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace gestproJuanGarcia.persistence
{
    public class ControladorCalendarific
    {
        private readonly string claveApi = "XF4ogYCKIIBd6SPKPtkXDTQMLVvUeWkS";
        private readonly string urlBase = "https://calendarific.com/api/v2/holidays";

        public async Task<bool> EsDiaFestivo(string pais, DateTime fecha)
        {
            try
            {
                var respuesta = await ObtenerDiasFestivos(pais, fecha.Year);
                if (respuesta == null || respuesta.DiasFestivos == null)
                {
                    Console.WriteLine("No se encontraron días festivos en la respuesta.");
                    return false;
                }

                bool esFestivo = respuesta.DiasFestivos.Any(d => d.Fecha.Date == fecha.Date);
                Console.WriteLine(esFestivo ? "El día es festivo." : "El día no es festivo.");
                return esFestivo;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar si es festivo: {ex.Message}");
                return false;
            }
        }

        public async Task<RespuestaCalendarific> ObtenerDiasFestivos(string pais, int anio)
        {
            using (HttpClient clienteHttp = new HttpClient())
            {
                try
                {
                    string url = $"{urlBase}?api_key={claveApi}&country={pais}&year={anio}";
                    HttpResponseMessage respuesta = await clienteHttp.GetAsync(url);
                    respuesta.EnsureSuccessStatusCode();

                    var responseContent = await respuesta.Content.ReadAsStringAsync();
                    Console.WriteLine("Respuesta de la API:");
                    Console.WriteLine(responseContent);

                    var opcionesJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var documentoJson = JsonDocument.Parse(responseContent);

                    if (!documentoJson.RootElement.TryGetProperty("response", out JsonElement response) ||
                        !response.TryGetProperty("holidays", out JsonElement holidays) ||
                        holidays.ValueKind != JsonValueKind.Array)
                    {
                        Console.WriteLine("Estructura de JSON inesperada o sin datos de días festivos.");
                        return new RespuestaCalendarific { DiasFestivos = new List<DiaFestivo>(), Pais = pais, Anio = anio.ToString() };
                    }

                    var diasFestivos = new List<DiaFestivo>();
                    foreach (JsonElement holiday in holidays.EnumerateArray())
                    {
                        var diaFestivo = new DiaFestivo
                        {
                            Nombre = holiday.GetProperty("name").GetString(),
                            Descripcion = holiday.GetProperty("description").GetString(),
                            FechaIso = holiday.GetProperty("date").GetProperty("iso").GetString(),
                            Pais = pais,
                            Tipos = holiday.TryGetProperty("type", out JsonElement tipoArray) && tipoArray.ValueKind == JsonValueKind.Array
                                ? tipoArray.EnumerateArray().Select(t => t.GetString()).ToList()
                                : new List<string> { "Desconocido" },
                            Localidad = holiday.TryGetProperty("locations", out JsonElement localidad) ? localidad.GetString() : ""
                        };
                        diasFestivos.Add(diaFestivo);
                    }

                    return new RespuestaCalendarific { DiasFestivos = diasFestivos, Pais = pais, Anio = anio.ToString() };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en la llamada a la API: {ex.Message}");
                    return new RespuestaCalendarific { DiasFestivos = new List<DiaFestivo>(), Pais = pais, Anio = anio.ToString() };
                }
            }
        }
    }
}