using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace To_do_list__1._1_
{
    public partial class Detail_Form : Form
    {
        public Detail_Form()
        {
            InitializeComponent();
        }
        bool saved = true;

        //variable for image
        Image[] images;
        string[] images_path;
        int currentImages = 0;


        //variable for url
        int index = 0;
        string browser = "MicrosoftEdge";

        private void Detail_Form_Load(object sender, EventArgs e)
        {
            this.Text = Global.CurrentL_for_menudrop.Text;

            //read the default browser to open Url if exists
            if (System.IO.File.Exists("Default Browser"))
            {
                StreamReader Browser_file = new StreamReader("Default Browser");
                browser = Browser_file.ReadLine();
                Browser_file.Dispose();
            }
            //init openfiledialog
            openFileDialog1.Title = "Choose the image";
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                                     "All files (*.*)|*.*";

            //init combobox
            comboBox1.Items.Add("Image");
            comboBox1.Items.Add("Url");
            comboBox1.SelectedIndex = 0;

            //open images if exists
            if (System.IO.File.Exists(Global.CurrentL_for_menudrop.Text + "\\" + "Images_Path "))
            {
                StreamReader file = new StreamReader(Global.CurrentL_for_menudrop.Text + "\\" + "Images_Path ");

                int s = int.Parse( file.ReadLine());
                images = new Image[s];
                images_path = new string [s];

                int index = 0;
                while (!file.EndOfStream)
                {
                    images_path[index] = file.ReadLine();
                    images[index] = Image.FromFile(images_path[index]);

                    index++;
                }
                ImageLbl.Text = "Image(" + currentImages + " / " + index + ")";
                file.Dispose();


                //set urlPanel autoscoll (without horizontal scoll)
                UrlPanel.HorizontalScroll.Value = 0;
                UrlPanel.HorizontalScroll.Visible = false;
                UrlPanel.HorizontalScroll.Maximum = 0;
                UrlPanel.HorizontalScroll.Enabled = false;
                UrlPanel.AutoScroll = true;
            }

            //open Urls if exists
            if (System.IO.File.Exists(Global.CurrentL_for_menudrop.Text + "\\" + "Url"))
            {
                StreamReader file = new StreamReader(Global.CurrentL_for_menudrop.Text + "\\" + "Url");

                index =int.Parse( file.ReadLine());

                for (int i = 0; i < index; i++)
                {
                    string txt = file.ReadLine();
                    Point a = new Point(int.Parse(file.ReadLine()), int.Parse(file.ReadLine()));
                    //new url
                    Label Url = new Label();
                    Url.Text = txt;
                    Url.ForeColor = SystemColors.MenuHighlight;
                    Url.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Underline);
                    Url.Size = new Size(UrlPanel.Width, Url.Height);
                    Url.Location = a;
                    Url.Click += Url_Click;

                    UrlPanel.Controls.Add(Url);
                    Url.BringToFront();
                }

                file.Dispose();
            }

            //init browsers
            Browsers.Items.Add("Google");
            Browsers.Items.Add("Microsoft Edge");
            Browsers.Items.Add("Brave");
            Browsers.Items.Add("firefox");


            //open text if exists
            if (System.IO.File.Exists(Global.CurrentL_for_menudrop.Text + "\\" + "Text"))
            {
                StreamReader file = new StreamReader(Global.CurrentL_for_menudrop.Text + "\\" + "Text");
                richTextBox1.Text = file.ReadToEnd();
                file.Dispose();
            }
        }

        private void Url_Click(object sender, EventArgs e)
        {
            int start;
            string _url = (sender as Label).Text;
            start = _url.IndexOf(')');
            _url = _url.Substring(start + 1);

            try
            {
                System.Diagnostics.Process.Start(browser, _url);
            }
            catch
            {
                MessageBox.Show("The system can't find " + browser);
                System.Diagnostics.Process.Start("microsoftEdge", _url);
            }
        }

        private void AddCmd_Click(object sender, EventArgs e)
        {
            saved = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                   DialogResult check = openFileDialog1.ShowDialog();

                    if (check == DialogResult.Cancel) break;
            
                    
                    if (images != null)
                    {
                        //resize image to make it has enough space to save all images
                        Image[] temp = images;
                        images = new Image[images.Length + 1];

                        //preserve previous images
                        for (int i = 0; i < temp.Length; i++)
                        {
                            images[i] = temp[i];
                        }
                        //save new image
                        images[images.Length - 1] = Image.FromFile(openFileDialog1.FileName);

                        //save a new copy of the image in the computer
                        images[images.Length - 1].Save(Global.CurrentL_for_menudrop.Text + "\\" +(images.Length - 1).ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);



                        //save image_path
                        string[] temp2 = images_path;
                        images_path = new string[images_path.Length + 1];

                        //preserve previous paths
                        for (int i = 0; i < temp2.Length; i++)
                        {
                            images_path[i] = temp2[i];
                        }

                        //save new image path
                        images_path[images_path.Length - 1] = Global.CurrentL_for_menudrop.Text + "\\" + (images.Length - 1).ToString() + ".png";
                    }
                    else
                    {
                        //resize image to make it has enough space to save all images
                        images = new Image[1];
                        images[0] = Image.FromFile(openFileDialog1.FileName);

                        //create new folder
                        if (!Directory.Exists(Global.CurrentL_for_menudrop.Text))
                        {
                            Directory.CreateDirectory(Global.CurrentL_for_menudrop.Text);
                        }
                        //save a new copy of image in the computer 
                        images[0].Save(Global.CurrentL_for_menudrop.Text + "\\0.png", System.Drawing.Imaging.ImageFormat.Png);

                        //resize image_path to make it has enough space to save all images
                        images_path = new string[1];
                        images_path[0] = Global.CurrentL_for_menudrop.Text + "\\" + "0.png";
                    }

                    int n = images.Length;
                    ImageLbl.Text = "Image("+ currentImages + " / " + n + ")";

                    break;

                case 1:
                    string txt = Global.InputBox("Insert the Url");

                    if (txt == "") break;

                    index++;

                    //new url
                    Label Url = new Label();
                    Url.Text = index.ToString() + ")" + txt;
                    Url.ForeColor = SystemColors.MenuHighlight;
                    Url.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Underline);
                    Url.Size = new Size(UrlPanel.Width, Url.Height);
                    Url.Location = new Point(8, 11 + 20 * index);
                    Url.Click += Url_Click;

                    UrlPanel.Controls.Add(Url);
                    Url.BringToFront();


                    break;
                default:
                    break;
            }
        }

        private void NextCmd_Click(object sender, EventArgs e)
        {
            if (images == null) return;
            if (currentImages < images.Length)
            {
                currentImages++;
                pictureBox1.BackgroundImage = images[currentImages - 1];
                ImageLbl.Text = "Image(" + currentImages + " / " + images.Length + ")";
            }
        }

        private void PreviousCmd_Click(object sender, EventArgs e)
        {
            if (currentImages - 2 >= 0)
            {
                currentImages--;
                pictureBox1.BackgroundImage = images[currentImages - 1];
                ImageLbl.Text = "Image(" + currentImages + " / " + images.Length + ")";
            }
        }

        private void SaveCmd_Click(object sender, EventArgs e)
        {
            //save the default browser to open Url
            StreamWriter Browser_file = new StreamWriter("Default Browser");
            Browser_file.WriteLine(browser);
            Browser_file.Dispose();

            //create directory if it needs
            if (!Directory.Exists(Global.CurrentL_for_menudrop.Text))
            {
                Directory.CreateDirectory(Global.CurrentL_for_menudrop.Text);
            }

            //save image
            if (images != null)
            {
                StreamWriter file = new StreamWriter(Global.CurrentL_for_menudrop.Text + "\\" + "Images_Path ");

                if (images != null)
                {
                    file.WriteLine(images.Length.ToString());

                    foreach (string a in images_path)
                    {
                        file.WriteLine(a.ToString());
                    }
                }
                file.Dispose();

            }

            //save url
            StreamWriter UrlFile = new StreamWriter(Global.CurrentL_for_menudrop.Text + "\\" + "Url");
            UrlFile.WriteLine(index.ToString());
            foreach (Control url in UrlPanel.Controls) 
            {
                if (url is Label)
                {
                    if ((url as Label).Text == "Url") continue;

                    UrlFile.WriteLine((url as Label).Text);
                    UrlFile.WriteLine((url as Label).Location.X);
                    UrlFile.WriteLine((url as Label).Location.Y);
                }
            
            }
            UrlFile.Dispose();

            //save text
            StreamWriter TxtFile = new StreamWriter(Global.CurrentL_for_menudrop.Text + "\\" + "Text");
            TxtFile.WriteLine(richTextBox1.Text);
            TxtFile.Dispose();




            saved = true;
            this.Close();
        }

        private void Browsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            saved = false;
            switch(Browsers.SelectedIndex){
                case 0:
                    browser = "chrome";
                    break;
                case 1:
                    browser = "MicrosoftEdge";
                    break;
                case 2:
                    browser = "Brave";
                    break;
                case 3:
                    browser = "firefox";
                    break;
                default:
                    browser = "MicrosoftEdge";
                    break;
            }
        }

        private void Detail_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved == false)
            {
                DialogResult result = MessageBox.Show("Do you want save all changes made", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Cancel) 
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.Yes) SaveCmd.PerformClick();
            }

        }

        private void DeleteCmd_Click(object sender, EventArgs e)
        {
            saved = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    //don't open delet form if there isn't any image
                    if (images == null)
                    {
                        saved = true;
                        MessageBox.Show("There isn't any image");
                        break;
                    }

                    //delete images

                    //save all image in global
                    Global.NewImages = images;

                    //save in a variable if the user want delete an image or an url
                    Global.delete = "Image";

                    //call delete form
                    Form d = new Delete_form();
                    d.ShowDialog();

                    //update images
                    images = Global.NewImages;

                    //update label 
                    ImageLbl.Text = "Image(" + currentImages + " / " + images.Length + ")";

                    break;

                case 1:
                    //don't open delet form if there isn't any url
                    if (images == null)
                    {
                        saved = true;
                        MessageBox.Show("There isn't any url");
                        break;
                    }

                    //delete url
                    Label[] allUrls = new Label[index];
                    Global.urls = new string[index];
                    int i = 0;

                    //get all urls and delete them
                    foreach (Control url in UrlPanel.Controls)
                    {
                        if (url is Label)
                        {
                            if ((url as Label).Text == "Url") continue;
                            allUrls[i] = (url as Label);
                            Global.urls[i] = (url as Label).Text;
                            i++;
                        }
                    }


                    foreach (Label url in allUrls)
                    {
                            UrlPanel.Controls.Remove(url);
                    }

                    //save in a variable if the user want delete an image or an url
                    Global.delete = "Url";

                    //call delete form
                    Form del = new Delete_form();
                    del.ShowDialog();

                    index = 0;
                    foreach (string url in Global.urls)
                    {
                        index++;

                        //new url
                        Label Url = new Label();
                        Url.Text = url;
                        Url.ForeColor = SystemColors.MenuHighlight;
                        Url.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Underline);
                        Url.Size = new Size(UrlPanel.Width, Url.Height);
                        Url.Location = new Point(8, 11 + 20 * index);
                        Url.Click += Url_Click;

                        UrlPanel.Controls.Add(Url);
                        Url.BringToFront();
                    }

                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentImages != 0)
            {
                System.Diagnostics.Process.Start(@images_path[currentImages - 1]);
            }
        }
    }
}
