using gestproJuanGarcia.persistence.manages;
using System;
using System.Collections.Generic;

namespace gestproJuanGarcia.domain
{
  public class Rol
  {
    private int _idRol;
    private string _nombreRol;
    private string _descRol;

    private List<Rol> _rolList;
    public RolManager rm;

    public Rol() => rm = new RolManager();

    public Rol(string nombreRol, string descRol)
    {
      rm = new RolManager();
      _idRol = rm.getLastId(this);

      _nombreRol = nombreRol;
      _descRol = descRol;
    }

    public Rol(int idRol, string nombreRol, string descRol)
    {
      rm = new RolManager();

      _idRol = idRol;
      _nombreRol = nombreRol;
      _descRol = descRol;
    }

    // Getters y Setters
    public int IdRol
    {
      get => _idRol;
      set => _idRol = value;
    }

    public string NombreRol
    {
      get => _nombreRol;
      set => _nombreRol = value;
    }

    public string DescRol
    {
      get => _descRol;
      set => _descRol = value;
    }

    public List<Rol> getRolList()
    {
      _rolList = rm.leerRoles();
      return _rolList;
    }

    public void insertar()
    {
      rm.insertarRol(this);
    }

    public void modificar()
    {
      rm.modificarRol(this);
    }

    public void eliminar()
    {
      rm.eliminarRol(this);
    }

    public void genRol()
    {
      this._idRol = rm.getLastId(this);

      this._nombreRol = "Rol_" + new Random().Next(1000, 9999);
      this._descRol = "Descripción del rol: " + _nombreRol;
    }
  }
}
