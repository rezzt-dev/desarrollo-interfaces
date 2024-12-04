using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestproJuanGarcia.domain
{
  internal class Proyecto
  {
    private int _id;
    private String _codigo;
    private String _nombre;
    private String _descripcion;
    private double _presupuesto;

    private List<Proyecto> _proyectoList;
    public ProyectoManager pm;

    public Proyecto() => pm = new ProyectoManager();

    public Proyecto(string codigo, string nombre, string descripcion, double presupuesto)
    {
      pm = new ProyectoManager();
      _id = pm.getLastId(this);

      _codigo = codigo;
      _nombre = nombre;
      _descripcion = descripcion;
      _presupuesto = presupuesto;
    }

    public Proyecto(int id, string codigo, string nombre, string descripcion, double presupuesto)
    {
      pm = new ProyectoManager();

      _id = id;
      _codigo = codigo;
      _nombre = nombre;
      _descripcion = descripcion;
      _presupuesto = presupuesto;
    }

    public List<Proyecto> getProyectList()
    {
      _proyectoList = pm.leerProyectos();
      return _proyectoList;
    }

    public void insertar()
    {
      pm.insertarProyecto(this);
    }

    public void modificar()
    {
      pm.modificarProyecto(this);
    }

    public void eliminar()
    {
      pm.eliminarProyecto(this);
    }

    public void genProyecto ()
    {
      this._id = pm.getLastId(this);

      String[] codeNameProy = genCodeProyect();
      this._codigo = codeNameProy[0];
      this._nombre = codeNameProy[1];
      this._descripcion = "EJEMPLO DESCRIPCION PROYECTO " + _codigo;
      this._presupuesto = Convert.ToDouble(new Random().Next(0, 12000));
    }

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


    public int Id { get => _id; set => _id = value; }
    public string Codigo { get => _codigo; set => _codigo = value;}
    public string Nombre { get => _nombre; set => _nombre = value;}
    public string Descripcion { get => _descripcion; set => _descripcion = value;}
    public double Presupuesto { get => _presupuesto; set => _presupuesto = value;}
  }
}
