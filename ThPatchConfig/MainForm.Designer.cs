namespace ThPatchConfig
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Games", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Game Settings Editors", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLauncher = new System.Windows.Forms.TabPage();
            this.remGame = new System.Windows.Forms.Button();
            this.scanGame = new System.Windows.Forms.Button();
            this.addGame = new System.Windows.Forms.Button();
            this.gameListView = new System.Windows.Forms.ListView();
            this.launcherImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.Patches = new System.Windows.Forms.GroupBox();
            this.delPatch = new System.Windows.Forms.Button();
            this.addPatch = new System.Windows.Forms.Button();
            this.mvBot = new System.Windows.Forms.Button();
            this.mvTop = new System.Windows.Forms.Button();
            this.mvDown = new System.Windows.Forms.Button();
            this.mvUp = new System.Windows.Forms.Button();
            this.installedPatches = new System.Windows.Forms.ListBox();
            this.configDump = new System.Windows.Forms.CheckBox();
            this.configConsole = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameConfig = new System.Windows.Forms.Button();
            this.delConfig = new System.Windows.Forms.Button();
            this.createConfig = new System.Windows.Forms.Button();
            this.configList = new System.Windows.Forms.ListBox();
            this.tabRepos = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.patchServer = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authContact = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dlPatch = new System.Windows.Forms.Button();
            this.patchDesc = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.patchTitle = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.updateExtRepo = new System.Windows.Forms.Button();
            this.extRepo = new System.Windows.Forms.TextBox();
            this.updateRepoButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.repoTreeView = new System.Windows.Forms.TreeView();
            this.repoImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.timeBtwUpd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.updOther = new System.Windows.Forms.CheckBox();
            this.updAtExit = new System.Windows.Forms.CheckBox();
            this.skipCheckMbox = new System.Windows.Forms.CheckBox();
            this.bgUpd = new System.Windows.Forms.CheckBox();
            this.patchesImageList = new System.Windows.Forms.ImageList(this.components);
            this.repoMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dlAll = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWorkingDir = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabLauncher.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.Patches.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabRepos.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeBtwUpd)).BeginInit();
            this.repoMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLauncher);
            this.tabControl1.Controls.Add(this.tabConfig);
            this.tabControl1.Controls.Add(this.tabRepos);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(717, 590);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabLauncher
            // 
            this.tabLauncher.BackColor = System.Drawing.Color.White;
            this.tabLauncher.Controls.Add(this.remGame);
            this.tabLauncher.Controls.Add(this.scanGame);
            this.tabLauncher.Controls.Add(this.addGame);
            this.tabLauncher.Controls.Add(this.gameListView);
            this.tabLauncher.Location = new System.Drawing.Point(4, 22);
            this.tabLauncher.Name = "tabLauncher";
            this.tabLauncher.Padding = new System.Windows.Forms.Padding(3);
            this.tabLauncher.Size = new System.Drawing.Size(709, 564);
            this.tabLauncher.TabIndex = 0;
            this.tabLauncher.Text = "Launcher";
            // 
            // remGame
            // 
            this.remGame.Location = new System.Drawing.Point(249, 515);
            this.remGame.Name = "remGame";
            this.remGame.Size = new System.Drawing.Size(210, 46);
            this.remGame.TabIndex = 3;
            this.remGame.Text = "Remove Game";
            this.remGame.UseVisualStyleBackColor = true;
            this.remGame.Click += new System.EventHandler(this.remGame_Click);
            // 
            // scanGame
            // 
            this.scanGame.Location = new System.Drawing.Point(496, 515);
            this.scanGame.Name = "scanGame";
            this.scanGame.Size = new System.Drawing.Size(210, 46);
            this.scanGame.TabIndex = 2;
            this.scanGame.Text = "Scan for Games";
            this.scanGame.UseVisualStyleBackColor = true;
            this.scanGame.Click += new System.EventHandler(this.scanGame_Click);
            // 
            // addGame
            // 
            this.addGame.Location = new System.Drawing.Point(3, 515);
            this.addGame.Name = "addGame";
            this.addGame.Size = new System.Drawing.Size(210, 46);
            this.addGame.TabIndex = 1;
            this.addGame.Text = "Add Game";
            this.addGame.UseVisualStyleBackColor = true;
            this.addGame.Click += new System.EventHandler(this.addGame_Click);
            // 
            // gameListView
            // 
            listViewGroup3.Header = "Games";
            listViewGroup3.Name = "gameGroup";
            listViewGroup4.Header = "Game Settings Editors";
            listViewGroup4.Name = "customGroup";
            this.gameListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.gameListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.gameListView.HideSelection = false;
            this.gameListView.LargeImageList = this.launcherImageList;
            this.gameListView.Location = new System.Drawing.Point(3, 3);
            this.gameListView.MultiSelect = false;
            this.gameListView.Name = "gameListView";
            this.gameListView.Size = new System.Drawing.Size(703, 509);
            this.gameListView.TabIndex = 0;
            this.gameListView.TileSize = new System.Drawing.Size(32, 32);
            this.gameListView.UseCompatibleStateImageBehavior = false;
            this.gameListView.DoubleClick += new System.EventHandler(this.gameListView_DoubleClick);
            // 
            // launcherImageList
            // 
            this.launcherImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.launcherImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.launcherImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.Patches);
            this.tabConfig.Controls.Add(this.groupBox1);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(709, 564);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Text = "Config";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // Patches
            // 
            this.Patches.Controls.Add(this.delPatch);
            this.Patches.Controls.Add(this.addPatch);
            this.Patches.Controls.Add(this.mvBot);
            this.Patches.Controls.Add(this.mvTop);
            this.Patches.Controls.Add(this.mvDown);
            this.Patches.Controls.Add(this.mvUp);
            this.Patches.Controls.Add(this.installedPatches);
            this.Patches.Controls.Add(this.configDump);
            this.Patches.Controls.Add(this.configConsole);
            this.Patches.Dock = System.Windows.Forms.DockStyle.Right;
            this.Patches.Location = new System.Drawing.Point(311, 3);
            this.Patches.Name = "Patches";
            this.Patches.Size = new System.Drawing.Size(395, 558);
            this.Patches.TabIndex = 2;
            this.Patches.TabStop = false;
            this.Patches.Text = "Installed Patches";
            // 
            // delPatch
            // 
            this.delPatch.Location = new System.Drawing.Point(286, 199);
            this.delPatch.Name = "delPatch";
            this.delPatch.Size = new System.Drawing.Size(103, 30);
            this.delPatch.TabIndex = 10;
            this.delPatch.Text = "Delete Patch";
            this.delPatch.UseVisualStyleBackColor = true;
            this.delPatch.Click += new System.EventHandler(this.delPatch_Click);
            // 
            // addPatch
            // 
            this.addPatch.Location = new System.Drawing.Point(286, 163);
            this.addPatch.Name = "addPatch";
            this.addPatch.Size = new System.Drawing.Size(103, 30);
            this.addPatch.TabIndex = 9;
            this.addPatch.Text = "Add Patch";
            this.addPatch.UseVisualStyleBackColor = true;
            this.addPatch.Click += new System.EventHandler(this.addPatch_Click);
            // 
            // mvBot
            // 
            this.mvBot.Location = new System.Drawing.Point(286, 127);
            this.mvBot.Name = "mvBot";
            this.mvBot.Size = new System.Drawing.Size(103, 30);
            this.mvBot.TabIndex = 8;
            this.mvBot.Text = "Move To Bottom";
            this.mvBot.UseVisualStyleBackColor = true;
            this.mvBot.Click += new System.EventHandler(this.mvBot_Click);
            // 
            // mvTop
            // 
            this.mvTop.Location = new System.Drawing.Point(286, 91);
            this.mvTop.Name = "mvTop";
            this.mvTop.Size = new System.Drawing.Size(103, 30);
            this.mvTop.TabIndex = 7;
            this.mvTop.Text = "Move To Top";
            this.mvTop.UseVisualStyleBackColor = true;
            this.mvTop.Click += new System.EventHandler(this.mvTop_Click);
            // 
            // mvDown
            // 
            this.mvDown.Location = new System.Drawing.Point(286, 55);
            this.mvDown.Name = "mvDown";
            this.mvDown.Size = new System.Drawing.Size(103, 30);
            this.mvDown.TabIndex = 6;
            this.mvDown.Text = "Move Down";
            this.mvDown.UseVisualStyleBackColor = true;
            this.mvDown.Click += new System.EventHandler(this.mvDown_Click);
            // 
            // mvUp
            // 
            this.mvUp.Location = new System.Drawing.Point(286, 19);
            this.mvUp.Name = "mvUp";
            this.mvUp.Size = new System.Drawing.Size(103, 30);
            this.mvUp.TabIndex = 5;
            this.mvUp.Text = "Move Up";
            this.mvUp.UseVisualStyleBackColor = true;
            this.mvUp.Click += new System.EventHandler(this.mvUp_Click);
            // 
            // installedPatches
            // 
            this.installedPatches.FormattingEnabled = true;
            this.installedPatches.Location = new System.Drawing.Point(6, 19);
            this.installedPatches.Name = "installedPatches";
            this.installedPatches.Size = new System.Drawing.Size(274, 537);
            this.installedPatches.TabIndex = 4;
            // 
            // configDump
            // 
            this.configDump.AutoSize = true;
            this.configDump.Location = new System.Drawing.Point(286, 258);
            this.configDump.Name = "configDump";
            this.configDump.Size = new System.Drawing.Size(79, 17);
            this.configDump.TabIndex = 3;
            this.configDump.Text = "DAT Dump";
            this.configDump.UseVisualStyleBackColor = true;
            this.configDump.CheckedChanged += new System.EventHandler(this.configDump_CheckedChanged);
            // 
            // configConsole
            // 
            this.configConsole.AutoSize = true;
            this.configConsole.Location = new System.Drawing.Point(286, 235);
            this.configConsole.Name = "configConsole";
            this.configConsole.Size = new System.Drawing.Size(64, 17);
            this.configConsole.TabIndex = 2;
            this.configConsole.Text = "Console";
            this.configConsole.UseVisualStyleBackColor = true;
            this.configConsole.CheckedChanged += new System.EventHandler(this.configConsole_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameConfig);
            this.groupBox1.Controls.Add(this.delConfig);
            this.groupBox1.Controls.Add(this.createConfig);
            this.groupBox1.Controls.Add(this.configList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 558);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patch Configurations";
            // 
            // nameConfig
            // 
            this.nameConfig.Location = new System.Drawing.Point(212, 510);
            this.nameConfig.Name = "nameConfig";
            this.nameConfig.Size = new System.Drawing.Size(84, 41);
            this.nameConfig.TabIndex = 3;
            this.nameConfig.Text = "Rename";
            this.nameConfig.UseVisualStyleBackColor = true;
            this.nameConfig.Click += new System.EventHandler(this.nameConfig_Click);
            // 
            // delConfig
            // 
            this.delConfig.Location = new System.Drawing.Point(110, 510);
            this.delConfig.Name = "delConfig";
            this.delConfig.Size = new System.Drawing.Size(84, 41);
            this.delConfig.TabIndex = 2;
            this.delConfig.Text = "Delete";
            this.delConfig.UseVisualStyleBackColor = true;
            this.delConfig.Click += new System.EventHandler(this.delConfig_Click);
            // 
            // createConfig
            // 
            this.createConfig.Location = new System.Drawing.Point(6, 511);
            this.createConfig.Name = "createConfig";
            this.createConfig.Size = new System.Drawing.Size(84, 41);
            this.createConfig.TabIndex = 1;
            this.createConfig.Text = "Create New";
            this.createConfig.UseVisualStyleBackColor = true;
            this.createConfig.Click += new System.EventHandler(this.createConfig_Click);
            // 
            // configList
            // 
            this.configList.FormattingEnabled = true;
            this.configList.Location = new System.Drawing.Point(6, 19);
            this.configList.Name = "configList";
            this.configList.Size = new System.Drawing.Size(290, 485);
            this.configList.TabIndex = 0;
            this.configList.SelectedIndexChanged += new System.EventHandler(this.configList_SelectedIndexChanged);
            // 
            // tabRepos
            // 
            this.tabRepos.Controls.Add(this.groupBox3);
            this.tabRepos.Controls.Add(this.groupBox4);
            this.tabRepos.Controls.Add(this.groupBox2);
            this.tabRepos.Location = new System.Drawing.Point(4, 22);
            this.tabRepos.Name = "tabRepos";
            this.tabRepos.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepos.Size = new System.Drawing.Size(709, 564);
            this.tabRepos.TabIndex = 2;
            this.tabRepos.Text = "Online Repositories";
            this.tabRepos.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.patchServer);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.authContact);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dlPatch);
            this.groupBox3.Controls.Add(this.patchDesc);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.patchTitle);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(311, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 299);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // patchServer
            // 
            this.patchServer.BackColor = System.Drawing.SystemColors.Control;
            this.patchServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patchServer.Location = new System.Drawing.Point(9, 232);
            this.patchServer.Name = "patchServer";
            this.patchServer.ReadOnly = true;
            this.patchServer.Size = new System.Drawing.Size(383, 20);
            this.patchServer.TabIndex = 8;
            this.patchServer.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Server";
            // 
            // authContact
            // 
            this.authContact.BackColor = System.Drawing.SystemColors.Control;
            this.authContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.authContact.Location = new System.Drawing.Point(9, 193);
            this.authContact.Name = "authContact";
            this.authContact.ReadOnly = true;
            this.authContact.Size = new System.Drawing.Size(383, 20);
            this.authContact.TabIndex = 6;
            this.authContact.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Author Contact";
            // 
            // dlPatch
            // 
            this.dlPatch.Location = new System.Drawing.Point(9, 258);
            this.dlPatch.Name = "dlPatch";
            this.dlPatch.Size = new System.Drawing.Size(383, 35);
            this.dlPatch.TabIndex = 4;
            this.dlPatch.Text = "Download Patch";
            this.dlPatch.UseVisualStyleBackColor = true;
            this.dlPatch.Click += new System.EventHandler(this.dlPatch_Click);
            // 
            // patchDesc
            // 
            this.patchDesc.BackColor = System.Drawing.SystemColors.Control;
            this.patchDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patchDesc.Location = new System.Drawing.Point(9, 71);
            this.patchDesc.Name = "patchDesc";
            this.patchDesc.ReadOnly = true;
            this.patchDesc.Size = new System.Drawing.Size(383, 103);
            this.patchDesc.TabIndex = 3;
            this.patchDesc.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // patchTitle
            // 
            this.patchTitle.BackColor = System.Drawing.SystemColors.Control;
            this.patchTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.patchTitle.Location = new System.Drawing.Point(9, 32);
            this.patchTitle.Name = "patchTitle";
            this.patchTitle.ReadOnly = true;
            this.patchTitle.Size = new System.Drawing.Size(383, 20);
            this.patchTitle.TabIndex = 1;
            this.patchTitle.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.updateExtRepo);
            this.groupBox4.Controls.Add(this.extRepo);
            this.groupBox4.Controls.Add(this.updateRepoButton);
            this.groupBox4.Location = new System.Drawing.Point(311, 305);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(398, 256);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Toolbox";
            // 
            // updateExtRepo
            // 
            this.updateExtRepo.Location = new System.Drawing.Point(8, 94);
            this.updateExtRepo.Name = "updateExtRepo";
            this.updateExtRepo.Size = new System.Drawing.Size(384, 35);
            this.updateExtRepo.TabIndex = 2;
            this.updateExtRepo.Text = "Download Repository List from a Server";
            this.updateExtRepo.UseVisualStyleBackColor = true;
            this.updateExtRepo.Click += new System.EventHandler(this.updateExtRepo_Click);
            // 
            // extRepo
            // 
            this.extRepo.Location = new System.Drawing.Point(9, 73);
            this.extRepo.Name = "extRepo";
            this.extRepo.Size = new System.Drawing.Size(382, 20);
            this.extRepo.TabIndex = 1;
            // 
            // updateRepoButton
            // 
            this.updateRepoButton.Location = new System.Drawing.Point(9, 19);
            this.updateRepoButton.Name = "updateRepoButton";
            this.updateRepoButton.Size = new System.Drawing.Size(383, 48);
            this.updateRepoButton.TabIndex = 0;
            this.updateRepoButton.Text = "Download ThPatch Repository List";
            this.updateRepoButton.UseVisualStyleBackColor = true;
            this.updateRepoButton.Click += new System.EventHandler(this.updateRepoButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.repoTreeView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 558);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repository List";
            // 
            // repoTreeView
            // 
            this.repoTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repoTreeView.ImageIndex = 0;
            this.repoTreeView.ImageList = this.repoImageList;
            this.repoTreeView.Location = new System.Drawing.Point(3, 16);
            this.repoTreeView.Name = "repoTreeView";
            this.repoTreeView.SelectedImageIndex = 0;
            this.repoTreeView.Size = new System.Drawing.Size(296, 539);
            this.repoTreeView.TabIndex = 0;
            this.repoTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.repoTreeView_AfterSelect);
            // 
            // repoImageList
            // 
            this.repoImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("repoImageList.ImageStream")));
            this.repoImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.repoImageList.Images.SetKeyName(0, "Web_blue_16x.png");
            this.repoImageList.Images.SetKeyName(1, "FolderClosed_16x.png");
            this.repoImageList.Images.SetKeyName(2, "Package_16x.png");
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.changeWorkingDir);
            this.tabSettings.Controls.Add(this.timeBtwUpd);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.updOther);
            this.tabSettings.Controls.Add(this.updAtExit);
            this.tabSettings.Controls.Add(this.skipCheckMbox);
            this.tabSettings.Controls.Add(this.bgUpd);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(709, 564);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "ThPatch Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // timeBtwUpd
            // 
            this.timeBtwUpd.Location = new System.Drawing.Point(269, 174);
            this.timeBtwUpd.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.timeBtwUpd.Name = "timeBtwUpd";
            this.timeBtwUpd.Size = new System.Drawing.Size(39, 20);
            this.timeBtwUpd.TabIndex = 6;
            this.timeBtwUpd.ValueChanged += new System.EventHandler(this.ThPatchSettingChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Time Between Updates";
            // 
            // updOther
            // 
            this.updOther.AutoSize = true;
            this.updOther.Location = new System.Drawing.Point(269, 151);
            this.updOther.Name = "updOther";
            this.updOther.Size = new System.Drawing.Size(95, 17);
            this.updOther.TabIndex = 4;
            this.updOther.Text = "Update Others";
            this.updOther.UseVisualStyleBackColor = true;
            this.updOther.CheckedChanged += new System.EventHandler(this.ThPatchSettingChanged);
            // 
            // updAtExit
            // 
            this.updAtExit.AutoSize = true;
            this.updAtExit.Location = new System.Drawing.Point(269, 128);
            this.updAtExit.Name = "updAtExit";
            this.updAtExit.Size = new System.Drawing.Size(93, 17);
            this.updAtExit.TabIndex = 3;
            this.updAtExit.Text = "Update at Exit";
            this.updAtExit.UseVisualStyleBackColor = true;
            this.updAtExit.CheckedChanged += new System.EventHandler(this.ThPatchSettingChanged);
            // 
            // skipCheckMbox
            // 
            this.skipCheckMbox.AutoSize = true;
            this.skipCheckMbox.Location = new System.Drawing.Point(269, 105);
            this.skipCheckMbox.Name = "skipCheckMbox";
            this.skipCheckMbox.Size = new System.Drawing.Size(148, 17);
            this.skipCheckMbox.TabIndex = 2;
            this.skipCheckMbox.Text = "Skip Check Message Box";
            this.skipCheckMbox.UseVisualStyleBackColor = true;
            this.skipCheckMbox.CheckedChanged += new System.EventHandler(this.ThPatchSettingChanged);
            // 
            // bgUpd
            // 
            this.bgUpd.AutoSize = true;
            this.bgUpd.Location = new System.Drawing.Point(269, 82);
            this.bgUpd.Name = "bgUpd";
            this.bgUpd.Size = new System.Drawing.Size(127, 17);
            this.bgUpd.TabIndex = 1;
            this.bgUpd.Text = "Background Updates";
            this.bgUpd.UseVisualStyleBackColor = true;
            this.bgUpd.CheckedChanged += new System.EventHandler(this.ThPatchSettingChanged);
            // 
            // patchesImageList
            // 
            this.patchesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("patchesImageList.ImageStream")));
            this.patchesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.patchesImageList.Images.SetKeyName(0, "FolderClosed_16x.png");
            this.patchesImageList.Images.SetKeyName(1, "Package_16x.png");
            // 
            // repoMenuStrip
            // 
            this.repoMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dlAll});
            this.repoMenuStrip.Name = "dlAll";
            this.repoMenuStrip.Size = new System.Drawing.Size(190, 26);
            // 
            // dlAll
            // 
            this.dlAll.Name = "dlAll";
            this.dlAll.Size = new System.Drawing.Size(189, 22);
            this.dlAll.Text = "Download All Patches";
            this.dlAll.Click += new System.EventHandler(this.dlAll_Click);
            // 
            // changeWorkingDir
            // 
            this.changeWorkingDir.Location = new System.Drawing.Point(269, 200);
            this.changeWorkingDir.Name = "changeWorkingDir";
            this.changeWorkingDir.Size = new System.Drawing.Size(163, 41);
            this.changeWorkingDir.TabIndex = 7;
            this.changeWorkingDir.Text = "Change Thcrap Directory";
            this.changeWorkingDir.UseVisualStyleBackColor = true;
            this.changeWorkingDir.Click += new System.EventHandler(this.changeWorkingDir_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(717, 590);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThPatch Config";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabLauncher.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.Patches.ResumeLayout(false);
            this.Patches.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabRepos.ResumeLayout(false);
            this.tabRepos.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeBtwUpd)).EndInit();
            this.repoMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLauncher;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.TabPage tabRepos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TreeView repoTreeView;
        private System.Windows.Forms.RichTextBox patchDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox patchTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList repoImageList;
        private System.Windows.Forms.Button dlPatch;
        private System.Windows.Forms.Button updateRepoButton;
        private System.Windows.Forms.RichTextBox authContact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox patchServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox Patches;
        private System.Windows.Forms.Button nameConfig;
        private System.Windows.Forms.Button delConfig;
        private System.Windows.Forms.Button createConfig;
        private System.Windows.Forms.ListBox configList;
        private System.Windows.Forms.CheckBox configDump;
        private System.Windows.Forms.CheckBox configConsole;
        private System.Windows.Forms.ImageList patchesImageList;
        private System.Windows.Forms.Button mvBot;
        private System.Windows.Forms.Button mvTop;
        private System.Windows.Forms.Button mvDown;
        private System.Windows.Forms.Button mvUp;
        private System.Windows.Forms.ListBox installedPatches;
        private System.Windows.Forms.Button delPatch;
        private System.Windows.Forms.Button addPatch;
        private System.Windows.Forms.ContextMenuStrip repoMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem dlAll;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TextBox extRepo;
        private System.Windows.Forms.Button updateExtRepo;
        private System.Windows.Forms.ListView gameListView;
        private System.Windows.Forms.ImageList launcherImageList;
        private System.Windows.Forms.NumericUpDown timeBtwUpd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox updOther;
        private System.Windows.Forms.CheckBox updAtExit;
        private System.Windows.Forms.CheckBox skipCheckMbox;
        private System.Windows.Forms.CheckBox bgUpd;
        private System.Windows.Forms.Button remGame;
        private System.Windows.Forms.Button scanGame;
        private System.Windows.Forms.Button addGame;
        private System.Windows.Forms.Button changeWorkingDir;
    }
}

