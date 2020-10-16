using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Atomus.Compressor
{
    public class Adapter : ICompress, ICompressAsync, IDecompress, IDecompressAsync
    {
        private static ICore core;
        
        public Adapter()
        {
            try
            {
                if (core == null)
                {
                    core = this.CreateInstance("Compressor");
                }
            }
            catch (AtomusException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw new AtomusException(exception);
            }
        }

        byte[] ICompress.ToBytes(byte[] source)
        {
            return ((ICompress)core).ToBytes(source);
        }
        async Task<byte[]> ICompressAsync.ToBytesAsync(byte[] source)
        {
            return await ((ICompressAsync)core).ToBytesAsync(source);
        }
        byte[] ICompress.ToBytes(ISerializable source)
        {
            return ((ICompress)core).ToBytes(source);
        }
        async Task<byte[]> ICompressAsync.ToBytesAsync(ISerializable source)
        {
            return await ((ICompressAsync)core).ToBytesAsync(source);
        }
        string ICompress.ToString(ISerializable source)
        {
            return ((ICompress)core).ToString(source);
        }
        async Task<string> ICompressAsync.ToStringAsync(ISerializable source)
        {
            return await ((ICompressAsync)core).ToStringAsync(source);
        }
        string ICompress.ToString(string source)
        {
            return ((ICompress)core).ToString(source);
        }
        async Task<string> ICompressAsync.ToStringAsync(string source)
        {
            return await ((ICompressAsync)core).ToStringAsync(source);
        }

        byte[] IDecompress.ToBytes(byte[] source)
        {
            return ((IDecompress)core).ToBytes(source);
        }
        async Task<byte[]> IDecompressAsync.ToBytesAsync(byte[] source)
        {
            return await ((IDecompressAsync)core).ToBytesAsync(source);
        }
        ISerializable IDecompress.ToSerializable(byte[] source)
        {
            return ((IDecompress)core).ToSerializable(source);
        }
        async Task<ISerializable> IDecompressAsync.ToSerializableAsync(byte[] source)
        {
            return await ((IDecompressAsync)core).ToSerializableAsync(source);
        }
        ISerializable IDecompress.ToSerializable(string source)
        {
            return ((IDecompress)core).ToSerializable(source);
        }
        async Task<ISerializable> IDecompressAsync.ToSerializableAsync(string source)
        {
            return await ((IDecompressAsync)core).ToSerializableAsync(source);
        }
        string IDecompress.ToString(string source)
        {
            return ((IDecompress)core).ToString(source);
        }
        async Task<string> IDecompressAsync.ToStringAsync(string source)
        {
            return await ((IDecompressAsync)core).ToStringAsync(source);
        }
    }
}
