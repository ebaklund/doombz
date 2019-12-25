using System.Collections;
using System.Collections.Generic;

namespace doombz
{
  public class WadLumpList : IReadOnlyList<WadLump>
  {
    private PinnedWadData _wadData;
    private int _pos;
    private int _count;

    public WadLumpList(PinnedWadData wadData, int pos, int count)
    { 
      _wadData = wadData;
      _count = count;
      _pos = pos;
    }

    public int Count
    { get {
      return _count;
    }}

    public WadLump this[int i]
    { get {
      return new WadLump(_wadData, _pos + i * WadLump.Sizeof);
    }}

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