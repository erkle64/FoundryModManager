namespace FoundryModManager
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonApplyAndRunSteamDemo = new System.Windows.Forms.Button();
            this.buttonApplyAndRun = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.panelConfigurations = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAddConfiguration = new System.Windows.Forms.Button();
            this.buttonRemoveConfiguration = new System.Windows.Forms.Button();
            this.listConfigurations = new System.Windows.Forms.ListBox();
            this.labelConfigurations = new System.Windows.Forms.Label();
            this.panelMods = new System.Windows.Forms.Panel();
            this.buttonModHome = new System.Windows.Forms.Button();
            this.listMods = new System.Windows.Forms.CheckedListBox();
            this.labelMods = new System.Windows.Forms.Label();
            this.panelPath = new System.Windows.Forms.Panel();
            this.inputPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.openFileDialogFoundryExe = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelButtons.SuspendLayout();
            this.panelConfigurations.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMods.SuspendLayout();
            this.panelPath.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonApplyAndRunSteamDemo);
            this.panelButtons.Controls.Add(this.buttonApplyAndRun);
            this.panelButtons.Controls.Add(this.buttonApply);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(4, 342);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.panelButtons.Size = new System.Drawing.Size(524, 48);
            this.panelButtons.TabIndex = 0;
            // 
            // buttonApplyAndRunSteamDemo
            // 
            this.buttonApplyAndRunSteamDemo.AutoSize = true;
            this.buttonApplyAndRunSteamDemo.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonApplyAndRunSteamDemo.Location = new System.Drawing.Point(63, 5);
            this.buttonApplyAndRunSteamDemo.Name = "buttonApplyAndRunSteamDemo";
            this.buttonApplyAndRunSteamDemo.Size = new System.Drawing.Size(239, 38);
            this.buttonApplyAndRunSteamDemo.TabIndex = 2;
            this.buttonApplyAndRunSteamDemo.Text = "Apply and Run Foundry Demo with Steam";
            this.buttonApplyAndRunSteamDemo.UseVisualStyleBackColor = true;
            this.buttonApplyAndRunSteamDemo.Click += new System.EventHandler(this.buttonApplyAndRunSteamDemo_Click);
            // 
            // buttonApplyAndRun
            // 
            this.buttonApplyAndRun.AutoSize = true;
            this.buttonApplyAndRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonApplyAndRun.Location = new System.Drawing.Point(302, 5);
            this.buttonApplyAndRun.Name = "buttonApplyAndRun";
            this.buttonApplyAndRun.Size = new System.Drawing.Size(142, 38);
            this.buttonApplyAndRun.TabIndex = 1;
            this.buttonApplyAndRun.Text = "Apply and Run Foundry";
            this.buttonApplyAndRun.UseVisualStyleBackColor = true;
            this.buttonApplyAndRun.Click += new System.EventHandler(this.buttonApplyAndRun_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonApply.Location = new System.Drawing.Point(444, 5);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 38);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // panelConfigurations
            // 
            this.panelConfigurations.Controls.Add(this.panel1);
            this.panelConfigurations.Controls.Add(this.listConfigurations);
            this.panelConfigurations.Controls.Add(this.labelConfigurations);
            this.panelConfigurations.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelConfigurations.Location = new System.Drawing.Point(328, 54);
            this.panelConfigurations.Name = "panelConfigurations";
            this.panelConfigurations.Size = new System.Drawing.Size(200, 288);
            this.panelConfigurations.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAddConfiguration);
            this.panel1.Controls.Add(this.buttonRemoveConfiguration);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 32);
            this.panel1.TabIndex = 3;
            // 
            // buttonAddConfiguration
            // 
            this.buttonAddConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddConfiguration.Location = new System.Drawing.Point(0, 0);
            this.buttonAddConfiguration.Name = "buttonAddConfiguration";
            this.buttonAddConfiguration.Size = new System.Drawing.Size(100, 32);
            this.buttonAddConfiguration.TabIndex = 1;
            this.buttonAddConfiguration.Text = "New Config";
            this.buttonAddConfiguration.UseVisualStyleBackColor = true;
            this.buttonAddConfiguration.Click += new System.EventHandler(this.buttonAddConfiguration_Click);
            // 
            // buttonRemoveConfiguration
            // 
            this.buttonRemoveConfiguration.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRemoveConfiguration.Location = new System.Drawing.Point(100, 0);
            this.buttonRemoveConfiguration.Name = "buttonRemoveConfiguration";
            this.buttonRemoveConfiguration.Size = new System.Drawing.Size(100, 32);
            this.buttonRemoveConfiguration.TabIndex = 0;
            this.buttonRemoveConfiguration.Text = "Delete Config";
            this.buttonRemoveConfiguration.UseVisualStyleBackColor = true;
            this.buttonRemoveConfiguration.Click += new System.EventHandler(this.buttonRemoveConfiguration_Click);
            // 
            // listConfigurations
            // 
            this.listConfigurations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listConfigurations.FormattingEnabled = true;
            this.listConfigurations.IntegralHeight = false;
            this.listConfigurations.ItemHeight = 15;
            this.listConfigurations.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.listConfigurations.Location = new System.Drawing.Point(0, 20);
            this.listConfigurations.Name = "listConfigurations";
            this.listConfigurations.Size = new System.Drawing.Size(200, 268);
            this.listConfigurations.TabIndex = 2;
            this.listConfigurations.SelectedIndexChanged += new System.EventHandler(this.listConfigurations_SelectedIndexChanged);
            // 
            // labelConfigurations
            // 
            this.labelConfigurations.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelConfigurations.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelConfigurations.Location = new System.Drawing.Point(0, 0);
            this.labelConfigurations.Name = "labelConfigurations";
            this.labelConfigurations.Size = new System.Drawing.Size(200, 20);
            this.labelConfigurations.TabIndex = 1;
            this.labelConfigurations.Text = "Configurations";
            // 
            // panelMods
            // 
            this.panelMods.Controls.Add(this.buttonModHome);
            this.panelMods.Controls.Add(this.listMods);
            this.panelMods.Controls.Add(this.labelMods);
            this.panelMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMods.Location = new System.Drawing.Point(4, 54);
            this.panelMods.Name = "panelMods";
            this.panelMods.Size = new System.Drawing.Size(324, 288);
            this.panelMods.TabIndex = 2;
            // 
            // buttonModHome
            // 
            this.buttonModHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonModHome.Location = new System.Drawing.Point(0, 256);
            this.buttonModHome.Name = "buttonModHome";
            this.buttonModHome.Size = new System.Drawing.Size(324, 32);
            this.buttonModHome.TabIndex = 2;
            this.buttonModHome.Text = "Open Selected Mod Homepage";
            this.buttonModHome.UseVisualStyleBackColor = true;
            this.buttonModHome.Click += new System.EventHandler(this.buttonModHome_Click);
            // 
            // listMods
            // 
            this.listMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMods.FormattingEnabled = true;
            this.listMods.IntegralHeight = false;
            this.listMods.Location = new System.Drawing.Point(0, 20);
            this.listMods.Name = "listMods";
            this.listMods.Size = new System.Drawing.Size(324, 268);
            this.listMods.TabIndex = 1;
            this.listMods.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listMods_ItemCheck);
            // 
            // labelMods
            // 
            this.labelMods.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMods.Location = new System.Drawing.Point(0, 0);
            this.labelMods.Name = "labelMods";
            this.labelMods.Size = new System.Drawing.Size(324, 20);
            this.labelMods.TabIndex = 0;
            this.labelMods.Text = "Mods";
            // 
            // panelPath
            // 
            this.panelPath.Controls.Add(this.inputPath);
            this.panelPath.Controls.Add(this.buttonBrowse);
            this.panelPath.Controls.Add(this.labelPath);
            this.panelPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPath.Location = new System.Drawing.Point(4, 4);
            this.panelPath.Name = "panelPath";
            this.panelPath.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.panelPath.Size = new System.Drawing.Size(524, 50);
            this.panelPath.TabIndex = 3;
            // 
            // inputPath
            // 
            this.inputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPath.Location = new System.Drawing.Point(0, 20);
            this.inputPath.Name = "inputPath";
            this.inputPath.Size = new System.Drawing.Size(424, 23);
            this.inputPath.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonBrowse.Location = new System.Drawing.Point(424, 20);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(100, 23);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelPath
            // 
            this.labelPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPath.Location = new System.Drawing.Point(0, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(524, 20);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "Foundry Path";
            // 
            // openFileDialogFoundryExe
            // 
            this.openFileDialogFoundryExe.DefaultExt = "exe";
            this.openFileDialogFoundryExe.FileName = "Foundry.exe";
            this.openFileDialogFoundryExe.Filter = "Foundry.exe|Foundry.exe|All Files|*.*";
            this.openFileDialogFoundryExe.InitialDirectory = "C:\\";
            this.openFileDialogFoundryExe.Title = "Locate Foundry.exe";
            this.openFileDialogFoundryExe.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogFoundryExe_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(4, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(524, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 416);
            this.Controls.Add(this.panelMods);
            this.Controls.Add(this.panelConfigurations);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelPath);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Foundry Mod Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelConfigurations.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelMods.ResumeLayout(false);
            this.panelPath.ResumeLayout(false);
            this.panelPath.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelButtons;
        private Panel panelConfigurations;
        private Label labelConfigurations;
        private Panel panelMods;
        private CheckedListBox listMods;
        private Label labelMods;
        private Button buttonApply;
        private ListBox listConfigurations;
        private Button buttonApplyAndRun;
        private Panel panelPath;
        private TextBox inputPath;
        private Button buttonBrowse;
        private Label labelPath;
        private OpenFileDialog openFileDialogFoundryExe;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button buttonApplyAndRunSteamDemo;
        private Panel panel1;
        private Button buttonAddConfiguration;
        private Button buttonRemoveConfiguration;
        private Button buttonModHome;
    }
}