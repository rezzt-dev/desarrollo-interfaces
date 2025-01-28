using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  public class Empleado
  {
    private int _idEmpleado;
    private int _idUsuario;
    private int _idRol;

    private string _nombreEmpleado;
    private string _apellidosEmpleado;
    private int _csrEmpleado;

    private List<Empleado> _empleadoList;
    public EmpleadoManager em;

    public Empleado () => em = new EmpleadoManager ();
    public Empleado(string nombre, string apellidos, int csr)
    {
      em = new EmpleadoManager();
      _idEmpleado = em.getLastId(this);

      _nombreEmpleado = nombre;
      _apellidosEmpleado = apellidos;
      _csrEmpleado = csr;
    }
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

    public int IdEmpleado
    {
      get => _idEmpleado;
      set => _idEmpleado = value;
    }
    public int IdRol
    {
      get => _idRol;
      set => _idRol = value;
    }
    public int IdUsuario
    {
      get => _idUsuario;
      set => _idUsuario = value;
    }
    public string NombreEmpleado
    {
      get => _nombreEmpleado;
      set => _nombreEmpleado = value;
    }
    public string ApellidosEmpleado
    {
      get => _apellidosEmpleado;
      set => _apellidosEmpleado = value;
    }
    public int CsrEmpleado
    {
      get => _csrEmpleado;
      set => _csrEmpleado = value;
    }

    public List<Empleado> getEmpleadoList()
    {
      _empleadoList = em.leerEmpleados();
      return _empleadoList;
    }

    public void insertar()
    {
      em.insertarEmpleado(this);
    }
    public void modificar()
    {
      em.modificarEmpleado(this);
    }
    public void eliminar()
    {
      em.eliminarEmpleado(this);
    }
  }
}
