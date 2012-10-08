using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PackageGenerator.Forms {
    public partial class PackageBeingGeneratredForm : Form {
        public PackageBeingGeneratredForm() {
            InitializeComponent();
        }

        private void PackageBeingGeneratredForm_Load(object sender, EventArgs e) {
            pcPackageGeneration.Rotate = true;
        }

       
    }
}
