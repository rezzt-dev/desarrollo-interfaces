using System;
using System.Collections.Generic;

namespace gestproJuanGarcia.domain
{
  public class DiaFestivo
  {
    public string Nombre { get; set; } // Nombre del día festivo
    public string Descripcion { get; set; } // Descripción del día festivo
    public DateTime Fecha { get; set; } // Fecha del día festivo
    public string Pais { get; set; } // País del día festivo
    public string Tipo { get; set; } // Tipo de día festivo (nacional, religioso, etc.)
    public string Localidad { get; set; } // Región/localidad (si aplica)
  }

  public class RespuestaCalendarific
  {
    public List<DiaFestivo> DiasFestivos { get; set; } // Lista de días festivos
    public string Pais { get; set; } // País consultado
    public string Anio { get; set; } // Año de la consulta
  }
}

