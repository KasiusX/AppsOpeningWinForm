using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps
{
    public class Validations
    {
        public bool ValidateLayout(string name, List<AppModel> apps)
        {
            if (string.IsNullOrEmpty(name))
                throw new ValidationException("Enter laoyut name.");
            if (apps.Count == 0)
                throw new ValidationException("Select apps.");
            return true;
        }

    }
}
