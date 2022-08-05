using System.Security.Cryptography;

namespace DotDumper.Helpers
{
    /// <summary>
    /// This class contains functions to hash a byte array, after which the hash is returned as a string
    /// </summary>
    class Hashes
    {
        /// <summary>
        /// Calculates the MD-5 hash of the given byte array 
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The MD-5 hash as a string</returns>
        public static string Md5(byte[] data)
        {
            MD5 md5 = MD5.Create();
            return CalculateHash(md5, data);
        }

        /// <summary>
        /// Calculates the SHA-1 hash of the given byte array 
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The SHA-1 hash as a string</returns>
        public static string Sha1(byte[] data)
        {
            SHA1 sha1 = SHA1.Create();
            return CalculateHash(sha1, data);
        }

        /// <summary>
        /// Calculates the SHA-256 hash of the given byte array 
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The SHA-256 hash as a string</returns>
        public static string Sha256(byte[] data)
        {
            SHA256 sha256 = SHA256.Create();
            return CalculateHash(sha256, data);
        }

        /// <summary>
        /// This function calculates the hash of the given data, using the given hashing algorithm
        /// </summary>
        /// <param name="hashAlgorithm">The hashing algorithm to use</param>
        /// <param name="data">The data to hash</param>
        /// <returns>The hash of the data as a string, based on the given hash algorithm</returns>
        private static string CalculateHash(HashAlgorithm hashAlgorithm, byte[] data)
        {
            byte[] rawHash = hashAlgorithm.ComputeHash(data);

            string hash = "";

            for (int i = 0; i < rawHash.Length; i++)
            {
                hash += rawHash[i].ToString("x2");
            }

            return hash;
        }
    }
}
