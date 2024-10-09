namespace proyectoPinocho
{
  internal class Program
  {
    public static void main (string[] args) {
      Console.WriteLine(" - Proyecto Pinocho | JGC by Juan Garcia Cazallas - ");

      int filasRio = 12;
      int columnasRio = 12;
      Tablero rioBase = new Tablero(filasRio, columnasRio);

      Pinocho pinocho = new Pinocho("Pinocho");
      Grillo grillo = new Grillo("Grillo");
      CompeticionPesca competicion = new CompeticionPesca(rioBase, pinocho, grillo);

      competicion.IniciarCompeticion();

      Console.WriteLine("\n  > Presiona cualquier tecla para salir...");
      Console.ReadKey();
    }
  }
}
