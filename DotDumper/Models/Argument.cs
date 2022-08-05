using System.Collections.Generic;

namespace DotDumper.Models
{
    /// <summary>
    /// This class is used to store the type, name, and value of an argument in a serialisable model
    /// </summary>
    public class Argument
    {
        /// <summary>
        /// The type of the given argument, in full (i.e. System.String, rather than String)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The name of the argument, i.e. the function definition "Main(string[] args)" has "args" as the name of the function's sole argument
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the argument, in textual form (which can also be a reference to a hash, as defined in the list of hashes)
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The list of related file hashes as Hash objects
        /// </summary>
        public List<Hash> RelatedFileHashes { get; set; }

        /// <summary>
        /// The constructor to make an Argument object
        /// </summary>
        /// <param name="type">The type of the given argument, in full (i.e. System.String, rather than String)</param>
        /// <param name="name">The name of the argument, i.e. the function definition "Main(string[] args)" has "args" as the name of the function's sole argument</param>
        /// <param name="value">The value of the argument, in textual form (which can also be a reference to a hash, as defined in the list of hashes)</param>
        /// <param name="relatedFileHashes">The list of related file hashes as Hash objects</param>
        public Argument(string type, string name, string value, List<Hash> relatedFileHashes)
        {
            Type = type;
            Name = name;
            Value = value;
            RelatedFileHashes = relatedFileHashes;
        }

        /// <summary>
        /// DO NOTE USE THIS CONSTRUCTOR! This is an empty constructor to be able to serialise the object, which is its sole purpose!
        /// </summary>
        public Argument()
        {

        }
    }
}
