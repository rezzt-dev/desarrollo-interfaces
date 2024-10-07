using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioMarioBros
{
  internal class helperOperaciones
  {
    private static int posMarioI = 0;
    private static int posMarioJ = 0;

    private static List<int> posILista = new List<int>();
    private static List<int> posJLista = new List<int>();

    private static bool tableroOculto = true;

    // metodo "fillRandomValue" | rellena un tablero con valores aleatorios =>
    public static void fillRandomValue (string[,] inputTablero) {
      Random random = new Random ();

      for (int i = 0; i < inputTablero.GetLength (0); i++) {
        for (int j = 0; j < inputTablero.GetLength (1); j++) {
          if (inputTablero[i, j] == inputTablero[posMarioI, posMarioJ]) {
            inputTablero[i, j] = "M";
          } else if (isPosInList(i,j)) {
            inputTablero[i, j] = "-";
          } else {
            inputTablero[i, j] = Convert.ToString(random.Next(0, 3));
          }
        }
      }
    }

     // metodo "isPosInList" | comprueba si una posicion esta en la lista =>
    public static bool isPosInList (int inputI, int inputJ) {
      for (int index = 0; index < posILista.Count; index++) {
        if (posILista[index] == inputI && posJLista[index] == inputJ) {
          return true;
        }
    }
    return false;
    }

     // metodo "printTablero" | imprime un tablero en pantalla =>
    public static void printTablero (string[,] inputTablero) {
      for (int i = 0; i < inputTablero.GetLength (0); i++) {
        for (int j = 0; j < inputTablero.GetLength (1); j++) {
          Console.Write (" " + inputTablero[i, j] + " ");
        }
        Console.WriteLine ();
      }
    }

     // metodo "printTableroOculto" | imprime un tablero en pantalla oculto =>
    public static void printTableroOculto (string[,] inputTablero) {
      for (int i = 0; i < inputTablero.GetLength (0); i++) {
        for (int j = 0; j < inputTablero.GetLength (1); j++) {
          if (inputTablero[i, j] == inputTablero[posMarioI, posMarioJ]) {
            Console.Write(" M ");
          }
          else if (isPosInList(i, j)) {
            Console.Write(" - ");
          }
          else
          {
            Console.Write(" x ");
          }
        }
        Console.WriteLine ();
      }
    }

     // metodo "mostrarMenu" | muestra el menu de opciones =>
    public static void mostrarMenu () {
      Console.WriteLine("\n> Donde quieres mover a Mario:");
      Console.WriteLine(" 1. Derecha.");
      Console.WriteLine(" 2. Izquierda.");
      Console.WriteLine(" 3. Arriba.");
      Console.WriteLine(" 4. Abajo.");

      Console.WriteLine("\n 0. Salir.");
    }

     // metodo "movimientoTablero" | mueve un caracter donde se indique =>
    public static int movimientoTablero (string[,] inputTablero, ref int inputI, ref int inputJ, ref Mario inputMario) {
      int returnValue = 0;
      inputTablero[inputI, inputJ] = "-";
      posILista.Add (inputI);
      posJLista.Add (inputJ);

      Console.WriteLine("  > Introduce la proxima posicion: ");
      int inputPosicion = Convert.ToInt32(Console.ReadLine());


      switch (inputPosicion) {
        case 0:
          Console.WriteLine ("  > Saliendo...");
          return returnValue = 3;
        case 1:
          if (inputJ < inputTablero.GetLength(1) - 1) inputJ++;
          else Console.WriteLine("Posicion Incorrecta");
          break;
        case 2:
          if (inputJ > 0) inputJ--;
          else Console.WriteLine("Posicion Incorrecta");
          break;
        case 3:
          if (inputI > 0) inputI--;
          else Console.WriteLine("Posicion Incorrecta");
          break;
        case 4:
          if (inputI < inputTablero.GetLength(0) - 1) inputI++;
          else Console.WriteLine("Posicion Incorrecta");
          break;
      }

      returnValue = int.Parse(inputTablero[inputI, inputJ]);
      inputTablero[inputI, inputJ] = "M";
      posMarioI = inputI;
      posMarioJ = inputJ;


      if (inputI == 7 && inputJ == 7 && inputMario.CantPocima >= 5) returnValue = 3;

      return returnValue;
    }

     // metodo "procesarMovimiento" | bucle sin fin para mover caracteres =>
    public static void procesarMovimiento(string[,] inputTablero, Mario inputMario) {
      int i = 0, j = 0;
      inputTablero[i, j] = "M";

      bool salir = false;
      while (!salir) {
        Console.Clear();
        Console.WriteLine($"NumVidas: {inputMario.NumVidas} | CantPocima: {inputMario.CantPocima}");
        Console.WriteLine();

        fillRandomValue(inputTablero);
        if (inputMario.CantPocima >= 5) {
          inputTablero[7, 7] = "S";
        }

        if (tableroOculto) {
          printTableroOculto(inputTablero);
        } else {
          printTablero(inputTablero);
        }

        mostrarMenu();

        int returnValue = movimientoTablero(inputTablero, ref i, ref j, ref inputMario);

        switch (returnValue) {
          case 0:
            inputMario.NumVidas--;
            break;
          case 1:
            inputMario.NumVidas++;
            break;
          case 2:
            inputMario.CantPocima += 2;
            break;
          case 3:
            salir = true;
            break;
          default:
            inputMario.NumVidas++;
            break;
        }

        if (inputMario.NumVidas <= 0)
        {
          salir = true;
        }
      }

      if (inputMario.NumVidas <= 0) {
        Console.Clear();
        Console.WriteLine("GAME OVER");
        Console.ReadKey();
      }
      else if (inputMario.CantPocima >= 5) {
        Console.Clear();
        Console.WriteLine("Has salvado a la Peach!");
        Console.ReadKey();
      }
    }

     // metodo "setTableroOculto" | poner el tablero en oculto o no =>
    public static void setTableroOculto (bool setOculto)
    {
      if (setOculto)
      {
        tableroOculto = true;
      } else
      {
        tableroOculto = false;
      }
    }
  }
}
