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
using Newtonsoft.Json.Linq;

namespace ThPatchConfig
{
    public partial class PatchPicker : Form
    {
        public string dir;
        public string path;
        public string[] dependencies;

        public PatchPicker(string directory)
        {
            dir = directory;
            InitializeComponent();
        }

        private void PatchPicker_Load(object sender, EventArgs e)
        {
            patchTree.Nodes.AddRange(FindInstalledPatches());
        }
        
        TreeNode[] FindInstalledPatches()
        {
            List<TreeNode> nodes = new List<TreeNode>();

            string[] repoFiles = Directory.GetFiles(dir, "repo.js", SearchOption.AllDirectories);
            for (int i = 0; i < repoFiles.Length; i++)
            {
                JObject json = JObject.Parse(File.ReadAllText(repoFiles[i]));

                TreeNode r = new TreeNode();
                r.Text = $"[{json["id"].Value<string>()}] {json["title"].Value<string>()}";
                r.ImageIndex = 0;
                r.SelectedImageIndex = 0;

                string[] patchFiles = Directory.GetFiles(Path.GetDirectoryName(repoFiles[i]), "patch.js", SearchOption.AllDirectories);
                for (int c = 0; c < patchFiles.Length; c++)
                {
                    json = JObject.Parse(File.ReadAllText(patchFiles[c]));

                    TreeNode p = new TreeNode();
                    p.Text = json["id"].Value<string>();
                    p.ImageIndex = 1;
                    p.SelectedImageIndex = 1;

                    p.Tag = Path.GetDirectoryName(patchFiles[c]);

                    r.Nodes.Add(p);
                }

                nodes.Add(r);
            }

            return nodes.ToArray();
        }

        private void patchTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            patchPath.Text = (string)patchTree.SelectedNode.Tag;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (patchPath.Text != "")
            {
                path = patchPath.Text;
                if (path.StartsWith(dir))
                {
                    path = path.Remove(0, dir.Length);
                }
                path = path.Replace('\\', '/').TrimStart('/') + "/";

                JObject json = JObject.Parse(File.ReadAllText(patchPath.Text + "\\patch.js"));

                dependencies = new string[] { };
                if (json.ContainsKey("dependencies"))
                {
                    JArray depends = json["dependencies"].Value<JArray>();
                    dependencies = new string[depends.Children().Count()];
                    for (int i = 0; i < depends.Children().Count(); i++)
                    {
                        dependencies[i] = "repos/" + depends[i].Value<string>() + "/";
                    }
                }

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error: Path cannot be empty.", "ThPatch Config", MessageBoxButtons.OK);
            }
        }
    }
}
