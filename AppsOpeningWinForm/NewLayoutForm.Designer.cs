namespace AppsOpeningWinForm
{
    partial class NewLayoutForm
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
            this.aviableAppsCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.createLayoutButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.openedAppsLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aviableAppsCheckListBox
            // 
            this.aviableAppsCheckListBox.CheckOnClick = true;
            this.aviableAppsCheckListBox.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aviableAppsCheckListBox.FormattingEnabled = true;
            this.aviableAppsCheckListBox.HorizontalScrollbar = true;
            this.aviableAppsCheckListBox.Location = new System.Drawing.Point(12, 48);
            this.aviableAppsCheckListBox.Name = "aviableAppsCheckListBox";
            this.aviableAppsCheckListBox.Size = new System.Drawing.Size(274, 469);
            this.aviableAppsCheckListBox.TabIndex = 0;
            // 
            // createLayoutButton
            // 
            this.createLayoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createLayoutButton.Location = new System.Drawing.Point(308, 454);
            this.createLayoutButton.Name = "createLayoutButton";
            this.createLayoutButton.Size = new System.Drawing.Size(246, 78);
            this.createLayoutButton.TabIndex = 1;
            this.createLayoutButton.Text = "Create layout";
            this.createLayoutButton.UseVisualStyleBackColor = false;
            this.createLayoutButton.Click += new System.EventHandler(this.createLayoutButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.backButton.Location = new System.Drawing.Point(308, 370);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(246, 78);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(301, 48);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(116, 37);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // nameValue
            // 
            this.nameValue.Location = new System.Drawing.Point(308, 88);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(246, 45);
            this.nameValue.TabIndex = 3;
            // 
            // openedAppsLabel
            // 
            this.openedAppsLabel.AutoSize = true;
            this.openedAppsLabel.Location = new System.Drawing.Point(12, 8);
            this.openedAppsLabel.Name = "openedAppsLabel";
            this.openedAppsLabel.Size = new System.Drawing.Size(232, 37);
            this.openedAppsLabel.TabIndex = 4;
            this.openedAppsLabel.Text = "Opened apps:";
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.White;
            this.refreshButton.BackgroundImage = global::AppsOpeningWinForm.Properties.Resources.Refresh;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(240, 8);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(46, 37);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.UseVisualStyleBackColor = false;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // NewLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 556);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.openedAppsLabel);
            this.Controls.Add(this.nameValue);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.createLayoutButton);
            this.Controls.Add(this.aviableAppsCheckListBox);
            this.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "NewLayoutForm";
            this.Text = "New layout";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewLayoutForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox aviableAppsCheckListBox;
        private System.Windows.Forms.Button createLayoutButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameValue;
        private System.Windows.Forms.Label openedAppsLabel;
        private System.Windows.Forms.Button refreshButton;
    }
}