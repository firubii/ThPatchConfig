using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ThPatchConfig
{
    public enum RepositoryType
    {
        Online,
        Local
    }

    public struct Repository
    {
        public RepositoryType RepoType;
        public string Contact;
        public string Id;
        public string[] Neighbors;
        public Dictionary<string, string> Patches;
        public string[] Servers;
        public string Title;
        public string UrlDesc;
    }

    public struct Patch
    {
        public string Id;
        public string Title;
        public string[] Dependencies;
        public bool Update;
        public string[] Servers;
    }

    public struct PatchConfig
    {
        public string Name;
        public bool Console;
        public bool DatDump;
        public string[] Patches;
    }

    public struct Config
    {
        public bool BackgroundUpdates;
        public bool SkipCheckMsg;
        public int TimeBetweenUpdates;
        public bool UpdateAtExit;
        public bool UpdateOthers;
    }

    public partial class MainForm : Form
    {
        List<Repository> repos;
        List<PatchConfig> configs;
        Dictionary<string, string> games;
        ProgressWindow progress;
        string workingDir;

        List<string> parsedRepos;

        public MainForm(string dir)
        {
            repos = new List<Repository>();
            configs = new List<PatchConfig>();
            games = new Dictionary<string, string>();
            parsedRepos = new List<string>();
            progress = new ProgressWindow();
            workingDir = dir;
            InitializeComponent();

            tabControl1_Selected(null, new TabControlEventArgs(tabControl1.TabPages[0], 0, TabControlAction.Selected));
        }

        private void MainForm_Load(object sender, EventArgs e) { }

        void DownloadRepoList(string url)
        {
            using (WebClient client = new WebClient())
            {
                string repoJson;

                try { repoJson = client.DownloadString(url.TrimEnd('/') + "/repo.js"); }
                catch { MessageBox.Show($"Error: Repository at \"{url}\" has no repo.js file.", this.Text, MessageBoxButtons.OK); return; }

                JObject json;
                try { json = JObject.Parse(repoJson); }
                catch { MessageBox.Show($"Error: Could not parse repo.js of repository at \"{url}\".", this.Text, MessageBoxButtons.OK); return; }

                parsedRepos.Add(url.TrimEnd('/'));

                Repository r = new Repository();
                r.Title = json["title"].Value<string>();
                r.RepoType = RepositoryType.Online;

                r.Contact = json["contact"].Value<string>();
                r.Id = json["id"].Value<string>();

                if (!Directory.Exists(workingDir + "\\repos\\" + r.Id))
                    Directory.CreateDirectory(workingDir + "\\repos\\" + r.Id);
                if (!File.Exists(workingDir + "\\repos\\" + r.Id + "\\repo.js"))
                    File.WriteAllText(workingDir + "\\repos\\" + r.Id + "\\repo.js", repoJson);

                List<string> neighbors = new List<string>();
                if (json.ContainsKey("neighbors"))
                {
                    JArray neighborList = json["neighbors"].Value<JArray>();
                    for (int i = 0; i < neighborList.Count; i++)
                    {
                        neighbors.Add(neighborList[i].Value<string>());
                    }
                    neighborList.RemoveAll();
                }
                r.Neighbors = neighbors.ToArray();

                JObject patchList = json["patches"].Value<JObject>();
                Dictionary<string, string> patches = new Dictionary<string, string>();
                foreach (JProperty prop in patchList.Children())
                {
                    patches.Add(prop.Name, (string)prop.Value);
                }
                r.Patches = patches;
                patchList.RemoveAll();

                JArray serverList = json["servers"].Value<JArray>();
                List<string> servers = new List<string>();
                for (int i = 0; i < serverList.Count; i++)
                {
                    servers.Add(serverList[i].Value<string>());
                }
                r.Servers = servers.ToArray();
                serverList.RemoveAll();

                repos.Add(r);

                json.RemoveAll();

                for (int i = 0; i < r.Neighbors.Length; i++)
                {
                    if (!parsedRepos.Contains(r.Neighbors[i].TrimEnd('/')))
                        DownloadRepoList(r.Neighbors[i]);
                }
            }
        }

        void UpdateRepoList()
        {
            repoTreeView.Nodes.Clear();
            repoTreeView.BeginUpdate();
            for (int i = 0; i < repos.Count; i++)
            {
                TreeNode r = new TreeNode();
                r.Text = $"[{repos[i].Id}] {repos[i].Title}";
                r.ContextMenuStrip = repoMenuStrip;

                if (repos[i].RepoType == RepositoryType.Online)
                {
                    r.ImageIndex = 0;
                    r.SelectedImageIndex = 0;
                }
                else
                {
                    r.ImageIndex = 1;
                    r.SelectedImageIndex = 1;
                }

                foreach (KeyValuePair<string, string> pair in repos[i].Patches)
                {
                    TreeNode p = new TreeNode();
                    p.Text = pair.Key;
                    p.ImageIndex = 2;
                    p.SelectedImageIndex = 2;
                    r.Nodes.Add(p);
                }
                repoTreeView.Nodes.Add(r);
            }
            repoTreeView.EndUpdate();
        }

        Patch DownloadPatchInformation(Repository repo, string patchId)
        {
            Patch p = new Patch();

            using (WebClient client = new WebClient())
            {
                progress.SetProgressText($"Downloading patch information of {patchId}...");

                string patchJson;

                try { patchJson = client.DownloadString($"{repo.Servers[0].TrimEnd('/')}/{patchId}/patch.js"); }
                catch { MessageBox.Show($"Error: Repository at \"{repo.Servers[0]}\" has no patch.js file.", this.Text, MessageBoxButtons.OK); return p; }

                JObject json;
                try { json = JObject.Parse(patchJson); }
                catch { MessageBox.Show($"Error: Could not parse patch.js of repository at \"{repo.Servers[0]}\".", this.Text, MessageBoxButtons.OK); return p; }
                
                p.Id = json["id"].Value<string>();
                p.Title = json["title"].Value<string>();

                if (json.ContainsKey("update"))
                    p.Update = json["update"].Value<bool>();
                
                if (!Directory.Exists(workingDir + "\\repos\\" + repo.Id + "\\" + patchId))
                    Directory.CreateDirectory(workingDir + "\\repos\\" + repo.Id + "\\" + patchId);
                if (!File.Exists(workingDir + "\\repos\\" + repo.Id + "\\" + patchId + "\\patch.js"))
                    File.WriteAllText(workingDir + "\\repos\\" + repo.Id + "\\" + patchId + "\\patch.js", patchJson);

                List<string> depends = new List<string>();
                if (json.ContainsKey("dependencies"))
                {
                    JArray dependList = json["dependencies"].Value<JArray>();
                    for (int i = 0; i < dependList.Count; i++)
                    {
                        depends.Add(dependList[i].Value<string>());
                    }
                    dependList.RemoveAll();
                }
                p.Dependencies = depends.ToArray();

                JArray serverList = json["servers"].Value<JArray>();
                List<string> servers = new List<string>();
                for (int i = 0; i < serverList.Count; i++)
                {
                    servers.Add(serverList[i].Value<string>());
                }
                p.Servers = servers.ToArray();
                serverList.RemoveAll();

                json.RemoveAll();

                for (int i = 0; i < p.Dependencies.Length; i++)
                {
                    if (p.Dependencies[i].Contains('/'))
                    {
                        string[] depend = p.Dependencies[i].Split('/');
                        DownloadPatchInformation(repos.Find(x => x.Id == depend[0]), depend[1]);
                    }
                    else
                    {
                        DownloadPatchInformation(repo, p.Dependencies[i]);
                    }
                }
            }

            return p;
        }

        void DownloadPatch(Repository repo, string patchId)
        {
            Patch p = DownloadPatchInformation(repo, patchId);

            //Download dependencies first
            for (int i = 0; i < p.Dependencies.Length; i++)
            {
                string[] depend = p.Dependencies[i].Split('/');
                DownloadPatch(repos.Find(x => x.Id == depend[0]), depend[1]);
            }

            using (WebClient client = new WebClient())
            {
                string filesJson;

                try { filesJson = client.DownloadString($"{p.Servers[0].TrimEnd('/')}/files.js"); }
                catch { MessageBox.Show($"Error: Repository at \"{p.Servers[0]}\" has no files.js file.", this.Text, MessageBoxButtons.OK); return; }

                JObject json;
                try { json = JObject.Parse(filesJson); }
                catch { MessageBox.Show($"Error: Could not parse files.js of repository at \"{p.Servers[0]}\".", this.Text, MessageBoxButtons.OK); return; }

                string patchDir = workingDir + "\\repos\\" + repo.Id + "\\" + patchId;
                if (!Directory.Exists(patchDir))
                    Directory.CreateDirectory(patchDir);
                if (!File.Exists(patchDir + "\\files.js"))
                    File.WriteAllText(patchDir + "\\files.js", filesJson);

                /*int prog = 0;
                progress.SetProgressText($"Downloading patch {patchId}...");
                progress.SetProgressMax(json.Children().Count());
                foreach (JProperty prop in json.Children<JProperty>())
                {
                    if (!Directory.Exists(Path.GetDirectoryName(patchDir + "\\" + prop.Name.Replace('/', '\\'))))
                        Directory.CreateDirectory(Path.GetDirectoryName(patchDir + "\\" + prop.Name.Replace('/', '\\')));

                    try { client.DownloadFile($"{p.Servers[0].TrimEnd('/')}/{prop.Name}", patchDir + "\\" + prop.Name.Replace('/', '\\')); }
                    catch { }

                    prog++;
                    progress.SetProgress(prog);
                }*/
            }
        }

        private void repoTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (repoTreeView.SelectedNode.Parent != null)
            {
                int r = repoTreeView.SelectedNode.Parent.Index;
                int index = repoTreeView.SelectedNode.Index;

                patchTitle.Text = repos[r].Patches.Keys.ElementAt(index);
                patchDesc.Text = repos[r].Patches[patchTitle.Text];
                authContact.Text = repos[r].Contact;
                patchServer.Lines = repos[r].Servers;
            }
        }

        private void updateRepoButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            updateRepoButton.Enabled = false;
            DownloadRepoList("https://srv.thpatch.net");
            UpdateRepoList();

            this.Cursor = Cursors.Arrow;
            this.Enabled = true;
        }

        private void dlPatch_Click(object sender, EventArgs e)
        {
            if (repoTreeView.SelectedNode != null)
            {
                if (repoTreeView.SelectedNode.Parent != null)
                {
                    int r = repoTreeView.SelectedNode.Parent.Index;
                    int index = repoTreeView.SelectedNode.Index;

                    this.Cursor = Cursors.WaitCursor;
                    this.Enabled = false;

                    DownloadPatchInformation(repos[r], repos[r].Patches.Keys.ElementAt(index));

                    this.Cursor = Cursors.Arrow;
                    this.Enabled = true;
                }
            }
        }

        void LoadConfigs()
        {
            configs.Clear();
            if (Directory.Exists(workingDir + "\\config"))
            {
                string[] files = Directory.GetFiles(workingDir + "\\config", "*.js");
                for (int i = 0; i < files.Length; i++)
                {
                    if (Path.GetFileName(files[i]) == "config.js" || Path.GetFileName(files[i]) == "games.js")
                        continue;

                    PatchConfig config = new PatchConfig();

                    JObject json = JObject.Parse(File.ReadAllText(files[i]));

                    config.Name = Path.GetFileNameWithoutExtension(files[i]);
                    config.Console = json["console"].Value<bool>();
                    config.DatDump = json["dat_dump"].Value<bool>();

                    List<string> patchList = new List<string>();
                    JArray patches = json["patches"].Value<JArray>();
                    foreach (JObject o in patches.Children<JObject>())
                    {
                        patchList.Add(o["archive"].Value<string>());
                    }
                    config.Patches = patchList.ToArray();

                    configs.Add(config);
                }
            }
        }

        void UpdateConfigList()
        {
            configList.Items.Clear();
            configList.BeginUpdate();
            for (int i = 0; i < configs.Count; i++)
            {
                configList.Items.Add(configs[i].Name);
            }
            configList.EndUpdate();
        }

        void SaveConfig(PatchConfig config)
        {
            JObject json = new JObject();
            json.Add("console", JToken.FromObject(config.Console));
            json.Add("dat_dump", JToken.FromObject(config.Console));

            JArray patches = new JArray();
            for (int i = 0; i < config.Patches.Length; i++)
            {
                JObject obj = new JObject();
                obj.Add("archive", JToken.FromObject(config.Patches[i]));
                patches.Add(obj);
            }
            json.Add("patches", patches);
            
            using (StreamWriter writer = new StreamWriter(workingDir + "\\config\\" + config.Name + ".js"))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
                {
                    json.WriteTo(jsonWriter);
                }
            }
        }

        void UpdateInstalledPatchesList()
        {
            installedPatches.Items.Clear();

            if (configList.SelectedIndex >= 0)
            {
                PatchConfig c = configs[configList.SelectedIndex];
                for (int i = 0; i < c.Patches.Length; i++)
                {
                    installedPatches.Items.Add(c.Patches[i]);
                }

                configConsole.Checked = c.Console;
                configDump.Checked = c.DatDump;
            }
        }

        void LoadGames()
        {
            games.Clear();
            if (File.Exists(workingDir + "\\config\\games.js"))
            {
                JObject json = JObject.Parse(File.ReadAllText(workingDir + "\\config\\games.js"));
                foreach (JProperty prop in json.Children<JProperty>())
                {
                    games.Add(prop.Name, (string)prop.Value);
                }
            }
        }

        void SaveGameList()
        {
            var sortedGames = games.OrderBy(x => x.Key);

            JObject json = new JObject();
            foreach (KeyValuePair<string, string> pair in sortedGames)
            {
                json.Add(pair.Key, pair.Value);
            }

            using (StreamWriter writer = new StreamWriter(workingDir + "\\config\\games.js"))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
                {
                    json.WriteTo(jsonWriter);
                }
            }
        }

        void UpdateGameList()
        {
            gameListView.Items.Clear();
            gameListView.BeginUpdate();

            launcherImageList.Images.Clear();
            foreach (KeyValuePair<string, string> pair in games)
            {
                if (!File.Exists(pair.Value))
                {
                    MessageBox.Show($"Error: Game \"{pair.Key}\" does not exist at given path:\n\"{pair.Value}\"", this.Text, MessageBoxButtons.OK);
                    continue;
                }
                else if (Path.GetExtension(pair.Value).ToLower() != ".exe")
                {
                    MessageBox.Show($"Error: Game \"{pair.Key}\" is not an executable at given path:\n\"{pair.Value}\"", this.Text, MessageBoxButtons.OK);
                    continue;
                }

                launcherImageList.Images.Add(Icon.ExtractAssociatedIcon(pair.Value));

                ListViewItem item = new ListViewItem();
                item.Text = pair.Key;
                item.ImageIndex = launcherImageList.Images.Count - 1;
                item.ToolTipText = pair.Value;
                
                if (Path.GetFileName(pair.Value) == "custom.exe")
                {
                    item.Group = gameListView.Groups[1];
                }
                else
                {
                    item.Group = gameListView.Groups[0];
                }
                gameListView.Items.Add(item);
            }
            gameListView.EndUpdate();
        }

        void UpdateThpatchSettings()
        {
            if (File.Exists(workingDir + "\\config\\config.js"))
            {
                JObject json = JObject.Parse(File.ReadAllText(workingDir + "\\config\\config.js"));
                bgUpd.Checked = json["background_updates"].Value<bool>();
                skipCheckMbox.Checked = json["skip_check_mbox"].Value<bool>();
                timeBtwUpd.Value = json["time_between_updates"].Value<int>();
                updAtExit.Checked = json["update_at_exit"].Value<bool>();
                updOther.Checked = json["update_others"].Value<bool>();
            }
        }

        void SaveThpatchSettings()
        {
            JObject json = new JObject();
            json.Add("background_updates", JToken.FromObject(bgUpd.Checked));
            json.Add("skip_check_mbox", JToken.FromObject(skipCheckMbox.Checked));
            json.Add("time_between_updates", JToken.FromObject((int)timeBtwUpd.Value));
            json.Add("update_at_exit", JToken.FromObject(updAtExit.Checked));
            json.Add("update_others", JToken.FromObject(updOther.Checked));

            using (StreamWriter writer = new StreamWriter(workingDir + "\\config\\config.js"))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
                {
                    json.WriteTo(jsonWriter);
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    LoadGames();
                    UpdateGameList();
                    break;
                case 1:
                    LoadConfigs();
                    UpdateConfigList();
                    break;
                case 3:
                    UpdateThpatchSettings();
                    break;
                default:
                    break;
            }
        }

        private void configList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInstalledPatchesList();
        }

        private void mvUp_Click(object sender, EventArgs e)
        {
            int index = installedPatches.SelectedIndex;
            if (index > 0)
            {
                PatchConfig c = configs[configList.SelectedIndex];
                string p = c.Patches[index];
                List<string> patches = c.Patches.ToList();

                patches.RemoveAt(index);
                patches.Insert(index - 1, p);

                c.Patches = patches.ToArray();
                configs[configList.SelectedIndex] = c;
                UpdateInstalledPatchesList();

                installedPatches.SelectedIndex = index - 1;

                SaveConfig(configs[configList.SelectedIndex]);
            }
        }

        private void mvDown_Click(object sender, EventArgs e)
        {
            int index = installedPatches.SelectedIndex;
            if (index < installedPatches.Items.Count - 1)
            {
                PatchConfig c = configs[configList.SelectedIndex];
                string p = c.Patches[index];
                List<string> patches = c.Patches.ToList();

                patches.RemoveAt(index);
                patches.Insert(index + 1, p);

                c.Patches = patches.ToArray();
                configs[configList.SelectedIndex] = c;
                UpdateInstalledPatchesList();

                installedPatches.SelectedIndex = index + 1;

                SaveConfig(configs[configList.SelectedIndex]);
            }
        }

        private void mvTop_Click(object sender, EventArgs e)
        {
            int index = installedPatches.SelectedIndex;
            PatchConfig c = configs[configList.SelectedIndex];
            string p = c.Patches[index];
            List<string> patches = c.Patches.ToList();

            patches.RemoveAt(index);
            patches.Insert(0, p);

            c.Patches = patches.ToArray();
            configs[configList.SelectedIndex] = c;
            UpdateInstalledPatchesList();

            installedPatches.SelectedIndex = 0;

            SaveConfig(configs[configList.SelectedIndex]);
        }

        private void mvBot_Click(object sender, EventArgs e)
        {
            int index = installedPatches.SelectedIndex;
            PatchConfig c = configs[configList.SelectedIndex];
            string p = c.Patches[index];
            List<string> patches = c.Patches.ToList();

            patches.RemoveAt(index);
            patches.Add(p);

            c.Patches = patches.ToArray();
            configs[configList.SelectedIndex] = c;
            UpdateInstalledPatchesList();

            installedPatches.SelectedIndex = installedPatches.Items.Count - 1;

            SaveConfig(configs[configList.SelectedIndex]);
        }

        private void addPatch_Click(object sender, EventArgs e)
        {
            PatchPicker patchPicker = new PatchPicker(workingDir);
            if (patchPicker.ShowDialog() == DialogResult.OK)
            {
                PatchConfig c = configs[configList.SelectedIndex];
                List<string> patches = c.Patches.ToList();
                
                for (int i = 0; i < patchPicker.dependencies.Length; i++)
                {
                    if (!patches.Contains(patchPicker.dependencies[i]))
                        patches.Add(patchPicker.dependencies[i]);
                }

                if (!patches.Contains(patchPicker.path))
                    patches.Add(patchPicker.path);

                c.Patches = patches.ToArray();

                configs[configList.SelectedIndex] = c;
                UpdateInstalledPatchesList();

                SaveConfig(configs[configList.SelectedIndex]);
            }
        }

        private void delPatch_Click(object sender, EventArgs e)
        {
            int index = installedPatches.SelectedIndex;
            PatchConfig c = configs[configList.SelectedIndex];
            List<string> patches = c.Patches.ToList();

            patches.RemoveAt(index);
            c.Patches = patches.ToArray();

            configs[configList.SelectedIndex] = c;
            UpdateInstalledPatchesList();

            if (index >= c.Patches.Length)
            {
                installedPatches.SelectedIndex = c.Patches.Length - 1;
            }

            SaveConfig(configs[configList.SelectedIndex]);
        }

        private void configConsole_CheckedChanged(object sender, EventArgs e)
        {
            int index = configList.SelectedIndex;
            PatchConfig c = configs[index];

            c.Console = configConsole.Checked;

            configs[index] = c;

            SaveConfig(configs[index]);
        }

        private void configDump_CheckedChanged(object sender, EventArgs e)
        {
            int index = configList.SelectedIndex;
            PatchConfig c = configs[index];

            c.DatDump = configDump.Checked;

            configs[index] = c;

            SaveConfig(configs[index]);
        }

        private void createConfig_Click(object sender, EventArgs e)
        {
            PatchConfig c = new PatchConfig();
            c.Name = "new config";
            c.Console = false;
            c.DatDump = false;
            c.Patches = new string[] { };

            SaveConfig(c);
            configs.Add(c);
            
            UpdateConfigList();
        }

        private void delConfig_Click(object sender, EventArgs e)
        {
            int index = configList.SelectedIndex;

            if (MessageBox.Show($"Are you sure you want to delete {configs[index].Name}?\nThis cannot be undone.", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(workingDir + "\\config\\" + configs[index].Name + ".js");
                configs.RemoveAt(index);

                UpdateConfigList();

                if (index >= configs.Count)
                {
                    configList.SelectedIndex = configs.Count - 1;
                }
            }
        }

        private void nameConfig_Click(object sender, EventArgs e)
        {
            int index = configList.SelectedIndex;
            PatchConfig c = configs[index];
            RenameWindow rename = new RenameWindow(c.Name);
            if (rename.ShowDialog() == DialogResult.OK)
            {
                File.Move(workingDir + "\\config\\" + c.Name + ".js", workingDir + "\\config\\" + rename.newName + ".js");
                c.Name = rename.newName;

                configs[index] = c;
                UpdateConfigList();

                configList.SelectedIndex = index;
            }
        }

        private void dlAll_Click(object sender, EventArgs e)
        {
            if (repoTreeView.SelectedNode.Parent == null)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                int index = repoTreeView.SelectedNode.Index;

                foreach (KeyValuePair<string, string> pair in repos[index].Patches)
                {
                    DownloadPatchInformation(repos[index], pair.Key);
                }

                this.Cursor = Cursors.Arrow;
                this.Enabled = true;
            }
        }

        private void updateExtRepo_Click(object sender, EventArgs e)
        {
            if (extRepo.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                DownloadRepoList(extRepo.Text);
                UpdateRepoList();

                this.Cursor = Cursors.Arrow;
                this.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error: URL cannot be empty.", this.Text, MessageBoxButtons.OK);
            }
        }

        private void ThPatchSettingChanged(object sender, EventArgs e)
        {
            SaveThpatchSettings();
        }

        private void gameListView_DoubleClick(object sender, EventArgs e)
        {
            int index = gameListView.SelectedIndices[0];
            List<string> configNames = new List<string>();
            for (int i = 0; i < configs.Count; i++)
            {
                configNames.Add(configs[i].Name);
            }
            ConfigPicker configSel = new ConfigPicker(workingDir + "\\config");
            if (configSel.ShowDialog() == DialogResult.OK)
            {
                if (configSel.config != "(None)")
                {
                    Process.Start(workingDir + "\\thcrap_loader.exe", $"\"{configSel.config}.js\" \"{games.Keys.ElementAt(index)}\"");
                }
                else
                {
                    Process.Start(games.Values.ElementAt(index));
                }
            }
        }

        private void addGame_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select Touhou game or custom executable";
            open.Filter = "Executable Files|*.exe";
            open.InitialDirectory = Path.GetDirectoryName(workingDir);
            open.CheckFileExists = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                string formattedPath = open.FileName.Replace('\\', '/');
                if (games.Values.Contains(formattedPath) || games.Keys.Contains(Path.GetFileNameWithoutExtension(open.FileName)))
                {
                    MessageBox.Show("This game has already been added.", this.Text, MessageBoxButtons.OK);
                    return;
                }

                if (Path.GetFileName(open.FileName) == "custom.exe")
                {
                    string[] thExe = Directory.GetFiles(Path.GetDirectoryName(open.FileName), "th*.exe", SearchOption.TopDirectoryOnly);
                    if (thExe.Length == 0)
                    {
                        MessageBox.Show("Error: No Touhou game found alongside this custom.exe.", this.Text, MessageBoxButtons.OK);
                        return;
                    }
                    games.Add(Path.GetFileNameWithoutExtension(thExe[0]) + "_custom", formattedPath);
                }
                else
                {
                    games.Add(Path.GetFileNameWithoutExtension(open.FileName), formattedPath);
                }

                SaveGameList();
                UpdateGameList();
            }
        }

        private void remGame_Click(object sender, EventArgs e)
        {
            if (gameListView.SelectedIndices.Count > 0)
            {
                int index = gameListView.SelectedIndices[0];

                games.Remove(games.Keys.ElementAt(index));

                SaveGameList();
                UpdateGameList();
            }
        }

        private void scanGame_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.SelectedPath = workingDir;
            open.ShowNewFolderButton = false;
            open.Description = "Select folder to scan from";
            if (open.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                //Download nmlgc version jsons for hash matching if they aren't already downloaded
                //Will check files.js later I'm not up for doing that rn
                JObject json;

                if (!File.Exists(workingDir + "\\repos\\nmlgc\\base_tsa\\versions.js"))
                {
                    using (WebClient client = new WebClient())
                        client.DownloadFile("https://mirrors.thpatch.net/nmlgc/base_tsa/versions.js", workingDir + "\\repos\\nmlgc\\base_tsa\\versions.js");
                }
                if (!File.Exists(workingDir + "\\repos\\nmlgc\\base_tasofro\\versions.js"))
                {
                    using (WebClient client = new WebClient())
                        client.DownloadFile("https://mirrors.thpatch.net/nmlgc/base_tasofro/versions.js", workingDir + "\\repos\\nmlgc\\base_tasofro\\versions.js");
                }

                List<byte[]> exeHashes = new List<byte[]>();

                //Compile list of all hashes

                json = JObject.Parse(File.ReadAllText(workingDir + "\\repos\\nmlgc\\base_tsa\\versions.js"));
                JObject h = json["hashes"].Value<JObject>();
                foreach (JProperty prop in h.Children<JProperty>())
                {
                    byte[] buffer = new byte[32];
                    for (int i = 0; i < 32; i++)
                    {
                        buffer[i] = byte.Parse(""+prop.Name[i * 2] + prop.Name[i * 2 + 1], System.Globalization.NumberStyles.HexNumber);
                    }
                    exeHashes.Add(buffer);
                }

                json = JObject.Parse(File.ReadAllText(workingDir + "\\repos\\nmlgc\\base_tasofro\\versions.js"));
                h = json["hashes"].Value<JObject>();
                foreach (JProperty prop in h.Children<JProperty>())
                {
                    byte[] buffer = new byte[32];
                    for (int i = 0; i < 32; i++)
                    {
                        buffer[i] = byte.Parse("" + prop.Name[i * 2] + prop.Name[i * 2 + 1], System.Globalization.NumberStyles.HexNumber);
                    }
                    exeHashes.Add(buffer);
                }

                //Search for all valid files, by specific file names in order to reduce scan time

                List<string> searchResults = new List<string>();
                searchResults.AddRange(Directory.GetFiles(open.SelectedPath, "th*.exe", SearchOption.AllDirectories));
                searchResults.AddRange(Directory.GetFiles(open.SelectedPath, "東方紅魔郷.exe", SearchOption.AllDirectories));
                searchResults.AddRange(Directory.GetFiles(open.SelectedPath, "alcostg.exe", SearchOption.AllDirectories));
                searchResults.AddRange(Directory.GetFiles(open.SelectedPath, "megamari.exe", SearchOption.AllDirectories));
                searchResults.AddRange(Directory.GetFiles(open.SelectedPath, "marilega.exe", SearchOption.AllDirectories));
                searchResults.AddRange(Directory.GetFiles(open.SelectedPath, "6kinoko.exe", SearchOption.AllDirectories));

                SHA256 sha256 = SHA256.Create();

                for (int i = 0; i < searchResults.Count; i++)
                {
                    //Console.WriteLine("Processing " + searchResults[i]);
                    string formattedPath = searchResults[i].Replace('\\', '/');
                    if (!games.Values.Contains(formattedPath) && !games.Keys.Contains(Path.GetFileNameWithoutExtension(searchResults[i])))
                    {
                        byte[] fileHash;
                        using (FileStream stream = new FileStream(searchResults[i], FileMode.Open))
                            fileHash = sha256.ComputeHash(stream);

                        /*Console.Write("File SHA256 Hash: ");
                        for (int b = 0; b < fileHash.Length; b++)
                        {
                            Console.Write(fileHash[b].ToString("X2").ToLower());
                        }
                        Console.Write("\n");*/

                        //There's probably a better way to do this
                        for (int b = 0; b < exeHashes.Count; b++)
                        {
                            if (exeHashes[b].SequenceEqual(fileHash))
                            {
                                string name = Path.GetFileNameWithoutExtension(searchResults[i]);
                                if (name == "東方紅魔郷")
                                {
                                    name = "th06";
                                    if (File.Exists(Path.GetDirectoryName(searchResults[i]) + "\\vpatch.exe"))
                                    {
                                        games.Add(name, (Path.GetDirectoryName(searchResults[i]) + "\\vpatch.exe").Replace('\\','/'));
                                        break;
                                    }
                                }
                                else if (name == "6kinoko")
                                {
                                    name = "nsml";
                                }

                                games.Add(name, formattedPath);
                                break;
                            }
                        }
                    }
                    //else Console.WriteLine("Already exists, skipping");

                    if (Path.GetFileName(searchResults[i]).StartsWith("th") || Path.GetFileName(searchResults[i]) == "東方紅魔郷.exe")
                    {
                        formattedPath = (Path.GetDirectoryName(searchResults[i]) + "\\custom.exe").Replace('\\', '/');

                        //Console.WriteLine("Attempting to find custom.exe at " + Path.GetDirectoryName(searchResults[i]) + "\\custom.exe");
                        if (File.Exists(Path.GetDirectoryName(searchResults[i]) + "\\custom.exe"))
                        {
                            //Console.WriteLine("Found custom.exe");
                            if (!games.Values.Contains(formattedPath) && !games.Keys.Contains(Path.GetDirectoryName(searchResults[i]) + "\\custom.exe"))
                            {
                                byte[] fileHash;
                                using (FileStream stream = new FileStream(Path.GetDirectoryName(searchResults[i]) + "\\custom.exe", FileMode.Open))
                                    fileHash = sha256.ComputeHash(stream);

                                /*Console.Write("File SHA256 Hash: ");
                                for (int b = 0; b < fileHash.Length; b++)
                                {
                                    Console.Write(fileHash[b].ToString("X2").ToLower());
                                }
                                Console.Write("\n");*/

                                //There's probably a better way to do this
                                for (int b = 0; b < exeHashes.Count; b++)
                                {
                                    if (exeHashes[b].SequenceEqual(fileHash))
                                    {
                                        string name = Path.GetFileNameWithoutExtension(searchResults[i]) + "_custom";
                                        if (Path.GetFileName(searchResults[i]) == "東方紅魔郷.exe")
                                            name = "th06_custom";

                                        games.Add(name, formattedPath);
                                        break;
                                    }
                                }
                            }
                            //else Console.WriteLine("Already exists, skipping");
                        }
                    }
                }

                this.Cursor = Cursors.Arrow;
                this.Enabled = true;

                MessageBox.Show("Game scan complete.", this.Text, MessageBoxButtons.OK);

                SaveGameList();
                UpdateGameList();
            }
        }

        string DetectThCrap(string dir)
        {
            string d = dir;
            if (!File.Exists(dir + "\\bin\\thcrap_loader.exe"))
            {
                if (MessageBox.Show("Could not detect thcrap in this directory." +
                                 "\nWould you like to select a different directory?" +
                               "\n\nThis folder would be the root folder, where the folders \"bin\", \"config\", and \"repos\" are.",
                                    "ThPatch Config", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FolderBrowserDialog open = new FolderBrowserDialog();
                    open.SelectedPath = dir;
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        d = DetectThCrap(open.SelectedPath);
                    }
                    else
                    {
                        d = workingDir;
                    }
                }
                else
                {
                    d = workingDir;
                }
            }
            return d;
        }

        private void changeWorkingDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.SelectedPath = workingDir;
            if (open.ShowDialog() == DialogResult.OK)
            {
                workingDir = DetectThCrap(open.SelectedPath);

                File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\workingdir.txt", workingDir);
            }
        }
    }
}
