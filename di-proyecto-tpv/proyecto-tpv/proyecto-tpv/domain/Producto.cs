using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_tpv.persistence.model;

namespace proyecto_tpv.domain
{
  public class Producto
  {
    private int _id;
    private string _nombre;
    private decimal _precio;
    private int _idCategoria;
    private string _nombreCategoria;
    private int _cantStock;
    private int _cantidad;

    private List<Producto> _productosList;
    private ManageProductos mp;
    private ManageCategorias mc;
    private Inventario inventario;

    public Producto () => mp = new ManageProductos ();

    public Producto(string nombre, decimal precio, string nombreCategoria, int cantStock)
    {
      mp = new ManageProductos();
      mc = new ManageCategorias ();
      _id = mp.getLastId(this);
      _nombre = nombre;
      _precio = precio;
      _nombreCategoria = nombreCategoria;
      _idCategoria = new Categoria().getCategoriaList().Find(c => c.Nombre.Equals(nombreCategoria)).Id;
      _cantStock = cantStock;
      _cantidad = 0;
    }

    public Producto (string nombre, decimal precio, int idCategoria, string nombreCategoria, int cantStock)
    {
      mp = new ManageProductos ();
      _id = mp.getLastId(this);
      _nombre = nombre;
      _precio = precio;
      _nombreCategoria = nombreCategoria;
      _idCategoria = idCategoria;
      _cantStock = cantStock;
      _cantidad = 0;
    }
    public Producto (int id, string nombre, decimal precio, int idCategoria, string nombreCategoria, int cantStock)
    {
      mp = new ManageProductos();
      _id = id;
      _nombre = nombre;
      _precio = precio;
      _idCategoria = idCategoria;
      _nombreCategoria = nombreCategoria;
      _cantStock = cantStock;
      _cantidad = 0;
    }
    public Producto (int id, string nombre, decimal precio, int idCategoria)
    {
      mp = new ManageProductos();
      _id = id;
      _nombre = nombre;
      _precio = precio;
      _idCategoria = idCategoria;
      _cantidad = 0;
    }

    public List<Producto> getProductoList ()
    {
      _productosList = mp.leerProductos();
      return _productosList;
    }

    public void insertar()
    {
      mp.insertarProducto(this);
    }
    public void modificar()
    {
      mp.modificarProducto(this);
    }
    public void eliminar()
    {
      mp.eliminarProducto(this);
    }

    public int Id { get => _id; set => _id = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
    public decimal Precio { get => _precio; set => _precio = value; }
    public int idCategoria { get => _idCategoria; set => _idCategoria = value; }
    public string NombreCategoria { get => _nombreCategoria; set => _nombreCategoria = value; }
    public int Stock { get => _cantStock; set => _cantStock = value; }
    public int Cantidad { get => _cantidad; set => _cantidad = value; }
  }
}
