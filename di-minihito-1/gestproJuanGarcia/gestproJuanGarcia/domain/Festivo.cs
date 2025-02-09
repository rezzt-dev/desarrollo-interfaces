using System;
using System.Collections.Generic;

namespace gestproJuanGarcia.domain
{
    public class DiaFestivo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Cambiar DateTime a string y hacer el parseo después
        public string FechaIso { get; set; }

        public DateTime Fecha
        {
            get
            {
                if (DateTime.TryParse(FechaIso, out DateTime fechaParseada))
                {
                    return fechaParseada;
                }
                return DateTime.MinValue; // Si hay error, devuelve una fecha mínima válida.
            }
        }

        public string Pais { get; set; }

        // Manejar que 'type' puede ser un array en la API
        public List<string> Tipos { get; set; } = new List<string>();

        public string Tipo
        {
            get
            {
                return Tipos.Count > 0 ? Tipos[0] : "Desconocido";
            }
        }

        public string Localidad { get; set; }
    }

    public class RespuestaCalendarific
    {
        public List<DiaFestivo> DiasFestivos { get; set; } = new List<DiaFestivo>();
        public string Pais { get; set; }
        public string Anio { get; set; }
    }
}
