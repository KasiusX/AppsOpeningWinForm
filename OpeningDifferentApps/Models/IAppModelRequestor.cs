using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpeningDifferentApps.Models
{
    public interface IAppModelRequestor
    {
        void AddApplication(AppModel app);
    }
}
