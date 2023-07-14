namespace DotDumper.Models
{
    /// <summary>
    /// A model to contain the MD-5, SHA-1, and SHA-256 hash for a given file
    /// </summary>
    public class Hash
    {
        /// <summary>
        /// The MD-5 hash of the referenced file
        /// </summary>
        public string Md5 { get; set; }

        /// <summary>
        /// The SHA-1 hash of the referenced file
        /// </summary>
        public string Sha1 { get; set; }

        /// <summary>
        /// The SHA-256 hash of the referenced file
        /// </summary>
        public string Sha256 { get; set; }

        /// <summary>
        /// The SHA-384 hash of the referenced file
        /// </summary>
        public string Sha384 { get; set; }

        /// <summary>
        /// The SHA-512 hash of the referenced file
        /// </summary>
        public string Sha512 { get; set; }

        /// <summary>
        /// The TypeRef hash of the referenced file
        /// </summary>
        public string TypeRef { get; set; }

        /// <summary>
        /// The import hash of the referenced file
        /// </summary>
        public string ImportHash { get; set; }

        /// <summary>
        /// The authenticode hash (SHA-256 based) of the referenced file
        /// </summary>
        public string AuthenticodeSha256 { get; set; }

        /// <summary>
        /// Creates a hash object with the given values for the corresponding hashes
        /// </summary>
        /// <param name="md5">The MD-5 hash of the referenced file</param>
        /// <param name="sha1">The SHA-1 hash of the referenced file</param>
        /// <param name="sha256">The SHA-256 hash of the referenced file</param>
        /// <param name="sha384">The SHA-384 hash of the referenced file</param>
        /// <param name="sha512">The SHA-512 hash of the referenced file</param>
        /// <param name="typeRef">The TypeRef hash of the referenced file</param>
        /// <param name="importHash">The import hash of the referenced file</param>
        /// <param name="authenticodeSha256">The authenticode hash (SHA-256 based) of the referenced file</param>
        public Hash(string md5, string sha1, string sha256, string sha384, string sha512, string typeRef, string importHash, string authenticodeSha256)
        {
            Md5 = md5;
            Sha1 = sha1;
            Sha256 = sha256;
            Sha384 = sha384;
            Sha512 = sha512;
            TypeRef = typeRef;
            ImportHash = importHash;
            AuthenticodeSha256 = authenticodeSha256;
        }

        /// <summary>
        /// DO NOTE USE THIS CONSTRUCTOR! This is an empty constructor to be able to serialise the object, which is its sole purpose!
        /// </summary>
        public Hash()
        {

        }
    }
}
