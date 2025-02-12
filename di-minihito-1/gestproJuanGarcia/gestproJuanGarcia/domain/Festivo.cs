using System;
using System.Collections.Generic;

namespace gestproJuanGarcia.domain
{
  /// <summary>
  /// clase de diafestivo para manejar la api de calendalific
  /// </summary>
  public class DiaFestivo
    {
    /// <summary>
    /// Gets or sets the nombre.
    /// </summary>
    /// <value>
    /// The nombre.
    /// </value>
    public string Nombre { get; set; }
    /// <summary>
    /// Gets or sets the descripcion.
    /// </summary>
    /// <value>
    /// The descripcion.
    /// </value>
    public string Descripcion { get; set; }

    // Cambiar DateTime a string y hacer el parseo después
    /// <summary>
    /// Gets or sets the fecha iso.
    /// </summary>
    /// <value>
    /// The fecha iso.
    /// </value>
    public string FechaIso { get; set; }

    /// <summary>
    /// Gets the fecha.
    /// </summary>
    /// <value>
    /// The fecha.
    /// </value>
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

    /// <summary>
    /// Gets or sets the pais.
    /// </summary>
    /// <value>
    /// The pais.
    /// </value>
    public string Pais { get; set; }

    // Manejar que 'type' puede ser un array en la API
    /// <summary>
    /// Gets or sets the tipos.
    /// </summary>
    /// <value>
    /// The tipos.
    /// </value>
    public List<string> Tipos { get; set; } = new List<string>();

    /// <summary>
    /// Gets the tipo.
    /// </summary>
    /// <value>
    /// The tipo.
    /// </value>
    public string Tipo
    {
      get
      {
        return Tipos.Count > 0 ? Tipos[0] : "Desconocido";
      }
    }

    /// <summary>
    /// Gets or sets the localidad.
    /// </summary>
    /// <value>
    /// The localidad.
    /// </value>
    public string Localidad { get; set; }
    }

  /// <summary>
  /// 
  /// </summary>
  public class RespuestaCalendarific
  {
    /// <summary>
    /// Gets or sets the dias festivos.
    /// </summary>
    /// <value>
    /// The dias festivos.
    /// </value>
    public List<DiaFestivo> DiasFestivos { get; set; } = new List<DiaFestivo>();
    /// <summary>
    /// Gets or sets the pais.
    /// </summary>
    /// <value>
    /// The pais.
    /// </value>
    public string Pais { get; set; }
    /// <summary>
    /// Gets or sets the anio.
    /// </summary>
    /// <value>
    /// The anio.
    /// </value>
    public string Anio { get; set; }
  }
}
