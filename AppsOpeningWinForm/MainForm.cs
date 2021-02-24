using OpeningDifferentApps;
using OpeningDifferentApps.Models;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            CheckForUpdates();

            AddVersionNumber();
        }

        private void AddVersionNumber()
        {
            this.Text += Application.ProductVersion;
        }
        private async Task CheckForUpdates()
        {
            using(var manager = new UpdateManager(@"D:\Data\StartingDifferentAppsData\UpdateData"))
            {
                await manager.UpdateApp(); 
            }
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
            catch (IOException e)
            {
                MessageBoxes.WarningMessageBox(e.Message, "Data files opened!");
            }

            layoutsListBox.DisplayMember = "Name";

            if (layoutsListBox.Items.Count != 0)
                layoutsListBox.SetSelected(0, true);
        }       

        private void deleteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (layoutsListBox.SelectedItem == null)
                return;
            LayoutModel layoutToDelete = (LayoutModel)layoutsListBox.SelectedItem;

            if (MessageBoxes.AskMessageBox($"Delete {layoutToDelete.Name} layout?", "Delete layout") == DialogResult.Yes)
            {
                try
                {
                    manager.DeleteLayoutModel(layoutToDelete);
                }
                catch(Exception ex)
                {
                    MessageBoxes.WarningMessageBox(ex.Message, "Data files opened.");
                }
                SetBindings();
            }
        }

        private async void editLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (layoutsListBox.SelectedItem != null)
            {
                await LoadLayout();
                EditLayoutForm form = new EditLayoutForm(manager, (LayoutModel)layoutsListBox.SelectedItem);
                form.ShowDialog();
                SetBindings();
            }
        }

        private void closeAllAppsButton_Click(object sender, EventArgs e)
        {
            if (MessageBoxes.AskMessageBox("Do you wonna close all apps?", "Close all apps") == DialogResult.Yes)
            {
                try
                {
                    manager.CloseAllVisibleProcesses();
                }
                catch(Win32Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }        

        private void layoutsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loadLayoutButton_Click(this, EventArgs.Empty);
        }

        private void loadLayoutButton_Click(object sender, EventArgs e)
        {
            string message = LoadLayout().Result;
            if (message != "")
                MessageBoxes.InformationMessageBox(message, "Done");
        }

        private async Task<string> LoadLayout()
        {
            string message = "";
            if (layoutsListBox.SelectedItem != null)
            {
                LoadLayoutRequest request = new LoadLayoutRequest
                {
                    Layout = (LayoutModel)layoutsListBox.SelectedItem,
                    MoveApps = moveAppsCheckbox.Checked,
                    OnlyClosedApps = OnlyClossedAppsCheckBox.Checked,
                    OnlyThisLayout = OnlyThisLayoutCheckbox.Checked
                };

                try
                {
                    message = Task.Run(() => message = manager.LoadLayoutModel(request)).Result;
                }
                catch (Win32Exception ex)
                {
                    MessageBoxes.ErrorMessageBox(ex.Message, "Acces denined");                    
                }
            }
            return message;
        }
    }
}
