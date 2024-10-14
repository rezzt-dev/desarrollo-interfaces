using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_pinocho
{
  class Grillo : helperCharacter
  {
    public Grillo(string name) : base(name)
    {
      CurrentPosition = new Tuple<int, int>(0, 0);
      Path.Add(CurrentPosition);
    }

    public override void Move(Rio rio)
    {
      Random random = new Random();
      int x = random.Next(0, rio.Filas);
      int y = random.Next(0, rio.Columnas);

      if (x >= 0 && x < rio.Filas)
      {
        CurrentPosition = new Tuple<int, int>(x, y);
        Path.Add(CurrentPosition);

        // Aseguramos que y está dentro del rango antes de acceder a rio.Contenido
        if (y >= 0 && y < rio.Columnas)
        {
          switch (rio.Contenido[x, y])
          {
            case 0: Lives--; break;
            case 2: if (Fish > 0) Fish--; break;
            case 3: Fish++; break;
          }
        }
        else
        {
          // Manejar el caso en que y está fuera de rango
          Console.WriteLine("El Grillo intentó moverse fuera del tablero en la columna.");
        }
      }
      else
      {
        // Manejar el caso en que x está fuera de rango
        Console.WriteLine("El Grillo ha llegado al final del río.");
      }
    }
  }
}
