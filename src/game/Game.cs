using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace doombz
{
  public class Game
  {
    Wad _wad;
    Renderer _renderer;

    public Game(byte[] wadBytes, IJSRuntime jsRuntime)
    {
      System.Console.WriteLine("Game.Game()");
      _wad = new Wad(wadBytes);
      _renderer = new Renderer(jsRuntime);
    }

    public async Task Initialize()
    {
      System.Console.WriteLine("Game.Initialize()");
      await _renderer.DrawLumpAsPatch(_wad.LumpMap["TITLEPIC"]);
    }

    public async Task Loop(TimeSpan interval)
    {
      DateTime now = System.DateTime.Now;
      TimeSpan dt = new TimeSpan(0);

      while (true)
      {
        DateTime t1 = now;
        DateTime t2 = now + interval;

        Iterate(t1, dt);

        now = System.DateTime.Now;

        if (now < t2)
        {
          await Task.Delay((int) (t2 - now).TotalMilliseconds);
          now = System.DateTime.Now;
        }

        dt = now - t1;
      }
    }

    private void Iterate(DateTime t, TimeSpan dt)
    {
      System.Console.WriteLine("Game.Iterate()");
    }
  }
}