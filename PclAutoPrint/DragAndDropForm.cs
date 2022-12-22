﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PclAutoPrint {
    public partial class DragAndDropForm : Form {
        public DragAndDropForm() {
            InitializeComponent();
        }

        private void labelDropTarget_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void labelDropTarget_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) FilePrinter.PrintOneFile(file, !checkBox1.Checked);
        }
    }
}