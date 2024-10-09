using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioTablero
{
  internal class Program
  {
    static void Main(string[] args)
    {
       string[,] mainTablero = new string[4, 4];
       operacionesTablero.fillTablero(mainTablero, "x");
       operacionesTablero.setPosition(mainTablero, 0, 0, "o");

       operacionesTablero.procesarMovimiento(mainTablero);
       Console.ReadKey();
    }
  }
}
