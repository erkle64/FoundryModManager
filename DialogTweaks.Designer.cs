namespace FoundryModManager
{
    partial class DialogTweaks
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
            checkedListBoxTweaks = new CheckedListBox();
            buttonCancel = new Button();
            buttonAccept = new Button();
            linkLabelLibrary = new LinkLabel();
            SuspendLayout();
            // 
            // checkedListBoxTweaks
            // 
            checkedListBoxTweaks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListBoxTweaks.FormattingEnabled = true;
            checkedListBoxTweaks.Location = new Point(12, 30);
            checkedListBoxTweaks.Name = "checkedListBoxTweaks";
            checkedListBoxTweaks.Size = new Size(460, 418);
            checkedListBoxTweaks.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(397, 456);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            buttonAccept.DialogResult = DialogResult.OK;
            buttonAccept.Location = new Point(316, 456);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(75, 23);
            buttonAccept.TabIndex = 2;
            buttonAccept.Text = "Accept";
            buttonAccept.UseVisualStyleBackColor = true;
            // 
            // linkLabelLibrary
            // 
            linkLabelLibrary.AutoSize = true;
            linkLabelLibrary.Location = new Point(12, 9);
            linkLabelLibrary.Name = "linkLabelLibrary";
            linkLabelLibrary.Size = new Size(295, 15);
            linkLabelLibrary.TabIndex = 4;
            linkLabelLibrary.TabStop = true;
            linkLabelLibrary.Text = "Foundry Library Website: https://foundry.erkle64.com/";
            linkLabelLibrary.LinkClicked += linkLabelLibrary_LinkClicked;
            // 
            // DialogTweaks
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(484, 491);
            Controls.Add(linkLabelLibrary);
            Controls.Add(buttonAccept);
            Controls.Add(buttonCancel);
            Controls.Add(checkedListBoxTweaks);
            Name = "DialogTweaks";
            Text = "Toggle Tweaks";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBoxTweaks;
        private Button buttonCancel;
        private Button buttonAccept;
        private LinkLabel linkLabelLibrary;
    }
}