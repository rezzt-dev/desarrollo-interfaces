using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  internal class Proyecto
  {
    private int _codigo;
    private String _nombre;
    private String _fechaInicio;
    private String _fechaFin;

    public Proyecto() { }

    public Proyecto(int codigo, string nombre, string fechaInicio, string fechaFin)
    {
      _codigo = codigo;
      _nombre = nombre;
      _fechaInicio = fechaInicio;
      _fechaFin = fechaFin;
    }

    public int Codigo { get => _codigo; set => _codigo = value;}
    public string Nombre { get => _nombre; set => _nombre = value;}
    public string FechaInicio { get => _fechaInicio; set => _fechaInicio = value;}
    public string FechaFin { get => _fechaFin; set => _fechaFin = value;}
  }
}
