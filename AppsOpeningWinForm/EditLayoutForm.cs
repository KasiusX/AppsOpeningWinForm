using OpeningDifferentApps;
using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppsOpeningWinForm
{
    public partial class EditLayoutForm : Form, IAppModelRequestor
    {
        private AppsManager manager;
        private LayoutModel layoutToEdit;
        private List<AppModel> manuallyAddedApps = new List<AppModel>();
        private LayoutLogic logic;
        public EditLayoutForm(AppsManager manager, LayoutModel layoutModelToEdit)
        {
            InitializeComponent();
            logic = new LayoutLogic(manager);
            this.manager = manager;
            layoutToEdit = layoutModelToEdit;
            SetBindings();
        }

        private void SetBindings()
        {
            logic.AddVisibleApps(aviableAppsCheckListBox);

            logic.AddManuallyAddedApps(aviableAppsCheckListBox, manuallyAddedApps);

            aviableAppsCheckListBox.DisplayMember = "Name";
            nameValue.Text = layoutToEdit.Name;

            AddAppModelsFromModelToEdit();
        } 

        private void AddAppModelsFromModelToEdit()
        {
            RemoveAppsIfInModelToEdit();

            aviableAppsCheckListBox.Items.AddRange(layoutToEdit.Apps.OrderBy(x => x.Name).ToArray());            
            foreach (AppModel app in layoutToEdit.Apps)
            {
                int index = aviableAppsCheckListBox.Items.IndexOf(app);
                aviableAppsCheckListBox.SetItemChecked(index, true);
            }
        }
        private void RemoveAppsIfInModelToEdit()
        {
            List<AppModel> appsToRemove = new List<AppModel>();

            foreach (AppModel checkBoxApp in aviableAppsCheckListBox.Items)
            {
                if (IsAppInModelToEdit(checkBoxApp))
                    appsToRemove.Add(checkBoxApp);
            }

            RemoveAppsFromCheckList(appsToRemove);
        }

        private bool IsAppInModelToEdit(AppModel app)
        {
            List<AppModel> filteredApps = layoutToEdit.Apps.Where(x => x.Name == app.Name).ToList();
            if (filteredApps.Count != 0)
                return true;
            return false;
        }

        private void RemoveAppsFromCheckList(List<AppModel> appsToRemove)
        {
            foreach (AppModel appToDelete in appsToRemove)
            {
                aviableAppsCheckListBox.Items.Remove(appToDelete);
            }
        }


        private void refreshButton_Click(object sender, EventArgs e)
        {
            SetBindings();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editLayoutButton_Click(object sender, EventArgs e)
        {
            List<AppModel> selectedApps = logic.GetCheckedApps(aviableAppsCheckListBox);
            try
            {
                if (manager.EditLayoutModel(nameValue.Text, selectedApps, layoutToEdit.Id, layoutToEdit))
                    this.Close();
            }
            catch (ValidationException ex)
            {
                MessageBoxes.InformationMessageBox(ex.Message, "Not valid input");
            }
            catch (Exception ex)
            {
                MessageBoxes.WarningMessageBox(ex.Message, "Data files opened");
            }
        }     

        private void addAppManualy_Click(object sender, EventArgs e)
        {
            AddingApplicationManualy form = new AddingApplicationManualy(this);
            form.ShowDialog();
        }

        public void AddApplication(AppModel app)
        {
            manuallyAddedApps.Add(app);
            SetBindings();
        }
    }
}
