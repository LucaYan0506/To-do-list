
namespace To_do_list__1._1_
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
            this.components = new System.ComponentModel.Container();
            this.MenuSlide = new System.Windows.Forms.Panel();
            this.IconBackground = new System.Windows.Forms.PictureBox();
            this.AddNewActivityCmd = new System.Windows.Forms.Button();
            this.IconPanel = new System.Windows.Forms.Panel();
            this.CloseMenuSlide = new System.Windows.Forms.Timer(this.components);
            this.OpenMenuslide = new System.Windows.Forms.Timer(this.components);
            this.OpenCmd = new System.Windows.Forms.Button();
            this.Title2Lbl = new System.Windows.Forms.Label();
            this.Title1Lbl = new System.Windows.Forms.Label();
            this.Title3Lbl = new System.Windows.Forms.Label();
            this.MoveLabel = new System.Windows.Forms.Timer(this.components);
            this.DeleteCmd = new System.Windows.Forms.Button();
            this.FollowMouse = new System.Windows.Forms.Timer(this.components);
            this.MenuSlide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuSlide
            // 
            this.MenuSlide.AutoScroll = true;
            this.MenuSlide.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MenuSlide.Controls.Add(this.IconBackground);
            this.MenuSlide.Location = new System.Drawing.Point(0, 33);
            this.MenuSlide.Name = "MenuSlide";
            this.MenuSlide.Size = new System.Drawing.Size(300, 393);
            this.MenuSlide.TabIndex = 1;
            this.MenuSlide.SizeChanged += new System.EventHandler(this.MenuSlide_SizeChanged);
            this.MenuSlide.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // IconBackground
            // 
            this.IconBackground.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.IconBackground.Location = new System.Drawing.Point(0, 0);
            this.IconBackground.Name = "IconBackground";
            this.IconBackground.Size = new System.Drawing.Size(50, 393);
            this.IconBackground.TabIndex = 2;
            this.IconBackground.TabStop = false;
            this.IconBackground.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // AddNewActivityCmd
            // 
            this.AddNewActivityCmd.Location = new System.Drawing.Point(149, -1);
            this.AddNewActivityCmd.Name = "AddNewActivityCmd";
            this.AddNewActivityCmd.Size = new System.Drawing.Size(152, 35);
            this.AddNewActivityCmd.TabIndex = 1;
            this.AddNewActivityCmd.Text = "Add New Section";
            this.AddNewActivityCmd.UseVisualStyleBackColor = true;
            this.AddNewActivityCmd.Click += new System.EventHandler(this.AddNewSectionCmd_Click);
            this.AddNewActivityCmd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // IconPanel
            // 
            this.IconPanel.AutoScroll = true;
            this.IconPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.IconPanel.Location = new System.Drawing.Point(0, 33);
            this.IconPanel.Name = "IconPanel";
            this.IconPanel.Size = new System.Drawing.Size(50, 393);
            this.IconPanel.TabIndex = 1;
            this.IconPanel.SizeChanged += new System.EventHandler(this.MenuSlide_SizeChanged);
            this.IconPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // CloseMenuSlide
            // 
            this.CloseMenuSlide.Interval = 10;
            this.CloseMenuSlide.Tick += new System.EventHandler(this.CloseMenuSlide_Tick);
            // 
            // OpenMenuslide
            // 
            this.OpenMenuslide.Interval = 10;
            this.OpenMenuslide.Tick += new System.EventHandler(this.OpenMenuslide_Tick);
            // 
            // OpenCmd
            // 
            this.OpenCmd.BackColor = System.Drawing.SystemColors.ControlDark;
            this.OpenCmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenCmd.Location = new System.Drawing.Point(0, 0);
            this.OpenCmd.Name = "OpenCmd";
            this.OpenCmd.Size = new System.Drawing.Size(50, 33);
            this.OpenCmd.TabIndex = 2;
            this.OpenCmd.UseVisualStyleBackColor = false;
            this.OpenCmd.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // Title2Lbl
            // 
            this.Title2Lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Title2Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title2Lbl.Location = new System.Drawing.Point(571, 2);
            this.Title2Lbl.Name = "Title2Lbl";
            this.Title2Lbl.Size = new System.Drawing.Size(263, 45);
            this.Title2Lbl.TabIndex = 3;
            this.Title2Lbl.Text = "In progress";
            this.Title2Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title2Lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // Title1Lbl
            // 
            this.Title1Lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Title1Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title1Lbl.Location = new System.Drawing.Point(304, 2);
            this.Title1Lbl.Name = "Title1Lbl";
            this.Title1Lbl.Size = new System.Drawing.Size(264, 45);
            this.Title1Lbl.TabIndex = 4;
            this.Title1Lbl.Text = "Haven\'t start yet";
            this.Title1Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title1Lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // Title3Lbl
            // 
            this.Title3Lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Title3Lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title3Lbl.Location = new System.Drawing.Point(837, 2);
            this.Title3Lbl.Name = "Title3Lbl";
            this.Title3Lbl.Size = new System.Drawing.Size(264, 45);
            this.Title3Lbl.TabIndex = 5;
            this.Title3Lbl.Text = "Finished";
            this.Title3Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title3Lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // MoveLabel
            // 
            this.MoveLabel.Interval = 1;
            this.MoveLabel.Tick += new System.EventHandler(this.MoveLabel_Tick);
            // 
            // DeleteCmd
            // 
            this.DeleteCmd.Location = new System.Drawing.Point(-1, -1);
            this.DeleteCmd.Name = "DeleteCmd";
            this.DeleteCmd.Size = new System.Drawing.Size(153, 35);
            this.DeleteCmd.TabIndex = 6;
            this.DeleteCmd.Text = "Delete Current Section";
            this.DeleteCmd.UseVisualStyleBackColor = true;
            this.DeleteCmd.Click += new System.EventHandler(this.DeleteCmd_Click);
            this.DeleteCmd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // FollowMouse
            // 
            this.FollowMouse.Interval = 1;
            this.FollowMouse.Tick += new System.EventHandler(this.FollowMouse_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1106, 427);
            this.Controls.Add(this.Title2Lbl);
            this.Controls.Add(this.Title1Lbl);
            this.Controls.Add(this.Title3Lbl);
            this.Controls.Add(this.MenuSlide);
            this.Controls.Add(this.AddNewActivityCmd);
            this.Controls.Add(this.IconPanel);
            this.Controls.Add(this.DeleteCmd);
            this.Controls.Add(this.OpenCmd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(871, 466);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MenuSlide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuSlide;
        private System.Windows.Forms.Panel IconPanel;
        private System.Windows.Forms.Button AddNewActivityCmd;
        private System.Windows.Forms.PictureBox IconBackground;
        private System.Windows.Forms.Timer CloseMenuSlide;
        private System.Windows.Forms.Timer OpenMenuslide;
        private System.Windows.Forms.Button OpenCmd;
        private System.Windows.Forms.Label Title2Lbl;
        private System.Windows.Forms.Label Title1Lbl;
        private System.Windows.Forms.Label Title3Lbl;
        private System.Windows.Forms.Timer MoveLabel;
        private System.Windows.Forms.Button DeleteCmd;
        private System.Windows.Forms.Timer FollowMouse;
    }
}

