namespace doombz
{
  public struct WadInfo
  {
    private WadIterator _itr;

    public WadInfo(WadIterator itr)
    { 
      _itr = itr;
    }

    public string Identification
    {
      get => WadMarshal.GetString(_itr + 0, 4); // Should be "IWAD" or "PWAD".
    }

    public int NumLumps
    {
      get => WadMarshal.GetInt32(_itr + 4);
    }

    public int InfotableOfs
    {
      get => WadMarshal.GetInt32(_itr + 8);
    }
  }
}