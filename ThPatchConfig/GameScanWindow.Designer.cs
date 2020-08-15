namespace ThPatchConfig
{
    partial class GameScanWindow
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
            this.scanListView = new System.Windows.Forms.ListView();
            this.okButton = new System.Windows.Forms.Button();
            this.incl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.icon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // scanListView
            // 
            this.scanListView.CheckBoxes = true;
            this.scanListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.incl,
            this.icon,
            this.path});
            this.scanListView.FullRowSelect = true;
            this.scanListView.GridLines = true;
            this.scanListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.scanListView.HideSelection = false;
            this.scanListView.Location = new System.Drawing.Point(12, 13);
            this.scanListView.MultiSelect = false;
            this.scanListView.Name = "scanListView";
            this.scanListView.ShowGroups = false;
            this.scanListView.Size = new System.Drawing.Size(370, 358);
            this.scanListView.TabIndex = 0;
            this.scanListView.UseCompatibleStateImageBehavior = false;
            this.scanListView.View = System.Windows.Forms.View.Details;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 382);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(371, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // incl
            // 
            this.incl.Text = "Include";
            // 
            // icon
            // 
            this.icon.Text = "Icon";
            // 
            // path
            // 
            this.path.Text = "Path";
            this.path.Width = 245;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // GameScanWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 417);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.scanListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameScanWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GameScanWindow";
            this.Load += new System.EventHandler(this.GameScanWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView scanListView;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ColumnHeader incl;
        private System.Windows.Forms.ColumnHeader icon;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ImageList imageList;
    }
}