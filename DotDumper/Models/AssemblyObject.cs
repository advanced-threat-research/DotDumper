namespace DotDumper.Models
{
    /// <summary>
    /// An object to reference Assembly objects, based on a SHA-256 hash, and a name
    /// </summary>
    public class AssemblyObject
    {
        /// <summary>
        /// The SHA-256 hash of the assembly object it references
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// The name of the referenced assembly object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The constructor to create an instance of this object type
        /// </summary>
        /// <param name="hash">The SHA-256 hash of the assembly object it references</param>
        /// <param name="name">The name of the referenced assembly object</param>
        public AssemblyObject(string hash, string name)
        {
            Hash = hash;
            Name = name;
        }

        /// <summary>
        /// DO NOTE USE THIS CONSTRUCTOR! This is an empty constructor to be able to serialise the object, which is its sole purpose!
        /// </summary>
        public AssemblyObject()
        {

        }
    }
}
