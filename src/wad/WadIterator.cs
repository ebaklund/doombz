namespace doombz
{
  public struct WadIterator
  {
    private byte[] _bytes;
    private int _offset;

    public WadIterator(byte[] bytes)
    { 
      _bytes = bytes;
      _offset = 0;
    }

    public WadIterator(WadIterator that, int step)
    { 
      _bytes = that._bytes;
      _offset = that._offset + step;
    }

    public byte[] Bytes
    {
      get => _bytes;
    }

    public int Offset
    {
      get => _offset;
    }

    public int MaxOffset
    {
      get => Bytes.Length - 1;
    }

    public byte this[int i]
    {
      get => _bytes[_offset + i];
    }

    public static WadIterator operator + (WadIterator that, int step)
    {
      return new WadIterator(that, step);
    }

    public override string ToString ()
    {
      return "WadIterator { " + "Offset: " + Offset.ToString() + ", MaxOffset: " + MaxOffset.ToString() + " }";
    }
  }
}