using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_pinocho
{
  internal class Rio
  {
    public int[,] Contenido { get; private set; }
    public int Filas { get; private set; }
    public int Columnas { get; private set; }

    public Rio(int inputFilas, int inputColumnas)
    {
      Filas = inputFilas;
      Columnas = inputColumnas;

      Contenido = new int[inputFilas, Columnas];
      Random random = new Random();

      for (int i = 0; i < Filas; i++)
      {
        for (int j = 0; j < Columnas; j++)
        {
          Contenido[i, j] = random.Next(0, 4);
        }
      }
    }

    public void Display(List<helperCharacter> inputChars)
    {
      Console.Clear();
      for (int i = 0; i < Filas; i++)
      {
        for (int j = 0; j < Columnas; j++)
        {
          var tempChar = inputChars.Find(c => c.CurrentPosition.Item1 == i && c.CurrentPosition.Item2 == j);
          if (tempChar != null)
          {
            Console.ForegroundColor = tempChar is Pinocho ? ConsoleColor.Blue : ConsoleColor.Green;

            Console.Write(tempChar.Name[0] + " ");
            Console.ResetColor();
          }
          else if (i == Filas - 1 && j == Columnas - 1)
          {
            Console.Write("» ");
          }
          else
          {
            Console.Write("~ ");
          }
        }

        Console.WriteLine();
      }
    }
  }
}
