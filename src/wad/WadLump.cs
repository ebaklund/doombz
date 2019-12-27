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
    //  System.Console.WriteLine("WadLump.WadLump(): " + ToString());
    }

    public int DataOffset
    {
      get => WadMarshal.GetInt32(_itr + 0);
    }

    public WadIterator DataItr
    {
      get => new WadIterator(_itr.Bytes) + DataOffset;
    }

    public int Size
    { get => WadMarshal.GetInt32(_itr + 4);
    }

    public string Name
    {
      get => WadMarshal.GetString(_itr + 8, 8);
    }

    public override string ToString ()
    {
      return "WadLump "
        + "{ Name: " + Name
        + ", DataOffset: \"" + DataOffset.ToString() + "\""
        + ", Size: " + Size.ToString()
        + ", DataItr: " + DataItr.ToString()
        + " }";
    }
  }
}