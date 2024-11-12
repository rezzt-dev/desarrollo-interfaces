using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioManejoPersonas.domain
{
  internal class Persona
  {
    private String _nombre;
    private String _apellidos;
    private int _edad;

    public Persona() { }
    public Persona(String nombre, String apellidos, int edad)
    {
      this._nombre = nombre;
      this._apellidos = apellidos;
      this._edad = edad;
    }

    public string Nombre {get => _nombre; set => _nombre = value;}
    public string Apellidos {get => _apellidos; set => _apellidos = value;}
    public int Edad {get => _edad; set => _edad = value;}

    public void last()
    {

    }
  }
}
