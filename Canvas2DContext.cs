using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

public class Canvas2DContext
{
  private readonly IJSRuntime jsRuntime;
  private readonly ElementReference canvasRef;

  public Canvas2DContext(IJSRuntime jsRuntime, ElementReference canvasRef)
  {
      this.jsRuntime = jsRuntime;
      this.canvasRef = canvasRef;
  }

  public async Task DrawLine(long startX, long startY, long endX, long endY)
  {
      await jsRuntime.InvokeAsync<object>("DoomCanvas.drawLine", canvasRef, startX, startY, endX, endY);
  }

  public async Task SetStrokeStyleAsync(string strokeStyle)
  {
      await jsRuntime.InvokeAsync<object>("DoomCanvas.setContextPropertyValue", canvasRef, "strokeStyle", strokeStyle);
  }
}
