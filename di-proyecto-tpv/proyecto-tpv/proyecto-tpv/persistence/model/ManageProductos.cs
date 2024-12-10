using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using DataGridPersonas.persistence;
using proyecto_tpv.domain;

namespace proyecto_tpv.persistence.model
{
  public class ManageProductos
  {
    private DataTable dataTable;
    private List<Producto> listProductos;
    private List<Inventario> listInventario;
    int lastId;

    public ManageProductos ()
    {
      dataTable = new DataTable ();
      listProductos = new List<Producto> ();
    }

    public List<Producto> leerProductos ()
    {
      Producto producto = new Producto ();
      List<Inventario> listaInventario = new Inventario().getInventarioList();
      List<Categoria> listaCategoria = new Categoria().getCategoriaList();

      List<Producto> listaTempProductos = new List<Producto> ();
      List<Object> listProd = DBBroker.obtenerAgente().leer("SELECT * FROM tpv_bar.productos");

      foreach (List<Object> aux in listProd)
      {
        producto = new Producto(Convert.ToInt32(aux[0]), aux[1].ToString(), Convert.ToDecimal(aux[2]), Convert.ToInt32(aux[3]));
        listaTempProductos.Add(producto);
      }

      foreach (Producto tempProducto in listaTempProductos)
      {
        Categoria tempCategoria = listaCategoria.Find(c => c.Id == tempProducto.idCategoria);
        Inventario tempInventario = listaInventario.Find(i => i.Id == tempProducto.Id);
        producto = new Producto(tempProducto.Id, tempProducto.Nombre, tempProducto.Precio, tempProducto.idCategoria, tempCategoria.Nombre, tempInventario.Stock);
        listProductos.Add(producto);
      }

      return listProductos;
    }

    public int getLastId (Producto producto)
    {
      List<Object> listAux;
      listAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(id_producto), 0) FROM tpv_bar.productos");

      foreach (List<Object> aux in listAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    public void insertarProducto (Producto producto)
    {
      string precioFormateado = producto.Precio.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
      string query = $"INSERT INTO tpv_bar.productos (id_producto, nombre, precio, id_categoria) " +
                     $"VALUES ({producto.Id}, {producto.Nombre}, {precioFormateado}, {producto.idCategoria});";

      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar(query);

      Inventario tempIvent = new Inventario();
      tempIvent.Id = producto.Id;
      tempIvent.Stock = producto.Stock;
      tempIvent.insertar();
    }
    public void modificarProducto(Producto producto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE tpv_bar.productos SET nombre = '" +
        producto.Nombre + "', precio = " + 
        producto.Precio + ", id_categoria = " + 
        producto.idCategoria + " WHERE id_producto = " + producto.Id + ";");

      Inventario tempIvent = new Inventario();
      tempIvent.Id = producto.Id;
      tempIvent.Stock = producto.Stock;
      tempIvent.modificar();
    }
    public void eliminarProducto(Producto producto)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM tpv_bar.productos where id_producto = " + producto.Id);

      Inventario tempIvent = new Inventario();
      tempIvent.Id = producto.Id;
      tempIvent.Stock = producto.Stock;
      tempIvent.eliminar();
    }
  }
}
