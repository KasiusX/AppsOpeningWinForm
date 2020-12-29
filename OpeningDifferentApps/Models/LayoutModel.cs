using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps.Models
{
    public class LayoutModel : IIds
    {
        public int Id { get; set; }        
        public List<AppModel> Apps = new List<AppModel>();
        public string Name { get; set; }

        public override string ToString()
        {
            string appIds = "";
            foreach (AppModel app in Apps)
            {
                appIds += $"{app.Id}|";
            }
            appIds = appIds.Remove(appIds.Length - 1);

            return $"{Id},{Name},{appIds}";
        }
    }
}
