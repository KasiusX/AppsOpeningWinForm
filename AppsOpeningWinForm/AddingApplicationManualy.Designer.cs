
namespace AppsOpeningWinForm
{
    partial class AddingApplicationManualy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingApplicationManualy));
            this.nameValue = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.saveAppButton = new System.Windows.Forms.Button();
            this.filePathTextbox = new System.Windows.Forms.TextBox();
            this.getFileButton = new System.Windows.Forms.Button();
            this.appFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // nameValue
            // 
            this.nameValue.Location = new System.Drawing.Point(19, 60);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(246, 45);
            this.nameValue.TabIndex = 3;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 20);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(116, 37);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name:";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(12, 118);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(81, 37);
            this.fileLabel.TabIndex = 4;
            this.fileLabel.Text = "File:";
            // 
            // saveAppButton
            // 
            this.saveAppButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.saveAppButton.Location = new System.Drawing.Point(19, 281);
            this.saveAppButton.Name = "saveAppButton";
            this.saveAppButton.Size = new System.Drawing.Size(246, 78);
            this.saveAppButton.TabIndex = 5;
            this.saveAppButton.Text = "Save app";
            this.saveAppButton.UseVisualStyleBackColor = false;
            this.saveAppButton.Click += new System.EventHandler(this.saveAppButton_Click);
            // 
            // filePathTextbox
            // 
            this.filePathTextbox.Location = new System.Drawing.Point(19, 164);
            this.filePathTextbox.Name = "filePathTextbox";
            this.filePathTextbox.ReadOnly = true;
            this.filePathTextbox.Size = new System.Drawing.Size(246, 45);
            this.filePathTextbox.TabIndex = 3;
            // 
            // getFileButton
            // 
            this.getFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.getFileButton.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getFileButton.Location = new System.Drawing.Point(141, 118);
            this.getFileButton.Name = "getFileButton";
            this.getFileButton.Size = new System.Drawing.Size(124, 40);
            this.getFileButton.TabIndex = 5;
            this.getFileButton.Text = "Get";
            this.getFileButton.UseVisualStyleBackColor = false;
            this.getFileButton.Click += new System.EventHandler(this.getFileButton_Click);
            // 
            // AddingApplicationManualy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(292, 371);
            this.Controls.Add(this.getFileButton);
            this.Controls.Add(this.saveAppButton);
            this.Controls.Add(this.filePathTextbox);
            this.Controls.Add(this.nameValue);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.nameLabel);
            this.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "AddingApplicationManualy";
            this.Text = "Add application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameValue;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button saveAppButton;
        private System.Windows.Forms.TextBox filePathTextbox;
        private System.Windows.Forms.Button getFileButton;
        private System.Windows.Forms.OpenFileDialog appFileOpenFileDialog;
    }
}