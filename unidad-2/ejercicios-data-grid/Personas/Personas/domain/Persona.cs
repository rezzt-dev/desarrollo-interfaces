using Personas.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.domain
{
  internal class Persona
  {
    private int Id;
    private String nombre;
    private String apellidos;
    private int edad;
    public PeopleManage pm;
    private List<Persona> listaPersonas;
    /* public Persona(string nombre, string apellidos,int edad)
     {
         this.nombre = nombre;
         this.apellidos = apellidos;
         this.edad = edad;
     }*/
    public Persona()
    {
      pm = new PeopleManage();
    }
    public Persona(int id)
    {
      pm = new PeopleManage();
      Id = id;
    }
    /* public Persona(string nombre, string apellidos, int edad)
     {
         this.nombre = nombre;
         this.apellidos = apellidos;
         this.edad = edad;
     }*/
    public Persona(string nombre, string apellidos, int edad)
    {
      this.nombre = nombre;
      this.apellidos = apellidos;
      this.edad = edad;
      pm = new PeopleManage();
    }
    /*public void leerP()
    {
        pm.leerPersonas();

    }*/
    public List<Persona> gListaPersonas()
    {
      listaPersonas = pm.leerPersonas();
      return listaPersonas;

    }
    public void insertar()
    {
      Id = pm.lastId(this);
      Id = Id + 1;
      pm.insertarPersona(this, Id);
    }

    public void eliminar()
    {
      pm.deletePersona(this);
    }

    public void modificar()
    {
      pm.modificarPersona(this);
    }

    public void last()
    {
      Id = pm.lastId(this);
    }

    public int id { get => Id; set => Id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellidos { get => apellidos; set => apellidos = value; }
    public int Edad { get => edad; set => edad = value; }
  }

}
