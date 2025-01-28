using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  public class DiaFestivo
  {
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    public string Pais { get; set; }
    public string Tipo { get; set; }
    public string Localidad { get; set; }
  }

  public class RespuestaCalendarific
  {
    public List<DiaFestivo> DiasFestivos { get; set; }
    public string Pais { get; set; }
    public string Anio { get; set; }
  }
}
