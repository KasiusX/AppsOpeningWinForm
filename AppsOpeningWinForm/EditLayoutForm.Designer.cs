namespace AppsOpeningWinForm
{
    partial class EditLayoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLayoutForm));
            this.refreshButton = new System.Windows.Forms.Button();
            this.openedAppsLabel = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.editLayoutButton = new System.Windows.Forms.Button();
            this.aviableAppsCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.White;
            this.refreshButton.BackgroundImage = global::AppsOpeningWinForm.Properties.Resources.Refresh;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(240, 89);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(46, 37);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // openedAppsLabel
            // 
            this.openedAppsLabel.AutoSize = true;
            this.openedAppsLabel.Location = new System.Drawing.Point(12, 89);
            this.openedAppsLabel.Name = "openedAppsLabel";
            this.openedAppsLabel.Size = new System.Drawing.Size(232, 37);
            this.openedAppsLabel.TabIndex = 11;
            this.openedAppsLabel.Text = "Opened apps:";
            // 
            // nameValue
            // 
            this.nameValue.Location = new System.Drawing.Point(308, 169);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(246, 45);
            this.nameValue.TabIndex = 10;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(301, 129);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(116, 37);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "Name:";
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.backButton.Location = new System.Drawing.Point(308, 436);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(246, 78);
            this.backButton.TabIndex = 7;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // editLayoutButton
            // 
            this.editLayoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.editLayoutButton.Location = new System.Drawing.Point(308, 520);
            this.editLayoutButton.Name = "editLayoutButton";
            this.editLayoutButton.Size = new System.Drawing.Size(246, 78);
            this.editLayoutButton.TabIndex = 8;
            this.editLayoutButton.Text = "Edit layout";
            this.editLayoutButton.UseVisualStyleBackColor = false;
            this.editLayoutButton.Click += new System.EventHandler(this.editLayoutButton_Click);
            // 
            // aviableAppsCheckListBox
            // 
            this.aviableAppsCheckListBox.CheckOnClick = true;
            this.aviableAppsCheckListBox.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aviableAppsCheckListBox.FormattingEnabled = true;
            this.aviableAppsCheckListBox.HorizontalScrollbar = true;
            this.aviableAppsCheckListBox.Location = new System.Drawing.Point(12, 129);
            this.aviableAppsCheckListBox.Name = "aviableAppsCheckListBox";
            this.aviableAppsCheckListBox.Size = new System.Drawing.Size(274, 469);
            this.aviableAppsCheckListBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(156, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 55);
            this.label1.TabIndex = 12;
            this.label1.Text = "Edit layout";
            // 
            // EditLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 636);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.openedAppsLabel);
            this.Controls.Add(this.nameValue);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.editLayoutButton);
            this.Controls.Add(this.aviableAppsCheckListBox);
            this.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.MaximumSize = new System.Drawing.Size(600, 675);
            this.MinimumSize = new System.Drawing.Size(600, 675);
            this.Name = "EditLayoutForm";
            this.Text = "Edit layout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label openedAppsLabel;
        private System.Windows.Forms.TextBox nameValue;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button editLayoutButton;
        private System.Windows.Forms.CheckedListBox aviableAppsCheckListBox;
        private System.Windows.Forms.Label label1;
    }
}