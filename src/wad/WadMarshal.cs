
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace doombz
{
  public static class WadMarshal
  {
    private static string AssertStr (string mn, string expr, WadIterator itr)
    {
      return String.Format(mn + ": Assert({0}), {1}", expr, itr.ToString());
    }

    public static byte GetInt8(WadIterator itr)
    {
      var mn = "WadMarshal.GetInt8()";
      Debug.Assert(itr.Offset >= 0, AssertStr(mn, "itr.Offset >= 0", itr));
      Debug.Assert(itr.Offset < itr.Bytes.Length, AssertStr(mn, "itr.Offset < itr.Bytes.Length", itr));
      Debug.Assert((itr.Offset + 1) <= itr.Bytes.Length, AssertStr(mn, "(itr.Offset + 1) <= itr.Bytes.Length", itr));

      return itr.Bytes[itr.Offset];
    }

    public static int GetInt16(WadIterator itr)
    {
      var mn = "WadMarshal.GetInt16()";
      Debug.Assert(itr.Offset >= 0, AssertStr(mn, "itr.Offset >= 0", itr));
      Debug.Assert(itr.Offset < itr.Bytes.Length, AssertStr(mn, "itr.Offset < itr.Bytes.Length", itr));
      Debug.Assert((itr.Offset + 2) <= itr.Bytes.Length, AssertStr(mn, "(itr.Offset + 2) <= itr.Bytes.Length", itr));

      return MemoryMarshal.Read<Int16>(new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, 2));
    }

    public static int GetInt32(WadIterator itr)
    {
      var mn = "WadMarshal.GetInt32()";
      Debug.Assert(itr.Offset >= 0, AssertStr(mn, "itr.Offset >= 0", itr));
      Debug.Assert(itr.Offset < itr.Bytes.Length, AssertStr(mn, "itr.Offset < itr.Bytes.Length", itr));
      Debug.Assert((itr.Offset + 4) <= itr.Bytes.Length, AssertStr(mn, "(itr.Offset + 4) <= itr.Bytes.Length", itr));

      return MemoryMarshal.Read<Int32>(new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, 4));
    }

    public static string GetString(WadIterator itr, int byteCount)
    {
      var mn = "WadMarshal.GetString()";
      Debug.Assert(itr.Offset >= 0, AssertStr(mn, "itr.Offset >= 0", itr));
      Debug.Assert(itr.Offset < itr.Bytes.Length, AssertStr(mn, "itr.Offset < itr.Bytes.Length", itr));
      Debug.Assert((itr.Offset + byteCount) <= itr.Bytes.Length, AssertStr(mn, "(itr.Offset + byteCount) <= itr.Bytes.Length", itr));

      return Encoding.ASCII.GetString(itr.Bytes, itr.Offset, byteCount);
    }

    public static ReadOnlySpan<byte> GetByteSpan(WadIterator itr, int byteCount)
    {
      var mn = "WadMarshal.GetByteSpan()";
      Debug.Assert(itr.Offset >= 0, AssertStr(mn, "itr.Offset >= 0", itr));
      Debug.Assert(itr.Offset < itr.Bytes.Length, AssertStr(mn, "itr.Offset < itr.Bytes.Length", itr));
      Debug.Assert((itr.Offset + byteCount) <= itr.Bytes.Length, AssertStr(mn, "(itr.Offset + byteCount) <= itr.Bytes.Length", itr));

      return new ReadOnlySpan<byte>(itr.Bytes, itr.Offset, byteCount);
    }

    public static ReadOnlySpan<Int16> GetInt16Span(WadIterator itr, int byteCount)
    {
      var mn = "WadMarshal.GetInt16Span()";
      Debug.Assert(itr.Offset >= 0, AssertStr(mn, "itr.Offset >= 0", itr));
      Debug.Assert(itr.Offset < itr.Bytes.Length, AssertStr(mn, "itr.Offset < itr.Bytes.Length", itr));
      Debug.Assert((itr.Offset + byteCount) <= itr.Bytes.Length, AssertStr(mn, "(itr.Offset + byteCount) <= itr.Bytes.Length", itr));
      Debug.Assert((byteCount % sizeof(Int16)) == 0, AssertStr(mn, "(byteCount % sizeof(Int16)) == 0", itr));

      return MemoryMarshal.Cast<byte, Int16>(GetByteSpan(itr, byteCount));
    }

    public static ReadOnlySpan<Int32> GetInt32Span(WadIterator itr, int byteCount)
    {
      var mn = "WadMarshal.GetInt32Span()";
      Debug.Assert(itr.Offset >= 0, AssertStr(mn, "itr.Offset >= 0", itr));
      Debug.Assert(itr.Offset < itr.Bytes.Length, AssertStr(mn, "itr.Offset < itr.Bytes.Length", itr));
      Debug.Assert((itr.Offset + byteCount) <= itr.Bytes.Length, AssertStr(mn, "(itr.Offset + byteCount) <= itr.Bytes.Length", itr));
      Debug.Assert((byteCount % sizeof(Int32)) == 0, AssertStr(mn, "(byteCount % sizeof(Int32)) == 0", itr));

      return MemoryMarshal.Cast<byte, Int32>(GetByteSpan(itr, byteCount));
    }

    public static Int32[] AsInt32Array(ReadOnlySpan<byte> input)
    {
      var output = new Int32[input.Length];

      for (int i = 0; i < input.Length; ++i)
        output[i] = input[i];

      return output;
    }
  }
}
