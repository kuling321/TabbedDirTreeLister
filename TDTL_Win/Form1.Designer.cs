namespace WindowsFormsApp1
{
    partial class Form1
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
            this.listBox1_ = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1_
            // 
            this.listBox1_.AllowDrop = true;
            this.listBox1_.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1_.FormattingEnabled = true;
            this.listBox1_.Location = new System.Drawing.Point(3, 46);
            this.listBox1_.Name = "listBox1_";
            this.listBox1_.Size = new System.Drawing.Size(566, 251);
            this.listBox1_.TabIndex = 1;
            this.listBox1_.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragDrop);
            this.listBox1_.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 34);
            this.label1.TabIndex = 3;
            this.label1.Text = "To Generate a tabbed list of a Directory, drop only a directory via Windows Explo" +
    "rer. Dropping a directory immidiately generates a hierarchical tabbed list right" +
    " into root of same directory.";
            this.label1.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragDrop);
            this.label1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(566, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tabbed Directory Tree Lister\r\nversion : 1.0.0.0\r\ncontact developer at: kursatturk" +
    "ay@gmail.com";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 343);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1_);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TABBED DIRECTORY TREE LISTER";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFolderPath_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

