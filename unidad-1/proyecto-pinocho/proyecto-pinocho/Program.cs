using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_pinocho
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Bienvenido a la competición de pesca en el río Guadalquivir!");

      // Parámetros del río
      int riverLength = 19;
      int riverWidth = 19;

      Rio rio = new Rio(riverLength, riverWidth);
      Jugador1 pinocho = new Jugador1("Pinocho");
      Jugador2 grillo = new Jugador2("Grillo");

      Competicion competition = new Competicion(rio, pinocho, grillo);
      competition.Start();

      Console.WriteLine("\nPresiona cualquier tecla para salir...");
      Console.ReadKey();
    }
  }
}
