using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps.Models
{
    public class ListBoxAppModel
    {
        public AppModel App { get; set; }
        public string Title { get; set; }
        public IntPtr Window { get; set; }

        public override string ToString()
        {
            return $"{App.Name}({Title})";
        }
    }
}
