using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_tpv.persistence.model;

namespace proyecto_tpv.domain
{
  public class Categoria
  {
    private int _id;
    private string _nombre;

    private List<Categoria> _listaCategoria;
    public ManageCategorias mc;

    public Categoria () => mc = new ManageCategorias ();
    public Categoria (string nombre)
    {
      mc = new ManageCategorias ();
      _id = mc.getLastId(this);
      _nombre = nombre;
    }

    public Categoria (int id, string nombre)
    {
      mc = new ManageCategorias ();
      _id = id;
      _nombre = nombre;
    }

    public List<Categoria> getCategoriaList()
    {
      _listaCategoria = mc.leerCategorias();
      return _listaCategoria;
    }

    public void insertar ()
    {
      mc.insertarCategoria(this);
    }
    public void modificar()
    {
      mc.modificarCategoria(this);
    }
    public void eliminar()
    {
      mc.eliminarCategoria(this);
    }

    public int Id { get => _id; set => _id = value; }
    public string Nombre { get => _nombre; set => _nombre = value; }
  }
}
