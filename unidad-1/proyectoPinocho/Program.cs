namespace proyectoPinocho {
  public class Program {
    public static void Main(string[] args) {
      Console.Clear();
      Tablero tablero = new Tablero();
      Jugador jugador1 = new Jugador("A", 3, 18);
      
      tablero.guardarCharsJugadores(jugador1);
      tablero.procesarMovimiento(jugador1);
    }
  }
}
