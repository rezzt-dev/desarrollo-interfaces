using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioMario
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string[,] tableroMario = new string[8, 8];
      helperOperaciones.fillRandomValues(tableroMario);
      helperOperaciones.printTableroOculto(tableroMario);
      Console.ReadKey();
    }
  }
}
