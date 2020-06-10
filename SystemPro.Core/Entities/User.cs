using System;
using System.Collections.Generic;

namespace SystemPro.Core.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeIdentificationId { get; set; }
        public int NumberId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastChange { get; set; }
        public bool Active { get; set; }
        public int RolId { get; set; }

        public IEnumerable<Menu> Menu { get; set; }

        public virtual Roles Rol { get; set; }
        public virtual TypeIdentification TypeIdentification { get; set; }
    }
}
