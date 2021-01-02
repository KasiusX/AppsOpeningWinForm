namespace AppsOpeningWinForm
{
    partial class MainLayoutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLayoutForm));
            this.createLayoutButton = new System.Windows.Forms.Button();
            this.loadLayoutButton = new System.Windows.Forms.Button();
            this.layoutsListBox = new System.Windows.Forms.ListBox();
            this.deleteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.editLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OnlyClossedAppsCheckBox = new System.Windows.Forms.CheckBox();
            this.closeAllAppsButton = new System.Windows.Forms.Button();
            this.moveAppsCheckbox = new System.Windows.Forms.CheckBox();
            this.OnlyThisLayoutCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // createLayoutButton
            // 
            this.createLayoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createLayoutButton.Location = new System.Drawing.Point(49, 566);
            this.createLayoutButton.Name = "createLayoutButton";
            this.createLayoutButton.Size = new System.Drawing.Size(246, 78);
            this.createLayoutButton.TabIndex = 1;
            this.createLayoutButton.Text = "Create layout";
            this.createLayoutButton.UseVisualStyleBackColor = false;
            this.createLayoutButton.Click += new System.EventHandler(this.createLayoutButton_Click);
            // 
            // loadLayoutButton
            // 
            this.loadLayoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loadLayoutButton.Location = new System.Drawing.Point(341, 707);
            this.loadLayoutButton.Name = "loadLayoutButton";
            this.loadLayoutButton.Size = new System.Drawing.Size(246, 78);
            this.loadLayoutButton.TabIndex = 3;
            this.loadLayoutButton.Text = "Load layout";
            this.loadLayoutButton.UseVisualStyleBackColor = false;
            this.loadLayoutButton.Click += new System.EventHandler(this.loadLayoutButton_Click);
            // 
            // layoutsListBox
            // 
            this.layoutsListBox.AllowDrop = true;
            this.layoutsListBox.FormattingEnabled = true;
            this.layoutsListBox.HorizontalScrollbar = true;
            this.layoutsListBox.ItemHeight = 37;
            this.layoutsListBox.Location = new System.Drawing.Point(120, 57);
            this.layoutsListBox.MaximumSize = new System.Drawing.Size(400, 450);
            this.layoutsListBox.MinimumSize = new System.Drawing.Size(400, 450);
            this.layoutsListBox.Name = "layoutsListBox";
            this.layoutsListBox.Size = new System.Drawing.Size(400, 448);
            this.layoutsListBox.TabIndex = 0;
            this.layoutsListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.layoutsListBox_KeyDown);
            // 
            // deleteLinkLabel
            // 
            this.deleteLinkLabel.AutoSize = true;
            this.deleteLinkLabel.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLinkLabel.Location = new System.Drawing.Point(451, 32);
            this.deleteLinkLabel.Name = "deleteLinkLabel";
            this.deleteLinkLabel.Size = new System.Drawing.Size(68, 22);
            this.deleteLinkLabel.TabIndex = 6;
            this.deleteLinkLabel.TabStop = true;
            this.deleteLinkLabel.Text = "Delete";
            this.deleteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.deleteLinkLabel_LinkClicked);
            // 
            // editLinkLabel
            // 
            this.editLinkLabel.AutoSize = true;
            this.editLinkLabel.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLinkLabel.Location = new System.Drawing.Point(120, 32);
            this.editLinkLabel.Name = "editLinkLabel";
            this.editLinkLabel.Size = new System.Drawing.Size(47, 22);
            this.editLinkLabel.TabIndex = 5;
            this.editLinkLabel.TabStop = true;
            this.editLinkLabel.Text = "Edit";
            this.editLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editLinkLabel_LinkClicked);
            // 
            // OnlyClossedAppsCheckBox
            // 
            this.OnlyClossedAppsCheckBox.AutoSize = true;
            this.OnlyClossedAppsCheckBox.Checked = true;
            this.OnlyClossedAppsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OnlyClossedAppsCheckBox.Location = new System.Drawing.Point(341, 566);
            this.OnlyClossedAppsCheckBox.Name = "OnlyClossedAppsCheckBox";
            this.OnlyClossedAppsCheckBox.Size = new System.Drawing.Size(300, 41);
            this.OnlyClossedAppsCheckBox.TabIndex = 2;
            this.OnlyClossedAppsCheckBox.Text = "Only closed apps";
            this.OnlyClossedAppsCheckBox.UseVisualStyleBackColor = true;
            // 
            // closeAllAppsButton
            // 
            this.closeAllAppsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.closeAllAppsButton.Location = new System.Drawing.Point(49, 707);
            this.closeAllAppsButton.Name = "closeAllAppsButton";
            this.closeAllAppsButton.Size = new System.Drawing.Size(246, 78);
            this.closeAllAppsButton.TabIndex = 4;
            this.closeAllAppsButton.Text = "Close all apps";
            this.closeAllAppsButton.UseVisualStyleBackColor = false;
            this.closeAllAppsButton.Click += new System.EventHandler(this.closeAllAppsButton_Click);
            // 
            // moveAppsCheckbox
            // 
            this.moveAppsCheckbox.AutoSize = true;
            this.moveAppsCheckbox.Checked = true;
            this.moveAppsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.moveAppsCheckbox.Location = new System.Drawing.Point(341, 613);
            this.moveAppsCheckbox.Name = "moveAppsCheckbox";
            this.moveAppsCheckbox.Size = new System.Drawing.Size(202, 41);
            this.moveAppsCheckbox.TabIndex = 2;
            this.moveAppsCheckbox.Text = "Move apps";
            this.moveAppsCheckbox.UseVisualStyleBackColor = true;
            // 
            // OnlyThisLayoutCheckbox
            // 
            this.OnlyThisLayoutCheckbox.AutoSize = true;
            this.OnlyThisLayoutCheckbox.Location = new System.Drawing.Point(341, 660);
            this.OnlyThisLayoutCheckbox.Name = "OnlyThisLayoutCheckbox";
            this.OnlyThisLayoutCheckbox.Size = new System.Drawing.Size(280, 41);
            this.OnlyThisLayoutCheckbox.TabIndex = 2;
            this.OnlyThisLayoutCheckbox.Text = "Only this layout";
            this.OnlyThisLayoutCheckbox.UseVisualStyleBackColor = true;
            // 
            // MainLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(665, 821);
            this.Controls.Add(this.OnlyThisLayoutCheckbox);
            this.Controls.Add(this.moveAppsCheckbox);
            this.Controls.Add(this.OnlyClossedAppsCheckBox);
            this.Controls.Add(this.editLinkLabel);
            this.Controls.Add(this.deleteLinkLabel);
            this.Controls.Add(this.layoutsListBox);
            this.Controls.Add(this.closeAllAppsButton);
            this.Controls.Add(this.loadLayoutButton);
            this.Controls.Add(this.createLayoutButton);
            this.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.MinimumSize = new System.Drawing.Size(440, 860);
            this.Name = "MainLayoutForm";
            this.Text = "Layouts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createLayoutButton;
        private System.Windows.Forms.Button loadLayoutButton;
        private System.Windows.Forms.ListBox layoutsListBox;
        private System.Windows.Forms.LinkLabel deleteLinkLabel;
        private System.Windows.Forms.LinkLabel editLinkLabel;
        private System.Windows.Forms.CheckBox OnlyClossedAppsCheckBox;
        private System.Windows.Forms.Button closeAllAppsButton;
        private System.Windows.Forms.CheckBox moveAppsCheckbox;
        private System.Windows.Forms.CheckBox OnlyThisLayoutCheckbox;
    }
}

