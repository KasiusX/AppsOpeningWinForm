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
    public partial class EditLayoutForm : Form
    {
        private AppsManager manager;
        private LayoutModel modelToEdit;
        public EditLayoutForm(AppsManager manager,LayoutModel layoutModelToEdit)
        {
            InitializeComponent();
            this.manager = manager;
            modelToEdit = layoutModelToEdit;
            SetBindings();
        }

        private void SetBindings()
        {
            aviableAppsCheckListBox.Items.Clear();
            aviableAppsCheckListBox.Items.AddRange(manager.GetVisibleProcesses().ToArray());
            
            aviableAppsCheckListBox.DisplayMember = "Name";
            nameValue.Text = modelToEdit.Name;

            RemoveAppsIfInModelToEdit();
            AddModelToEditItems();
        }

        
        private void RemoveAppsIfInModelToEdit()
        {
            List<AppModel> appsToDelete = new List<AppModel>();
            foreach (AppModel checkBoxApp in aviableAppsCheckListBox.Items)
            {
                List<AppModel> filteredApps = modelToEdit.Apps.Where(x => x.Name == checkBoxApp.Name).ToList();
                if (filteredApps.Count != 0)
                    appsToDelete.Add(checkBoxApp);
            }
            foreach (AppModel appToDelete  in appsToDelete)
            {
                aviableAppsCheckListBox.Items.Remove(appToDelete);
            }
        }

        private void AddModelToEditItems()
        {
            aviableAppsCheckListBox.Items.AddRange(modelToEdit.Apps.ToArray());
            foreach (AppModel app in modelToEdit.Apps)
            {
                aviableAppsCheckListBox.SetItemChecked(aviableAppsCheckListBox.Items.IndexOf(app), true);
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
            List<AppModel> selectedApps = GetCheckedApps();
            try
            {
                if (manager.EditLayoutModel(nameValue.Text, selectedApps, modelToEdit.Id))
                    this.Close();
            }
            catch (ValidationException ex)
            {
                InformationMessageBox(ex.Message, "Not valid input");
            }
            catch (Exception ex)
            {
                WarningMessageBox(ex.Message, "Data files opened");
            }
        }

        private List<AppModel> GetCheckedApps()
        {
            List<AppModel> output = new List<AppModel>();
            foreach (var app in aviableAppsCheckListBox.CheckedItems)
            {
                output.Add((AppModel)app);
            }
            return output;
        }

        private void WarningMessageBox(string message, string title) => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void InformationMessageBox(string message, string title) => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
