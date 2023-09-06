using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns
{

    // The Prototype pattern is a creational design pattern. You can use it when a prototype instance determines
    // the type of object you need to create. Then, that prototypical instance is cloned to create new instances
    // of the same type.

    // The Prototype pattern is a creational design pattern that is used to instantiate new objects by copying an
    // existing object. The prototype object serves as a template from which you can create new objects

    public class AddressType1
    {
        public string? State { get; set; }
        public string? City { get; set; }
    }
    public class AddressType2: ICloneable
    {
        public string? State { get; set; }
        public string? City { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class AuthorForShallowCopy : ICloneable
    {
        public string Name { get; set; }
        public string TwitterAccount { get; set; }
        public string Website { get; set; }
        public AddressType1 HomeAddress { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class AuthorForDeepCopy : ICloneable
    {
        public string Name { get; set; }
        public string TwitterAccount { get; set; }
        public string Website { get; set; }
        public AddressType2 HomeAddress { get; set; }
        public object Clone()
        {
            AuthorForDeepCopy obj = (AuthorForDeepCopy)this.MemberwiseClone();
            obj.HomeAddress = (AddressType2)this.HomeAddress.Clone();
            return obj;
        }
    }


}
