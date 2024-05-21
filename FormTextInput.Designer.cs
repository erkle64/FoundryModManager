namespace FoundryModManager
{
    partial class FormTextInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTextInput));
            panel1 = new Panel();
            buttonOk = new Button();
            buttonCancel = new Button();
            panel2 = new Panel();
            textName = new TextBox();
            panel3 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonOk);
            panel1.Controls.Add(buttonCancel);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 82);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 8, 8, 8);
            panel1.Size = new Size(314, 42);
            panel1.TabIndex = 0;
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = DialogResult.OK;
            buttonOk.Dock = DockStyle.Right;
            buttonOk.Location = new Point(106, 8);
            buttonOk.Margin = new Padding(2, 2, 2, 2);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(100, 26);
            buttonOk.TabIndex = 1;
            buttonOk.Text = "&Ok";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Dock = DockStyle.Right;
            buttonCancel.Location = new Point(206, 8);
            buttonCancel.Margin = new Padding(2, 2, 12, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(100, 26);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "&Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(textName);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 40);
            panel2.Margin = new Padding(2, 2, 2, 2);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8, 8, 8, 8);
            panel2.Size = new Size(314, 42);
            panel2.TabIndex = 2;
            // 
            // textName
            // 
            textName.Dock = DockStyle.Fill;
            textName.Location = new Point(8, 8);
            textName.Margin = new Padding(2, 2, 2, 2);
            textName.Name = "textName";
            textName.Size = new Size(298, 23);
            textName.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(2, 2, 2, 2);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(8, 8, 8, 8);
            panel3.Size = new Size(314, 40);
            panel3.TabIndex = 3;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(298, 24);
            label1.TabIndex = 0;
            label1.Text = "Name for new configuration?";
            // 
            // FormTextInput
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(314, 124);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            Name = "FormTextInput";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuration Name";
            Load += FormTextInput_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonOk;
        private Button buttonCancel;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        public TextBox textName;
    }
}