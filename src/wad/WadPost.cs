using System;

/*
typedef PACKED_STRUCT (
{
    short		width;		// bounding box size
    short		height;
    short		leftoffset;	// pixels to the left of origin
    short		topoffset;	// pixels below the origin
    int			columnofs[8];	// only [width] used
}) patch_t;

typedef PACKED_STRUCT (
{
    byte		topdelta;	// -1 is the last post in a column
    byte		length; 	// length data bytes follows
}) post_t;

// column_t is a list of 0 or more post_t, (byte)-1 terminated
typedef post_t	column_t;
*/
namespace doombz
{
  public struct WadPost
  {
    private WadIterator _itr;

    public WadPost(WadIterator itr)
    { 
      _itr = itr;
    }

    public int TopDelta
    {
      get => (int) _itr[0];
    }

    public int Length
    {
      get => (int) _itr[1];
    }

    public bool IsEnd
    {
      get => TopDelta == 0xFF;
    }

    public ReadOnlySpan<byte> Colors
    {
      get => WadMarshal.GetByteSpan(_itr + 3, Length);
    }

    public WadPost Next
    {
      get => new WadPost(_itr + 3 + Length);
    }
  }
}