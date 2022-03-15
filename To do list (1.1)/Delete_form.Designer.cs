
namespace To_do_list__1._1_
{
    partial class Delete_form
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
            this.DeleteCmd = new System.Windows.Forms.Button();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.UrlPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // DeleteCmd
            // 
            this.DeleteCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCmd.Location = new System.Drawing.Point(655, 415);
            this.DeleteCmd.Name = "DeleteCmd";
            this.DeleteCmd.Size = new System.Drawing.Size(100, 32);
            this.DeleteCmd.TabIndex = 0;
            this.DeleteCmd.Text = "Delete";
            this.DeleteCmd.UseVisualStyleBackColor = true;
            this.DeleteCmd.Click += new System.EventHandler(this.DeleteCmd_Click);
            // 
            // ImagePanel
            // 
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePanel.Location = new System.Drawing.Point(0, 0);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(758, 450);
            this.ImagePanel.TabIndex = 1;
            // 
            // UrlPanel
            // 
            this.UrlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UrlPanel.Location = new System.Drawing.Point(0, 0);
            this.UrlPanel.Name = "UrlPanel";
            this.UrlPanel.Size = new System.Drawing.Size(758, 450);
            this.UrlPanel.TabIndex = 0;
            // 
            // Delete_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.ImagePanel);
            this.Controls.Add(this.DeleteCmd);
            this.Controls.Add(this.UrlPanel);
            this.Name = "Delete_form";
            this.Text = "Delete_form";
            this.Load += new System.EventHandler(this.Delete_form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Delete_form_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Delete_form_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteCmd;
        private System.Windows.Forms.Panel ImagePanel;
        private System.Windows.Forms.Panel UrlPanel;
    }
}