using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPinocho
{
  class Pinocho : Caracter
  {
   //————————————————————————————————————————————————————————————————————————————————————————
   // constructores =>
    public Pinocho (string inputNombre) : base(inputNombre) {}

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos abstractos =>
    public override void Mover (Tablero inputTablero) {
      Random random = new Random();
      int x = random.Next(0, inputTablero.Columnas);
      int y = random.Next(0, inputTablero.Columnas);

      posicionActual = new Tuple<int, int>(x, y);
      camino.Add(posicionActual);

      switch (inputTablero.tableroGeneral[x, y]) {
        case 0:
          vidas--;
          break;
        case 2:
          if (pez > 0) pez--;
          break;
        case 3:
          pez++;
          break;
      }
    }
  }
}
