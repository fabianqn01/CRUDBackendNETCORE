using System;
using System.Collections.Generic;

namespace SystemPro.Core.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            MenuRol = new HashSet<MenuRol>();
            User = new HashSet<User>();
        }

        public int RolId { get; set; }
        public string RolName { get; set; }

        public virtual ICollection<MenuRol> MenuRol { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
