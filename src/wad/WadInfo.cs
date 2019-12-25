namespace doombz
{
  public class WadInfo
  {
    private PinnedWadData _wadData;

    public WadInfo(PinnedWadData wadData)
    { 
      _wadData = wadData;
    }

    public string Identification
    { get {
      return _wadData.GetString(0, 4); // Should be "IWAD" or "PWAD".
    }}

    public int NumLumps
    { get {
      return _wadData.ReadInt32(4);
    }}

    public int InfotableOfs
    { get {
      return _wadData.ReadInt32(8);
    }}
  };
}