using proyectoAPI.controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoAPI.modelo
{
  internal class ApiObject
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Dictionary<string, string> Data { get; set; }
  }
}
