
namespace To_do_list__1._1_
{
    partial class Detail_Form
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
            this.UrlPanel = new System.Windows.Forms.Panel();
            this.Browsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.AddCmd = new System.Windows.Forms.Button();
            this.Textbox = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PreviousCmd = new System.Windows.Forms.Button();
            this.NextCmd = new System.Windows.Forms.Button();
            this.ImageLbl = new System.Windows.Forms.Label();
            this.DeleteCmd = new System.Windows.Forms.Button();
            this.SaveCmd = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UrlPanel.SuspendLayout();
            this.Textbox.SuspendLayout();
            this.ImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UrlPanel
            // 
            this.UrlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UrlPanel.Controls.Add(this.Browsers);
            this.UrlPanel.Controls.Add(this.label1);
            this.UrlPanel.Location = new System.Drawing.Point(12, 46);
            this.UrlPanel.Name = "UrlPanel";
            this.UrlPanel.Size = new System.Drawing.Size(401, 200);
            this.UrlPanel.TabIndex = 0;
            // 
            // Browsers
            // 
            this.Browsers.FormattingEnabled = true;
            this.Browsers.Location = new System.Drawing.Point(239, 3);
            this.Browsers.Name = "Browsers";
            this.Browsers.Size = new System.Drawing.Size(159, 21);
            this.Browsers.TabIndex = 1;
            this.Browsers.Text = "Default Browser";
            this.Browsers.SelectedIndexChanged += new System.EventHandler(this.Browsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Url";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(257, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // AddCmd
            // 
            this.AddCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCmd.Location = new System.Drawing.Point(275, 11);
            this.AddCmd.Name = "AddCmd";
            this.AddCmd.Size = new System.Drawing.Size(168, 28);
            this.AddCmd.TabIndex = 1;
            this.AddCmd.Text = "Add";
            this.AddCmd.UseVisualStyleBackColor = true;
            this.AddCmd.Click += new System.EventHandler(this.AddCmd_Click);
            // 
            // Textbox
            // 
            this.Textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Textbox.Controls.Add(this.richTextBox1);
            this.Textbox.Controls.Add(this.label2);
            this.Textbox.Location = new System.Drawing.Point(12, 264);
            this.Textbox.Name = "Textbox";
            this.Textbox.Size = new System.Drawing.Size(401, 188);
            this.Textbox.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(398, 156);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Text";
            // 
            // ImagePanel
            // 
            this.ImagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ImagePanel.Controls.Add(this.pictureBox1);
            this.ImagePanel.Controls.Add(this.PreviousCmd);
            this.ImagePanel.Controls.Add(this.NextCmd);
            this.ImagePanel.Controls.Add(this.ImageLbl);
            this.ImagePanel.Location = new System.Drawing.Point(419, 46);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(389, 406);
            this.ImagePanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::To_do_list__1._1_.Properties.Resources.NoneImage;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(12, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(372, 320);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PreviousCmd
            // 
            this.PreviousCmd.BackgroundImage = global::To_do_list__1._1_.Properties.Resources.Actions_go_previous_icon;
            this.PreviousCmd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PreviousCmd.Location = new System.Drawing.Point(3, 358);
            this.PreviousCmd.Name = "PreviousCmd";
            this.PreviousCmd.Size = new System.Drawing.Size(54, 46);
            this.PreviousCmd.TabIndex = 4;
            this.PreviousCmd.UseVisualStyleBackColor = true;
            this.PreviousCmd.Click += new System.EventHandler(this.PreviousCmd_Click);
            // 
            // NextCmd
            // 
            this.NextCmd.BackgroundImage = global::To_do_list__1._1_.Properties.Resources.same_1_;
            this.NextCmd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NextCmd.Location = new System.Drawing.Point(332, 358);
            this.NextCmd.Name = "NextCmd";
            this.NextCmd.Size = new System.Drawing.Size(54, 46);
            this.NextCmd.TabIndex = 3;
            this.NextCmd.UseVisualStyleBackColor = true;
            this.NextCmd.Click += new System.EventHandler(this.NextCmd_Click);
            // 
            // ImageLbl
            // 
            this.ImageLbl.AutoSize = true;
            this.ImageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageLbl.ForeColor = System.Drawing.Color.ForestGreen;
            this.ImageLbl.Location = new System.Drawing.Point(8, 9);
            this.ImageLbl.Name = "ImageLbl";
            this.ImageLbl.Size = new System.Drawing.Size(90, 20);
            this.ImageLbl.TabIndex = 2;
            this.ImageLbl.Text = "Image (0/0)";
            // 
            // DeleteCmd
            // 
            this.DeleteCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCmd.Location = new System.Drawing.Point(449, 12);
            this.DeleteCmd.Name = "DeleteCmd";
            this.DeleteCmd.Size = new System.Drawing.Size(180, 28);
            this.DeleteCmd.TabIndex = 2;
            this.DeleteCmd.Text = "Delete";
            this.DeleteCmd.UseVisualStyleBackColor = true;
            this.DeleteCmd.Click += new System.EventHandler(this.DeleteCmd_Click);
            // 
            // SaveCmd
            // 
            this.SaveCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveCmd.Location = new System.Drawing.Point(635, 11);
            this.SaveCmd.Name = "SaveCmd";
            this.SaveCmd.Size = new System.Drawing.Size(168, 28);
            this.SaveCmd.TabIndex = 3;
            this.SaveCmd.Text = "Save";
            this.SaveCmd.UseVisualStyleBackColor = true;
            this.SaveCmd.Click += new System.EventHandler(this.SaveCmd_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Detail_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 461);
            this.Controls.Add(this.SaveCmd);
            this.Controls.Add(this.DeleteCmd);
            this.Controls.Add(this.ImagePanel);
            this.Controls.Add(this.Textbox);
            this.Controls.Add(this.AddCmd);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.UrlPanel);
            this.Name = "Detail_Form";
            this.Text = "Detail_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Detail_Form_FormClosing);
            this.Load += new System.EventHandler(this.Detail_Form_Load);
            this.UrlPanel.ResumeLayout(false);
            this.UrlPanel.PerformLayout();
            this.Textbox.ResumeLayout(false);
            this.Textbox.PerformLayout();
            this.ImagePanel.ResumeLayout(false);
            this.ImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UrlPanel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button AddCmd;
        private System.Windows.Forms.Panel Textbox;
        private System.Windows.Forms.Panel ImagePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button PreviousCmd;
        private System.Windows.Forms.Button NextCmd;
        private System.Windows.Forms.Label ImageLbl;
        private System.Windows.Forms.Button DeleteCmd;
        private System.Windows.Forms.Button SaveCmd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox Browsers;
    }
}