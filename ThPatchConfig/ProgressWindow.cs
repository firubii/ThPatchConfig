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
    public partial class ProgressWindow : Form
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        async public void SetProgressText(string text)
        {
            await Task.Run(new Action(() => { progressText.Text = text; }));
        }

        async public void SetProgressMax(int max)
        {
            await Task.Run(new Action(() => { progressBar1.Maximum = max; }));
        }

        async public void SetProgress(int value)
        {
            await Task.Run(new Action(() => { progressBar1.Value = value; }));
        }
    }
}
