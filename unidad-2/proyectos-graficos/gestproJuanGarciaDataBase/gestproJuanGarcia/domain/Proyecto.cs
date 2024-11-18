using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestproJuanGarcia.persistence.manage;
using Org.BouncyCastle.Bcpg;

namespace gestproJuanGarcia.domain
{
  internal class Proyecto
  {
    private int _id;
    private String _codigo;
    private String _nombre;
    private String _descripcion;
    private double _presupuesto;

    public ProjectManager pm;
    private List<Proyecto> _listProyecto;

    public Proyecto() => pm = new ProjectManager();

    public Proyecto(int id, string codigo, string nombre, string descripcion, double presupuesto)
    {
      _id = id;
      _codigo = codigo;
      _nombre = nombre;
      _descripcion = descripcion;
      _presupuesto = presupuesto;
      pm = new ProjectManager();
    }

    public Proyecto(string codigo, string nombre, string descripcion, double presupuesto)
    {
      pm = new ProjectManager();
      this._id = pm.getLastId(this);

      _codigo = codigo;
      _nombre = nombre;
      _descripcion = descripcion;
      _presupuesto = presupuesto;
      
    }

    public List<Proyecto> genListProyecto()
    {
      _listProyecto = pm.leerProyectos();
      return _listProyecto;
    }

    public void insertar ()
    {
      pm.insertarProyecto(this);
    }

    public void modificar ()
    {
      pm.modificarProyecto(this);
    }

    public void eliminar ()
    {
      pm.eliminarProyecto(this);
    }


    public int Id { get => _id; set => _id = value; }
    public string Codigo { get => _codigo; set => _codigo = value;}
    public string Nombre { get => _nombre; set => _nombre = value;}
    public string Descripcion { get => _descripcion; set => _descripcion = value;}
    public double Presupuesto { get => _presupuesto; set => _presupuesto = value;}
  }
}
