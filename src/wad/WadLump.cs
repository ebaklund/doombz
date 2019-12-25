namespace doombz
{
  public class WadLump
  {
    private PinnedWadData _wadData;
    private int _pos;

    public static int Sizeof
    { get {
      return 16;
    }}

    public WadLump(PinnedWadData wadData, int pos)
    { 
      _wadData = wadData;
      _pos = pos;
    }

    public int DataPos
    { get {
      return _wadData.ReadInt32(_pos + 0);
    }}

    public int Size
    { get {
      return _wadData.ReadInt32(_pos + 4);
    }}

    public string Name
    { get {
      return _wadData.GetString(_pos + 8, 8);
    }}
  }
}