using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ThPatchConfig
{
    public partial class ConfigPicker : Form
    {
        string dir;
        public string config;

        public ConfigPicker(string directory)
        {
            dir = directory;
            InitializeComponent();
        }

        private void ConfigPicker_Load(object sender, EventArgs e)
        {
            configDropDown.SelectedIndex = 0;
            FindConfigs();
        }

        void FindConfigs()
        {
            List<string> files = Directory.GetFiles(dir, "*.js").ToList();
            for (int i = 0; i < files.Count; i++)
            {
                files[i] = Path.GetFileNameWithoutExtension(files[i]);
                if (files[i] == "config" || files[i] == "games")
                {
                    files.RemoveAt(i);
                    i--;
                }
            }
            configDropDown.Items.AddRange(files.ToArray());
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            config = (string)configDropDown.SelectedItem;
            DialogResult = DialogResult.OK;
        }
    }
}
