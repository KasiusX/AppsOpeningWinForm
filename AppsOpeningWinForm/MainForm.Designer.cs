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
            this.createLayoutButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.layoutsListBox = new System.Windows.Forms.ListBox();
            this.deleteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.editLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OnlyClossedAppsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // createLayoutButton
            // 
            this.createLayoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createLayoutButton.Location = new System.Drawing.Point(83, 493);
            this.createLayoutButton.Name = "createLayoutButton";
            this.createLayoutButton.Size = new System.Drawing.Size(246, 78);
            this.createLayoutButton.TabIndex = 0;
            this.createLayoutButton.Text = "Create layout";
            this.createLayoutButton.UseVisualStyleBackColor = false;
            this.createLayoutButton.Click += new System.EventHandler(this.createLayoutButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(83, 624);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 78);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load layout";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // layoutsListBox
            // 
            this.layoutsListBox.AllowDrop = true;
            this.layoutsListBox.FormattingEnabled = true;
            this.layoutsListBox.HorizontalScrollbar = true;
            this.layoutsListBox.ItemHeight = 37;
            this.layoutsListBox.Location = new System.Drawing.Point(12, 39);
            this.layoutsListBox.Name = "layoutsListBox";
            this.layoutsListBox.Size = new System.Drawing.Size(399, 448);
            this.layoutsListBox.TabIndex = 1;
            // 
            // deleteLinkLabel
            // 
            this.deleteLinkLabel.AutoSize = true;
            this.deleteLinkLabel.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLinkLabel.Location = new System.Drawing.Point(343, 14);
            this.deleteLinkLabel.Name = "deleteLinkLabel";
            this.deleteLinkLabel.Size = new System.Drawing.Size(68, 22);
            this.deleteLinkLabel.TabIndex = 2;
            this.deleteLinkLabel.TabStop = true;
            this.deleteLinkLabel.Text = "Delete";
            // 
            // editLinkLabel
            // 
            this.editLinkLabel.AutoSize = true;
            this.editLinkLabel.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editLinkLabel.Location = new System.Drawing.Point(12, 14);
            this.editLinkLabel.Name = "editLinkLabel";
            this.editLinkLabel.Size = new System.Drawing.Size(47, 22);
            this.editLinkLabel.TabIndex = 2;
            this.editLinkLabel.TabStop = true;
            this.editLinkLabel.Text = "Edit";
            // 
            // OnlyClossedAppsCheckBox
            // 
            this.OnlyClossedAppsCheckBox.AutoSize = true;
            this.OnlyClossedAppsCheckBox.Location = new System.Drawing.Point(83, 577);
            this.OnlyClossedAppsCheckBox.Name = "OnlyClossedAppsCheckBox";
            this.OnlyClossedAppsCheckBox.Size = new System.Drawing.Size(300, 41);
            this.OnlyClossedAppsCheckBox.TabIndex = 3;
            this.OnlyClossedAppsCheckBox.Text = "Only closed apps";
            this.OnlyClossedAppsCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(423, 736);
            this.Controls.Add(this.OnlyClossedAppsCheckBox);
            this.Controls.Add(this.editLinkLabel);
            this.Controls.Add(this.deleteLinkLabel);
            this.Controls.Add(this.layoutsListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.createLayoutButton);
            this.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.Name = "MainLayoutForm";
            this.Text = "Layouts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createLayoutButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox layoutsListBox;
        private System.Windows.Forms.LinkLabel deleteLinkLabel;
        private System.Windows.Forms.LinkLabel editLinkLabel;
        private System.Windows.Forms.CheckBox OnlyClossedAppsCheckBox;
    }
}

