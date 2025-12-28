using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakpointConflictTracker.Models
{
    public class ConflictItem
    {
        public string ModName { get; set; }
        public string Category { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
    }
}
