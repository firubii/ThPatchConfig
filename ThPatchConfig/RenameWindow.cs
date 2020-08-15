using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThPatchConfig
{
    public partial class RenameWindow : Form
    {
        public string newName;

        public RenameWindow(string name)
        {
            InitializeComponent();
            configName.Text = name;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            newName = configName.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
