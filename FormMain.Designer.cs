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
            this.buttonApplyAndRun = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.panelConfigurations = new System.Windows.Forms.Panel();
            this.listConfigurations = new System.Windows.Forms.ListBox();
            this.labelConfigurations = new System.Windows.Forms.Label();
            this.panelMods = new System.Windows.Forms.Panel();
            this.listMods = new System.Windows.Forms.CheckedListBox();
            this.labelMods = new System.Windows.Forms.Label();
            this.panelButtons.SuspendLayout();
            this.panelConfigurations.SuspendLayout();
            this.panelMods.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonApplyAndRun);
            this.panelButtons.Controls.Add(this.buttonApply);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 368);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.panelButtons.Size = new System.Drawing.Size(532, 48);
            this.panelButtons.TabIndex = 0;
            // 
            // buttonApplyAndRun
            // 
            this.buttonApplyAndRun.AutoSize = true;
            this.buttonApplyAndRun.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonApplyAndRun.Location = new System.Drawing.Point(310, 5);
            this.buttonApplyAndRun.Name = "buttonApplyAndRun";
            this.buttonApplyAndRun.Size = new System.Drawing.Size(142, 38);
            this.buttonApplyAndRun.TabIndex = 1;
            this.buttonApplyAndRun.Text = "Apply and Run Foundry";
            this.buttonApplyAndRun.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonApply.Location = new System.Drawing.Point(452, 5);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 38);
            this.buttonApply.TabIndex = 0;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // panelConfigurations
            // 
            this.panelConfigurations.Controls.Add(this.listConfigurations);
            this.panelConfigurations.Controls.Add(this.labelConfigurations);
            this.panelConfigurations.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelConfigurations.Location = new System.Drawing.Point(332, 0);
            this.panelConfigurations.Name = "panelConfigurations";
            this.panelConfigurations.Size = new System.Drawing.Size(200, 368);
            this.panelConfigurations.TabIndex = 1;
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
            this.listConfigurations.Size = new System.Drawing.Size(200, 348);
            this.listConfigurations.TabIndex = 2;
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
            this.panelMods.Controls.Add(this.listMods);
            this.panelMods.Controls.Add(this.labelMods);
            this.panelMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMods.Location = new System.Drawing.Point(0, 0);
            this.panelMods.Name = "panelMods";
            this.panelMods.Size = new System.Drawing.Size(332, 368);
            this.panelMods.TabIndex = 2;
            // 
            // listMods
            // 
            this.listMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMods.FormattingEnabled = true;
            this.listMods.IntegralHeight = false;
            this.listMods.Location = new System.Drawing.Point(0, 20);
            this.listMods.Name = "listMods";
            this.listMods.Size = new System.Drawing.Size(332, 348);
            this.listMods.TabIndex = 1;
            // 
            // labelMods
            // 
            this.labelMods.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMods.Location = new System.Drawing.Point(0, 0);
            this.labelMods.Name = "labelMods";
            this.labelMods.Size = new System.Drawing.Size(332, 20);
            this.labelMods.TabIndex = 0;
            this.labelMods.Text = "Mods";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 416);
            this.Controls.Add(this.panelMods);
            this.Controls.Add(this.panelConfigurations);
            this.Controls.Add(this.panelButtons);
            this.Name = "FormMain";
            this.Text = "Foundry Mod Manager";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.panelConfigurations.ResumeLayout(false);
            this.panelMods.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}