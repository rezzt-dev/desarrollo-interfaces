using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyectoPersonas.persistence.manages;

namespace proyectoPersonas.domain
{
  internal class Persona
  {
      // constantes & variables =>
    private int id;
    private String nombre;
    private String apellido;
    private int edad;
    public ManejoPersonas mp;
    private List<Persona> listaPersonas;

    //————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
    // constructores =>
    public Persona() => mp = new ManejoPersonas();

    public Persona (string inputNombre, string inputApellido, int inputEdad)
    {
      mp = new ManejoPersonas();
      this.id = mp.getLastId(this);
      this.nombre = inputNombre;
      this.apellido = inputApellido;
      this.edad = inputEdad;
    }

    public Persona(int inputId, string inputNombre, string inputApellido, int inputEdad)
    {
      mp = new ManejoPersonas();
      this.id = inputId;

      this.nombre = inputNombre;
      this.apellido = inputApellido;
      this.edad = inputEdad;
    }

    //————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
    // metodos publicos =>
    // metodo | genListaPersonas | genera y devuelve una lista de personas ==>
    public List<Persona> genListaPersonas()
    {
      listaPersonas = mp.leerPersonas();
      return listaPersonas;
    }

    // metodo | insertar | inserta una persona en la base de datos ==>
    public void insertar ()
    {
      mp.insertarPersona(this);
    }

      // metodo | modificar | modifica una persona en la base de datos ==>
    public void modificar ()
    {
      mp.modificarPersona(this);
    }

      // metodo | eliminar | elimina una persona en la base de datos ==>
    public void eliminar()
    {
      mp.deletePersona(this);
    }

    //————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
    // atributos | getters & setters =>
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public int Edad { get => edad; set => edad = value; }
  }
}
