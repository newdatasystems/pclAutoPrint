namespace PclAutoPrint {
    partial class DragAndDropForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DragAndDropForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDropTarget = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelMonitor = new System.Windows.Forms.Label();
            this.pictureSettings = new System.Windows.Forms.PictureBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.labelVersion);
            this.panel1.Controls.Add(this.labelDropTarget);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 380);
            this.panel1.TabIndex = 0;
            // 
            // labelDropTarget
            // 
            this.labelDropTarget.AllowDrop = true;
            this.labelDropTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDropTarget.Location = new System.Drawing.Point(0, 0);
            this.labelDropTarget.Name = "labelDropTarget";
            this.labelDropTarget.Size = new System.Drawing.Size(592, 380);
            this.labelDropTarget.TabIndex = 1;
            this.labelDropTarget.Text = "Drag files here to send to printer";
            this.labelDropTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDropTarget.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDropTarget_DragDrop);
            this.labelDropTarget.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDropTarget_DragEnter);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(357, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(188, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Prompt to delete files after printing.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // labelMonitor
            // 
            this.labelMonitor.AutoSize = true;
            this.labelMonitor.Location = new System.Drawing.Point(3, 5);
            this.labelMonitor.Name = "labelMonitor";
            this.labelMonitor.Size = new System.Drawing.Size(90, 13);
            this.labelMonitor.TabIndex = 3;
            this.labelMonitor.Text = "Monitor turned off";
            // 
            // pictureSettings
            // 
            this.pictureSettings.AccessibleDescription = "Gear icon for settings changes";
            this.pictureSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureSettings.Image = global::PclAutoPrint.Properties.Resources.settings_png;
            this.pictureSettings.Location = new System.Drawing.Point(562, 5);
            this.pictureSettings.Name = "pictureSettings";
            this.pictureSettings.Size = new System.Drawing.Size(24, 24);
            this.pictureSettings.TabIndex = 3;
            this.pictureSettings.TabStop = false;
            this.pictureSettings.Click += new System.EventHandler(this.pictureSettings_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.Location = new System.Drawing.Point(499, 363);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(90, 13);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "v1.1.1.1";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DragAndDropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 403);
            this.Controls.Add(this.pictureSettings);
            this.Controls.Add(this.labelMonitor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DragAndDropForm";
            this.Text = "PCL Auto Printer";
            this.Click += new System.EventHandler(this.pictureSettings_Click);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDropTarget;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label labelMonitor;
        private System.Windows.Forms.PictureBox pictureSettings;
        private System.Windows.Forms.Label labelVersion;
    }
}