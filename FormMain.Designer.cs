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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelButtons = new Panel();
            buttonApplyAndRunSteamDemo = new Button();
            buttonApplyAndRun = new Button();
            buttonApply = new Button();
            panelConfigurations = new Panel();
            panel1 = new Panel();
            buttonAddConfiguration = new Button();
            buttonRemoveConfiguration = new Button();
            listConfigurations = new ListBox();
            labelConfigurations = new Label();
            panelMods = new Panel();
            buttonModHome = new Button();
            listMods = new CheckedListBox();
            labelMods = new Label();
            panelPath = new Panel();
            inputPath = new TextBox();
            buttonBrowse = new Button();
            labelPath = new Label();
            openFileDialogFoundryExe = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panelButtons.SuspendLayout();
            panelConfigurations.SuspendLayout();
            panel1.SuspendLayout();
            panelMods.SuspendLayout();
            panelPath.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(buttonApplyAndRunSteamDemo);
            panelButtons.Controls.Add(buttonApplyAndRun);
            panelButtons.Controls.Add(buttonApply);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(4, 342);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(5);
            panelButtons.Size = new Size(524, 48);
            panelButtons.TabIndex = 0;
            // 
            // buttonApplyAndRunSteamDemo
            // 
            buttonApplyAndRunSteamDemo.AutoSize = true;
            buttonApplyAndRunSteamDemo.Dock = DockStyle.Right;
            buttonApplyAndRunSteamDemo.Location = new Point(63, 5);
            buttonApplyAndRunSteamDemo.Name = "buttonApplyAndRunSteamDemo";
            buttonApplyAndRunSteamDemo.Size = new Size(239, 38);
            buttonApplyAndRunSteamDemo.TabIndex = 2;
            buttonApplyAndRunSteamDemo.Text = "Apply and Run Foundry with Steam";
            buttonApplyAndRunSteamDemo.UseVisualStyleBackColor = true;
            buttonApplyAndRunSteamDemo.Click += buttonApplyAndRunSteamDemo_Click;
            // 
            // buttonApplyAndRun
            // 
            buttonApplyAndRun.AutoSize = true;
            buttonApplyAndRun.Dock = DockStyle.Right;
            buttonApplyAndRun.Location = new Point(302, 5);
            buttonApplyAndRun.Name = "buttonApplyAndRun";
            buttonApplyAndRun.Size = new Size(142, 38);
            buttonApplyAndRun.TabIndex = 1;
            buttonApplyAndRun.Text = "Apply and Run Foundry";
            buttonApplyAndRun.UseVisualStyleBackColor = true;
            buttonApplyAndRun.Click += buttonApplyAndRun_Click;
            // 
            // buttonApply
            // 
            buttonApply.Dock = DockStyle.Right;
            buttonApply.Location = new Point(444, 5);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(75, 38);
            buttonApply.TabIndex = 0;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // panelConfigurations
            // 
            panelConfigurations.Controls.Add(panel1);
            panelConfigurations.Controls.Add(listConfigurations);
            panelConfigurations.Controls.Add(labelConfigurations);
            panelConfigurations.Dock = DockStyle.Right;
            panelConfigurations.Location = new Point(328, 54);
            panelConfigurations.Name = "panelConfigurations";
            panelConfigurations.Size = new Size(200, 288);
            panelConfigurations.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAddConfiguration);
            panel1.Controls.Add(buttonRemoveConfiguration);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 256);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 32);
            panel1.TabIndex = 3;
            // 
            // buttonAddConfiguration
            // 
            buttonAddConfiguration.Dock = DockStyle.Fill;
            buttonAddConfiguration.Location = new Point(0, 0);
            buttonAddConfiguration.Name = "buttonAddConfiguration";
            buttonAddConfiguration.Size = new Size(100, 32);
            buttonAddConfiguration.TabIndex = 1;
            buttonAddConfiguration.Text = "New Config";
            buttonAddConfiguration.UseVisualStyleBackColor = true;
            buttonAddConfiguration.Click += buttonAddConfiguration_Click;
            // 
            // buttonRemoveConfiguration
            // 
            buttonRemoveConfiguration.Dock = DockStyle.Right;
            buttonRemoveConfiguration.Location = new Point(100, 0);
            buttonRemoveConfiguration.Name = "buttonRemoveConfiguration";
            buttonRemoveConfiguration.Size = new Size(100, 32);
            buttonRemoveConfiguration.TabIndex = 0;
            buttonRemoveConfiguration.Text = "Delete Config";
            buttonRemoveConfiguration.UseVisualStyleBackColor = true;
            buttonRemoveConfiguration.Click += buttonRemoveConfiguration_Click;
            // 
            // listConfigurations
            // 
            listConfigurations.Dock = DockStyle.Fill;
            listConfigurations.FormattingEnabled = true;
            listConfigurations.IntegralHeight = false;
            listConfigurations.ItemHeight = 15;
            listConfigurations.Items.AddRange(new object[] { "1", "2", "3" });
            listConfigurations.Location = new Point(0, 20);
            listConfigurations.Name = "listConfigurations";
            listConfigurations.Size = new Size(200, 268);
            listConfigurations.TabIndex = 2;
            listConfigurations.SelectedIndexChanged += listConfigurations_SelectedIndexChanged;
            // 
            // labelConfigurations
            // 
            labelConfigurations.Dock = DockStyle.Top;
            labelConfigurations.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelConfigurations.Location = new Point(0, 0);
            labelConfigurations.Name = "labelConfigurations";
            labelConfigurations.Size = new Size(200, 20);
            labelConfigurations.TabIndex = 1;
            labelConfigurations.Text = "Configurations";
            // 
            // panelMods
            // 
            panelMods.Controls.Add(buttonModHome);
            panelMods.Controls.Add(listMods);
            panelMods.Controls.Add(labelMods);
            panelMods.Dock = DockStyle.Fill;
            panelMods.Location = new Point(4, 54);
            panelMods.Name = "panelMods";
            panelMods.Size = new Size(324, 288);
            panelMods.TabIndex = 2;
            // 
            // buttonModHome
            // 
            buttonModHome.Dock = DockStyle.Bottom;
            buttonModHome.Location = new Point(0, 256);
            buttonModHome.Name = "buttonModHome";
            buttonModHome.Size = new Size(324, 32);
            buttonModHome.TabIndex = 2;
            buttonModHome.Text = "Open Selected Mod Homepage";
            buttonModHome.UseVisualStyleBackColor = true;
            buttonModHome.Click += buttonModHome_Click;
            // 
            // listMods
            // 
            listMods.Dock = DockStyle.Fill;
            listMods.FormattingEnabled = true;
            listMods.IntegralHeight = false;
            listMods.Location = new Point(0, 20);
            listMods.Name = "listMods";
            listMods.Size = new Size(324, 268);
            listMods.TabIndex = 1;
            listMods.ItemCheck += listMods_ItemCheck;
            // 
            // labelMods
            // 
            labelMods.Dock = DockStyle.Top;
            labelMods.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelMods.Location = new Point(0, 0);
            labelMods.Name = "labelMods";
            labelMods.Size = new Size(324, 20);
            labelMods.TabIndex = 0;
            labelMods.Text = "Mods";
            // 
            // panelPath
            // 
            panelPath.Controls.Add(inputPath);
            panelPath.Controls.Add(buttonBrowse);
            panelPath.Controls.Add(labelPath);
            panelPath.Dock = DockStyle.Top;
            panelPath.Location = new Point(4, 4);
            panelPath.Name = "panelPath";
            panelPath.Padding = new Padding(0, 0, 0, 7);
            panelPath.Size = new Size(524, 50);
            panelPath.TabIndex = 3;
            // 
            // inputPath
            // 
            inputPath.Dock = DockStyle.Fill;
            inputPath.Location = new Point(0, 20);
            inputPath.Name = "inputPath";
            inputPath.Size = new Size(424, 23);
            inputPath.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Dock = DockStyle.Right;
            buttonBrowse.Location = new Point(424, 20);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(100, 23);
            buttonBrowse.TabIndex = 1;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // labelPath
            // 
            labelPath.Dock = DockStyle.Top;
            labelPath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPath.Location = new Point(0, 0);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(524, 20);
            labelPath.TabIndex = 2;
            labelPath.Text = "Foundry Path";
            // 
            // openFileDialogFoundryExe
            // 
            openFileDialogFoundryExe.DefaultExt = "exe";
            openFileDialogFoundryExe.FileName = "Foundry.exe";
            openFileDialogFoundryExe.Filter = "Foundry.exe|Foundry.exe|All Files|*.*";
            openFileDialogFoundryExe.InitialDirectory = "C:\\";
            openFileDialogFoundryExe.Title = "Locate Foundry.exe";
            openFileDialogFoundryExe.FileOk += openFileDialogFoundryExe_FileOk;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(4, 390);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(524, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(0, 17);
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 416);
            Controls.Add(panelMods);
            Controls.Add(panelConfigurations);
            Controls.Add(panelButtons);
            Controls.Add(panelPath);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Padding = new Padding(4);
            Text = "Foundry Mod Manager";
            Load += FormMain_Load;
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            panelConfigurations.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panelMods.ResumeLayout(false);
            panelPath.ResumeLayout(false);
            panelPath.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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