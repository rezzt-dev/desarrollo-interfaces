using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioTablero
{
  internal class operacionesTablero
  {
    public static void fillTablero(string[,] inputTablero, string inputChar)
    {
      for (int i = 0; i < inputTablero.GetLength(0); i++)
      {
        for (int j = 0; j < inputTablero.GetLength(1); j++)
        {
          inputTablero[i, j] = inputChar;
        }
      }
    }

    public static void setPosition(string[,] inputTablero, int iInput, int jInput, string inputChar)
    {
      inputTablero[iInput, jInput] = inputChar;
    }

    public static void printTablero(string[,] inputTablero)
    {
      for (int i = 0; i < inputTablero.GetLength(0); i++)
      {
        for (int j = 0; j < inputTablero.GetLength(1); j++)
        {
          Console.Write(" " + inputTablero[i, j] + " ");
        }

        Console.WriteLine();
      }
    }

     // metodo "mostrarMenuOpciones" | mover la o donde se indique =>
    public static void mostrarMenuOpciones ()
    {
      Console.WriteLine("\n> Donde quieres mover la 'o':");
      Console.WriteLine(" 1. Derecha.");
      Console.WriteLine(" 2. Izquierda.");
      Console.WriteLine(" 3. Arriba.");
      Console.WriteLine(" 4. Abajo.");

      Console.WriteLine("\n 0. Salir.");
    }

     // metodo "movimientoCaracter" | mueve el caracter donde se indique =>
    public static void movimientoCaracter(string[,] inputTablero, ref int i, ref int j)
    {
      inputTablero[i, j] = "x";

      Console.WriteLine("  - Introduce donde quieres mover el caracter: ");
      int nuevaPosicion = int.Parse(Console.ReadLine());

      switch (nuevaPosicion)
      {
        case 0:
          break;
        case 1:
          if (j < inputTablero.GetLength(1) - 1) j++;
          break;
        case 2:
          if (j > 0) j--;
          break;
        case 3:
          if (i > 0) i--;
          break;
        case 4:
          if (i < inputTablero.GetLength(0) - 1) i++;
          break;

        default:
          Console.WriteLine("direccion no valida.");
          break;
      }

      inputTablero[i, j] = "o";
    }

     // metodo "procesarMovimiento" | bucle sin fin para mover caracteres =>
    public static void procesarMovimiento(string[,] inputTablero)
    {
      int i = 0, j = 0;
      inputTablero[i, j] = "o";

      bool continuar = true;
      while (continuar)
      {
        printTablero(inputTablero);
        mostrarMenuOpciones();

        movimientoCaracter(inputTablero, ref i, ref j);

        Console.WriteLine("  - Quieres continuar moviendo? (s/n) ");
        string response = Console.ReadLine().ToLower();

        if (response == "n")
        {
          continuar = false;
        }
      }
    }
  }
}
