using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps.Models
{
    public class LoadLayoutRequest
    {
        public LayoutModel Layout { get; set; }
        public bool OnlyClosedApps { get; set; }
        public bool MoveApps { get; set; }
        public bool OnlyThisLayout { get; set; }
    }
}
