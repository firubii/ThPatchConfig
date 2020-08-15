namespace ThPatchConfig
{
    partial class ConfigPicker
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
            this.okButton = new System.Windows.Forms.Button();
            this.configDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(11, 38);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(455, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // configDropDown
            // 
            this.configDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configDropDown.FormattingEnabled = true;
            this.configDropDown.Items.AddRange(new object[] {
            "(None)"});
            this.configDropDown.Location = new System.Drawing.Point(12, 12);
            this.configDropDown.Name = "configDropDown";
            this.configDropDown.Size = new System.Drawing.Size(454, 21);
            this.configDropDown.TabIndex = 7;
            // 
            // ConfigPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 74);
            this.Controls.Add(this.configDropDown);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patch Configuration Selector";
            this.Load += new System.EventHandler(this.ConfigPicker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox configDropDown;
    }
}