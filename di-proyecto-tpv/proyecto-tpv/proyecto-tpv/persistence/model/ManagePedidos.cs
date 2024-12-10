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
  public class ManagePedidos
  {
    private DataTable dataTable;
    private List<Pedido> listaPedidos;
    private List<DetallesPedido> listaDetallesPedido;
    int lastId;

    public ManagePedidos ()
    {
      dataTable = new DataTable ();
      listaPedidos = new List<Pedido> ();
    }

    public List<Pedido> leerPedidos ()
    {
      Pedido auxPedido = new Pedido ();
      List<Object> lista = DBBroker.obtenerAgente().leer("SELECT * FROM tpv_bar.pedidos");
      foreach (List<Object> aux in lista)
      {
        auxPedido = new Pedido(Convert.ToInt32(aux[0]), Convert.ToDateTime(aux[1]), Convert.ToInt32(aux[2]), Convert.ToInt32(aux[3]), aux[4].ToString());
        listaPedidos.Add (auxPedido);
      }

      return listaPedidos;
    }

    public List<DetallesPedido> leerDetallesPedido (Pedido pedido)
    {
      DetallesPedido dePedido = new DetallesPedido ();
      List<Object> lista = DBBroker.obtenerAgente().leer("SELECT dp.id_detalle, dp.id_pedido, dp.id_producto, p.nombre AS nombre_producto, dp.cantidad, dp.subtotal " +
        "FROM tpv_bar.detallespedidos dp JOIN productos p ON dp.id_producto = p.id_producto WHERE dp.id_pedido = " + pedido.Id);

      foreach (List<Object> aux in lista)
      {
        dePedido = new DetallesPedido(Convert.ToInt32(aux[0]), Convert.ToInt32(aux[1]), Convert.ToInt32(aux[2]), aux[3].ToString(), Convert.ToInt32(aux[4]), Convert.ToDecimal(aux[5]));
        listaDetallesPedido.Add(dePedido);
      }

      return listaDetallesPedido;
    }

    public int getLastId (Pedido pedido)
    {
      List<Object> listaAux;
      listaAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(id_pedido), 0) FROM tpv_bar.pedidos;");

      foreach (List<Object> aux in listaAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    public void insertarPedido (Pedido pedido)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("INSERT INTO tpv_bar.pedidos (id_pedido, fecha_hora, id_mesa, id_usuario, estado) VALUES (" + 
        pedido.Id + ", '" +
        pedido.FechaHora.ToString("yyyy-MM-dd HH:mm:ss") + "', " + 
        pedido.IdMesa + ", " + 
        pedido.IdUsuaio + ", '" + 
        pedido.Estado + "');");
    }

    public void modificarPedido(Pedido pedido)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("UPDATE tpv_bar.pedidos SET fecha_hora = '" + 
        pedido.FechaHora + "', id_mesa = " + 
        pedido.IdMesa + ", id_usuario = " + 
        pedido.IdUsuaio + ", estado = '" + 
        pedido.Estado + "' WHERE id_pedido = " + pedido.Id + ";");
    }

    public void eliminarPedido(Pedido pedido)
    {
      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar("DELETE FROM tpv_bar.pedidos WHERE id_pedido = " + pedido.Id + ";");
    }
  }
}
