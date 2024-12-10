using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_tpv.persistence.model;

namespace proyecto_tpv.domain
{
  public class DetallesPedido
  {
    private int _id;
        private int _idPedido;
        private int _idProducto;
        private int _cantidad;
        private decimal _subtotal;
        private string _nombreProducto;

        private List<DetallesPedido> _listaDetallesPedido;
        private ManageDetallesPedido mdp;

        // Constructor por defecto
        public DetallesPedido() 
        {
            mdp = new ManageDetallesPedido();
        }

        // Constructor con idDetalle, idPedido, idProducto y cantidad
        public DetallesPedido(int idPedido, int idProducto, int cantidad)
        {
            mdp = new ManageDetallesPedido();
            _id = mdp.getLastId(this);
            _idPedido = idPedido;
            _idProducto = idProducto;
            _cantidad = cantidad;
            _subtotal = 0;
            _nombreProducto = string.Empty;
        }

        // Constructor con todos los atributos básicos
        public DetallesPedido(int idDetalle, int idPedido, int idProducto, int cantidad)
        {
            mdp = new ManageDetallesPedido();
            _id = idDetalle;
            _idPedido = idPedido;
            _idProducto = idProducto;
            _cantidad = cantidad;
            _subtotal = 0;
            _nombreProducto = string.Empty;
        }

        // Constructor con subtotal
        public DetallesPedido(int idPedido, int idProducto, int cantidad, decimal subtotal)
        {
            mdp = new ManageDetallesPedido();
            _id = mdp.getLastId(this);
            _idPedido = idPedido;
            _idProducto = idProducto;
            _cantidad = cantidad;
            _subtotal = subtotal;
            _nombreProducto = string.Empty;
        }

        // Constructor con todos los parámetros incluidos
        public DetallesPedido(int idDetalle, int idPedido, int idProducto, int cantidad, decimal subtotal)
        {
            mdp = new ManageDetallesPedido();
            _id = idDetalle;
            _idPedido = idPedido;
            _idProducto = idProducto;
            _cantidad = cantidad;
            _subtotal = subtotal;
            _nombreProducto = string.Empty;
        }

        // Constructor con nombre del producto
        public DetallesPedido(int idDetalle, int idPedido, int idProducto, string nombreProducto, int cantidad, decimal subtotal)
        {
            mdp = new ManageDetallesPedido();
            _id = idDetalle;
            _idPedido = idPedido;
            _idProducto = idProducto;
            _nombreProducto = nombreProducto;
            _cantidad = cantidad;
            _subtotal = subtotal;
        }

        // Método para obtener la lista de detalles de pedidos
        public List<DetallesPedido> getDetallesPedido()
        {
            _listaDetallesPedido = mdp.leerDetallesPedido();
            return _listaDetallesPedido;
        }

        // Método para insertar un detalle de pedido
        public void insertar()
        {
            mdp.insertarDetalle(this);
        }

        // Método para modificar un detalle de pedido
        public void modificar()
        {
            mdp.modificarDetalle(this);
        }

        // Método para eliminar un detalle de pedido
        public void eliminar()
        {
            mdp.eliminarDetalle(this);
        }

        // Propiedades
        public int Id 
        { 
            get => _id; 
            set => _id = value; 
        }

        public int IdPedido 
        { 
            get => _idPedido; 
            set => _idPedido = value; 
        }

        public int IdProducto 
        { 
            get => _idProducto; 
            set => _idProducto = value; 
        }

        public int Cantidad 
        { 
            get => _cantidad; 
            set => _cantidad = value; 
        }

        public decimal Subtotal 
        { 
            get => _subtotal; 
            set => _subtotal = value; 
        }

        public string NombreProducto 
        { 
            get => _nombreProducto; 
            set => _nombreProducto = value; 
        }
  }
}
