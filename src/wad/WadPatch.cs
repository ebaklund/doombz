using System;
using System.Diagnostics;

namespace doombz
{
  public class WadPatch
  {
    private WadIterator _itr;

    public WadPatch(WadIterator itr)
    { 
      _itr = itr;
    }

    public int Width
    {
      get => WadMarshal.GetInt16(_itr + 0);
    }

    public int Height
    {
      get => WadMarshal.GetInt16(_itr + 2);
    }

    public int X
    {
      get => (int) WadMarshal.GetInt16(_itr + 4);
    }

    public int Y
    {
      get => WadMarshal.GetInt16(_itr + 6);
    }

    public int GetColumnOfs(int i)
    {
      return WadMarshal.GetInt32(_itr + 8 + i * sizeof(Int32));
    }

    public WadColumn GetColumn(int i)
    {
      Debug.Assert(i < Width, "WadPatch.GetColumn(): Assert(i < Width)");
      return new WadColumn(_itr + GetColumnOfs(i));
    }

    public override string ToString ()
    {
      return "WadPatch "
        + "{ X: " + X.ToString()
        + ", Y: " + Y.ToString()
        + ", Width: " + Width.ToString()
        + ", Height: " + Height.ToString()
        + " }";
    }
  }
}