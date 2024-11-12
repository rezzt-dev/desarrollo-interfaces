using DataGridPersonas.persistence;
using Mysqlx.Crud;
using Personas.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Personas.persistence
{
  internal class PeopleManage
  {
    private DataTable table { get; set; }
    private List<Persona> listaPersonas { get; set; }
    int Id;
    public PeopleManage()
    {
      table = new DataTable();
      listaPersonas = new List<Persona>();


    }


    public List<Persona> leerPersonas()
    {
      Persona persona = null;
      List<Object> aux = DBBroker.obtenerAgente().leer("Select * from mydb.persona;");
      foreach (List<Object> c in aux)
      {
        persona = new Persona(c[1].ToString(), c[2].ToString(), Convert.ToInt32(c[3]));
        listaPersonas.Add(persona);
      }


      /// <summary>
      /// Simulate a DB reading
      /// </summary>
      /*ListaPersonas.Add(new DataGridPersonas.Persona("Miguel", "Diaz", 21));
          ListaPersonas.Add(new Persona("Silvia", "Aparicio", 21));
          ListaPersonas.Add(new Persona("Antonio", "Sobrino", 18));
          ListaPersonas.Add(new Persona("Javier", "Moreno", 20));
          ListaPersonas.Add(new Persona("Stacy", "Estrada", 21));
          ListaPersonas.Add(new Persona("Carlos", "Mora", 20));
          ListaPersonas.Add(new Persona("Patricia", "López de la Franca", 21));
          ListaPersonas.Add(new Persona("David", "Ruedas", 25));
          ListaPersonas.Add(new Persona("Miguel", "Pelaez", 20));
          ListaPersonas.Add(new Persona("Pedro", "Menchen", 22));
          ListaPersonas.Add(new Persona("Rosa María", "Zapata", 00));*/


      return listaPersonas;
    }

    public void insertarPersona(Persona p, int lastId)
    {
      DBBroker dBBroker = DBBroker.obtenerAgente();

      //MessageBox.Show(lastId.ToString());
      dBBroker.modificar("Insert into mydb.persona (idpersona,nombre,apellido,edad) values (" + lastId + ",'" + p.Nombre + "','" + p.Apellidos + "'," + p.Edad + ");");
    }
    public int lastId(Persona p)
    {
      List<Object> listaPersonas;
      listaPersonas = DBBroker.obtenerAgente().leer("select MAX(idpersona) FROM mydb.persona");
      foreach (List<Object> aux in listaPersonas)
      {
        Id = Convert.ToInt32(aux[0])+1;
      }
      return Id;
    }

    public int returnId (Persona p)
    {
      List<Object> listaPersonas = DBBroker.obtenerAgente().leer("SELECT idpersona FROM mydb.persona WHERE nombre = '" + p.Nombre + "' AND apellido = '" + p.Apellidos + "' AND edad = " + p.Edad + ";");
      foreach (List<Object> aux in listaPersonas)
      {
        Id = Convert.ToInt32(aux[0]);
       }
      return Id;
    }

    public void deletePersona(Persona p)
    {
      DBBroker dBBroker = DBBroker.obtenerAgente();
      dBBroker.modificar("DELETE FROM mydb.persona WHERE idpersona = " + returnId(p) + ";");
    }

    public void modificarPersona (Persona p)
    {
      DBBroker dBBroker = DBBroker.obtenerAgente();
      dBBroker.modificar("UPDATE mydb.persona SET nombre = '" + p.Nombre + "', apellido = '" + p.Apellidos + "', edad = " + p.Edad + " WHERE idpersona = " + returnId(p) + ";");
    }
  }
}
