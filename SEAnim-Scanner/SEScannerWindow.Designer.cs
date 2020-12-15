namespace SEAnimScanner
{
    /// 
    /// Copyright (C) 2020 by OfficialPLanet (RealPlanet @GitHub) refer to License.txt or ABOUT button at runtime
    /// 
    partial class AppWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppWindow));
            this.extBttn = new System.Windows.Forms.Button();
            this.animList = new System.Windows.Forms.ListBox();
            this.ScanBtt = new System.Windows.Forms.Button();
            this.outputTextbox = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.readAnimsBackground = new System.ComponentModel.BackgroundWorker();
            this.getFilePathBackground = new System.ComponentModel.BackgroundWorker();
            this.GitButton = new System.Windows.Forms.Button();
            this.LicensBtt = new System.Windows.Forms.Button();
            this.DDlabel = new System.Windows.Forms.Label();
            this.JointLabelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // extBttn
            // 
            resources.ApplyResources(this.extBttn, "extBttn");
            this.extBttn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.extBttn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.extBttn.ForeColor = System.Drawing.SystemColors.Desktop;
            this.extBttn.Name = "extBttn";
            this.extBttn.UseVisualStyleBackColor = false;
            this.extBttn.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // animList
            // 
            this.animList.AllowDrop = true;
            this.animList.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.animList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animList.ForeColor = System.Drawing.SystemColors.Control;
            this.animList.FormattingEnabled = true;
            resources.ApplyResources(this.animList, "animList");
            this.animList.Name = "animList";
            this.animList.SelectedIndexChanged += new System.EventHandler(this.animList_SelectedIndexChanged);
            // 
            // ScanBtt
            // 
            resources.ApplyResources(this.ScanBtt, "ScanBtt");
            this.ScanBtt.BackgroundImage = global::SEAnimScanner.Properties.Resources.back_white_matte;
            this.ScanBtt.ForeColor = System.Drawing.Color.Crimson;
            this.ScanBtt.Name = "ScanBtt";
            this.ScanBtt.UseVisualStyleBackColor = true;
            this.ScanBtt.Click += new System.EventHandler(this.startScan_ClickEvent);
            // 
            // outputTextbox
            // 
            resources.ApplyResources(this.outputTextbox, "outputTextbox");
            this.outputTextbox.BackColor = System.Drawing.Color.Silver;
            this.outputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTextbox.Name = "outputTextbox";
            this.outputTextbox.ReadOnly = true;
            this.outputTextbox.TextChanged += new System.EventHandler(this.outputTextbox_TextChanged);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.BackColor = System.Drawing.Color.Black;
            this.progressBar.ForeColor = System.Drawing.Color.Green;
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // InputBox
            // 
            resources.ApplyResources(this.InputBox, "InputBox");
            this.InputBox.Name = "InputBox";
            this.InputBox.TextChanged += new System.EventHandler(this.InputBox_TextChanged);
            // 
            // GitButton
            // 
            this.GitButton.BackColor = System.Drawing.Color.SlateGray;
            this.GitButton.BackgroundImage = global::SEAnimScanner.Properties.Resources.back_white_matte;
            resources.ApplyResources(this.GitButton, "GitButton");
            this.GitButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GitButton.Name = "GitButton";
            this.GitButton.UseVisualStyleBackColor = false;
            this.GitButton.Click += new System.EventHandler(this.GitButton_Click);
            // 
            // LicensBtt
            // 
            this.LicensBtt.BackColor = System.Drawing.Color.SlateGray;
            this.LicensBtt.BackgroundImage = global::SEAnimScanner.Properties.Resources.back_white_matte;
            resources.ApplyResources(this.LicensBtt, "LicensBtt");
            this.LicensBtt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LicensBtt.Name = "LicensBtt";
            this.LicensBtt.UseVisualStyleBackColor = false;
            this.LicensBtt.Click += new System.EventHandler(this.LicensBtt_Click);
            // 
            // DDlabel
            // 
            resources.ApplyResources(this.DDlabel, "DDlabel");
            this.DDlabel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.DDlabel.ForeColor = System.Drawing.SystemColors.Control;
            this.DDlabel.Name = "DDlabel";
            // 
            // JointLabelInfo
            // 
            resources.ApplyResources(this.JointLabelInfo, "JointLabelInfo");
            this.JointLabelInfo.BackColor = System.Drawing.SystemColors.Window;
            this.JointLabelInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.JointLabelInfo.Name = "JointLabelInfo";
            // 
            // AppWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::SEAnimScanner.Properties.Resources.back_black_matte;
            this.CancelButton = this.extBttn;
            this.Controls.Add(this.DDlabel);
            this.Controls.Add(this.JointLabelInfo);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.LicensBtt);
            this.Controls.Add(this.GitButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.outputTextbox);
            this.Controls.Add(this.ScanBtt);
            this.Controls.Add(this.animList);
            this.Controls.Add(this.extBttn);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "AppWindow";
            this.Load += new System.EventHandler(this.AppWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button extBttn;
        private System.Windows.Forms.ListBox animList;
        private System.Windows.Forms.Button ScanBtt;
        private System.Windows.Forms.RichTextBox outputTextbox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox InputBox;
        private System.ComponentModel.BackgroundWorker readAnimsBackground;
        private System.ComponentModel.BackgroundWorker getFilePathBackground;
        private System.Windows.Forms.Button GitButton;
        private System.Windows.Forms.Button LicensBtt;
        private System.Windows.Forms.Label DDlabel;
        private System.Windows.Forms.Label JointLabelInfo;
    }
}

