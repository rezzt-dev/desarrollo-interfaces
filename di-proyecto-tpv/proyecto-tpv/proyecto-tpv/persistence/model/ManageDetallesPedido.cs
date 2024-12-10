using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridPersonas.persistence;
using proyecto_tpv.domain;

namespace proyecto_tpv.persistence.model
{
  public class ManageDetallesPedido
  {
    private List<DetallesPedido> listaDetalles;
    private int lastId;

    public ManageDetallesPedido()
    {
      listaDetalles = new List<DetallesPedido>();
    }

    // Leer todos los detalles de pedidos
    public List<DetallesPedido> leerDetallesPedido()
    {
      List<DetallesPedido> detalles = new List<DetallesPedido>();
      List<Object> list = DBBroker.obtenerAgente().leer("SELECT * FROM tpv_bar.detallespedidos");

      foreach (List<Object> aux in list)
      {
        // Crear un nuevo objeto DetallesPedido a partir de los datos obtenidos
        var detalle = new DetallesPedido(
            Convert.ToInt32(aux[0]),
            Convert.ToInt32(aux[1]),
            Convert.ToInt32(aux[2]),
            Convert.ToInt32(aux[3]),
            Convert.ToDecimal(aux[4])
        );

        detalles.Add(detalle);
      }

      return detalles;
    }

    // Obtener el último ID de detalle
    public int getLastId(DetallesPedido dePedido)
    {
      // Se obtiene el último id_detalle de la base de datos para generar el próximo
      List<Object> listaAux = DBBroker.obtenerAgente().leer("SELECT COALESCE (MAX(id_detalle), 0) FROM tpv_bar.detallespedidos;");
      foreach (List<Object> aux in listaAux)
      {
        lastId = Convert.ToInt32(aux[0]) + 1;
      }

      return lastId;
    }

    // Insertar un nuevo detalle de pedido
    public void insertarDetalle(DetallesPedido dePedido)
    {
      string subtotalFormateado = dePedido.Subtotal.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
      // Verificar si los valores del detalle son válidos
      if (dePedido.IdPedido <= 0 || dePedido.IdProducto <= 0 || dePedido.Cantidad <= 0 || dePedido.Subtotal <= 0)
      {
        throw new ArgumentException("Uno de los valores en dePedido no es válido.");
      }

      // Insertar el detalle en la base de datos
      string query = $"INSERT INTO tpv_bar.detallespedidos (id_pedido, id_producto, cantidad, subtotal) " +
                     $"VALUES ({dePedido.IdPedido}, {dePedido.IdProducto}, {dePedido.Cantidad}, {subtotalFormateado});";

      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar(query);
    }

    // Modificar un detalle de pedido existente
    public void modificarDetalle(DetallesPedido dePedido)
    {
      // Modificar el detalle de pedido en la base de datos
      string query = $"UPDATE tpv_bar.detallespedidos SET " +
                     $"id_pedido = {dePedido.IdPedido}, " +
                     $"id_producto = {dePedido.IdProducto}, " +
                     $"cantidad = {dePedido.Cantidad}, " +
                     $"subtotal = {dePedido.Subtotal} " +
                     $"WHERE id_detalle = {dePedido.Id};";

      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar(query);
    }

    // Eliminar un detalle de pedido
    public void eliminarDetalle(DetallesPedido dePedido)
    {
      // Eliminar el detalle de pedido de la base de datos
      string query = $"DELETE FROM tpv_bar.detallespedidos WHERE id_detalle = {dePedido.Id};";

      DBBroker dbBroker = DBBroker.obtenerAgente();
      dbBroker.modificar(query);
    }

  }
}
