using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace doombz
{
  public class Renderer
  {
    private IJSRuntime _jsRuntime;

    public Renderer (IJSRuntime jsRuntime)
    {
      _jsRuntime = jsRuntime;
    }

    public async Task<int> DrawPost(WadPost wadPost, int x, int y)
    {
      System.Console.WriteLine("Renderer.DrawPost()");
      System.Console.WriteLine("  " + wadPost.ToString());

      int[] intArr = WadMarshal.AsInt32Array(wadPost.Colors);
      await _jsRuntime.InvokeAsync<object>("_CanvasInterop.drawPost", new object[] { intArr, x, y });

      return wadPost.Length;
    }

    public async Task<int> DrawColumn(WadColumn wadColumn, int x, int y)
    {
      System.Console.WriteLine("Renderer.DrawColumn()");

      int pxCount = 0;

      for (WadPost wadPost = wadColumn.Posts; !wadPost.IsEnd; wadPost = wadPost.Next)
       pxCount += await DrawPost(wadPost, x, y + pxCount);

      return pxCount;
    }

    public async Task DrawPatch(WadPatch wadPatch)
    {
      System.Console.WriteLine("Renderer.DrawPatch()");
      System.Console.WriteLine("  " + wadPatch.ToString());

      int pxCount = 0;
      int x0 = wadPatch.X;
      int y0 = wadPatch.Y;

      var n = wadPatch.Width;

      for (int i = 0; i < n; ++i)
      {
        System.Console.WriteLine("  column: " + i.ToString());
        pxCount += await DrawColumn(wadPatch.GetColumn(i), x0 + i, y0);
      }

      System.Console.WriteLine("  pxCount: " + pxCount.ToString());
    }

    public async Task DrawLumpAsPatch(WadLump wadLump)
    {
      System.Console.WriteLine("Renderer.DrawLumpAsPatch()");
      System.Console.WriteLine("  " + wadLump.ToString());

      var wadPatch = new WadPatch(wadLump.DataItr);

      await DrawPatch(wadPatch);
    }
  }
}