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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelButtons = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonApply = new Button();
            buttonApplyAndRun = new Button();
            buttonApplyAndRunSteamDemo = new Button();
            buttonTweaks = new Button();
            panelConfigurations = new Panel();
            panelConfigurationButtons = new Panel();
            buttonAddConfiguration = new Button();
            buttonRemoveConfiguration = new Button();
            listConfigurations = new ListBox();
            labelConfigurations = new Label();
            panelMods = new Panel();
            listMods = new CheckedListBox();
            labelMods = new Label();
            panelModButtons = new Panel();
            buttonModConfig = new Button();
            buttonModHome = new Button();
            textBoxModInfo = new TextBox();
            panelPath = new Panel();
            checkBoxTestBranch = new CheckBox();
            inputPath = new TextBox();
            buttonBrowse = new Button();
            labelPath = new Label();
            openFileDialogFoundryExe = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolTip = new ToolTip(components);
            panelDescription = new Panel();
            panelButtons.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelConfigurations.SuspendLayout();
            panelConfigurationButtons.SuspendLayout();
            panelMods.SuspendLayout();
            panelModButtons.SuspendLayout();
            panelPath.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelDescription.SuspendLayout();
            SuspendLayout();
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(tableLayoutPanel1);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(4, 463);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(5);
            panelButtons.Size = new Size(524, 48);
            panelButtons.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(buttonApply, 3, 0);
            tableLayoutPanel1.Controls.Add(buttonApplyAndRun, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonApplyAndRunSteamDemo, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonTweaks, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(524, 48);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonApply.Location = new Point(442, 3);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(79, 42);
            buttonApply.TabIndex = 0;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // buttonApplyAndRun
            // 
            buttonApplyAndRun.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonApplyAndRun.AutoSize = true;
            buttonApplyAndRun.Location = new Point(294, 3);
            buttonApplyAndRun.Name = "buttonApplyAndRun";
            buttonApplyAndRun.Size = new Size(142, 42);
            buttonApplyAndRun.TabIndex = 1;
            buttonApplyAndRun.Text = "Apply and Run Foundry";
            buttonApplyAndRun.UseVisualStyleBackColor = true;
            buttonApplyAndRun.Click += buttonApplyAndRun_Click;
            // 
            // buttonApplyAndRunSteamDemo
            // 
            buttonApplyAndRunSteamDemo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonApplyAndRunSteamDemo.AutoSize = true;
            buttonApplyAndRunSteamDemo.Location = new Point(84, 3);
            buttonApplyAndRunSteamDemo.Name = "buttonApplyAndRunSteamDemo";
            buttonApplyAndRunSteamDemo.Size = new Size(204, 42);
            buttonApplyAndRunSteamDemo.TabIndex = 2;
            buttonApplyAndRunSteamDemo.Text = "Apply and Run Foundry with Steam";
            buttonApplyAndRunSteamDemo.UseVisualStyleBackColor = true;
            buttonApplyAndRunSteamDemo.Click += buttonApplyAndRunSteamDemo_Click;
            // 
            // buttonTweaks
            // 
            buttonTweaks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonTweaks.Location = new Point(3, 3);
            buttonTweaks.Name = "buttonTweaks";
            buttonTweaks.Size = new Size(75, 42);
            buttonTweaks.TabIndex = 3;
            buttonTweaks.Text = "Toggle Tweaks";
            buttonTweaks.UseVisualStyleBackColor = true;
            buttonTweaks.Click += buttonTweaks_Click;
            // 
            // panelConfigurations
            // 
            panelConfigurations.Controls.Add(panelConfigurationButtons);
            panelConfigurations.Controls.Add(listConfigurations);
            panelConfigurations.Controls.Add(labelConfigurations);
            panelConfigurations.Dock = DockStyle.Right;
            panelConfigurations.Location = new Point(328, 54);
            panelConfigurations.Name = "panelConfigurations";
            panelConfigurations.Size = new Size(200, 345);
            panelConfigurations.TabIndex = 1;
            // 
            // panelConfigurationButtons
            // 
            panelConfigurationButtons.Controls.Add(buttonAddConfiguration);
            panelConfigurationButtons.Controls.Add(buttonRemoveConfiguration);
            panelConfigurationButtons.Dock = DockStyle.Bottom;
            panelConfigurationButtons.Location = new Point(0, 313);
            panelConfigurationButtons.Name = "panelConfigurationButtons";
            panelConfigurationButtons.Size = new Size(200, 32);
            panelConfigurationButtons.TabIndex = 3;
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
            listConfigurations.Size = new Size(200, 325);
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
            panelMods.Controls.Add(listMods);
            panelMods.Controls.Add(labelMods);
            panelMods.Controls.Add(panelModButtons);
            panelMods.Dock = DockStyle.Fill;
            panelMods.Location = new Point(4, 54);
            panelMods.Name = "panelMods";
            panelMods.Size = new Size(324, 345);
            panelMods.TabIndex = 2;
            // 
            // listMods
            // 
            listMods.Dock = DockStyle.Fill;
            listMods.FormattingEnabled = true;
            listMods.IntegralHeight = false;
            listMods.Location = new Point(0, 20);
            listMods.Name = "listMods";
            listMods.Size = new Size(324, 293);
            listMods.Sorted = true;
            listMods.TabIndex = 1;
            listMods.ItemCheck += listMods_ItemCheck;
            listMods.SelectedIndexChanged += listMods_SelectedIndexChanged;
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
            // panelModButtons
            // 
            panelModButtons.AutoSize = true;
            panelModButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelModButtons.Controls.Add(buttonModConfig);
            panelModButtons.Controls.Add(buttonModHome);
            panelModButtons.Dock = DockStyle.Bottom;
            panelModButtons.Location = new Point(0, 313);
            panelModButtons.MinimumSize = new Size(0, 32);
            panelModButtons.Name = "panelModButtons";
            panelModButtons.Size = new Size(324, 32);
            panelModButtons.TabIndex = 4;
            // 
            // buttonModConfig
            // 
            buttonModConfig.AutoSize = true;
            buttonModConfig.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonModConfig.Dock = DockStyle.Left;
            buttonModConfig.Location = new Point(162, 0);
            buttonModConfig.MinimumSize = new Size(162, 32);
            buttonModConfig.Name = "buttonModConfig";
            buttonModConfig.Size = new Size(162, 32);
            buttonModConfig.TabIndex = 3;
            buttonModConfig.Text = "Open Mod Config";
            buttonModConfig.UseVisualStyleBackColor = true;
            buttonModConfig.Click += buttonModConfig_Click;
            // 
            // buttonModHome
            // 
            buttonModHome.AutoSize = true;
            buttonModHome.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonModHome.Dock = DockStyle.Left;
            buttonModHome.Location = new Point(0, 0);
            buttonModHome.MinimumSize = new Size(162, 32);
            buttonModHome.Name = "buttonModHome";
            buttonModHome.Size = new Size(162, 32);
            buttonModHome.TabIndex = 2;
            buttonModHome.Text = "Open Mod Homepage";
            buttonModHome.UseVisualStyleBackColor = true;
            buttonModHome.Click += buttonModHome_Click;
            // 
            // textBoxModInfo
            // 
            textBoxModInfo.AcceptsReturn = true;
            textBoxModInfo.AcceptsTab = true;
            textBoxModInfo.Dock = DockStyle.Fill;
            textBoxModInfo.Location = new Point(5, 5);
            textBoxModInfo.Multiline = true;
            textBoxModInfo.Name = "textBoxModInfo";
            textBoxModInfo.ReadOnly = true;
            textBoxModInfo.Size = new Size(514, 54);
            textBoxModInfo.TabIndex = 0;
            // 
            // panelPath
            // 
            panelPath.Controls.Add(checkBoxTestBranch);
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
            // checkBoxTestBranch
            // 
            checkBoxTestBranch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxTestBranch.AutoSize = true;
            checkBoxTestBranch.Location = new Point(382, -1);
            checkBoxTestBranch.Name = "checkBoxTestBranch";
            checkBoxTestBranch.Size = new Size(142, 19);
            checkBoxTestBranch.TabIndex = 3;
            checkBoxTestBranch.Text = "FOUNDRY test branch";
            checkBoxTestBranch.UseVisualStyleBackColor = true;
            checkBoxTestBranch.CheckedChanged += checkBoxTestBranch_CheckedChanged;
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
            statusStrip1.Location = new Point(4, 511);
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
            // panelDescription
            // 
            panelDescription.Controls.Add(textBoxModInfo);
            panelDescription.Dock = DockStyle.Bottom;
            panelDescription.Location = new Point(4, 399);
            panelDescription.MinimumSize = new Size(0, 64);
            panelDescription.Name = "panelDescription";
            panelDescription.Padding = new Padding(5);
            panelDescription.Size = new Size(524, 64);
            panelDescription.TabIndex = 5;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 537);
            Controls.Add(panelMods);
            Controls.Add(panelConfigurations);
            Controls.Add(panelDescription);
            Controls.Add(panelButtons);
            Controls.Add(panelPath);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Padding = new Padding(4);
            Text = "Foundry Mod Manager v0.4.7";
            Load += FormMain_Load;
            panelButtons.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelConfigurations.ResumeLayout(false);
            panelConfigurationButtons.ResumeLayout(false);
            panelMods.ResumeLayout(false);
            panelMods.PerformLayout();
            panelModButtons.ResumeLayout(false);
            panelModButtons.PerformLayout();
            panelPath.ResumeLayout(false);
            panelPath.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelDescription.ResumeLayout(false);
            panelDescription.PerformLayout();
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
        private Panel panelConfigurationButtons;
        private Button buttonAddConfiguration;
        private Button buttonRemoveConfiguration;
        private Button buttonModHome;
        private Button buttonModConfig;
        private Panel panelModButtons;
        private ToolTip toolTip;
        private TextBox textBoxModInfo;
        private Panel panelDescription;
        private CheckBox checkBoxTestBranch;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonTweaks;
    }
}