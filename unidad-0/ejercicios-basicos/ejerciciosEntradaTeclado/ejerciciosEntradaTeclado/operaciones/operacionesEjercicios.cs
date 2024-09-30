using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejerciciosEntradaTeclado.operaciones
{
  internal class operacionesEjercicios
  {
   // Escribe un programa cuyo usuario pueda introducir el radio ( tipo de dato double) y que calcule el volumen y el Surface
   // del área de una esfera. La salida se muestra similar a la siguiente:
    public static void ejercicio8 ()
    {
      Console.WriteLine();
      double radio = Convert.ToDouble(Console.ReadLine());

      double area = 4 * Math.PI * (radio * radio);
      double volumen = 3 / 4 * Math.PI * (radio * radio * radio);

      Console.WriteLine("The volume is ${0} m3", volumen);
      Console.WriteLine("The surface area is ${0} m2", area);
      Console.WriteLine();
    }
  }
}
