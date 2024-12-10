using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Bcpg;
using proyecto_tpv.persistence.model;

namespace proyecto_tpv.domain
{
  public class Pedido
  {
    private int _id;
    private DateTime _fechaHora;
    private int _idMesa;
    private int _idUsuario;
    private string _estado;

    private List<Pedido> _listaPedidos;
    private List<DetallesPedido> _listaDetallesPedido;
    private ManagePedidos mp;

    public Pedido () => mp = new ManagePedidos ();

    public Pedido (int idMesa)
    {
      mp = new ManagePedidos ();
      _id = mp.getLastId(this);
      _fechaHora = DateTime.Now;
      _idMesa = idMesa;
      _idUsuario = 1;
      _estado = "pendiente";
    }

    public Pedido (int id, DateTime fechaHora, int idMesa, int idUsuario, string estado)
    {
      mp = new ManagePedidos ();
      _id = id;
      _fechaHora = fechaHora;
      _idMesa = idMesa;
      _idUsuario = idUsuario;
      _estado = estado;
    }

    public List<Pedido> getPedidoList ()
    {
      _listaPedidos = mp.leerPedidos();
      return _listaPedidos;
    }

    public List<DetallesPedido> getDetallesPedido ()
    {
      _listaDetallesPedido = mp.leerDetallesPedido(this);
      return _listaDetallesPedido;
    }

    public void insertar ()
    {
      mp.insertarPedido (this);
    }
    public void modificar()
    {
      mp.modificarPedido(this);
    }
    public void eliminar()
    {
      mp.eliminarPedido(this);
    }

    public int Id { get => _id; set => _id = value; }
    public DateTime FechaHora { get => _fechaHora; set => _fechaHora = value; }
    public int IdMesa { get => _idMesa; set => _idMesa = value; }
    public int IdUsuaio { get => _idUsuario; set => _idUsuario = value; }
    public string Estado { get => _estado; set => _estado = value; }
  }
}
