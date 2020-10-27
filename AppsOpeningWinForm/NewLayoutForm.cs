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
            List<AppModel> apps = GetCheckedApps();
            try
            {
                if (manager.CreateNewLayoutModels(nameValue.Text, apps))
                    SetBindings();
            }
            catch(ValidationException ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
