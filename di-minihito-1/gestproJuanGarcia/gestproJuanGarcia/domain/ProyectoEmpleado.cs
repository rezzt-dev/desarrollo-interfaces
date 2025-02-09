using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  public class ProyectoEmpleado
  {
    private DateTime _fecha;
    private int _idProyecto;
    private int _idEmpleado;

    private int _numHoras;
    private float _costes;

    private List<ProyectoEmpleado> _proyectoEmpleadoList;
    public ProyectoEmpleadoManager pem;

    public ProyectoEmpleado () => pem = new ProyectoEmpleadoManager ();
    public ProyectoEmpleado (int inputNumHoras, Decimal inputCostes, DateTime inputFecha, int inputIdProyecto, int inputIdEmpleado)
    {
      pem = new ProyectoEmpleadoManager ();
      _fecha = inputFecha;
      _idEmpleado = inputIdEmpleado;
      _numHoras = inputNumHoras;
      _costes = (float) inputCostes;
      _idProyecto = inputIdProyecto;
    }

    public DateTime Fecha
    {
      get => _fecha;
      set => _fecha = value;
    }

    public int IdProyecto
    {
      get => _idProyecto;
      set => _idProyecto = value;
    }

    public int IdEmpleado
    {
      set => _idEmpleado = value;
      get => _idEmpleado;
    }

    public int NumHoras { get => _numHoras; set => _numHoras = value; }
    public float Costes { get => _costes; set => _costes = value; }

    public List<ProyectoEmpleado> getProyectoEmpleadoList ()
    {
      _proyectoEmpleadoList = pem.leerListaProyectoEmpleado();
      return _proyectoEmpleadoList;
    }

    public void insertar ()
    {
      pem.insertarProyectoEmpleado(this);
    }
    public void modificar()
    {
      pem.modificarProyectoEmpleado(this);
    }
    public void eliminar()
    {
      pem.eliminarProyectoEmpleado(this);
    }
  }
}
