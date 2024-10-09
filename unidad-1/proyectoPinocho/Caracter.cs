using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoPinocho
{
  abstract class Caracter
  {
   // constantes & atributos =>
    public string nombre { get; protected set; }
    public int pez { get; protected set; }
    public int vidas { get; protected set; }
    public List<Tuple<int, int>> camino { get; protected set; }
    public Tuple<int, int> posicionActual { get; protected set; }

   //————————————————————————————————————————————————————————————————————————————————————————
   // constructores =>
    public Caracter (string inputNombre) {
      this.nombre = inputNombre;
      this.pez = 0;
      this.vidas = 0;
      this.camino = new List<Tuple<int, int>>();
      this.posicionActual = new Tuple<int, int>(-1, -1);
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos abstractos =>
    public abstract void Mover (Tablero inputTablero);

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos publicos =>
    public bool estaVivo () {
      return this.vidas > 0 && this.pez < 5 && this.camino.Count < 18;
    }
  }
}
