using System.Diagnostics.Contracts;

namespace proyectoPinocho {
  public class Tablero {
   // constantes & atributos =>
     // constantes =>
      // constantes valores -->
    const int VALUE_PIRANA = 0;
    const int VALUE_AGUA = 1;
    const int VALUE_PIEDRA = 2;
    const int VALUE_PEZ = 3;

     //————————————————————————————————————————————————————————————————
      // constantes tablero -->
    const int NUM_DEFECTO_FILAS = 12;
    const int NUM_DEFECTO_COLUMNAS = 12;
    const string CHAR_DEFECTO_SALIDA = "»";

    //————————————————————————————————————————————————————————————————————————————
     // atributos =>
      // atributos tablero -->
    private int numFilas;
    private int numColumnas;
    private String[,] tableroGeneral;
    public List<String> charsJugadores;
    public List<Jugador> listaJugadores;

     //————————————————————————————————————————————————————————————————
      // atributos salida -->
    private string charJugadoresConcat;
    private int filaSalida;
    private int columnaSalida;
    private string charSalida;

   //————————————————————————————————————————————————————————————————————————————————————————
   // constructores =>
    public Tablero(int inputFilas, int inputColumnas) {
      this.numFilas = inputFilas;
      this.numColumnas = inputColumnas;
      this.tableroGeneral = new String[inputFilas, inputColumnas];

      this.charSalida = CHAR_DEFECTO_SALIDA;
      this.filaSalida = (this.numFilas - 1);
      this.columnaSalida = (this.numColumnas - 1);

      charsJugadores = new List<String>();
      listaJugadores = new List<Jugador>();
      this.charJugadoresConcat = "";
    }

    public Tablero (int inputFilas, int inputColumnas, string inputExitChar) {
      this.numFilas = inputFilas;
      this.numColumnas = inputColumnas;
      this.tableroGeneral = new String[inputFilas, inputColumnas];

      this.charSalida = inputExitChar;
      this.filaSalida = (this.numFilas - 1);
      this.columnaSalida = (this.numColumnas - 1);

      charsJugadores = new List<String>();
      listaJugadores = new List<Jugador>();
      this.charJugadoresConcat = "";
    }

