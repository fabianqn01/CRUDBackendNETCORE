using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SystemPro.Core.DTOs
{
    public partial class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TypeIdentificationId { get; set; }
        public int NumberId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } 
        public DateTime? LastChange { get; set; }
        public bool Active { get; set; }

        public int RolId { get; set; }

    }
}
