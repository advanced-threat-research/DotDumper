using System.Linq;
using System.Security.Cryptography;
using DotDumper.Hooks;
using PeNet;

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
        /// Calculates the SHA-384 hash of the given byte array 
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The SHA-384 hash as a string</returns>
        public static string Sha384(byte[] data)
        {
            SHA384 sha384 = SHA384.Create();
            return CalculateHash(sha384, data);
        }

        /// <summary>
        /// Calculates the SHA-512 hash of the given byte array 
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The SHA-512 hash as a string</returns>
        public static string Sha512(byte[] data)
        {
            SHA512 sha512 = SHA512.Create();
            return CalculateHash(sha512, data);
        }

        /// <summary>
        /// Calculates the TypeRef hash of the given byte array. Hooks are set prior to returning from this function!
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The TypeRef hash as a string, or an empty string in case an error occurs (i.e. the input is not a valid PE file which targets the DotNet Framework)</returns>
        public static string TypeRef(byte[] data)
        {
            HookManager.UnHookAll();
            if (PeFile.TryParse(data, out PeFile peFile) == false)
            {
                return "";
            }

            if (peFile.IsDotNet == false)
            {
                return "";
            }

            string typeRefHash = peFile.TypeRefHash;
            if (typeRefHash == null)
            {
                typeRefHash = "";
            }
            HookManager.HookAll();

            return typeRefHash;
        }

        /// <summary>
        /// Calculates the import hash of the given byte array. Hooks are set prior to returning from this function!
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The import hash as a string, or an empty string in case an error occurs (i.e. the input is not a valid PE file)</returns>
        public static string ImportHash(byte[] data)
        {
            HookManager.UnHookAll();
            if (PeFile.TryParse(data, out PeFile peFile) == false)
            {
                return "";
            }

            string importHash = peFile.ImpHash;
            if (importHash == null)
            {
                importHash = "";
            }
            HookManager.HookAll();

            return importHash;
        }

        /// <summary>
        /// Calculates the authenticode hash (SHA-256 based) of the given byte array. Hooks are set prior to returning from this function!
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The authenticode hash (SHA-256 based) as a string, or an empty string in case an error occurs (i.e. the input is not a valid PE)</returns>
        public static string AuthenticodeSha256(byte[] data)
        {
            return Authenticode(data, SHA256.Create());
        }

        /// <summary>
        /// Calculates the authenticode hash (based on the provided hash algorithm) of the given byte array. Hooks are set prior to returning from this function!
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <param name="hashAlgorithm">The hashing algorithm to use</param>
        /// <returns>The authenticode hash (based on the provided hash algorithm), or an empty string in case an error occurs (i.e. the input is not a valid PE file)</returns>
        private static string Authenticode(byte[] data, HashAlgorithm hashAlgorithm)
        {
            HookManager.UnHookAll();
            if (PeFile.TryParse(data, out PeFile peFile) == false)
            {
                return "";
            }

            string authenticode = peFile.Authenticode.ComputeAuthenticodeHashFromPeFile(hashAlgorithm).ToList().ToHexString();
            if (authenticode == null || authenticode.Length < 2)
            {
                authenticode = authenticode.Substring(2);
            }
            else
            {
                authenticode = "";
            }
            HookManager.HookAll();

            return authenticode;
        }

        /// <summary>
        /// This function calculates the hash of the given data, using the given hashing algorithm
        /// </summary>
        /// <param name="hashAlgorithm">The hashing algorithm to use</param>
        /// <param name="data">The data to hash</param>
        /// <returns>The hash of the data as a string, based on the given hash algorithm</returns>
        private static string CalculateHash(HashAlgorithm hashAlgorithm, byte[] data)
        {
            string hash = "";

            if (data == null || hashAlgorithm == null)
            {
                return hash;
            }

            byte[] rawHash = hashAlgorithm.ComputeHash(data);

            for (int i = 0; i < rawHash.Length; i++)
            {
                hash += rawHash[i].ToString("x2");
            }

            return hash;
        }
    }
}
