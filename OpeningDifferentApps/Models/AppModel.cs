using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps.Models
{
    public class AppModel :IIds
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
    }
}
