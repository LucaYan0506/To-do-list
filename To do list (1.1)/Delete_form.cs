using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_do_list__1._1_
{
    public partial class Delete_form : Form
    {
        public Delete_form()
        {
            InitializeComponent();
        }

        CheckBox get_focused = null;

        //variable image
        int index = 0;
        Image[] images;
        CheckBox[] checkBoxes;

        //variable Url

        private void Delete_form_Load(object sender, EventArgs e)
        {
            UrlPanel.MouseMove += Delete_form_MouseMove;
            ImagePanel.MouseMove += Delete_form_MouseMove;

            if (Global.delete == "Image")
            {
                UrlPanel.Visible = false;
                ImagePanel.Visible = true;
                
                int size = Global.NewImages.Length;
                images = new Image[size];
                checkBoxes = new CheckBox[size];

                foreach (Image i in Global.NewImages)
                {
                    int x = 3 + 189 * (index % 4), y = 3;
                    if (index % 4 == 0) y += 170 * index / 4;


                    //create a picturebox
                    PictureBox picture = new PictureBox();
                    picture.Name = "pic" + (index).ToString();
                    picture.Size = new Size(186, 167);
                    picture.Location = new Point(x, y);
                    picture.BackColor = Color.White;
                    picture.BackgroundImage = i;
                    picture.BackgroundImageLayout = ImageLayout.Zoom;
                    picture.Click += Picture_Click;

                    ImagePanel.Controls.Add(picture);

                    //save the new image found
                    images[index] = i;

                    //create a check box for each picturebox 
                    CheckBox check = new CheckBox();
                    check.Name = "check" + (index).ToString();
                    check.Text = "";
                    check.Size = new Size(15, 14);
                    check.Location = new Point(x + 3, y + 3);
                    check.KeyDown += Delete_form_KeyDown;
                    ImagePanel.Controls.Add(check);
                    check.BringToFront();

                    //save the new checkbox in checkboxes
                    checkBoxes[index] = check;

                    index++;

                    //get the checkbox to focus (so can use key down func)
                    if (get_focused == null) get_focused = check;
                }
            }
            if (Global.delete == "Url")
            {
                UrlPanel.Visible = true;
                ImagePanel.Visible = false;

                for (int i = Global.urls.Length - 1; i >= 0 ; i--)
                {
                    CheckBox Url_delete = new CheckBox();
                    Url_delete.Text = Global.urls[i];
                    Url_delete.ForeColor = SystemColors.MenuHighlight;
                    Url_delete.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Underline);
                    Url_delete.Size = new Size(UrlPanel.Width, Url_delete.Height);
                    int l = Global.urls[i].IndexOf(")");
                    Url_delete.Location = new Point(8,9 + 20 * (int.Parse(Global.urls[i].Substring(0,l)) -  1));
                    Url_delete.KeyDown += Delete_form_KeyDown;
                    UrlPanel.Controls.Add(Url_delete);
                    Url_delete.BringToFront();

                    if (get_focused == null) get_focused = Url_delete;
                }

            }
            DeleteCmd.BringToFront();

            if (get_focused != null) get_focused.Focus();
        }

        private void Picture_Click(object sender, EventArgs e)
        {
            int pic_index = int.Parse((sender as PictureBox).Name.Substring(3));
            if (checkBoxes[pic_index].Checked == false) checkBoxes[pic_index].Checked = true;
            else checkBoxes[pic_index].Checked = false;


        }

        private void DeleteCmd_Click(object sender, EventArgs e)
        {
            if (Global.delete == "Image")
            {
                int size = 0;
                for (int i = 0; i < index; i++)
                {
                    if (checkBoxes[i].Checked == true) continue;
                    size++;
                }
                Global.NewImages = new Image[size];

                int images_index = 0;
                for (int i = 0; i < index; i++)
                {
                    if (checkBoxes[i].Checked == true) continue;
                    Global.NewImages[images_index] = images[i];
                    images_index++;
                }
            }

            if (Global.delete == "Url") 
            {
                int size = 0;

                foreach (Control url in UrlPanel.Controls)
                {

                    if (url is CheckBox)
                    {
                        if ((url as CheckBox).Checked == true) continue;
                        size++;
                    }

                }

                Global.urls = new string[size];
                int ind = 0;
                foreach (Control url in UrlPanel.Controls)
                {

                    if (url is CheckBox)
                    {
                        if ((url as CheckBox).Checked == true) continue;
                        Global.urls[ind] = (url as CheckBox).Text;
                        ind++;
                    }

                }

            }






                this.Close();

        }

        private void Delete_form_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void Delete_form_MouseMove(object sender, MouseEventArgs e)
        {
            if (get_focused != null) get_focused.Focus();
        }
    }
}
