using System;

namespace doombz
{
  public struct WadColumn
  {
    private WadPost _posts;

    public WadColumn(WadIterator itr)
    { 
      _posts = new WadPost(itr);
    }

    public WadPost Posts
    {
      get => _posts;
    }
  }
}
