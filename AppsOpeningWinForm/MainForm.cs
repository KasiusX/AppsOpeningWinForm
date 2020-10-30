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
            try
            {
                layoutsListBox.Items.AddRange(manager.GetLayoutModels().OrderBy(x => x.Name).ToArray());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                SetBindings();
            }
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

        private void deleteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LayoutModel layoutToDelete = (LayoutModel)layoutsListBox.SelectedItem;
            if (MessageBox.Show($"Delete {layoutToDelete.Name} layout?", "Delete layout", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    manager.DeleteLayoutModel(layoutToDelete);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                SetBindings();
            }
        }

        private void editLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditLayoutForm form = new EditLayoutForm(manager, (LayoutModel)layoutsListBox.SelectedItem);
            form.ShowDialog();
        }
    }
}
