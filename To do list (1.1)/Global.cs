using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_list__1._1_
{
    class Global
    {

        //public variable
        public static System.Windows.Forms.Label CurrentL_for_menudrop;
        public static Image[] NewImages;
        public static string delete;
        public static string[] urls;

       

        

        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////

        //Public InputBox
        private static Form box = new Form();
        private static TextBox txt2 = new TextBox();
        private static Button okCmd = new Button();
        public static string InputBox(string question = "")
        {
            //setting
            box.FormBorderStyle = FormBorderStyle.FixedSingle;
            box.ClientSize = new Size(360, 78);
            box.Text = "InputBox";
            box.StartPosition = FormStartPosition.CenterParent;
            box.FormClosed += Box_FormClosed;
            box.KeyDown += Box_KeyDown;

            //new label
            Label lbl = new Label();
            lbl.Text = question;
            lbl.Location = new Point(5, 5);
            lbl.AutoSize = true;
            lbl.MaximumSize = new Size(box.ClientSize.Width - 10, box.ClientSize.Height - 5);

            box.Controls.Add(lbl);

            //Resize box to fit
            while (box.ClientSize.Height < lbl.Height + 16 + 23 + 26)
            {
                box.ClientSize = new Size(box.ClientSize.Width, box.ClientSize.Height + 1);
            }

            //new textbox
            txt2.Size = new Size(box.ClientSize.Width - 10, 40);
            txt2.Font = new Font("Microsoft Sans Serif", 12f);
            txt2.Text = "";
            txt2.Location = new Point(5, box.ClientSize.Height - 55);
            txt2.KeyDown += Txt2_KeyDown;
            txt2.KeyDown += Box_KeyDown;

            box.Controls.Add(txt2);

            //ok button
            okCmd.Location = new Point(box.ClientSize.Width - 5 - okCmd.Width, box.ClientSize.Height - 26);
            okCmd.Text = "Ok";
            okCmd.Click += OkCmd_Click;
            box.Controls.Add(okCmd);

            //cancel button
            Button CancelCmd = new Button();
            CancelCmd.Location = new Point(5, box.ClientSize.Height - 26);
            CancelCmd.Text = "Cancel";
            CancelCmd.Click += CancelCmd_Click;
            box.Controls.Add(CancelCmd);

            //show dialog
            box.ShowDialog();

            //set focus on txt2
            box.ActiveControl = txt2;

            return txt2.Text;
        }

        private static void Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) box.Close();
        }

        private static void Txt2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                okCmd.PerformClick();
            }
        }

        private static void Box_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (okCmd.Name != "Clicked")
            {
                txt2.Text = "";
            }
        }

        private static void CancelCmd_Click(object sender, EventArgs e)
        {
            txt2.Text = "";
            box.Close();
        }

        private static void OkCmd_Click(object sender, EventArgs e)
        {
            (sender as Button).Name = "Clicked";
            box.Close();
        }


   
    }
}
