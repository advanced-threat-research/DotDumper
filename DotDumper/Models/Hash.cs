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
        /// Creates a hash object with the given values for the corresponding hashes
        /// </summary>
        /// <param name="md5">The MD-5 hash of the referenced file</param>
        /// <param name="sha1">The SHA-1 hash of the referenced file</param>
        /// <param name="sha256">The SHA-256 hash of the referenced file</param>
        public Hash(string md5, string sha1, string sha256)
        {
            Md5 = md5;
            Sha1 = sha1;
            Sha256 = sha256;
        }

        /// <summary>
        /// DO NOTE USE THIS CONSTRUCTOR! This is an empty constructor to be able to serialise the object, which is its sole purpose!
        /// </summary>
        public Hash()
        {

        }
    }
}
