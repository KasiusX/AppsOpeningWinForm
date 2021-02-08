using OpeningDifferentApps;
using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppsOpeningWinForm
{
    public class LayoutLogic
    {
        private AppsManager manager;

        public LayoutLogic(AppsManager manager)
        {
            this.manager = manager;
        }

        public void AddVisibleApps(CheckedListBox checkedListBox)
        {
            checkedListBox.Items.Clear();
            checkedListBox.Items.AddRange(manager.GetVisibleApps().OrderBy(x => x.Name).ToArray());
        }

        public void AddManuallyAddedApps(CheckedListBox checkedListBox, List<AppModel> manuallyAddedApps)
        {
            checkedListBox.Items.AddRange(manuallyAddedApps.OrderBy(x => x.Name).ToArray());
            SetManuallyAddedAppsChecked(manuallyAddedApps, checkedListBox);
        }
        private void SetManuallyAddedAppsChecked(List<AppModel> manuallyAddedApps, CheckedListBox checkedListBox)
        {
            foreach (AppModel app in manuallyAddedApps)
            {
                int index = checkedListBox.Items.IndexOf(app);
                checkedListBox.SetItemChecked(index, true);
            }
        }

        public List<AppModel> GetCheckedApps(CheckedListBox checkedListBox)
        {
            List<AppModel> checkedApps = new List<AppModel>();
            foreach (var app in checkedListBox.CheckedItems)
            {
                checkedApps.Add((AppModel)app);
            }
            return checkedApps;
        }
    }
}
