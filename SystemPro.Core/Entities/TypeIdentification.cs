using System;
using System.Collections.Generic;

namespace SystemPro.Core.Entities
{
    public partial class TypeIdentification
    {
        public TypeIdentification()
        {
            User = new HashSet<User>();
        }

        public int TypeIdentificationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
