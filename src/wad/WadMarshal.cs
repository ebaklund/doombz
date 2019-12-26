
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace doombz
{
  public static class WadMarshal
  {
    public static int GetInt16(WadIterator itr)
    {
      Debug.Assert(itr.Offset >= 0);
      Debug.Assert(itr.Offset < itr.Bytes.Length);
      Debug.Assert((itr.Offset + 2) < itr.Bytes.Length);

      return MemoryMarshal.Read<Int16>(new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, 2));
    }

    public static int GetInt32(WadIterator itr)
    {
      Debug.Assert(itr.Offset >= 0);
      Debug.Assert(itr.Offset < itr.Bytes.Length);
      Debug.Assert((itr.Offset + 4) < itr.Bytes.Length);

      return MemoryMarshal.Read<Int32>(new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, 4));
    }

    public static string GetString(WadIterator itr, int byteCount)
    {
      Debug.Assert(itr.Offset >= 0);
      Debug.Assert(itr.Offset < itr.Bytes.Length);
      Debug.Assert((itr.Offset + byteCount) < itr.Bytes.Length);

      return Encoding.ASCII.GetString(itr.Bytes, itr.Offset, byteCount);
    }

    public static ReadOnlySpan<byte> GetByteSpan(WadIterator itr, int byteCount)
    {
      Debug.Assert(itr.Offset >= 0);
      Debug.Assert(itr.Offset < itr.Bytes.Length);
      Debug.Assert((itr.Offset + byteCount) < itr.Bytes.Length);

      return new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, byteCount);
    }

    public static ReadOnlySpan<Int16> GetInt16Span(WadIterator itr, int byteCount)
    {
      Debug.Assert(itr.Offset >= 0);
      Debug.Assert(itr.Offset < itr.Bytes.Length);
      Debug.Assert((itr.Offset + byteCount) < itr.Bytes.Length);
      Debug.Assert((byteCount % sizeof(Int16)) == 0);

      return MemoryMarshal.Cast<byte, Int16>(new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, byteCount));
    }

    public static ReadOnlySpan<Int32> GetInt32Span(WadIterator itr, int byteCount)
    {
      Debug.Assert(itr.Offset >= 0);
      Debug.Assert(itr.Offset < itr.Bytes.Length);
      Debug.Assert((itr.Offset + byteCount) < itr.Bytes.Length);
      Debug.Assert((byteCount % sizeof(Int32)) == 0);

      return MemoryMarshal.Cast<byte, Int32>(new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, byteCount));
    }
  }
}
