using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testPinocho
{
  internal class Competicion
  {
    private Rio Rio { get; set; }
    private List<helperCharacter> Participants { get; set; }

    public Competicion(Rio rio, params helperCharacter[] characters)
    {
      Rio = rio;
      Participants = new List<helperCharacter>(characters);
    }

    public void Start()
    {
      while (Participants.Exists(c => c.IsAlive()))
      {
        foreach (var helperCharacter in Participants)
        {
          if (helperCharacter.IsAlive())
          {
            helperCharacter.Move(Rio);
            Rio.Display(Participants);
            PrintCurrentResults();
            Thread.Sleep(500); // Pausa para mejor visualización
          }
        }
      }

      PrintFinalResults();
    }

    private void PrintCurrentResults()
    {
      Console.WriteLine("\nResultados actuales:");
      foreach (var helperCharacter in Participants)
      {
        Console.WriteLine($"{helperCharacter.Name}: Peces: {helperCharacter.Fish}, Vidas: {helperCharacter.Lives}, Movimientos: {helperCharacter.Path.Count}");
      }
    }

    private void PrintFinalResults()
    {
      Console.WriteLine("\nResultados finales:");
      foreach (var character in Participants)
      {
        Console.WriteLine($"\nResultados de {character.Name}:");
        Console.WriteLine($"Peces capturados: {character.Fish}");
        Console.WriteLine($"Vidas restantes: {character.Lives}");
        Console.WriteLine($"Movimientos totales: {character.Path.Count}");
        Console.WriteLine("Camino recorrido:");
        foreach (var position in character.Path)
        {
          Console.Write($"({position.Item1},{position.Item2}) ");
        }
        Console.WriteLine();
      }

      helperCharacter winner = Participants.OrderByDescending(c => c.Fish).ThenByDescending(c => c.Lives).First();
      Console.WriteLine($"\n¡El ganador es {winner.Name} con {winner.Fish} peces!");
    }
  }
}
