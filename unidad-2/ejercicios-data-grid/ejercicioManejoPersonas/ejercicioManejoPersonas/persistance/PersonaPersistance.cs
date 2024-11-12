using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ejercicioManejoPersonas.domain;

namespace ejercicioManejoPersonas.persistance
{
  internal class PersonaPersistance
  {
    List<Persona> listPersonas;

    public PersonaPersistance()
    {
      listPersonas = new List<Persona> ();
    }

    public List<Persona> testLista ()
    {
      listPersonas.Add (new Persona("Juan", "Garcia", 18));
      listPersonas.Add (new Persona("Jorge", "Herrera", 19));
      listPersonas.Add (new Persona("Jose Angel", "Aguilar", 23));
      listPersonas.Add (new Persona("Aaron", "Cabrero", 20));

      return listPersonas;
    }

    public void lastId (Persona inputP)
    {
      List<Object> listPersona = new List<Object> ();
      listPersona = DBBroker.obtener
    }
  }
}
