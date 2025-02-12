using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  /// <summary>
  /// clase de empleado
  /// </summary>
  public class Empleado
  {
    /// <summary>
    /// The identifier empleado
    /// </summary>
    private int _idEmpleado;
    /// <summary>
    /// The identifier usuario
    /// </summary>
    private int _idUsuario;
    /// <summary>
    /// The identifier rol
    /// </summary>
    private int _idRol;

    /// <summary>
    /// The nombre empleado
    /// </summary>
    private string _nombreEmpleado;
    /// <summary>
    /// The apellidos empleado
    /// </summary>
    private string _apellidosEmpleado;
    /// <summary>
    /// The CSR empleado
    /// </summary>
    private int _csrEmpleado;

    /// <summary>
    /// The empleado list
    /// </summary>
    private List<Empleado> _empleadoList;
    /// <summary>
    /// The em
    /// </summary>
    public EmpleadoManager em;

    /// <summary>
    /// Initializes a new instance of the <see cref="Empleado"/> class.
    /// </summary>
    public Empleado () => em = new EmpleadoManager ();
    /// <summary>
    /// Initializes a new instance of the <see cref="Empleado"/> class.
    /// </summary>
    /// <param name="nombre">The nombre.</param>
    /// <param name="apellidos">The apellidos.</param>
    /// <param name="csr">The CSR.</param>
    public Empleado(string nombre, string apellidos, int csr)
    {
      em = new EmpleadoManager();
      _idEmpleado = em.getLastId(this);

      _nombreEmpleado = nombre;
      _apellidosEmpleado = apellidos;
      _csrEmpleado = csr;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Empleado"/> class.
    /// </summary>
    /// <param name="nombre">The nombre.</param>
    /// <param name="apellidos">The apellidos.</param>
    /// <param name="csr">The CSR.</param>
    /// <param name="_rol">The rol.</param>
    /// <param name="_usuario">The usuario.</param>
    public Empleado(string nombre, string apellidos, int csr, int _rol, int _usuario)
    {
      em = new EmpleadoManager ();
      _idEmpleado = em.getLastId(this);

      _nombreEmpleado = nombre;
      _apellidosEmpleado = apellidos;
      _csrEmpleado = csr;
      _idRol = _rol;
      _idUsuario = _usuario;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Empleado"/> class.
    /// </summary>
    /// <param name="nombre">The nombre.</param>
    /// <param name="apellidos">The apellidos.</param>
    /// <param name="csr">The CSR.</param>
    /// <param name="_rol">The rol.</param>
    public Empleado(string nombre, string apellidos, int csr, int _rol)
    {
      em = new EmpleadoManager();
      _idEmpleado = em.getLastId(this);

      _nombreEmpleado = nombre;
      _apellidosEmpleado = apellidos;
      _csrEmpleado = csr;
      _idRol = _rol;
      _idUsuario = 1;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Empleado"/> class.
    /// </summary>
    /// <param name="idEmple">The identifier emple.</param>
    /// <param name="nombre">The nombre.</param>
    /// <param name="apellidos">The apellidos.</param>
    /// <param name="csr">The CSR.</param>
    /// <param name="_usuario">The usuario.</param>
    /// <param name="_rol">The rol.</param>
    public Empleado(int idEmple, string nombre, string apellidos, int csr, int _usuario, int _rol)
    {
      em = new EmpleadoManager();
      _idEmpleado = idEmple;

      _nombreEmpleado = nombre;
      _apellidosEmpleado = apellidos;
      _csrEmpleado = csr;
      _idRol = _rol;
      _idUsuario = _usuario;
    }

    /// <summary>
    /// Gets or sets the identifier empleado.
    /// </summary>
    /// <value>
    /// The identifier empleado.
    /// </value>
    public int IdEmpleado
    {
      get => _idEmpleado;
      set => _idEmpleado = value;
    }
    /// <summary>
    /// Gets or sets the identifier rol.
    /// </summary>
    /// <value>
    /// The identifier rol.
    /// </value>
    public int IdRol
    {
      get => _idRol;
      set => _idRol = value;
    }
    /// <summary>
    /// Gets or sets the identifier usuario.
    /// </summary>
    /// <value>
    /// The identifier usuario.
    /// </value>
    public int IdUsuario
    {
      get => _idUsuario;
      set => _idUsuario = value;
    }
    /// <summary>
    /// Gets or sets the nombre empleado.
    /// </summary>
    /// <value>
    /// The nombre empleado.
    /// </value>
    public string NombreEmpleado
    {
      get => _nombreEmpleado;
      set => _nombreEmpleado = value;
    }
    /// <summary>
    /// Gets or sets the apellidos empleado.
    /// </summary>
    /// <value>
    /// The apellidos empleado.
    /// </value>
    public string ApellidosEmpleado
    {
      get => _apellidosEmpleado;
      set => _apellidosEmpleado = value;
    }
    /// <summary>
    /// Gets or sets the CSR empleado.
    /// </summary>
    /// <value>
    /// The CSR empleado.
    /// </value>
    public int CsrEmpleado
    {
      get => _csrEmpleado;
      set => _csrEmpleado = value;
    }

    /// <summary>
    /// Gets the empleado list.
    /// </summary>
    /// <returns></returns>
    public List<Empleado> getEmpleadoList()
    {
      _empleadoList = em.leerEmpleados();
      return _empleadoList;
    }

    /// <summary>
    /// Insertars this instance.
    /// </summary>
    public void insertar()
    {
      em.insertarEmpleado(this);
    }
    /// <summary>
    /// Modificars this instance.
    /// </summary>
    public void modificar()
    {
      em.modificarEmpleado(this);
    }
    /// <summary>
    /// Eliminars this instance.
    /// </summary>
    public void eliminar()
    {
      em.eliminarEmpleado(this);
    }
  }
}
