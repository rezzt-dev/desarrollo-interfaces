using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_pinocho
{
  abstract class helperCharacter
  {
    public string Name { get; protected set; }
    public int Fish { get; protected set; }
    public int Lives { get; protected set; }
    public List<Tuple<int, int>> Path { get; protected set; }
    public Tuple<int, int> CurrentPosition { get; protected set; }

    public helperCharacter(string name)
    {
      Name = name;
      Fish = 0;
      Lives = 3;
      Path = new List<Tuple<int, int>>();
      CurrentPosition = new Tuple<int, int>(-1, -1);
    }

    public abstract void Move(Rio rio);

    public bool IsAlive()
    {
      return Lives > 0 && Fish < 5 && Path.Count < 18;
    }
  }
}
