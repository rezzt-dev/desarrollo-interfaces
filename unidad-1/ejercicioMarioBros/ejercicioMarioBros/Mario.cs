using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioMarioBros
{
  internal class Mario
  {
     // atributos y constantes =>
    const int VIDAS_BASE = 3;
    const int POCIMA_BASE = 0;
    const int MAX_POCIMA = 5;

    private int numVidas;
    private int cantPocima;
    private bool noVidas;

     // constructores =>
    public Mario ()
    {
      this.numVidas = VIDAS_BASE;
      this.cantPocima = POCIMA_BASE;
      this.noVidas = false;
    }

    public Mario (int inputVidas, int inputPocima)
    {
      this.numVidas = inputVidas;
      this.cantPocima = inputPocima;
    }

     // getters & setters =>
    public int NumVidas
    {
      get { return numVidas; }
      set { numVidas = value; }
    }

    public int CantPocima
    {
      get { return cantPocima; }
      set
      {
        if (value > MAX_POCIMA)
          cantPocima = MAX_POCIMA;
        else
          cantPocima = value;
      }
    }

    public bool NoVidas
    {
      get { return noVidas; }
      set { noVidas = value; }
    }
  }
}
