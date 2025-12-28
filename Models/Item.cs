using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakpointConflictTracker.Models
{
    public class Item
    {
        public ItemType Type { get; }
        public string Name { get; set; }

        public Item (ItemType type, string name)
        {
            Type = type;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
