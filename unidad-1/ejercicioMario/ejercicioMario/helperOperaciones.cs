using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioMario
{
  internal class helperOperaciones
  {
    public static void fillRandomValues(string[,] tableroInput)
    {
      Random random = new Random();
      for (int i = 0; i < tableroInput.GetLength(0); i++)
      {
        for (int j = 0; j < tableroInput.GetLength(1); j++)
        {
          int randomValue = random.Next(0, 3);
          tableroInput[i, j] = randomValue.ToString();
        }
      }
    }

     // metodo "printTablero" | imprime el tablero en pantalla => 
    public static void printTablero(string[,] tableroInput)
    {
      for (int i = 0; i < tableroInput.GetLength(0); i++)
      {
        for (int j = 0; j < tableroInput.GetLength(1); j++)
        {
          Console.Write(" " + tableroInput[i, j] + " ");
        }
        Console.WriteLine();
      }
    }

     // metodo "printTablero" | imprime el tablero en pantalla => 
    public static void printTableroOculto(string[,] tableroInput)
    {
      for (int i = 0; i < tableroInput.GetLength(0); i++)
      {
        for (int j = 0; j <= tableroInput.GetLength(1); j++)
        {
          Console.Write(" x ");
        }

        Console.WriteLine();
      }
    }

     // metodo "mostrarMenu" | indica las opciones donde mover a mario => 
    public static void mostrarMenu ()
    {
      Console.WriteLine("\n> Donde quieres mover a Mario':");
      Console.WriteLine(" 1. Derecha.");
      Console.WriteLine(" 2. Izquierda.");
      Console.WriteLine(" 3. Arriba.");
      Console.WriteLine(" 4. Abajo.");

      Console.WriteLine("\n 0. Salir.");
    }


     // metodo "movimientoMario" | controla si el movimiento es valido => 
    public static int movimientoMario(string[,] tableroInput, ref int i, ref int j)
    {
      int posValue = int.Parse(tableroInput[i, j]);
      tableroInput[i, j] = "-";

      Console.WriteLine("  - Introduce la nueva posicion de Mario: ");
      int newPos = int.Parse(Console.ReadLine());

      switch (newPos)
      {
        case 0:
          break;

        case 1:
          if (j < tableroInput.GetLength(1) - 1) j++;
          break;

        case 2:
          if (j > 0) j--;
          break;

        case 3:
          if (i > 0) i--;
          break;

        case 4:
          if (i < tableroInput.GetLength(0) - 1) i++;
          break;

        default:
          Console.WriteLine(" > Direccion Invalida!");
          break;
      }

      tableroInput[i, j] = "M";
      return posValue;
    }

     // metodo "procesarMovimiento" | procesa el movimiento => 
    public static void procesarMovimiento(string[,] tableroInput)
    {
      int i = 0, j = 0;
      tableroInput[i, j] = "M";

      bool salir = false;
      while (!salir)
      {
        printTablero(tableroInput);
        mostrarMenu();

        switch (movimientoMario(tableroInput, ref i, ref j))
        {
          case 0:
            quitarVida();
            break;
          case 1:

        } 
      }
    }

     // 
    public static int quitarVida ()
    {
      return -1;
    }
  }
}
