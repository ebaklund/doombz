using System.Collections.Generic;

namespace doombz
{
  public class Wad
  {
    private PinnedWadData _wadData;
    private WadInfo _wadInfo;
    private IDictionary<string, WadLump> _lumpMap;

    public Wad (byte[] wadData)
    {
      _wadData = new PinnedWadData(wadData);
      _wadInfo = new WadInfo(_wadData);
      _lumpMap = new Dictionary<string, WadLump>();

      foreach (var lump in new WadLumpList(_wadData, _wadInfo.InfotableOfs, _wadInfo.NumLumps))
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
