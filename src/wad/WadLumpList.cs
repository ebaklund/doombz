using System.Collections;
using System.Collections.Generic;

namespace doombz
{
  public class WadLumpList : IReadOnlyList<WadLump>
  {
    private WadIterator _itr;
    private int _count;

    public WadLumpList(WadIterator itr, int lumpCount)
    { 
      _itr = itr;
      _count = lumpCount;
    }

    public int Count
    {
      get => _count;
    }

    public WadLump this[int i]
    {
      get => new WadLump(_itr + i * WadLump.Sizeof);
    }

    public IEnumerator<WadLump> GetEnumerator ()
    {
      return new WadLumpEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator ()
    {
      return GetEnumerator();
    }
  };
}