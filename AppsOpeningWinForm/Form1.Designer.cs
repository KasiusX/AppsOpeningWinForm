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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.deleteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.editLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // createLayoutButton
            // 
            this.createLayoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.createLayoutButton.Location = new System.Drawing.Point(81, 514);
            this.createLayoutButton.Name = "createLayoutButton";
            this.createLayoutButton.Size = new System.Drawing.Size(246, 78);
            this.createLayoutButton.TabIndex = 0;
            this.createLayoutButton.Text = "Create layout";
            this.createLayoutButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(81, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 78);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load layout";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 37;
            this.listBox1.Location = new System.Drawing.Point(12, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(399, 448);
            this.listBox1.TabIndex = 1;
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
            // MainLayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(423, 698);
            this.Controls.Add(this.editLinkLabel);
            this.Controls.Add(this.deleteLinkLabel);
            this.Controls.Add(this.listBox1);
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
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.LinkLabel deleteLinkLabel;
        private System.Windows.Forms.LinkLabel editLinkLabel;
    }
}