    public Tablero () {
      this.numFilas = NUM_DEFECTO_FILAS;
      this.numColumnas = NUM_DEFECTO_COLUMNAS;
      this.tableroGeneral = new String[NUM_DEFECTO_FILAS, NUM_DEFECTO_COLUMNAS];

      this.charSalida = CHAR_DEFECTO_SALIDA;
      this.filaSalida = (this.numFilas - 1);
      this.columnaSalida = (this.numColumnas - 1);

      charsJugadores = new List<String>();
      listaJugadores = new List<Jugador>();
      this.charJugadoresConcat = "";
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos privados =>
     // metodo "genRandomValue" | genera un valor aleatorio entre 0 y 3 -->
    private int getRandomValue() {
      Random random = new Random();
      int randomValue = random.Next(0, 4);
      return randomValue;
    }

     // metodo "printTablero" | imprime el tablero -->
    public void printTablero() {
      for (int i = 0; i < tableroGeneral.GetLength(0); i++) {
        for (int j = 0; j < tableroGeneral.GetLength(1); j++) {
          Console.Write(" " + this.tableroGeneral[i, j] + " ");
        }
        Console.WriteLine();
      }
    }

     // metodo "generarTablero" | genera el tablero -->
    public void generarTablero() {
      for (int i = 0; i < tableroGeneral.GetLength(0); i++) {
        for (int j = 0; j < tableroGeneral.GetLength(1); j++) {
          this.tableroGeneral[i, j] = this.getRandomValue().ToString();
        }
      }

      if (this.charJugadoresConcat != null) {
        tableroGeneral[0, 0] = this.charJugadoresConcat;
      } else {
        tableroGeneral[0, 0] = listaJugadores[0]._inicalNombre;
      }

      tableroGeneral[_filaSalida, _columnaSalida] = this._charSalida;
    }

     // metodo "fillTablero" | rellena el tablero con valores aleatorios -->
    public void fillTablero() {
      for (int i = 0; i < tableroGeneral.GetLength(0); i++) {
        for (int j = 0; j < tableroGeneral.GetLength(1); j++) {
          if (tableroGeneral[i,j] == this.charJugadoresConcat) {
            tableroGeneral[i,j] = this.charJugadoresConcat;
          } else if (charsJugadores.Contains(tableroGeneral[i, j])) {
            tableroGeneral[i, j] = listaJugadores[i]._inicalNombre;
          } else if (tableroGeneral[i, j] == this._charSalida) {
            tableroGeneral[i, j] = this._charSalida;
          } else if (estaPosicionEnLista(i, j)) {
            tableroGeneral[i, j] = "-";
          } else {
            tableroGeneral[i, j] = this.getRandomValue().ToString();
          }
        }
      }
    }

     // metodo "comprobarMovimiento" | comprueba si la posicion de salida es valida -->
    private bool comprobarMovimiento() {
      bool esValido = false;

      if (this.filaSalida >= 0 && this.filaSalida < this.numFilas && this.columnaSalida >= 0 && this.columnaSalida < this.numColumnas) {
        esValido = true;
      }
      return esValido;
    }

     // metodo "obtenerCaracterJugador" | obtiene el caracter del jugador -->
    public string obtenerCaracterJugador(Jugador inputJugador) {
      return inputJugador._inicalNombre;
    }

     // metodo "guardarCharsJugadores" | guarda los caracteres del jugador -->
    public void guardarCharsJugadores(Jugador inputJugador) {
      charsJugadores.Add(inputJugador._inicalNombre);
      this.charJugadoresConcat += obtenerCaracterJugador(inputJugador);
      this.listaJugadores.Add(inputJugador);
    }

     // metodo "estaPosicionEnLista" | comprueba si la posicion indicada esta en la lista -->
    public bool estaPosicionEnLista(int inputFila, int inputColumna) {
      bool esPosicionEnLista = false;
      
      for (int index = 0; index < listaJugadores.Count; index++) {
        for (int j = 0; j < listaJugadores[index]._listaFilasAnteriores.Count; j++) {
          if (listaJugadores[index]._listaFilasAnteriores[index] == inputFila && listaJugadores[index]._listaColumnasAnteriores[index] == inputColumna) {
            esPosicionEnLista = true;
          }
        }
      }

      return esPosicionEnLista;
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos publicos =>
      // metodo "printTableroOculto" | imprime el tablero oculto -->
    public void printTableroOculto() {
      int contJugadores = listaJugadores.Count;

      for (int i = 0; i < tableroGeneral.GetLength(0); i++) {
        for (int j = 0; j < tableroGeneral.GetLength(1); j++) {
          string charToprint = " x ";
          if (tableroGeneral[i,j] == this.charJugadoresConcat && (estanMismaPosicionJugadores() == true)) {
            charToprint = " " + this.charJugadoresConcat + " ";
          } else if (estanMismaPosicionJugadores() == false) {
            while (contJugadores > 0) {
              contJugadores--;
              if (tableroGeneral[listaJugadores[contJugadores]._filaActual, listaJugadores[contJugadores]._columnaActual] == listaJugadores[contJugadores]._inicalNombre) {
                charToprint = " " + listaJugadores[contJugadores]._inicalNombre + " ";
                break;
              }
            }
          }

          if (charsJugadores.Contains(tableroGeneral[i, j])) {
            charToprint = " " + tableroGeneral[i, j] + " ";
          } else if (tableroGeneral[i, j] == this._charSalida) {
            charToprint = " " + this._charSalida + " ";
          } else if (estaPosicionEnLista(i, j)) {
            charToprint = " - ";
          }

          Console.Write(charToprint);
        }
        Console.WriteLine();
      }
    }

      // metodo "printTableroOculto" | imprime el tablero oculto -->
    public void mostrarStatsJugadores() {
      for (int i = 0; i < listaJugadores.Count; i++) {
        listaJugadores[i].mostrarStats();
      }
    }

      // metodo "estanMismaPosicionJugadores" | comprueba si todos los jugadores estan en la misma posicion -->
    public bool estanMismaPosicionJugadores() {
      bool esSamePosition = false;

      for (int i = 0; i < listaJugadores.Count; i++) {
        for (int j = 0; j < listaJugadores.Count; j++) {
          if (i != j) {
            if (listaJugadores[i]._filaActual == listaJugadores[j]._filaActual && listaJugadores[i]._columnaActual == listaJugadores[j]._columnaActual) {
              esSamePosition = false;
            }
          }
        }
      }

      return esSamePosition;
    }

    //————————————————————————————————————————————————————————————————————————————
     // metodos movimiento =>
      // metodo "moverIzquierda" | mueve el jugador a la izquierda -->
    public void moverIzquierda(Jugador inputJugador) {
      tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = inputJugador._inicalNombre;

      if (inputJugador._columnaActual > 0) { // Cambiado para moverse correctamente a la izquierda
        // Guardar la posición anterior
        inputJugador._listaFilasAnteriores.Add(inputJugador._filaActual);
        inputJugador._listaColumnasAnteriores.Add(inputJugador._columnaActual);

        // Marcar la posición anterior con un guion
        tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = getRandomValue().ToString();

        // Mover el jugador
        inputJugador._columnaActual--;
      }
    }

      // metodo "moverDerecha" | mueve el jugador a la derecha -->
    public void moverDerecha(Jugador inputJugador) {
      tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = inputJugador._inicalNombre;

      if (inputJugador._columnaActual < tableroGeneral.GetLength(1) - 1) {
        inputJugador._listaFilasAnteriores.Add(inputJugador._filaActual);
        inputJugador._listaColumnasAnteriores.Add(inputJugador._columnaActual);

        tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = getRandomValue().ToString();

        inputJugador._columnaActual++;
      }

      tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = obtenerCaracterJugador(inputJugador);
      inputJugador._filaActual = inputJugador._filaActual;
    }

      // metodo "moverArriba" | mueve el jugador a la arriba -->
    public void moverArriba(Jugador inputJugador) {
      if (inputJugador._filaActual > 0) {
        inputJugador._listaFilasAnteriores.Add(inputJugador._filaActual);
        inputJugador._listaColumnasAnteriores.Add(inputJugador._columnaActual);

        inputJugador._filaActual--;
      }

      tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = obtenerCaracterJugador(inputJugador);
      inputJugador._columnaActual = inputJugador._columnaActual;
    }

      // metodo "moverAbajo" | mueve el jugador a la abajo -->
    public void moverAbajo(Jugador inputJugador) {
      if (inputJugador._filaActual < tableroGeneral.GetLength(0) - 1) {
        inputJugador._listaFilasAnteriores.Add(inputJugador._filaActual);
        inputJugador._listaColumnasAnteriores.Add(inputJugador._columnaActual);

        tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = "-";

        inputJugador._filaActual++;
      }

      tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual] = obtenerCaracterJugador(inputJugador);
      inputJugador._columnaActual = inputJugador._columnaActual;
    }

    //————————————————————————————————————————————————————————————————————————————
     // metodos movimiento avanzados =>
      // metodo "moverJugador" | mueve el jugador a la posicion de salida -->
    public bool moverJugador(Jugador inputJugador) {
      bool esJugadorMovido = false;

      switch (HelperClass.leerOpcionMenu(this)) {
        case 0:
          return false;
        case 1:
          this.moverIzquierda(inputJugador);
          break;
        case 2:
          this.moverDerecha(inputJugador);
          break;
        case 3:
          this.moverArriba(inputJugador);
          break;
        case 4:
          this.moverAbajo(inputJugador);
          break;
        default:
          esJugadorMovido = false;
          return esJugadorMovido;
      }

      esJugadorMovido = true;
      return esJugadorMovido;
    }

      // metodo "procesarMovimiento" | procesa el movimiento del jugador -->
    public void procesarMovimiento (Jugador inputJugador) {
      Console.Clear();

      if (inputJugador.noQuedanSaltos() == true) {
        Console.WriteLine();
        Console.WriteLine("No quedan saltos. Has perdido.");
        return;
      } else if (inputJugador.noQuedanVidas() == true) {
        Console.WriteLine();
        Console.WriteLine("No quedan vidas. Has perdido.");
        return;
      } else if (inputJugador.tieneMinimoPeces() == true && inputJugador.estaEnPosicionSalida(this) == true) {
        Console.WriteLine();
        Console.WriteLine("No quedan vidas. Has perdido.");
        return;
      }

      bool esValido = moverJugador(inputJugador);

      if (esValido == true) {
        if (int.TryParse(tableroGeneral[inputJugador._filaActual, inputJugador._columnaActual], out int valorCasilla)) {
          switch (valorCasilla) {
            case 0:
              inputJugador.lessHeart();
              inputJugador.countJump();
              break;
            case 1:
              inputJugador.countJump();
              break;
            case 2:
              inputJugador.lessFish();
              inputJugador.countJump();
              break;
            case 3:
              inputJugador.countFish();
              inputJugador.countJump();
              break;
            default:
              break;
          }
        }
      } else if (esValido == false) {
        Console.WriteLine("Saliendo...");
        Console.ReadKey();
        return;
      }

      procesarMovimiento(inputJugador);
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // getters & setters =>
    public int _numFilas {
      get { return numFilas; }
      set { numFilas = value; }
    }

    public int _numColumnas {
      get { return numColumnas; }
      set { numColumnas = value; }
    }

    public String[,] _tableroGeneral {
      get { return tableroGeneral; }
      set { tableroGeneral = value; }
    }

    public int _filaSalida {
      get { return filaSalida; }
      set { filaSalida = value; }
    }

    public int _columnaSalida {
      get { return columnaSalida; }
      set { columnaSalida = value; }
    }

    public string _charSalida {
      get { return charSalida; }
      set { charSalida = value; }
    }
  }
}