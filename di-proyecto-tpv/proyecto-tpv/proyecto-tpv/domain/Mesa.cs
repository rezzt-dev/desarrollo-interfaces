using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_tpv.persistence.model;

namespace proyecto_tpv.domain
{
  public class Mesa
  {
    private int _id;
    private int _numMesa;

    private List<Mesa> _listaMesas;
    public ManageMesas mm;

    public Mesa () => mm = new ManageMesas ();
    public Mesa (int numMesa)
    {
      mm = new ManageMesas ();
      _id = mm.getLastId(this);
      _numMesa = numMesa;
    }
    public Mesa (int id, int numMesa)
    {
      mm = new ManageMesas ();
      _id = id;
      _numMesa = numMesa;
    }

    public List<Mesa> getListaMesas ()
    {
      _listaMesas = mm.leerMesas();
      return _listaMesas;
    }

    public int Id { get => _id; set => _id = value; }
    public int NumMesa { get => _numMesa; set => _numMesa = value; }
  }
}
