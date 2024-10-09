namespace proyectoPinocho {
  public class Jugador {
   // constantes & atributos =>
     // constantes =>
      // constantes jugador -->
    const int MIN_VIDAS = 3;
    const int MIN_PECES = 5;
    const int INIT_PECES = 0;
    const int MAX_SALTOS = 18;

    //————————————————————————————————————————————————————————————————————————————
     // atributos =>
      // atributos jugador -->
    private string inicialNombre;
    private int numVidas;
    private int numPeces;
    private int minPeces;
    private int numSaltos;
    private int maxSaltos;

     //————————————————————————————————————————————————————————————————
      // atributos salida -->
    private int filaActual;
    private int columnaActual;
    private List<int> listaFilasAnteriores;
    private List<int> listaColumnasAnteriores;

   //————————————————————————————————————————————————————————————————————————————————————————
   // constructores =>
    public Jugador (string inputNombre, int inputVidas, int inputMinPeces, int inputMaxSaltos) {
      this.inicialNombre = inputNombre;
      this.numVidas = inputVidas;
      this.minPeces = inputMinPeces;
      this.maxSaltos = inputMaxSaltos;

      this.numPeces = INIT_PECES;
      this.numSaltos = 0;
      
      this.filaActual = 0;
      this.columnaActual = 0;
      this.listaFilasAnteriores = new List<int>();
      this.listaColumnasAnteriores = new List<int>();
    }

    public Jugador (string inputNombre, int inputVidas, int inputMaxSaltos) {
      this.inicialNombre = inputNombre;
      this.numVidas = inputVidas;
      this.maxSaltos = inputMaxSaltos;

      this.minPeces = MIN_PECES;
      this.numPeces = INIT_PECES;
      this.numSaltos = 0;
      
      this.filaActual = 0;
      this.columnaActual = 0;
      this.listaFilasAnteriores = new List<int>();
      this.listaColumnasAnteriores = new List<int>();
    }

    public Jugador (string inputNombre) {
      this.inicialNombre = inputNombre;

      this.numVidas = MIN_VIDAS;
      this.minPeces = MIN_PECES;
      this.numPeces = INIT_PECES;
      this.numSaltos = 0;
      
      this.filaActual = 0;
      this.columnaActual = 0;
      this.listaFilasAnteriores = new List<int>();
      this.listaColumnasAnteriores = new List<int>();
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos privados =>

   //————————————————————————————————————————————————————————————————————————————————————————
   // metodos publicos =>
     // metodos atributos jugador =>
      // metodo "lessHeart" | resta 1 vida -->
    public void lessHeart() {
      this.numVidas--;
    }

      // metodo "countJump" | suma 1 salto -->
    public void countJump() {
      this.numSaltos++;
    }

      // metodo "lessFish" | resta 1 pez -->
    public void lessFish() {
      this.numPeces--;
    }

      // metodo "countFish" | suma 1 pez -->
    public void countFish() {
      this.numPeces++;
    }

    //————————————————————————————————————————————————————————————————————————————
     // metodos atributos tablero =>
      // metodo "saveFilaActual" | guarda la fila actual -->
    public void saveFilaActual(int inputFila) {
      this.filaActual = inputFila;
      this.listaFilasAnteriores.Add(inputFila);
    }

      // metodo "saveColumnaActual" | guarda la columna actual -->
    public void saveColumnaActual(int inputColumna) {
      this.columnaActual = inputColumna;
      this.listaColumnasAnteriores.Add(inputColumna);
    }

    //————————————————————————————————————————————————————————————————————————————
     // metodos comprobacion =>
      // metodo "noQuedanSaltos" | comprueba si quedan saltos -->
    public bool noQuedanSaltos() {
      bool esNoQuedanSaltos = false;

      if (this.numSaltos >= this.maxSaltos) {
        esNoQuedanSaltos = true;
      }

      return esNoQuedanSaltos;
    }

      // metodo "noQuedanVidas" | comprueba si quedan vidas -->
    public bool noQuedanVidas() {
      bool esNoQuedanVidas = false;

      if (this.numVidas <= 0) {
        esNoQuedanVidas = true;
      }

      return esNoQuedanVidas;
    }

      // metodo "tieneMinimoPeces" | comprueba si tiene minimo peces -->
    public bool tieneMinimoPeces() {
      bool esTieneMinimoPeces = false;

      if (this.numPeces >= this.minPeces) {
        esTieneMinimoPeces = true;
      }

      return esTieneMinimoPeces;
    }

      // metodo "estaEnPosicionSalida" | comprueba si esta en posicion de salida -->
    public bool estaEnPosicionSalida(Tablero inputTablero) {
      bool esEstaEnPosicionSalida = false;

      if ((inputTablero._numFilas - 1) == this.filaActual && (inputTablero._numFilas - 1) == this.columnaActual) {
        esEstaEnPosicionSalida = true;
      }

      return esEstaEnPosicionSalida;
    }

      // metodo "puedeSalir" | comprueba si puede salir -->
    public bool puedeSalir(Tablero inputTablero) {
      bool esPuedeSalir = false;

      if (this.estaEnPosicionSalida(inputTablero) && (this.noQuedanVidas() == false) && (this.tieneMinimoPeces() == true)) {
        esPuedeSalir = true;
      }

      return esPuedeSalir;
    }

    //————————————————————————————————————————————————————————————————————————————
     // metodos estadisticas =>
      // metodo "mostrarStats" | muestra las estadisticas del jugador -->
    public void mostrarStats() {
      Console.WriteLine("\n Jugador: " + this._inicalNombre + " | Vidas: " + this._numVidas + " | Peces: " + this._numPeces + " | Saltos: " + this._numSaltos);
    }

   //————————————————————————————————————————————————————————————————————————————————————————
   // getters & setters =>
    public string _inicalNombre {
      get { return inicialNombre; }
      set { inicialNombre = value; }
    }

    public int _numVidas {
      get { return numVidas; }
      set { numVidas = value; }
    }

    public int _numPeces {
      get { return numPeces; }
      set { numPeces = value; }
    }

    public int _minPeces {
      get { return minPeces; }
      set { minPeces = value; }
    }

    public int _numSaltos {
      get { return numSaltos; }
      set { numSaltos = value; }
    }

    public int _maxSaltos {
      get { return maxSaltos; }
      set { maxSaltos = value; }
    }

    public int _filaActual {
      get { return filaActual; }
      set { filaActual = value; }
    }

    public int _columnaActual {
      get { return columnaActual; }
      set { columnaActual = value; }
    }

    public List<int> _listaFilasAnteriores {
      get { return listaFilasAnteriores; }
      set { listaFilasAnteriores = value; }
    }

    public List<int> _listaColumnasAnteriores {
      get { return listaColumnasAnteriores; }
      set { listaColumnasAnteriores = value; }
    }
  }
}