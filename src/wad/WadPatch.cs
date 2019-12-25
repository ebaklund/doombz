/*
typedef PACKED_STRUCT (
{
    short		width;		// bounding box size
    short		height;
    short		leftoffset;	// pixels to the left of origin
    short		topoffset;	// pixels below the origin
    int			columnofs[8];	// only [width] used
}) patch_t;
*/
namespace doombz
{
  public class WadPatch
  {
    private PinnedWadData _wadData;
    private int _pos;

    public WadPatch(PinnedWadData wadData, int pos)
    { 
      _wadData = wadData;
      _pos = pos;
    }

    public int width
    { get {
      return _wadData.ReadInt16(_pos + 0);
    }}

    public int height
    { get {
      return _wadData.ReadInt16(_pos + 2);
    }}

    public int x
    { get {
      return _wadData.ReadInt16(_pos + 4);
    }}

    public int y
    { get {
      return _wadData.ReadInt16(_pos + 6);
    }}

    public int ColumnOfs(int i)
    {
      return _wadData.ReadInt32(_pos + 8 + i);
    }
  }
}