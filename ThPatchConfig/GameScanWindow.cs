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
    public partial class GameScanWindow : Form
    {
        string dir;
        public List<string> gamePaths;

        public GameScanWindow(string directory)
        {
            dir = directory;
            gamePaths = new List<string>();
            InitializeComponent();
        }

        private void GameScanWindow_Load(object sender, EventArgs e)
        {
            gamePaths.AddRange(Directory.GetFiles(dir, "th*.exe", SearchOption.AllDirectories));
            gamePaths.AddRange(Directory.GetFiles(dir, "megmari.exe", SearchOption.AllDirectories));
            gamePaths.AddRange(Directory.GetFiles(dir, "nsml.exe", SearchOption.AllDirectories));

            for (int i = 0; i < gamePaths.Count; i++)
            {
                ListViewGroup grp = new ListViewGroup();
                ListViewItem chk = new ListViewItem();
                chk.Checked = true;
                ListViewItem icn = new ListViewItem();
                imageList.Images.Add(Icon.ExtractAssociatedIcon(gamePaths[i]));
                icn.ImageIndex = imageList.Images.Count - 1;
                ListViewItem pth = new ListViewItem();
                pth.Text = gamePaths[i];
                grp.Items.Add(chk);
                grp.Items.Add(icn);
                grp.Items.Add(pth);
                scanListView.Groups.Add(grp);
            }
        }
    }
}
