using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicios_1 {
  internal class Program {
    static void Main(string[] args) {
      /**
        Operaciones.positivos();

        int aleatorio = Operaciones.customRandom(5, 10);
        Console.WriteLine(aleatorio);
        Console.ReadKey();
      */

      // utilizacion de arraylist
      /*
       List<string> listaColores = new List<string>();
       .Add("azul");
       listaColores.Add("rojo");
       listaColores.Add("verde");
       listaColores.Add("amarillo");
       listaColores.Add("morado");

       Console.WriteLine(listaColores[1]);
       Console.ReadKey();

       listaColores[2] = "hola";
       Console.WriteLine(listaColores[2]);
       Console.ReadKey();

       foreach(string color in listaColores)
       {
         Console.WriteLine(color);
       }
       listaColores.Insert(2, "otra vez");
       Console.WriteLine(listaColores[2]);

       Console.ReadKey();
      */

      List<int> listaNum = Operaciones.customRandom(1, 50);
      
      for (int i = 0; i < listaNum.Count; i++)
      {
        Console.WriteLine(listaNum[i]);
      }

      Console.ReadKey();
    }
  }
}
