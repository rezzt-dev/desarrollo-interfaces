using System;
using System.Collections.Generic;

namespace ejercicioCoches
{
  internal class Program
  {
    static void Main(string[] args)
    {
      List<Coche> listaCoches = new List<Coche>();

      Console.WriteLine("> Introduce el numero de vehiculos que quieres agregar: ");
      int numVehiculos = int.Parse(Console.ReadLine());

      if (numVehiculos <= 0 )
      {
        Console.WriteLine(" ERROR! No se ha seleccionado ninguna cantidad.");
        Console.ReadKey();
      } else
      {
        

        for (int i = 0; i < numVehiculos; i++)
        {
          Console.WriteLine("  - Introduce el identificador: ");
          int _tempId = int.Parse(Console.ReadLine());

          Console.WriteLine("  - Introduce la marca: ");
          String _tempMarca = Console.ReadLine();

          Console.WriteLine("  - Introduce el modelo: ");
          String _tempModelo = Console.ReadLine();

          Console.WriteLine("  - Introduce los kilometros: ");
          int _tempKm = int.Parse(Console.ReadLine());

          Console.WriteLine("  - Introduce el precio: ");
          double _tempPrecio = double.Parse(Console.ReadLine());

          Coche tempCoche = new Coche(_tempId, _tempMarca, _tempModelo, _tempKm, _tempPrecio);
          listaCoches.Add(tempCoche);
        }
      }

      for (int i = 0; i < listaCoches.Count; i++)
      {
        Coche tempCoche = listaCoches[i];
        String infoCoche = tempCoche.ToString();
        Console.WriteLine(infoCoche);
        Console.ReadKey();
      }
    }
  }
}
