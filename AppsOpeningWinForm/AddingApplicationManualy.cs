using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpeningDifferentApps;
using OpeningDifferentApps.Models;

namespace AppsOpeningWinForm
{
    public partial class AddingApplicationManualy : Form
    {
        private readonly IAppModelRequestor requestor;
        private readonly Validations validations;
        private string filePath = "";

        
        public AddingApplicationManualy(IAppModelRequestor requestor)
        {
            InitializeComponent();
            this.requestor = requestor;
            validations = new Validations();
            appFileOpenFileDialog.Filter = "exe files(*.exe)|*.exe|url files(*.url)|*.url";
        }

        private void getFileButton_Click(object sender, EventArgs e)
        {
            if(appFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = appFileOpenFileDialog.FileName;
                filePathTextbox.Text = filePath;
            }
        }

        private void saveAppButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validations.ValidateApp(nameValue.Text, filePath))
                {
                    requestor.AddApplication(new AppModel { FilePath = filePath, Name = nameValue.Text });
                    Close();
                }
            }
            catch (ValidationException ex)
            {
                MessageBoxes.InformationMessageBox(ex.Message, "Not valid input");
            }
        }

        
    }
}
