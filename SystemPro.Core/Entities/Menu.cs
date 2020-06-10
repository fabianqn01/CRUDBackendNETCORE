using System;
using System.Collections.Generic;

namespace SystemPro.Core.Entities
{
    public partial class Menu
    {
        public Menu()
        {
            MenuRol = new HashSet<MenuRol>();
        }

        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Display { get; set; }
        public string Link { get; set; }
        public int FatherId { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<MenuRol> MenuRol { get; set; }
    }
}
