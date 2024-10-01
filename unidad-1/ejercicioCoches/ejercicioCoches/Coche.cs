using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioCoches
{
  internal class Coche
  {
   // atributos -
    private int _id;
    private string _marca;
    private string _modelo;
    private int _kilometros;
    private double _precio;

    public Coche(int _idInput, string _marcaInput, string _modeloInput, int _kilometrosInput, double _precioInput)
    {
      this._id = _idInput;
      this._marca = _marcaInput;
      this._modelo = _modeloInput;

      this._kilometros = _kilometrosInput;
      this._precio = _precioInput;
    }

    public int _Id
    {
      get { return _id; }
      set { _id = value; }
    }

    public string _Marca
    {
      get { return _marca; }
      set { _marca = value; }
    }

    public string _Modelo 
    { 
      get { return _modelo; } 
      set { _modelo = value; }
    }
    public int _Kilometros
    {
      get { return _kilometros; }
      set { _kilometros = value; }
    }

    public double _Precio
    {
      get { return _precio; }
      set { _precio = value; }
    }

    public override string ToString()
    {
      return ("| Id: " + this._id + " | Marca: " + this._marca + " | Modelo: " + this._modelo + " | Km: " + this._kilometros + " | Precio: " + this._precio + "$ |");
    }
  }
}
