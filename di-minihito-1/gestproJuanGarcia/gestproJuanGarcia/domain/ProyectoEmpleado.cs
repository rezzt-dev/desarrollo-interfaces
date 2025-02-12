using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  /// <summary>
  /// clase de proyecto empleado
  /// </summary>
  public class ProyectoEmpleado
  {
    /// <summary>
    /// The fecha
    /// </summary>
    private DateTime _fecha;
    /// <summary>
    /// The identifier proyecto
    /// </summary>
    private int _idProyecto;
    /// <summary>
    /// The identifier empleado
    /// </summary>
    private int _idEmpleado;

    /// <summary>
    /// The number horas
    /// </summary>
    private int _numHoras;
    /// <summary>
    /// The costes
    /// </summary>
    private float _costes;

    /// <summary>
    /// The proyecto empleado list
    /// </summary>
    private List<ProyectoEmpleado> _proyectoEmpleadoList;
    /// <summary>
    /// The pem
    /// </summary>
    public ProyectoEmpleadoManager pem;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProyectoEmpleado"/> class.
    /// </summary>
    public ProyectoEmpleado () => pem = new ProyectoEmpleadoManager ();
    /// <summary>
    /// Initializes a new instance of the <see cref="ProyectoEmpleado"/> class.
    /// </summary>
    /// <param name="inputNumHoras">The input number horas.</param>
    /// <param name="inputCostes">The input costes.</param>
    /// <param name="inputFecha">The input fecha.</param>
    /// <param name="inputIdProyecto">The input identifier proyecto.</param>
    /// <param name="inputIdEmpleado">The input identifier empleado.</param>
    public ProyectoEmpleado (int inputNumHoras, Decimal inputCostes, DateTime inputFecha, int inputIdProyecto, int inputIdEmpleado)
    {
      pem = new ProyectoEmpleadoManager ();
      _fecha = inputFecha;
      _idEmpleado = inputIdEmpleado;
      _numHoras = inputNumHoras;
      _costes = (float) inputCostes;
      _idProyecto = inputIdProyecto;
    }

    /// <summary>
    /// Gets or sets the fecha.
    /// </summary>
    /// <value>
    /// The fecha.
    /// </value>
    public DateTime Fecha
    {
      get => _fecha;
      set => _fecha = value;
    }

    /// <summary>
    /// Gets or sets the identifier proyecto.
    /// </summary>
    /// <value>
    /// The identifier proyecto.
    /// </value>
    public int IdProyecto
    {
      get => _idProyecto;
      set => _idProyecto = value;
    }

    /// <summary>
    /// Gets or sets the identifier empleado.
    /// </summary>
    /// <value>
    /// The identifier empleado.
    /// </value>
    public int IdEmpleado
    {
      set => _idEmpleado = value;
      get => _idEmpleado;
    }

    /// <summary>
    /// Gets or sets the number horas.
    /// </summary>
    /// <value>
    /// The number horas.
    /// </value>
    public int NumHoras { get => _numHoras; set => _numHoras = value; }
    /// <summary>
    /// Gets or sets the costes.
    /// </summary>
    /// <value>
    /// The costes.
    /// </value>
    public float Costes { get => _costes; set => _costes = value; }

    /// <summary>
    /// Gets the proyecto empleado list.
    /// </summary>
    /// <returns></returns>
    public List<ProyectoEmpleado> getProyectoEmpleadoList ()
    {
      _proyectoEmpleadoList = pem.leerListaProyectoEmpleado();
      return _proyectoEmpleadoList;
    }

    /// <summary>
    /// Insertars this instance.
    /// </summary>
    public void insertar ()
    {
      pem.insertarProyectoEmpleado(this);
    }
    /// <summary>
    /// Modificars this instance.
    /// </summary>
    public void modificar()
    {
      pem.modificarProyectoEmpleado(this);
    }
    /// <summary>
    /// Eliminars this instance.
    /// </summary>
    public void eliminar()
    {
      pem.eliminarProyectoEmpleado(this);
    }
  }
}
