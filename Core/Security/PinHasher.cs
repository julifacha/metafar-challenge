using Core.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Core.Security
{
    public class PinHasher : IPinHasher
    {
        private readonly HMACSHA512 x = new HMACSHA512(Encoding.UTF8.GetBytes("metafartest"));

        public byte[] Hash(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            var allBytes = new byte[bytes.Length];
            Buffer.BlockCopy(bytes, 0, allBytes, 0, bytes.Length);

            return x.ComputeHash(allBytes);
        }
    }
}