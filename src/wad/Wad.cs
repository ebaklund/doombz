using System.Collections.Generic;

namespace doombz
{
  public class Wad
  {
    private WadInfo _wadInfo;
    private IDictionary<string, WadLump> _lumpMap;

    public Wad (byte[] bytes)
    {
      System.Console.WriteLine("Wad.Wad()");

      var itr = new WadIterator(bytes);
      _wadInfo = new WadInfo(itr);
      _lumpMap = new Dictionary<string, WadLump>();
      var lumpList = new WadLumpList(itr + _wadInfo.InfotableOfs, _wadInfo.NumLumps);

      foreach (var lump in lumpList)
      {
        string key = lump.Name;

        if (_lumpMap.ContainsKey(key))
          _lumpMap.Remove(key); // Last has precedence

        _lumpMap.Add(key, lump);
      }
    }

    public WadInfo WadInfo
    { get {
      return _wadInfo;
    }}

    public IDictionary<string, WadLump> LumpMap
    { get {
      return _lumpMap;
    }}
  }
}
