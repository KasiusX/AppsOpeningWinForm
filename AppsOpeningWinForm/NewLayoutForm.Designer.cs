﻿namespace AppsOpeningWinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLayoutForm));
            this.aviableAppsCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.createLayoutButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.openedAppsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addAppManualyButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aviableAppsCheckListBox
            // 
            this.aviableAppsCheckListBox.CheckOnClick = true;
            this.aviableAppsCheckListBox.Font = new System.Drawing.Font("Lucida Sans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aviableAppsCheckListBox.FormattingEnabled = true;
            this.aviableAppsCheckListBox.HorizontalScrollbar = true;
            this.aviableAppsCheckListBox.Location = new System.Drawing.Point(12, 130);
            this.aviableAppsCheckListBox.Name = "aviableAppsCheckListBox";
            this.aviableAppsCheckListBox.Size = new System.Drawing.Size(616, 469);
            this.aviableAppsCheckListBox.TabIndex = 0;
            // 
            // createLayoutButton
            // 
            this.createLayoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createLayoutButton.Location = new System.Drawing.Point(671, 519);
            this.createLayoutButton.Name = "createLayoutButton";
            this.createLayoutButton.Size = new System.Drawing.Size(246, 78);
            this.createLayoutButton.TabIndex = 4;
            this.createLayoutButton.Text = "Create layout";
            this.createLayoutButton.UseVisualStyleBackColor = false;
            this.createLayoutButton.Click += new System.EventHandler(this.createLayoutButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.backButton.Location = new System.Drawing.Point(671, 435);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(246, 78);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(664, 128);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(116, 37);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // nameValue
            // 
            this.nameValue.Location = new System.Drawing.Point(671, 168);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(246, 45);
            this.nameValue.TabIndex = 2;
            this.nameValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameValue_KeyDown);
            // 
            // openedAppsLabel
            // 
            this.openedAppsLabel.AutoSize = true;
            this.openedAppsLabel.Location = new System.Drawing.Point(12, 90);
            this.openedAppsLabel.Name = "openedAppsLabel";
            this.openedAppsLabel.Size = new System.Drawing.Size(232, 37);
            this.openedAppsLabel.TabIndex = 4;
            this.openedAppsLabel.Text = "Opened apps:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 55);
            this.label1.TabIndex = 12;
            this.label1.Text = "Create layout";
            // 
            // addAppManualyButton
            // 
            this.addAppManualyButton.BackColor = System.Drawing.Color.White;
            this.addAppManualyButton.BackgroundImage = global::AppsOpeningWinForm.Properties.Resources.Plus1;
            this.addAppManualyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addAppManualyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAppManualyButton.Location = new System.Drawing.Point(582, 90);
            this.addAppManualyButton.Name = "addAppManualyButton";
            this.addAppManualyButton.Size = new System.Drawing.Size(46, 37);
            this.addAppManualyButton.TabIndex = 1;
            this.addAppManualyButton.UseMnemonic = false;
            this.addAppManualyButton.UseVisualStyleBackColor = false;
            this.addAppManualyButton.Click += new System.EventHandler(this.addAppManualyButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackColor = System.Drawing.Color.White;
            this.refreshButton.BackgroundImage = global::AppsOpeningWinForm.Properties.Resources.Refresh;
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshButton.Location = new System.Drawing.Point(522, 90);
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
            this.ClientSize = new System.Drawing.Size(949, 644);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addAppManualyButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.openedAppsLabel);
            this.Controls.Add(this.nameValue);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.createLayoutButton);
            this.Controls.Add(this.aviableAppsCheckListBox);
            this.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "NewLayoutForm";
            this.Text = "New layout";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addAppManualyButton;
    }
}