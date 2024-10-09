using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;

namespace testPinocho
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Bienvenido a la competición de pesca en el río Guadalquivir!");

      // Parámetros del río
      int riverLength = 12;
      int riverWidth = 12;

      Rio rio = new Rio(riverLength, riverWidth);
      Pinocho pinocho = new Pinocho("Pinocho");
      Grillo grillo = new Grillo("Grillo");

      Competicion competition = new Competicion(rio, pinocho, grillo);
      competition.Start();

      Console.WriteLine("\nPresiona cualquier tecla para salir...");
      Console.ReadKey();
    }
  }
}
