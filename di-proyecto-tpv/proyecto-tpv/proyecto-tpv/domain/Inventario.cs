using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using proyecto_tpv.persistence.model;

namespace proyecto_tpv.domain
{
  public class Inventario
  {
    private int _id;
    private int _stock;

    private List<Inventario> _inventarioList;
    private ManageInventario mi;

    public Inventario () => mi = new ManageInventario ();
    public Inventario (int stock)
    {
      mi = new ManageInventario ();
      _id = mi.getLastId(this);
      _stock = stock;
    }
    public Inventario (int id, int stock)
    {
      mi = new ManageInventario ();
      _id = id;
      _stock = stock;
    }

    public List<Inventario> getInventarioList ()
    {
      _inventarioList = mi.leerInventario();
      return _inventarioList;
    }

    public void insertar ()
    {
      mi.insertarInventario(this);
    }
    public void modificar ()
    {
      mi.modificarInventario(this);
    }
    public void eliminar ()
    {
      mi.eliminarInventario(this);
    }

    public int Id { get => _id; set => _id = value; }
    public int Stock { get => _stock; set => _stock = value; }
  }
}
