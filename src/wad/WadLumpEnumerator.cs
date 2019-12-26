using System;
using System.Collections;
using System.Collections.Generic;

namespace doombz
{
  public class WadLumpEnumerator : IEnumerator<WadLump>
  {
    private WadLumpList _wadLumps;
    private int _i;
    private WadLump _current;

    public WadLumpEnumerator(WadLumpList wadLumps)
    { 
      _wadLumps = wadLumps;
      _i = -1;
    }

    void IDisposable.Dispose()
    {
    }

    public bool MoveNext()
    {
      if (++_i >= _wadLumps.Count)
        return false;

      _current = _wadLumps[_i];

      return true;
    }

    public void Reset()
    {
      _i = -1;
    }

    public WadLump Current
    {
      get => _current;
    }

    object IEnumerator.Current
    {
      get => Current;
    }
  };
}