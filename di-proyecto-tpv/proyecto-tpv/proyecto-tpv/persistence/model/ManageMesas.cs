using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas.persistence;
using Mysqlx.Datatypes;
using proyecto_tpv.domain;
using System.Collections.Generic;
using Object = System.Object;

namespace proyecto_tpv.persistence.model
{
  public class ManageMesas
  {
    private DataTable dataTable;
    private List<Mesa> listaMesas;
    int lastId;

    public ManageMesas ()
    {
      dataTable = new DataTable ();
      listaMesas = new List<Mesa> ();
    }

    public List<Mesa> leerMesas ()
    {
      Mesa mesa = new Mesa ();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM tpv_bar.mesas;");

      foreach (List<Object> aux in list)
      {
        mesa = new Mesa(Convert.ToInt32(aux[0]), Convert.ToInt32(aux[1]));
        listaMesas.Add(mesa);
      }

      return listaMesas;
    }

    public int getLastId (Mesa mesa)
    {
      List<Object> listaAux;
      listaAux = DBBroker.obtenerAgente().leer("SELECT COALESCE (MAX(id_mesa), 0) FROM tpv_bar.mesas;");

      foreach (List<Object> aux in listaAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    public void insertarMesa (Mesa mesa)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO tpv_bar.mesas (id_mesa, numero) VALUES (" + 
        mesa.Id + ", " + mesa.NumMesa + ");");
    }
    public void modificarMesa(Mesa mesa)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE tpv_bar.mesas SET numero = " + mesa.NumMesa + " WHERE id_mesa = " + mesa.Id);
    }
    public void eliminarMesa(Mesa mesa)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FRROM tpv_bar.mesas WHERE id_mesa = " + mesa.Id + ";");
    }
  }
}
