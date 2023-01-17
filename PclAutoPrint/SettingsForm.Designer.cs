﻿namespace PclAutoPrint {
    partial class SettingsForm {
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
            this.labelSelectedPrinter = new System.Windows.Forms.Label();
            this.buttonChangePrinter = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioPrinterPrompt = new System.Windows.Forms.RadioButton();
            this.radioPrinterDefault = new System.Windows.Forms.RadioButton();
            this.radioPrinterSelected = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textUserDelay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkFolderMonitor = new System.Windows.Forms.CheckBox();
            this.checkAutoDelete = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textMonitorFolder = new System.Windows.Forms.TextBox();
            this.buttonFormSave = new System.Windows.Forms.Button();
            this.buttonFormCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSelectedPrinter
            // 
            this.labelSelectedPrinter.AutoSize = true;
            this.labelSelectedPrinter.Location = new System.Drawing.Point(23, 85);
            this.labelSelectedPrinter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectedPrinter.Name = "labelSelectedPrinter";
            this.labelSelectedPrinter.Size = new System.Drawing.Size(125, 16);
            this.labelSelectedPrinter.TabIndex = 3;
            this.labelSelectedPrinter.Text = "(no printer selected)";
            // 
            // buttonChangePrinter
            // 
            this.buttonChangePrinter.Location = new System.Drawing.Point(188, 56);
            this.buttonChangePrinter.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChangePrinter.Name = "buttonChangePrinter";
            this.buttonChangePrinter.Size = new System.Drawing.Size(129, 28);
            this.buttonChangePrinter.TabIndex = 4;
            this.buttonChangePrinter.Text = "Select Printer";
            this.buttonChangePrinter.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonChangePrinter);
            this.panel1.Controls.Add(this.labelSelectedPrinter);
            this.panel1.Controls.Add(this.radioPrinterPrompt);
            this.panel1.Controls.Add(this.radioPrinterDefault);
            this.panel1.Controls.Add(this.radioPrinterSelected);
            this.panel1.Location = new System.Drawing.Point(16, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 117);
            this.panel1.TabIndex = 3;
            // 
            // radioPrinterPrompt
            // 
            this.radioPrinterPrompt.AutoSize = true;
            this.radioPrinterPrompt.Checked = true;
            this.radioPrinterPrompt.Location = new System.Drawing.Point(4, 4);
            this.radioPrinterPrompt.Margin = new System.Windows.Forms.Padding(4);
            this.radioPrinterPrompt.Name = "radioPrinterPrompt";
            this.radioPrinterPrompt.Size = new System.Drawing.Size(161, 20);
            this.radioPrinterPrompt.TabIndex = 4;
            this.radioPrinterPrompt.TabStop = true;
            this.radioPrinterPrompt.Text = "Prompt to select printer";
            this.radioPrinterPrompt.UseVisualStyleBackColor = true;
            // 
            // radioPrinterDefault
            // 
            this.radioPrinterDefault.AutoSize = true;
            this.radioPrinterDefault.Location = new System.Drawing.Point(4, 32);
            this.radioPrinterDefault.Margin = new System.Windows.Forms.Padding(4);
            this.radioPrinterDefault.Name = "radioPrinterDefault";
            this.radioPrinterDefault.Size = new System.Drawing.Size(148, 20);
            this.radioPrinterDefault.TabIndex = 5;
            this.radioPrinterDefault.Text = "Print to default printer";
            this.radioPrinterDefault.UseVisualStyleBackColor = true;
            // 
            // radioPrinterSelected
            // 
            this.radioPrinterSelected.AutoSize = true;
            this.radioPrinterSelected.Location = new System.Drawing.Point(4, 60);
            this.radioPrinterSelected.Margin = new System.Windows.Forms.Padding(4);
            this.radioPrinterSelected.Name = "radioPrinterSelected";
            this.radioPrinterSelected.Size = new System.Drawing.Size(176, 20);
            this.radioPrinterSelected.TabIndex = 6;
            this.radioPrinterSelected.Text = "Always print to this printer:";
            this.radioPrinterSelected.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Printer Selection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Wait";
            // 
            // textUserDelay
            // 
            this.textUserDelay.Location = new System.Drawing.Point(53, 266);
            this.textUserDelay.Name = "textUserDelay";
            this.textUserDelay.Size = new System.Drawing.Size(26, 22);
            this.textUserDelay.TabIndex = 6;
            this.textUserDelay.Text = "0";
            this.textUserDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "seconds before printing.";
            // 
            // checkFolderMonitor
            // 
            this.checkFolderMonitor.AutoSize = true;
            this.checkFolderMonitor.Location = new System.Drawing.Point(20, 179);
            this.checkFolderMonitor.Name = "checkFolderMonitor";
            this.checkFolderMonitor.Size = new System.Drawing.Size(373, 20);
            this.checkFolderMonitor.TabIndex = 8;
            this.checkFolderMonitor.Text = "Monitor this folder for new files and print them automatically:";
            this.checkFolderMonitor.UseVisualStyleBackColor = true;
            // 
            // checkAutoDelete
            // 
            this.checkAutoDelete.AutoSize = true;
            this.checkAutoDelete.Location = new System.Drawing.Point(16, 324);
            this.checkAutoDelete.Name = "checkAutoDelete";
            this.checkAutoDelete.Size = new System.Drawing.Size(241, 20);
            this.checkAutoDelete.TabIndex = 9;
            this.checkAutoDelete.Text = "Delete file when printing is complete.";
            this.checkAutoDelete.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Folder Monitor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 244);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Wait Before Printing";
            // 
            // textMonitorFolder
            // 
            this.textMonitorFolder.Location = new System.Drawing.Point(33, 205);
            this.textMonitorFolder.Name = "textMonitorFolder";
            this.textMonitorFolder.Size = new System.Drawing.Size(360, 22);
            this.textMonitorFolder.TabIndex = 12;
            // 
            // buttonFormSave
            // 
            this.buttonFormSave.Location = new System.Drawing.Point(3, 3);
            this.buttonFormSave.Name = "buttonFormSave";
            this.buttonFormSave.Size = new System.Drawing.Size(75, 28);
            this.buttonFormSave.TabIndex = 13;
            this.buttonFormSave.Text = "Save";
            this.buttonFormSave.UseVisualStyleBackColor = true;
            this.buttonFormSave.Click += new System.EventHandler(this.buttonFormSave_Click);
            // 
            // buttonFormCancel
            // 
            this.buttonFormCancel.Location = new System.Drawing.Point(84, 3);
            this.buttonFormCancel.Name = "buttonFormCancel";
            this.buttonFormCancel.Size = new System.Drawing.Size(75, 28);
            this.buttonFormCancel.TabIndex = 14;
            this.buttonFormCancel.Text = "Cancel";
            this.buttonFormCancel.UseVisualStyleBackColor = true;
            this.buttonFormCancel.Click += new System.EventHandler(this.buttonFormCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonFormCancel);
            this.panel2.Controls.Add(this.buttonFormSave);
            this.panel2.Location = new System.Drawing.Point(131, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 32);
            this.panel2.TabIndex = 15;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 389);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textMonitorFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkAutoDelete);
            this.Controls.Add(this.checkFolderMonitor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textUserDelay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.Text = "Send to PCL Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelSelectedPrinter;
        private System.Windows.Forms.Button buttonChangePrinter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioPrinterPrompt;
        private System.Windows.Forms.RadioButton radioPrinterDefault;
        private System.Windows.Forms.RadioButton radioPrinterSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUserDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkFolderMonitor;
        private System.Windows.Forms.CheckBox checkAutoDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textMonitorFolder;
        private System.Windows.Forms.Button buttonFormSave;
        private System.Windows.Forms.Button buttonFormCancel;
        private System.Windows.Forms.Panel panel2;
    }
}