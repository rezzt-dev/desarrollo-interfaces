namespace proyectoPinocho {
  public class HelperClass {
   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos privados =>


   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos publicos =>
     // metodo "mostrarMenu" | muestra el menu principal -->
    public static void mostrarMenu() {
      Console.WriteLine();
      Console.WriteLine(" - Donde quieres moverte? - ");
      Console.WriteLine("  1. Izquierda");
      Console.WriteLine("  2. Derecha");
      Console.WriteLine("  3. Arriba");
      Console.WriteLine("  4. Abajo");

      Console.WriteLine();
      Console.WriteLine("  0. Salir");
      Console.WriteLine("————————————————————————————————");
    }

     // metodo "leerOpcionMenu" | lee la opcion del menu -->
    public static int leerOpcionMenu(Tablero inputTablero) {
      Console.Clear();
      Console.Clear();
      inputTablero.fillTablero();

      Console.Clear();
      Console.Clear();
      inputTablero.printTablero();
      inputTablero.mostrarStatsJugadores();

      Console.WriteLine();
      mostrarMenu();

      if (int.TryParse(Console.ReadLine(), out int opcion)) {
        return opcion;
      } else {
        Console.WriteLine("Opcion invalida");
        return leerOpcionMenu(inputTablero);
      }
    }
  }
}