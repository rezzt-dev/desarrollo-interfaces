using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioMarioBros
{
  internal class Program
  {
    static void Main(string[] args)
    {
      string[,] tableroMario = new string[8,8];
      Mario mario = new Mario(3, 0);

      helperOperaciones.setTableroOculto(false);
      helperOperaciones.fillRandomValue(tableroMario);
      helperOperaciones.procesarMovimiento(tableroMario, mario);
    }
  }
}