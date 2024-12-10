using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas.persistence;
using proyecto_tpv.domain;

namespace proyecto_tpv.persistence.model
{
  public class ManageInventario
  {
    private DataTable dataTable;
    private List<Inventario> listInventario;
    int lastId;

    public ManageInventario ()
    {
      dataTable = new DataTable ();
      listInventario = new List<Inventario> ();
    }

    public List<Inventario> leerInventario ()
    {
      Inventario inventario = new Inventario ();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM tpv_bar.inventario;");

      foreach (List<Object> aux in list)
      {
        inventario = new Inventario(Convert.ToInt32(aux[0]), Convert.ToInt32(aux[1]));
        listInventario.Add(inventario);
      }

      return listInventario;
    }

    public int getLastId(Inventario inventario)
    {
      List<Object> listAux;
      listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(id_producto), 0) FROM tpv_bar.inventario;");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    public void insertarInventario (Inventario inventario)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO tpv_bar.inventario (id_producto, stock) values (" +
        inventario.Id + ", " + 
        inventario.Stock + ");");
    }

    public void modificarInventario (Inventario inventario)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE tpv_bar.inventario SET stock = " + 
        inventario.Stock + " WHERE id_producto = " + inventario.Id + ";");
    }

    public void eliminarInventario (Inventario inventario)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM tpv_bar.inventario WHERE id_producto = " + inventario.Id + ";");
    }
  }
}
