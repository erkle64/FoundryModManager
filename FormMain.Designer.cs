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
            buttonTweaks = new Button();
            buttonApplyAndRunSteamDemo = new Button();
            buttonApplyAndRun = new Button();
            buttonApply = new Button();
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
            panelButtons.Location = new Point(5, 539);
            panelButtons.Margin = new Padding(2);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(611, 55);
            panelButtons.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            tableLayoutPanel1.Controls.Add(buttonTweaks, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonApplyAndRunSteamDemo, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonApplyAndRun, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonApply, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.MaximumSize = new Size(116667, 55);
            tableLayoutPanel1.MinimumSize = new Size(611, 55);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.Size = new Size(611, 55);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // buttonTweaks
            // 
            buttonTweaks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonTweaks.Location = new Point(2, 2);
            buttonTweaks.Margin = new Padding(2);
            buttonTweaks.Name = "buttonTweaks";
            buttonTweaks.Size = new Size(105, 51);
            buttonTweaks.TabIndex = 3;
            buttonTweaks.Text = "Toggle Tweaks";
            buttonTweaks.UseVisualStyleBackColor = true;
            buttonTweaks.Click += buttonTweaks_Click;
            // 
            // buttonApplyAndRunSteamDemo
            // 
            buttonApplyAndRunSteamDemo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonApplyAndRunSteamDemo.AutoSize = true;
            buttonApplyAndRunSteamDemo.Location = new Point(111, 2);
            buttonApplyAndRunSteamDemo.Margin = new Padding(2);
            buttonApplyAndRunSteamDemo.Name = "buttonApplyAndRunSteamDemo";
            buttonApplyAndRunSteamDemo.Size = new Size(191, 51);
            buttonApplyAndRunSteamDemo.TabIndex = 2;
            buttonApplyAndRunSteamDemo.Text = "Apply and Run Foundry with Steam";
            buttonApplyAndRunSteamDemo.UseVisualStyleBackColor = true;
            buttonApplyAndRunSteamDemo.Click += buttonApplyAndRunSteamDemo_Click;
            // 
            // buttonApplyAndRun
            // 
            buttonApplyAndRun.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonApplyAndRun.AutoSize = true;
            buttonApplyAndRun.Location = new Point(306, 2);
            buttonApplyAndRun.Margin = new Padding(2);
            buttonApplyAndRun.Name = "buttonApplyAndRun";
            buttonApplyAndRun.Size = new Size(191, 51);
            buttonApplyAndRun.TabIndex = 1;
            buttonApplyAndRun.Text = "Apply and Run Foundry";
            buttonApplyAndRun.UseVisualStyleBackColor = true;
            buttonApplyAndRun.Click += buttonApplyAndRun_Click;
            // 
            // buttonApply
            // 
            buttonApply.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonApply.Location = new Point(501, 2);
            buttonApply.Margin = new Padding(2);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(108, 51);
            buttonApply.TabIndex = 0;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // panelConfigurations
            // 
            panelConfigurations.Controls.Add(panelConfigurationButtons);
            panelConfigurations.Controls.Add(listConfigurations);
            panelConfigurations.Controls.Add(labelConfigurations);
            panelConfigurations.Dock = DockStyle.Right;
            panelConfigurations.Location = new Point(383, 63);
            panelConfigurations.Margin = new Padding(2);
            panelConfigurations.Name = "panelConfigurations";
            panelConfigurations.Size = new Size(233, 402);
            panelConfigurations.TabIndex = 1;
            // 
            // panelConfigurationButtons
            // 
            panelConfigurationButtons.Controls.Add(buttonAddConfiguration);
            panelConfigurationButtons.Controls.Add(buttonRemoveConfiguration);
            panelConfigurationButtons.Dock = DockStyle.Bottom;
            panelConfigurationButtons.Location = new Point(0, 365);
            panelConfigurationButtons.Margin = new Padding(2);
            panelConfigurationButtons.Name = "panelConfigurationButtons";
            panelConfigurationButtons.Size = new Size(233, 37);
            panelConfigurationButtons.TabIndex = 3;
            // 
            // buttonAddConfiguration
            // 
            buttonAddConfiguration.Dock = DockStyle.Fill;
            buttonAddConfiguration.Location = new Point(0, 0);
            buttonAddConfiguration.Margin = new Padding(2);
            buttonAddConfiguration.Name = "buttonAddConfiguration";
            buttonAddConfiguration.Size = new Size(116, 37);
            buttonAddConfiguration.TabIndex = 1;
            buttonAddConfiguration.Text = "New Config";
            buttonAddConfiguration.UseVisualStyleBackColor = true;
            buttonAddConfiguration.Click += buttonAddConfiguration_Click;
            // 
            // buttonRemoveConfiguration
            // 
            buttonRemoveConfiguration.Dock = DockStyle.Right;
            buttonRemoveConfiguration.Location = new Point(116, 0);
            buttonRemoveConfiguration.Margin = new Padding(2);
            buttonRemoveConfiguration.Name = "buttonRemoveConfiguration";
            buttonRemoveConfiguration.Size = new Size(117, 37);
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
            listConfigurations.Location = new Point(0, 23);
            listConfigurations.Margin = new Padding(2);
            listConfigurations.Name = "listConfigurations";
            listConfigurations.Size = new Size(233, 379);
            listConfigurations.TabIndex = 2;
            listConfigurations.SelectedIndexChanged += listConfigurations_SelectedIndexChanged;
            // 
            // labelConfigurations
            // 
            labelConfigurations.Dock = DockStyle.Top;
            labelConfigurations.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelConfigurations.Location = new Point(0, 0);
            labelConfigurations.Margin = new Padding(2, 0, 2, 0);
            labelConfigurations.Name = "labelConfigurations";
            labelConfigurations.Size = new Size(233, 23);
            labelConfigurations.TabIndex = 1;
            labelConfigurations.Text = "Configurations";
            // 
            // panelMods
            // 
            panelMods.Controls.Add(listMods);
            panelMods.Controls.Add(labelMods);
            panelMods.Controls.Add(panelModButtons);
            panelMods.Dock = DockStyle.Fill;
            panelMods.Location = new Point(5, 63);
            panelMods.Margin = new Padding(2);
            panelMods.Name = "panelMods";
            panelMods.Size = new Size(378, 402);
            panelMods.TabIndex = 2;
            // 
            // listMods
            // 
            listMods.Dock = DockStyle.Fill;
            listMods.FormattingEnabled = true;
            listMods.IntegralHeight = false;
            listMods.Location = new Point(0, 23);
            listMods.Margin = new Padding(2);
            listMods.Name = "listMods";
            listMods.Size = new Size(378, 342);
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
            labelMods.Margin = new Padding(2, 0, 2, 0);
            labelMods.Name = "labelMods";
            labelMods.Size = new Size(378, 23);
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
            panelModButtons.Location = new Point(0, 365);
            panelModButtons.Margin = new Padding(2);
            panelModButtons.MinimumSize = new Size(0, 37);
            panelModButtons.Name = "panelModButtons";
            panelModButtons.Size = new Size(378, 37);
            panelModButtons.TabIndex = 4;
            // 
            // buttonModConfig
            // 
            buttonModConfig.AutoSize = true;
            buttonModConfig.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonModConfig.Dock = DockStyle.Left;
            buttonModConfig.Location = new Point(189, 0);
            buttonModConfig.Margin = new Padding(2);
            buttonModConfig.MinimumSize = new Size(189, 37);
            buttonModConfig.Name = "buttonModConfig";
            buttonModConfig.Size = new Size(189, 37);
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
            buttonModHome.Margin = new Padding(2);
            buttonModHome.MinimumSize = new Size(189, 37);
            buttonModHome.Name = "buttonModHome";
            buttonModHome.Size = new Size(189, 37);
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
            textBoxModInfo.Location = new Point(7, 7);
            textBoxModInfo.Margin = new Padding(2);
            textBoxModInfo.Multiline = true;
            textBoxModInfo.Name = "textBoxModInfo";
            textBoxModInfo.ReadOnly = true;
            textBoxModInfo.Size = new Size(597, 60);
            textBoxModInfo.TabIndex = 0;
            // 
            // panelPath
            // 
            panelPath.Controls.Add(checkBoxTestBranch);
            panelPath.Controls.Add(inputPath);
            panelPath.Controls.Add(buttonBrowse);
            panelPath.Controls.Add(labelPath);
            panelPath.Dock = DockStyle.Top;
            panelPath.Location = new Point(5, 5);
            panelPath.Margin = new Padding(2);
            panelPath.Name = "panelPath";
            panelPath.Padding = new Padding(0, 0, 0, 7);
            panelPath.Size = new Size(611, 58);
            panelPath.TabIndex = 3;
            // 
            // checkBoxTestBranch
            // 
            checkBoxTestBranch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxTestBranch.AutoSize = true;
            checkBoxTestBranch.Location = new Point(470, -2);
            checkBoxTestBranch.Margin = new Padding(2);
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
            inputPath.Location = new Point(0, 23);
            inputPath.Margin = new Padding(2);
            inputPath.Name = "inputPath";
            inputPath.Size = new Size(494, 23);
            inputPath.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Dock = DockStyle.Right;
            buttonBrowse.Location = new Point(494, 23);
            buttonBrowse.Margin = new Padding(2);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(117, 28);
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
            labelPath.Margin = new Padding(2, 0, 2, 0);
            labelPath.Name = "labelPath";
            labelPath.Size = new Size(611, 23);
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
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(5, 594);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(2, 0, 16, 0);
            statusStrip1.Size = new Size(611, 22);
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
            panelDescription.Location = new Point(5, 465);
            panelDescription.Margin = new Padding(2);
            panelDescription.MinimumSize = new Size(0, 74);
            panelDescription.Name = "panelDescription";
            panelDescription.Padding = new Padding(7);
            panelDescription.Size = new Size(611, 74);
            panelDescription.TabIndex = 5;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 621);
            Controls.Add(panelMods);
            Controls.Add(panelConfigurations);
            Controls.Add(panelDescription);
            Controls.Add(panelButtons);
            Controls.Add(panelPath);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MinimumSize = new Size(634, 421);
            Name = "FormMain";
            Padding = new Padding(5);
            Text = "Foundry Mod Manager v0.4.10";
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
        private Button buttonTweaks;
        private TableLayoutPanel tableLayoutPanel1;
    }
}