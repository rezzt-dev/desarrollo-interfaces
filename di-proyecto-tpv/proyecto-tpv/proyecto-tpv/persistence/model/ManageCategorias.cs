using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas.persistence;
using proyecto_tpv.domain;

namespace proyecto_tpv.persistence.model
{
  public class ManageCategorias
  {
    private DataTable dataTable;
    private List<Categoria> listCategorias;
    int lastId;

    public ManageCategorias ()
    {
      dataTable = new DataTable ();
      listCategorias = new List<Categoria> ();
    }

    public List<Categoria> leerCategorias ()
    {
      Categoria categoria = new Categoria ();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM tpv_bar.categorias");

      foreach (List<Object> aux in list)
      {
        categoria = new Categoria(Convert.ToInt32(aux[0]), aux[1].ToString());
        listCategorias.Add(categoria);
      }

      return listCategorias;
    }

    public int getLastId (Categoria categoria)
    {
      List<Object> listAux;
      listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(id_categoria), 0) from tpv_bar.categorias");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }
      return lastId;
    }

    public void insertarCategoria (Categoria categoria)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO tpv_bar.categorias (id_categoria, nombre) values (" + 
        categoria.Id + ", '" + 
        categoria.Nombre + "');");
    }
    public void modificarCategoria(Categoria categoria)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE INTO tpv_bar.categorias nombre = '" + 
        categoria.Nombre + "' where id_categoria = " + categoria.Id + ";");
    }
    public void eliminarCategoria(Categoria categoria)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM tpv_bar.categorias where id_categoria = " + categoria.Id);
    }
  }
}
