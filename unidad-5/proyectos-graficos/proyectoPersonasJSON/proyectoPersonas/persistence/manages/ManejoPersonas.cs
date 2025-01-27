using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Agreement;
using proyectoPersonas.domain;

namespace proyectoPersonas.persistence.manages
{
  internal class RootObject
  {
    public List<Persona> Personas { get; set; }

  }

  internal class ManejoPersonas
  {
     // constantes & variables =>;
    private List<Persona> listaPersonas;
    int lastId;
    private int ultimaId = 1;
     // ruta al fichero json
    private string filepath;

     //————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
     // constructores =>
    public ManejoPersonas()
    {
      listaPersonas = new List<Persona>();
      filepath = "persona.json";
    }

    //————————————————————————————————————————————————————————————————————————————————————————————————————————————————————
    // metodos publicos =>
    // metodo | leerPersonas | lee todas las personas de la base de datos y las almacena en una lista que devuelve ==>
    public List<Persona> leerPersonas ()
    {
      var listaPersonas = new List<Persona>();

      try
      {
         // validamos el path
        if (string.IsNullOrWhiteSpace(filepath) || !File.Exists(filepath))
        {
          throw new ArgumentException(" !Hay un error en la ruta del archivo");
        }

        try
        {
          string jsonContent = File.ReadAllText(filepath);
          var rootList = JsonConvert.DeserializeObject<RootObject>(jsonContent);
          if (rootList == null || rootList.Personas == null)
          {
            Console.WriteLine(" !El JSON no contiene la estructura esperada.");
            listaPersonas = new List<Persona>();
          }

          listaPersonas = rootList.Personas.OrderBy(persona => persona.Id).ToList();
          
        } catch (JsonException jsonEx)
        {
          Console.WriteLine($" !Error al deserializar el JSON: {jsonEx.Message}");
          listaPersonas = new List<Persona>();
        }
        
      } catch (Exception ex)
      {
        Console.WriteLine(" !Error al leer el fichero json.");
      }

      return listaPersonas;
    }

      // metodo | insertarPersona | inserta una persona en la base de datos ==>
    public void insertarPersona(Persona inputPersona)
    {
      if (inputPersona == null)
      {
        throw new ArgumentNullException(nameof(inputPersona), "La persona a insertar no puede ser nula");
      }

      listaPersonas = leerPersonas();
      inputPersona.Id = getLastId(inputPersona);
      listaPersonas.Add(inputPersona);
      GuardarPersonas(inputPersona);
    }
    private void GuardarPersonas(Persona inputPersona)
    {
      var rootObject = new RootObject { Personas = listaPersonas };
      string jsonContent = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
      File.WriteAllText(filepath, jsonContent);
    }

      // metodo | getLastId | obtiene el ultimo id y le agrega 1 ==>
    public int getLastId (Persona inputPersona)
    {
      int lastId = leerPersonas().Count + 1;
      return lastId++;
    }

      // metodo | deletePersona | elimina una persona ==>
    public void deletePersona (Persona inputPersona)
    {
      listaPersonas = leerPersonas();
      var personaAEliminar = listaPersonas.FirstOrDefault(p => p.Id == inputPersona.Id);
      if (personaAEliminar != null)
      {
        listaPersonas.Remove(personaAEliminar);
        GuardarPersonas(inputPersona);
      }
    }

      // metodo | modificarPersona | modifica una persona ==>
    public void modificarPersona (Persona inputPersona)
    {
      if (inputPersona == null)
      {
        throw new ArgumentNullException(nameof(inputPersona));
      }

      listaPersonas = leerPersonas();
      var index = listaPersonas.FindIndex(p => p.Id == inputPersona.Id);
      if (index != -1)
      {
        listaPersonas[index] = inputPersona;
        GuardarPersonas(inputPersona);
      }
    }
  }
}
