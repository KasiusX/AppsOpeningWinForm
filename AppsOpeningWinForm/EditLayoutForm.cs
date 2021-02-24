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

        private async void SetBindings()
        {
            await logic.AddVisibleApps(aviableAppsCheckListBox);
            logic.AddManuallyAddedApps(aviableAppsCheckListBox, manuallyAddedApps);

            aviableAppsCheckListBox.DisplayMember = "Name";
            nameValue.Text = layoutToEdit.Name;

            CheckAppsFromLayoutToEdit();
        } 

        private void CheckAppsFromLayoutToEdit()
        {              
            foreach (AppModel app in layoutToEdit.Apps)
            {
                CheckApp(app);
            }
        }

        private void CheckApp(AppModel app)
        {
            int index = GetAppIndexFromListBox(app);
            aviableAppsCheckListBox.SetItemChecked(index, true);
        }

        private int GetAppIndexFromListBox(AppModel app)
        {
            foreach (ListBoxAppModel item in aviableAppsCheckListBox.Items)
            {
                if (item.App.Name == app.Name && item.App.Position.Equals(app.Position))
                    return aviableAppsCheckListBox.Items.IndexOf(item);
            }
            return -1;
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
