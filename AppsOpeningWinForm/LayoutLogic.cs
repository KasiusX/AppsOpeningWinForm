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

        public async void AddVisibleApps(CheckedListBox checkedListBox)
        {
            checkedListBox.Items.Clear();
            List<ListBoxAppModel> visibleApps = new List<ListBoxAppModel>();
            await Task.Run(() => visibleApps = manager.GetVisibleApps());
            checkedListBox.Items.AddRange(visibleApps.OrderBy(x => x.App.Name).ToArray());
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
                ListBoxAppModel selectedItem = (ListBoxAppModel)app;
                checkedApps.Add(selectedItem.App);
            }
            return checkedApps;
        }
    }
}
