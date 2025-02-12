using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  /// <summary>
  /// clase de proyecto
  /// </summary>
  public class Proyecto
  {
    /// <summary>
    /// The identifier
    /// </summary>
    private int _id;
    /// <summary>
    /// The codigo
    /// </summary>
    private String _codigo;
    /// <summary>
    /// The nombre
    /// </summary>
    private String _nombre;
    /// <summary>
    /// The descripcion
    /// </summary>
    private String _descripcion;
    /// <summary>
    /// The presupuesto
    /// </summary>
    private double _presupuesto;

    /// <summary>
    /// The proyecto list
    /// </summary>
    private List<Proyecto> _proyectoList;
    /// <summary>
    /// The pm
    /// </summary>
    public ProyectoManager pm;

    /// <summary>
    /// Initializes a new instance of the <see cref="Proyecto"/> class.
    /// </summary>
    public Proyecto() => pm = new ProyectoManager();

    /// <summary>
    /// Initializes a new instance of the <see cref="Proyecto"/> class.
    /// </summary>
    /// <param name="codigo">The codigo.</param>
    /// <param name="nombre">The nombre.</param>
    /// <param name="descripcion">The descripcion.</param>
    /// <param name="presupuesto">The presupuesto.</param>
    public Proyecto(string codigo, string nombre, string descripcion, double presupuesto)
    {
      pm = new ProyectoManager();
      _id = pm.getLastId(this);

      _codigo = codigo;
      _nombre = nombre;
      _descripcion = descripcion;
      _presupuesto = presupuesto;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Proyecto"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="codigo">The codigo.</param>
    /// <param name="nombre">The nombre.</param>
    /// <param name="descripcion">The descripcion.</param>
    /// <param name="presupuesto">The presupuesto.</param>
    public Proyecto(int id, string codigo, string nombre, string descripcion, double presupuesto)
    {
      pm = new ProyectoManager();

      _id = id;
      _codigo = codigo;
      _nombre = nombre;
      _descripcion = descripcion;
      _presupuesto = presupuesto;
    }

    /// <summary>
    /// Gets the proyect list.
    /// </summary>
    /// <returns></returns>
    public List<Proyecto> getProyectList()
    {
      _proyectoList = pm.leerProyectos();
      return _proyectoList;
    }

    /// <summary>
    /// Insertars this instance.
    /// </summary>
    public void insertar()
    {
      pm.insertarProyecto(this);
    }

    /// <summary>
    /// Modificars this instance.
    /// </summary>
    public void modificar()
    {
      pm.modificarProyecto(this);
    }

    /// <summary>
    /// Eliminars this instance.
    /// </summary>
    public void eliminar()
    {
      pm.eliminarProyecto(this);
    }

    /// <summary>
    /// Gens the proyecto.
    /// </summary>
    public void genProyecto ()
    {
      this._id = pm.getLastId(this);

      String[] codeNameProy = genCodeProyect();
      this._codigo = codeNameProy[0];
      this._nombre = codeNameProy[1];
      this._descripcion = "EJEMPLO DESCRIPCION PROYECTO " + _codigo;
      this._presupuesto = Convert.ToDouble(new Random().Next(0, 12000));
    }

    /// <summary>
    /// Gens the code proyect.
    /// </summary>
    /// <returns></returns>
    private String[] genCodeProyect ()
    {
      String[] results = new String[2];

      String codBase = "MTR";
      String numSecu = pm.getLastId(this).ToString();
      String[] nomEmpresas = { "ALLEGRO", "VELNEO", "SAP", "NATURGY", "SANTANDER", "MUTUAMADRILEÑA" };
      String anioNatural = DateTime.Now.Year.ToString().Remove(0, 2);

      int posRandom = new Random().Next(0, nomEmpresas.Length);

      results[0] = (codBase + numSecu + nomEmpresas[posRandom] + anioNatural);
      results[1] = nomEmpresas[posRandom];

      return results;
    }


    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public int Id { get => _id; set => _id = value; }
    /// <summary>
    /// Gets or sets the codigo.
    /// </summary>
    /// <value>
    /// The codigo.
    /// </value>
    public string Codigo { get => _codigo; set => _codigo = value;}
    /// <summary>
    /// Gets or sets the nombre.
    /// </summary>
    /// <value>
    /// The nombre.
    /// </value>
    public string Nombre { get => _nombre; set => _nombre = value;}
    /// <summary>
    /// Gets or sets the descripcion.
    /// </summary>
    /// <value>
    /// The descripcion.
    /// </value>
    public string Descripcion { get => _descripcion; set => _descripcion = value;}
    /// <summary>
    /// Gets or sets the presupuesto.
    /// </summary>
    /// <value>
    /// The presupuesto.
    /// </value>
    public double Presupuesto { get => _presupuesto; set => _presupuesto = value;}
  }
}
