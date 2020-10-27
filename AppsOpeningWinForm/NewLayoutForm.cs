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
        public List<LayoutModel> LayoutsToCreate{ get; set; }
        public NewLayoutForm(AppsManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            LayoutsToCreate = new List<LayoutModel>();
            ResetBindings();
        }

        private void createLayoutButton_Click(object sender, EventArgs e)
        {
            if (nameValue.Text != "" && aviableAppsCheckListBox.CheckedItems.Count != 0)
            {
                List<AppModel> apps = GetCheckedApps();
                LayoutsToCreate.Add(new LayoutModel { Name = nameValue.Text, apps = apps });
                ResetBindings();
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
        private void ResetBindings()
        {
            aviableAppsCheckListBox.Items.Clear();
            aviableAppsCheckListBox.Items.AddRange(manager.GetVisibleProcesses().ToArray());
            aviableAppsCheckListBox.DisplayMember = "Name";
            nameValue.Text = "";
        }

        private void NewLayoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(LayoutsToCreate.Count != 0)
            manager.CreateNewLayoutModels(LayoutsToCreate);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            ResetBindings();
        }
    }
}
