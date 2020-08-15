namespace ThPatchConfig
{
    partial class PatchPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatchPicker));
            this.patchTree = new System.Windows.Forms.TreeView();
            this.patchPath = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.patchesImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // patchTree
            // 
            this.patchTree.ImageIndex = 0;
            this.patchTree.ImageList = this.patchesImageList;
            this.patchTree.Location = new System.Drawing.Point(13, 13);
            this.patchTree.Name = "patchTree";
            this.patchTree.SelectedImageIndex = 0;
            this.patchTree.Size = new System.Drawing.Size(452, 420);
            this.patchTree.TabIndex = 0;
            this.patchTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.patchTree_AfterSelect);
            // 
            // patchPath
            // 
            this.patchPath.Location = new System.Drawing.Point(12, 439);
            this.patchPath.Name = "patchPath";
            this.patchPath.Size = new System.Drawing.Size(453, 20);
            this.patchPath.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(12, 465);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(453, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // patchesImageList
            // 
            this.patchesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("patchesImageList.ImageStream")));
            this.patchesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.patchesImageList.Images.SetKeyName(0, "FolderClosed_16x.png");
            this.patchesImageList.Images.SetKeyName(1, "Package_16x.png");
            // 
            // PatchPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 500);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.patchPath);
            this.Controls.Add(this.patchTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatchPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patch Picker";
            this.Load += new System.EventHandler(this.PatchPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView patchTree;
        private System.Windows.Forms.TextBox patchPath;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ImageList patchesImageList;
    }
}