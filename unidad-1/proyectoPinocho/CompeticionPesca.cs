using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPinocho
{
  internal class CompeticionPesca
  {
   // constantes & atributos =>
    private Tablero rioBase { get; set; }
    private List<Caracter> Pescadores { get; set; }
    
   //————————————————————————————————————————————————————————————————————————————————————————
   // constructores =>
    public CompeticionPesca (Tablero inputRioBase, params Caracter[] inputPescadores) {
      rioBase = inputRioBase;
      Pescadores = new List<Caracter>(inputPescadores);
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos privados =>
    private void imprimirResultadosActuales () {
      Console.WriteLine("\nResultados actuales:");

      foreach (var caracter in Pescadores) {
        Console.WriteLine($"{caracter.nombre}: Peces: {caracter.pez}, Vidas: {caracter.vidas}, Movimientos: {caracter.camino.Count}");
      }
    }

    private void imprimirResultadosFinales () {
      Console.WriteLine("\nResultados finales:");

      foreach (var caracter in Pescadores) {
        Console.WriteLine($"\nResultados de {caracter.nombre}:");
        Console.WriteLine($"Peces capturados: {caracter.pez}");
        Console.WriteLine($"Vidas restantes: {caracter.vidas}");
        Console.WriteLine($"Movimientos totales: {caracter.camino.Count}");
        Console.WriteLine("Camino recorrido:");

        foreach (var posicion in caracter.camino) {
          Console.Write($"({posicion.Item1},{posicion.Item2}) ");
        }

        Console.WriteLine();
      }

      Caracter pescadorGanador = Pescadores.OrderByDescending(c => c.pez).ThenByDescending(c => c.vidas).First();
      Console.WriteLine($"\n{pescadorGanador.nombre} gana la competición!");
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos publicos =>
    public void IniciarCompeticion() {
      while (Pescadores.Exists(c => c.estaVivo())) {
        foreach (var caracter in Pescadores) {
          if (caracter.estaVivo()) {
            caracter.Mover(rioBase);
            rioBase.ImprimirTablero(Pescadores);
            imprimirResultadosActuales();
            Thread.Sleep(500); // mejora la visualizacion
          }
        }
      }

      imprimirResultadosFinales();
    }
  }
}
