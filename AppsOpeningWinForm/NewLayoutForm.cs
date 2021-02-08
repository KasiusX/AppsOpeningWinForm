
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
    public partial class NewLayoutForm : Form, IAppModelRequestor
    {
        private AppsManager manager;
        List<AppModel> manuallyAddedApps = new List<AppModel>();
        private LayoutLogic logic;
        public NewLayoutForm(AppsManager manager)
        {
            InitializeComponent();
            logic = new LayoutLogic(manager);
            this.manager = manager;
            SetBindings();
        }

        private void createLayoutButton_Click(object sender, EventArgs e)
        {
            List<AppModel> selectedApps = logic.GetCheckedApps(aviableAppsCheckListBox);
            try
            {
                if (manager.CreateNewLayoutModels(nameValue.Text, selectedApps))
                {                    
                    Close();
                }
            }
            catch(ValidationException ex)
            {
                MessageBoxes.InformationMessageBox(ex.Message, "Not valid input");
            }
            catch(Exception ex) 
            {
                MessageBoxes.WarningMessageBox(ex.Message, "Data files opened!");
            }
        }
        

        private void SetBindings()
        {
            logic.AddVisibleApps(aviableAppsCheckListBox);

            logic.AddManuallyAddedApps(aviableAppsCheckListBox,manuallyAddedApps);

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

        private void nameValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                createLayoutButton_Click(this, EventArgs.Empty);
        }

        private void addAppManualyButton_Click(object sender, EventArgs e)
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
