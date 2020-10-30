using OpeningDifferentApps;
using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppsOpeningWinForm
{
    public partial class NewLayoutForm : Form
    {
        private AppsManager manager;
        public NewLayoutForm(AppsManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            SetBindings();
        }

        private void createLayoutButton_Click(object sender, EventArgs e)
        {
            List<AppModel> selectedApps = GetCheckedApps();
            try
            {
                if (manager.CreateNewLayoutModels(nameValue.Text, selectedApps))
                {
                    SetBindings();
                    Close();
                }
            }
            catch(ValidationException ex)
            {
                InformationMessageBox(ex.Message, "Not valid input");
            }
            catch(Exception ex) 
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
        private void SetBindings()
        {
            aviableAppsCheckListBox.Items.Clear();
            aviableAppsCheckListBox.Items.AddRange(manager.GetVisibleProcesses().ToArray());
            aviableAppsCheckListBox.DisplayMember = "Name";
            nameValue.Text = "";
        }        

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            SetBindings();
        }

        private void WarningMessageBox(string message, string title) => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        private void InformationMessageBox(string message, string title) => MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        private void nameValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                createLayoutButton_Click(this, EventArgs.Empty);
        }

        
    }
}
