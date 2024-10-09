using System.Diagnostics.Contracts;

namespace proyectoPinocho {
  public class Tablero {
   // constantes & atributos =>
    public int[,] tableroGeneral { get; private set; }
    public int Filas { get; private set; }
    public int Columnas { get; private set; }

   //————————————————————————————————————————————————————————————————————————————————————————
   // constructores =>
    public Tablero (int inputFilas, int inputColumnas) {
      this.Filas = inputFilas;
      this.Columnas = inputColumnas;

      this.tableroGeneral = new int[Filas, Columnas];
      Random random = new Random();

      for (int i = 0; i < Filas; i++) {
        for (int j = 0; j < Columnas; j++) {
          this.tableroGeneral[i, j] = random.Next(0,4);
        }
      }
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos publicos =>
    public void ImprimirTablero(List<Caracter> inputChars) {
      Console.Clear();

      for (int i = 0; i < this.Filas; i++) {
        for (int j = 0; j < this.Columnas; j++) {
          var tempChar = inputChars.Find(c => c.posicionActual.Item1 == i && c.posicionActual.Item2 == j);

          if (tempChar != null) {
            Console.ForegroundColor = tempChar is Pinocho ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(tempChar.nombre[0] + " ");
          } else if (i == this.Filas - 1 && j == this.Columnas - 1) {
            Console.Write("» ");
          } else {
            Console.Write("~ ");
          }
        }
        Console.WriteLine();
      }
    }
  }
}