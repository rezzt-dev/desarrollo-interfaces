using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ejercicios_1
{
  internal class Operaciones
  {
    public static void positivos ()
    {
      int positivo = 0; int contador = 0; int numero;
      Console.WriteLine(" > Introduce un numero: ");
      numero = Int32.Parse(Console.ReadLine());

      while (numero != 0)
      {
        if (numero > 0) positivo++;
        Console.WriteLine("I > Introduce un numero");
        numero = Int32.Parse(Console.ReadLine());
        contador++;
      }

      Console.WriteLine("  - Has introducido un total de {0}", contador);
      Console.WriteLine("  - De los cuales son positivos {0}", positivo);
      Console.ReadKey();
    }

    public static List<int> customRandom (int num1, int num2)
    {
      List<int> listaNum = new List<int>();
      int seed = (int)DateTime.Now.Ticks;

      for (int i = 0; i < 100; i++)
      {
        seed = (seed * 1103515245 + 12345) & 0x7fffffff;
        int randomNum = (int)(num1 + (seed % (num2 - num1 + 1)));
        listaNum.Add(randomNum);
      }

      return listaNum;
    }
  }
}
