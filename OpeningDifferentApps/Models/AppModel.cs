using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        public Rect Position { get; set; }

        public override string ToString()
        {
            return $"{Id},{Name},{FilePath},{Position.Bottom},{Position.Top},{Position.Left},{Position.Right}";
        }
    }
}
