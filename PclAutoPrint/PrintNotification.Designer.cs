namespace PclAutoPrint {
    partial class PrintNotification {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintNotification));
            this.labelSendingPclFile = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.buttonChangePrinter = new System.Windows.Forms.Button();
            this.buttonFormSave = new System.Windows.Forms.Button();
            this.buttonFormCancel = new System.Windows.Forms.Button();
            this.labelPrinterName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.picturePausePlay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturePausePlay)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSendingPclFile
            // 
            this.labelSendingPclFile.AutoSize = true;
            this.labelSendingPclFile.Location = new System.Drawing.Point(11, 8);
            this.labelSendingPclFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSendingPclFile.Name = "labelSendingPclFile";
            this.labelSendingPclFile.Size = new System.Drawing.Size(185, 20);
            this.labelSendingPclFile.TabIndex = 0;
            this.labelSendingPclFile.Text = "Sending PCL file to printer:";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(12, 29);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(103, 17);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "[No File Selected]";
            // 
            // buttonChangePrinter
            // 
            this.buttonChangePrinter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonChangePrinter.Location = new System.Drawing.Point(12, 58);
            this.buttonChangePrinter.Name = "buttonChangePrinter";
            this.buttonChangePrinter.Size = new System.Drawing.Size(160, 31);
            this.buttonChangePrinter.TabIndex = 2;
            this.buttonChangePrinter.Text = "Change Printer";
            this.buttonChangePrinter.UseVisualStyleBackColor = true;
            this.buttonChangePrinter.Click += new System.EventHandler(this.buttonChangePrinter_Click);
            // 
            // buttonFormSave
            // 
            this.buttonFormSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFormSave.Location = new System.Drawing.Point(356, 58);
            this.buttonFormSave.Name = "buttonFormSave";
            this.buttonFormSave.Size = new System.Drawing.Size(100, 31);
            this.buttonFormSave.TabIndex = 3;
            this.buttonFormSave.Text = "Print";
            this.buttonFormSave.UseVisualStyleBackColor = true;
            this.buttonFormSave.Click += new System.EventHandler(this.buttonFormSave_Click);
            // 
            // buttonFormCancel
            // 
            this.buttonFormCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFormCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonFormCancel.Location = new System.Drawing.Point(462, 58);
            this.buttonFormCancel.Name = "buttonFormCancel";
            this.buttonFormCancel.Size = new System.Drawing.Size(100, 31);
            this.buttonFormCancel.TabIndex = 4;
            this.buttonFormCancel.Text = "Cancel";
            this.buttonFormCancel.UseVisualStyleBackColor = true;
            this.buttonFormCancel.Click += new System.EventHandler(this.buttonFormCancel_Click);
            // 
            // labelPrinterName
            // 
            this.labelPrinterName.AutoSize = true;
            this.labelPrinterName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrinterName.Location = new System.Drawing.Point(203, 10);
            this.labelPrinterName.Name = "labelPrinterName";
            this.labelPrinterName.Size = new System.Drawing.Size(122, 17);
            this.labelPrinterName.TabIndex = 5;
            this.labelPrinterName.Text = "[No Printer Selected]";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerCountdown
            // 
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // picturePausePlay
            // 
            this.picturePausePlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePausePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picturePausePlay.Image = global::PclAutoPrint.Properties.Resources.pause_png;
            this.picturePausePlay.Location = new System.Drawing.Point(546, 11);
            this.picturePausePlay.Name = "picturePausePlay";
            this.picturePausePlay.Size = new System.Drawing.Size(16, 16);
            this.picturePausePlay.TabIndex = 6;
            this.picturePausePlay.TabStop = false;
            this.picturePausePlay.Click += new System.EventHandler(this.picturePausePlay_Click);
            // 
            // PrintNotification
            // 
            this.AcceptButton = this.buttonFormSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonFormCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(574, 96);
            this.Controls.Add(this.picturePausePlay);
            this.Controls.Add(this.labelPrinterName);
            this.Controls.Add(this.buttonFormCancel);
            this.Controls.Add(this.buttonFormSave);
            this.Controls.Add(this.buttonChangePrinter);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.labelSendingPclFile);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PCL Print Notification";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintNotification_FormClosing);
            this.Shown += new System.EventHandler(this.PrintNotification_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picturePausePlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSendingPclFile;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button buttonChangePrinter;
        private System.Windows.Forms.Button buttonFormSave;
        private System.Windows.Forms.Button buttonFormCancel;
        private System.Windows.Forms.Label labelPrinterName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.PictureBox picturePausePlay;
    }
}