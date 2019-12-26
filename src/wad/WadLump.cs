namespace doombz
{
  public class WadLump
  {
    WadIterator _itr;

    public static int Sizeof
    { get {
      return 16;
    }}

    public WadLump(WadIterator itr)
    { 
      _itr = itr;
    }

    public int DataPos
    {
      get => WadMarshal.GetInt32(_itr + 0);
    }

    public int Size
    { get => WadMarshal.GetInt32(_itr + 4);
    }

    public string Name
    {
      get => WadMarshal.GetString(_itr + 8, 8);
    }
  }
}