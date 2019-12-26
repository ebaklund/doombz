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

    public int width
    {
      get => WadMarshal.GetInt16(_itr + 0);
    }

    public int height
    {
      get => WadMarshal.GetInt16(_itr + 2);
    }

    public int x
    {
      get => WadMarshal.GetInt16(_itr + 4);
    }

    public int y
    {
      get => WadMarshal.GetInt16(_itr + 6);
    }

    public ReadOnlySpan<Int32> ColumnOfs
    {
      get => WadMarshal.GetInt32Span(_itr + 8, 8 * sizeof(Int32));
    }

    public WadColumn GetColumn(int i)
    {
      Debug.Assert(i < ColumnOfs.Length);
      return new WadColumn(_itr + ColumnOfs[i]);
    }
  }
}