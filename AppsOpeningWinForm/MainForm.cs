using OpeningDifferentApps;
using OpeningDifferentApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace AppsOpeningWinForm
{
    public partial class MainLayoutForm : Form
    {
        AppsManager manager = new AppsManager();
        public MainLayoutForm()
        {
            InitializeComponent();
            SetBindings();
        }

        private void createLayoutButton_Click(object sender, EventArgs e)
        {
            NewLayoutForm form = new NewLayoutForm(manager);
            form.ShowDialog();
            SetBindings();
        }

        private void SetBindings()
        {
            layoutsListBox.Items.Clear();
            layoutsListBox.Items.AddRange(manager.GetLayoutModels().ToArray());
            layoutsListBox.DisplayMember = "Name";
            if (layoutsListBox.Items.Count != 0)
                layoutsListBox.SetSelected(0, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                manager.LoadLayoutModel((LayoutModel)layoutsListBox.SelectedItem, OnlyClossedAppsCheckBox.Checked);
            }
            catch(Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
