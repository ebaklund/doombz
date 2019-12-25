
using System;
using System.Text;
using System.Runtime.InteropServices;

public class PinnedWadData
  {
    private byte[] _bytes;
    private GCHandle _gch;
    private IntPtr _ptr;

    public PinnedWadData (byte[] wadBytes)
    {
      _bytes = wadBytes;
      _gch = GCHandle.Alloc(wadBytes, GCHandleType.Pinned);
      _ptr = _gch.AddrOfPinnedObject();
    }

    ~PinnedWadData ()
    {
      _gch.Free();
    }

    public int ReadInt16(int i)
    {
      return Marshal.ReadInt16(_ptr + i);
    }

    public int ReadInt32(int i)
    {
      return Marshal.ReadInt32(_ptr + i);
    }

    public string GetString(int i, int l)
    {
      return Encoding.ASCII.GetString(_bytes, i, l);
    }

    public int[] CopyInt32Array(int i, int l)
    {
      int[] arr = new int[l];
      Marshal.Copy(_ptr + i, arr, 0, l);
      return arr;
    }
  }
