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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //dropMenu
         Panel DropMenu = new Panel();
         Label[] options;

        private void Show_DropMenu(Point Dropmenu_location)
        {
            options = new Label[2];

            DropMenu.Name = "DropMenu";
            DropMenu.BackColor = Color.White;
            DropMenu.Size = new Size(152, 44);
            DropMenu.Location = Dropmenu_location;
            DropMenu.Visible = true;
            DropMenu.BorderStyle = BorderStyle.FixedSingle;

            this.Controls.Add(DropMenu);
            DropMenu.BringToFront();

            string[] option_text = { "Order                        >", "Detail" };
            for (int i = 0; i < 2; i++)
            {
                options[i] = new Label();
                options[i].Text = option_text[i];
                options[i].Font = new Font("Microsoft Sans Serif", 10f);
                options[i].Size = new Size(DropMenu.Width, options[i].Height);
                options[i].Location = new Point(0, 20 * i);
                options[i].MouseMove += ChangeColorLabel;
                DropMenu.Controls.Add(options[i]);

                if (option_text[i] == "Order                        >")
                {
                    options[i].MouseHover += Show_orderInfo;
                }

                if (option_text[i] == "Detail")
                options[i].Click += Show_detail;

            }
        }

        Panel SubMenu = new Panel();
       
        private void Show_orderInfo(object sender, EventArgs e)
        {
            SubMenu.Visible = true;
            SubMenu.BackColor = Color.FromArgb(220, 220, 220);
            SubMenu.Size = new Size (80, 35);
            SubMenu.BorderStyle = BorderStyle.FixedSingle;
            SubMenu.Location = new Point(DropMenu.Location.X + DropMenu.Width - 2,DropMenu.Location.Y + 1);
            this.Controls.Add(SubMenu);

            //add label (a->z)
            Label Low_High = new Label();
            Low_High.Text = "A -> Z";
            Low_High.Font = new Font("Microsoft Sans Serif", 10f);
            Low_High.Size = new Size(SubMenu.Width, Low_High.PreferredHeight);
            Low_High.BackColor = Color.White;
            Low_High.MouseMove += ChangeColorLabel2;
            Low_High.Click += Low_High_Click;

            SubMenu.Controls.Add(Low_High);

            //add label (z->a)
            Label High_Low = new Label();
            High_Low.Text = "Z -> A";
            High_Low.Font = new Font("Microsoft Sans Serif", 10f);
            High_Low.Size = new Size(SubMenu.Width, High_Low.PreferredHeight);
            High_Low.Location = new Point(0, Low_High.Height);
            High_Low.BackColor = Color.White;
            High_Low.MouseMove += ChangeColorLabel2;
            High_Low.Click += High_Low_Click;

            SubMenu.Controls.Add(High_Low);

            SubMenu.BringToFront();
        }

        Label[] labels;
        private void Low_High_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working in progress");
            /*
            int size = 0;
            Label firstLabel = new Label();
            foreach (Control c in CustomizePanel.Controls)
            {
                if (c is Label)
                {
                    if ((c as Label).Location.X != Global.CurrentL_for_menudrop.Location.X) continue;
                    if (size == 0) firstLabel = (c as Label);
                    size++;
                }
            }

            if (labels == null)
            {

                labels = new Label[size];

                int index = 0;
                foreach (Control c in CustomizePanel.Controls)
                {

                    if (c is Label)
                    {
                        if ((c as Label).Location.X != Global.CurrentL_for_menudrop.Location.X) continue;
                        if (size == labels.Length && labels[index] == (c as Label)) break;
                        labels[index] = (c as Label);
                        index++;
                    }
                }

                //reorder labels based on the tabindex (so highest tabindex in on the bot)
                for (int x = 1; x < labels.Length; x++)
                {
                    for (int y = 0; y < x; y++)
                    {
                        if (labels[x].TabIndex > labels[y].TabIndex && labels[x].Location.Y < labels[y].Location.Y)
                        {
                            Point temp = labels[x].Location;
                            labels[x].Location = labels[y].Location;
                            labels[y].Location = temp;
                        }
                    }
                }
            }
            else if (labels[0] != firstLabel)
            {

                labels = new Label[size];

                int index = 0;
                foreach (Control c in CustomizePanel.Controls)
                {

                    if (c is Label)
                    {
                        if ((c as Label).Location.X != Global.CurrentL_for_menudrop.Location.X) continue;
                        if (size == labels.Length && labels[index] == (c as Label)) break;
                        labels[index] = (c as Label);
                        index++;
                    }
                }

                //reorder labels based on the tabindex (so highest tabindex in on the bot)
                for (int x = 1; x < labels.Length; x++)
                {
                    for (int y = 0; y < x; y++)
                    {
                        if (labels[x].TabIndex > labels[y].TabIndex && labels[x].Location.Y < labels[y].Location.Y)
                        {
                            Point temp = labels[x].Location;
                            labels[x].Location = labels[y].Location;
                            labels[y].Location = temp;
                        }
                    }
                }
            }


            for (int x = 0; x < size - 1; x++)
            {
                for (int y = x + 1; y < size; y++)
                {
                    if (labels[x].Text == labels[y].Text) continue;

                    int i = 0;
                    int char_and_number = 0;

                    while (labels[x].Text[i] == labels[y].Text[i])
                    {
                        if (labels[x].Text[i] - '0' < 10 && labels[x].Text[i] - '0' >= 0) break;
                        i++;
                    }

                    int first = labels[x].Text[i], second = labels[y].Text[i];

                    if (first - '0' < 10 && first - '0' >= 0)
                    {
                        first = first - '0';
                        int i2 = i + 1;

                        if (i2 < labels[x].Text.Length)
                        {
                            while (labels[x].Text[i2] - '0' < 10 && labels[x].Text[i2] - '0' >= 0)
                            {
                                first *= 10;
                                first += labels[x].Text[i2] - '0';
                                i2++;
                                if (i2 >= labels[x].Text.Length) break;
                            }
                        }
                    }
                    else char_and_number += 1;

                    if (second - '0' < 10 && second - '0' >= 0)
                    {
                        second = second - '0';
                        i++;
                        if (i < labels[y].Text.Length)
                        {
                            while (labels[y].Text[i] - '0' < 10 && labels[y].Text[i] - '0' >= 0)
                            {
                                second *= 10;
                                second += labels[y].Text[i] - '0';
                                i++;
                                if (i >= labels[y].Text.Length) break;
                            }
                        }

                    }
                    else char_and_number += 2;


                    if (char_and_number == 2)
                    {
                        Point temp = labels[x].Location;
                        labels[x].Location = labels[y].Location;
                        labels[y].Location = temp;

                        Label temp2 = labels[x];
                        labels[x] = labels[y];
                        labels[y] = temp2;
                    }

                    if (first > second && char_and_number % 3 == 0)
                    {
                        Point temp = labels[x].Location;
                        labels[x].Location = labels[y].Location;
                        labels[y].Location = temp;

                        Label temp2 = labels[x];
                        labels[x] = labels[y];
                        labels[y] = temp2;
                    }



                }
            }

            DropMenu.Visible = false;
            SubMenu.Visible = false;
            */
        }

        private void High_Low_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working in progress");
            /*
            int size = 0;
            Label firstLabel = new Label();
            foreach (Control c in CustomizePanel.Controls)
            {
                if (c is Label)
                {
                    if ((c as Label).Location.X != Global.CurrentL_for_menudrop.Location.X) continue;
                    if (size == 0) firstLabel = (c as Label);
                    size++;
                }
            }

            if (labels == null)
            {

                labels = new Label[size];

                int index = 0;
                foreach (Control c in CustomizePanel.Controls)
                {

                    if (c is Label)
                    {
                        if ((c as Label).Location.X != Global.CurrentL_for_menudrop.Location.X) continue;
                        if (size == labels.Length && labels[index] == (c as Label)) break;
                        labels[index] = (c as Label);
                        index++;
                    }
                }

                //reorder labels based on the tabindex (so highest tabindex in on the bot)
                for (int x = 1; x < labels.Length; x++)
                {
                    for (int y = 0; y < x; y++)
                    {
                        if (labels[x].TabIndex > labels[y].TabIndex && labels[x].Location.Y < labels[y].Location.Y)
                        {
                            Point temp = labels[x].Location;
                            labels[x].Location = labels[y].Location;
                            labels[y].Location = temp;
                        }
                    }
                }
            }
            else if (labels[0] != firstLabel)
            {

                labels = new Label[size];

                int index = 0;
                foreach (Control c in CustomizePanel.Controls)
                {

                    if (c is Label)
                    {
                        if ((c as Label).Location.X != Global.CurrentL_for_menudrop.Location.X) continue;
                        if (size == labels.Length && labels[index] == (c as Label)) break;
                        labels[index] = (c as Label);
                        index++;
                    }
                }

                //reorder labels based on the tabindex (so highest tabindex in on the bot)
                for (int x = 1; x < labels.Length; x++)
                {
                    for (int y = 0; y < x; y++)
                    {
                        if (labels[x].TabIndex > labels[y].TabIndex && labels[x].Location.Y < labels[y].Location.Y)
                        {
                            Point temp = labels[x].Location;
                            labels[x].Location = labels[y].Location;
                            labels[y].Location = temp;
                        }
                    }
                }
            }

            for (int x = 0; x < size - 1; x++)
            {
                for (int y = x + 1; y < size; y++)
                {
                    //if they are equal skip this step
                    if (labels[x].Text == labels[y].Text) continue;

                    int i = 0;

                    //this variable is used to check if first and second:
                    //  both char                        (0)
                    //  first letter and second number   (1)
                    //  first number and second letter   (2)
                    //  both number                      (3)

                    int char_and_number = 0;

                    //if the char in both of text are the same check the next char (if they are still same go to the next char)
                    while (labels[x].Text[i] == labels[y].Text[i])
                    {
                        //if both char are number then stop loop because 
                        //for the number is different (since we can have 53 and 5 and as we can see the first char of them is the same
                        //but they are acttualy different, in fact 53 is bigger than 5
                        if (labels[x].Text[i] - '0' < 10 && labels[x].Text[i] - '0' >= 0) break;
                        i++;
                    }

                    //get the "i"th char of them in intger (convert the char in ascii number)
                    int first = labels[x].Text[i], second = labels[y].Text[i];

                    //if first is a number try to get the entire number
                    //ex. 32462)adsfe     
                    //before the if    first = 3
                    //after the if first = 32462
                    if (first - '0' < 10 && first - '0' >= 0)
                    {
                        first = first - '0';
                        int i2 = i + 1;

                        //if i2 isn't less than f[x].text.length means that i2 is over the f[x].text, so avoid that error
                        if (i2 < labels[x].Text.Length)
                        {
                           //loop while next char of f[x] is a number
                            while (labels[x].Text[i2] - '0' < 10 && labels[x].Text[i2] - '0' >= 0)
                            {
                                //times 10 to "give the space for the number found"
                                //ex number got = 3    first = 12
                                //   before            first = 12
                                //   after             first = 120
                                first *= 10;
                                //add the number
                                //ex number got = 3    first = 12
                                //   before            first = 120
                                //   after             first = 123
                                first += labels[x].Text[i2] - '0';

                                //increase index
                                i2++;

                                //check if the index is higher/equal than lenght (if so means i2 is over than length, so stop loop since it already checked the last one)
                                if (i2 >= labels[x].Text.Length) break;
                            }
                        }
                    }
                    else char_and_number += 1;

                    //same as first
                    if (second - '0' < 10 && second - '0' >= 0)
                    {
                        second = second - '0';
                        i++;
                        if (i < labels[y].Text.Length)
                        {
                            while (labels[y].Text[i] - '0' < 10 && labels[y].Text[i] - '0' >= 0)
                            {
                                second *= 10;
                                second += labels[y].Text[i] - '0';
                                i++;
                                if (i >= labels[y].Text.Length) break;
                            }
                        }

                    }
                    else char_and_number += 2;

                    //if first is char and second is number than 
                    //whatever first is smaller that second or not 
                    //change their position
                    if (char_and_number == 1)
                    {
                        Point temp = labels[x].Location;
                        labels[x].Location = labels[y].Location;
                        labels[y].Location = temp;

                        Label temp2 = labels[x];
                        labels[x] = labels[y];
                        labels[y] = temp2;
                    }

                    //if first is smaller than second and 
                    //both are number or both are letter
                    //then change location
                    if (first < second && char_and_number % 3 == 0)
                    {
                        Point temp = labels[x].Location;
                        labels[x].Location = labels[y].Location;
                        labels[y].Location = temp;

                        Label temp2 = labels[x];
                        labels[x] = labels[y];
                        labels[y] = temp2;
                    }


                }
            }

            DropMenu.Visible = false;
            SubMenu.Visible = false;*/
        }

        private void Show_detail(object sender, EventArgs e)
        {
                Detail_Form detail = new Detail_Form();

                detail.Show();

            //hide dropmenu if there  is 
            if (DropMenu.Visible == true) DropMenu.Visible = false;
        }

        private void ChangeColorLabel(object sender, MouseEventArgs e)
        {
            (sender as Label).BackColor = SystemColors.Control;

            if ((sender as Label).Text == "Detail") SubMenu.Visible = false;

            foreach (Control lbl in DropMenu.Controls)
            {
                if (lbl is Label)
                {
                    if ((lbl as Label).Text == (sender as Label).Text)
                    {
                        continue;
                    }
                    (lbl as Label).BackColor = Color.White;
                }
            }
}

        private void ChangeColorLabel2(object sender, MouseEventArgs e)
        {

            (sender as Label).BackColor = SystemColors.Control;

            foreach (Control lbl in SubMenu.Controls)
            {
                if (lbl is Label)
                {
                    if ((lbl as Label).Text == (sender as Label).Text)
                    {
                        continue;
                    }
                    (lbl as Label).BackColor = Color.White;
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //variable

        //they are used to create new section (in menuslide) and corresponding icon (one in menuslide and one in iconpanel)
        RadioButton Section ;
        PictureBox IconOfSection;
        PictureBox copy;
        //save the index of the last section
        int indexOfTheSection = -1;
        //save index of the current section
        int indexOfTheCurrentSection = 0;
        //save image path
        string[] ImagePath = new string[0];

        //save the current panel or use to create a new panel 
        Panel CustomizePanel;

        //save the background of the current panel
        PictureBox GridBackground = new PictureBox();
        //this variable help to make sure that resize menuslide only when it needs.  
        bool scrollBarVisible = false;                  
        //this variable help to make sure that resize panels only when it needs.   
        bool[] scrollbar2Visible = new bool[1];

        //this is the index of the current panel
        //it help to seperato each scrollbar when we have more than one panel(so more than one scrollbar)
        int IndexOfScroll = 0;

        // save the position of the last Section
        int x = 33, y = -50;

        //save the position of mouse
        Point MouseLocation;

        // to save if the button (which open the menuslide) is clicked or not.
        //if it is clicked don't try to close menuslide, otherwise if the mouse is outside of menuslide close it
        bool ButtonClicked = false;

        //save previous button icon (in menuslide) and icon (in iconpanel)
        //used the change the color of the previous control (to light gray)
        Control PreviousButton,PreviousIcon1, PreviousIcon2;

        //save the position of each cell in the panel
        Point[,] GridCell = new Point[0,0];

        //when the user scroll with the mouse this variable will save that value 
        //used to make sure that the value of each scroll (delta) will change to 47 instead of 120
        int ScrollBarValue = 0;

        //when the user click one of the activity (label) this variable will save the label that is clicked  
        //used the delete the label that is clicked if textbox is empty and to move label
        Label CurrentL;

        //save the index of the next label in the current panel
        //so when i have newstuff0 indexoflabel = 1
        int[] indexOfLabel = new int[0];


        //save if the mouse is pressed
        bool MouseButtonPressed = false;

        //save the difference between the label.left and mouse 
        Point Diff_mouse_label;

        //save the position of a label when it is clicked (mouse down)
        Point OriginalPosition;

        //create a new textbox that can be use for each panel
        TextBox txt = new TextBox();

        //check if any change is saved
        bool saved = true;
        //check if the panel is deleted
        bool deleted = false;

        //check if it is the first time the the user open the app
        bool FirstOpen = false;

        //save the each "set" of height of the section
        int[] Section_height;

        //save the origin location(when is clicked) of the section
        Point OriginLocation;

        //save section and its icons that should be move
        RadioButton currentSection;
        PictureBox CurrentIcon1, CurrentIcon2;
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //function


        /// <summary>
        /// add new activity 
        /// </summary>
        private void AddNewSectionCmd_Click(object sender, EventArgs e)
        {
            saved = false;
          
            Image icon = null;
            string path = "";

            string nameOfsection = "Main";


            //if this isn't the first time that the user open the app 
            if (FirstOpen == false)
            {
                // set name of section
                nameOfsection = Global.InputBox("Insert the name of section");

                //exit if name = null or inputbox is cancel
                if (nameOfsection == "")
                {
                    return;
                }

                //ask the user if he want to add an image as the icon
                DialogResult question = new DialogResult();
                question = MessageBox.Show("Do you want to add an image as the icon", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (question == DialogResult.Yes)
                {
                    //let the user to change an image 
                    OpenFileDialog OpenImage = new OpenFileDialog();
                    OpenImage.Title = "Chose an image as an icon";
                    OpenImage.Filter = "PNG IMAGE|*.png";

                    if (OpenImage.ShowDialog() == DialogResult.OK)
                    {
                        icon = Image.FromFile(OpenImage.FileName);
                        path = OpenImage.FileName;
                    }

                }

                //ask for the name of the section 
                
            }

            //exit if name = null or inputbox is cancel
            if (nameOfsection == "")
            {
                return;
            }

            ImagePath = preserve_resize_string(ImagePath, ImagePath.Length + 1);
            ImagePath[ImagePath.Length - 1] = path;

            y += 50;
            indexOfTheSection++;
            MenuSlide.VerticalScroll.Value = 0;

            //create the section 
            Section = new RadioButton();
            Section.Name = "Activity" + indexOfTheSection.ToString();
            Section.Location = new Point (x,y);
            Section.Size = new Size(267, 50);
            Section.BackColor = Color.LightGray;
            Section.Text = nameOfsection;
            Section.Font = new Font("Microsoft Sans Serif", 24F);
            MenuSlide.Controls.Add(Section);
            Section.CheckedChanged += this.SLideMenuSelected;
            Section.MouseMove += Form1_MouseMove;
            Section.BringToFront();
            Section.MouseDown += Section_MouseDown;
            Section.MouseUp += Section_MouseUp;

            //create its icon
            IconOfSection = new PictureBox();
            IconOfSection.Name = "Icon" + indexOfTheSection.ToString();
            IconOfSection.Location = new Point(0, Section.Location.Y);
            IconOfSection.Size = new Size(50, 50);
            IconOfSection.BackColor = Color.LightGray;
            IconOfSection.BackgroundImage = icon;
            IconOfSection.BackgroundImageLayout = ImageLayout.Zoom;
            MenuSlide.Controls.Add(IconOfSection);
            IconOfSection.BringToFront();

            //create a copy of it and add in the icon panel 
             copy = new PictureBox();
            copy.Name = IconOfSection.Name + "Copy";
            copy.Location = IconOfSection.Location;
            copy.Size = IconOfSection.Size;
            copy.BackColor = IconOfSection.BackColor;
            copy.BackgroundImage = icon;
            copy.BackgroundImageLayout = ImageLayout.Zoom;
            IconPanel.Controls.Add(copy);
            this.copy.Click += new System.EventHandler(this.IconClicked);

            //create a new panel for this section
            
           Panel NewPanel = new Panel();
            NewPanel.Name = "panel" + indexOfTheSection;
            NewPanel.Size =new Size (821, 426);
            NewPanel.Location = new Point (301,0);
            NewPanel.MouseWheel += Panel_MouseWheel;

            //add background
            PictureBox Background = new PictureBox();
            Background.BackgroundImage = To_do_list__1._1_.Properties.Resources.Grid;
            Background.BackgroundImageLayout = ImageLayout.Tile;
            Background.Size = new Size(804, 426);
            Background.Location = new Point(0,0);
            Background.Click += GridBackground_Click;
            Background.MouseMove += Form1_MouseMove;
            Background.Resize += GridBackground_Resize;
            NewPanel.Controls.Add(Background);

            //add new panel
            NewPanel.Visible = false;
            this.Controls.Add(NewPanel);


            //update indexoflabel to have enought space to save indexs of panel
            indexOfLabel = preserve_resize_ArryInt(indexOfLabel, indexOfLabel.Length + 1);

            //update scrollbar2Visible to have enought space to save indexs of panel
            scrollbar2Visible = preserve_resize_ArrayBool(scrollbar2Visible, scrollbar2Visible.Length +1);
            
            //delete horizontal scroll for CustomizePanel
            NewPanel.AutoScroll = false;
            NewPanel.HorizontalScroll.Enabled = false;
            NewPanel.HorizontalScroll.Visible = false;
            NewPanel.HorizontalScroll.Maximum = 0;
            NewPanel.AutoScroll = true;

            //when the user click the arrow of the scrollbar to scroll down and up it 
            //the distance of each click on the scroll bar will be 47 (the distance of a block of the grid)
            NewPanel.VerticalScroll.Minimum = 0;
            NewPanel.VerticalScroll.SmallChange = 47;

            //add a scrollbar to fill the empty space in the panel
            VScrollBar vScroll = new VScrollBar();
            vScroll.Value = 0;
            vScroll.Width = 17;
            vScroll.Enabled = false;
            vScroll.Height = NewPanel.Height;
            vScroll.Location = new Point(NewPanel.Width - 17);
            NewPanel.Controls.Add(vScroll);
            vScroll.BringToFront();

            //update 
            Section_height = new int[indexOfTheSection];
            for (int i = 0; i < indexOfTheSection; i++)
            {
                Section_height[i] = 50 * i;
            }
        }



        /// <summary>
        /// change color when one of the activity is selected
        /// change also the panel
        /// </summary>
        private void SLideMenuSelected (object sender ,EventArgs e)
        {
            if (DropMenu.Visible == true) DropMenu.Visible = false;
            if (SubMenu.Visible == true) SubMenu.Visible = false;

            //if the paneld is deleted then delete the file in the system (if exists) and skip the save step
            if (deleted == true)
            {
                deleted = false;
                saved = true;
                if (System.IO.File.Exists(CustomizePanel.Name))
                {
                    System.IO.File.Delete(CustomizePanel.Name);
                    return;
                }
            }

            //update gridcell


            //ask the user if he wants to save changes made in the previous section 
            //ask only when the user made some changes
            if (saved == false)
            {
                saved = true;
                DialogResult result = MessageBox.Show("Do you want to save changes made?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //set scroll value to 0
                    CustomizePanel.AutoScrollPosition = new Point(0, 0);

                    //save 
                    StreamWriter file = new StreamWriter(CustomizePanel.Name);
                    foreach (Control ctrl in CustomizePanel.Controls)
                    {
                        if (ctrl is Label)
                        {
                          

                            file.WriteLine((ctrl as Label).Text);
                            file.WriteLine((ctrl as Label).TabIndex);
                            file.WriteLine((ctrl as Label).Size.Width);
                            file.WriteLine((ctrl as Label).Size.Height);
                            file.WriteLine((ctrl as Label).Location.X);
                            file.WriteLine((ctrl as Label).Location.Y);
                            file.WriteLine((ctrl as Label).BackColor.A);
                            file.WriteLine((ctrl as Label).BackColor.R);
                            file.WriteLine((ctrl as Label).BackColor.G);
                            file.WriteLine((ctrl as Label).BackColor.B);
                        }
                    }
                    file.Dispose();
                }
                else
                {
                    //delete all controls
                    CustomizePanel.Controls.Clear();
                    //add background
                    PictureBox Background = new PictureBox();
                    Background.BackgroundImage = To_do_list__1._1_.Properties.Resources.Grid;
                    Background.BackgroundImageLayout = ImageLayout.Tile;
                    Background.Size = new Size(804, 426);
                    Background.Location = new Point(0, 0);
                    Background.Click += GridBackground_Click;
                    Background.MouseMove += Form1_MouseMove;
                    Background.Resize += GridBackground_Resize;
                    CustomizePanel.Controls.Add(Background);

                    //read the origin panel.setting (e.g. panel1) if file exists
                    //if not just clear panel
                    if (System.IO.File.Exists(CustomizePanel.Name))
                    {
                        StreamReader file = new StreamReader(CustomizePanel.Name);

                        while (!file.EndOfStream)
                        {
                            Label Newstuff = new Label();
                            Newstuff.Text = file.ReadLine();
                            Newstuff.TabIndex = int.Parse(file.ReadLine());
                            indexOfLabel[indexOfTheCurrentSection]++;

                            int width = int.Parse(file.ReadLine());
                            int height = int.Parse(file.ReadLine());
                            Newstuff.Size = new Size (width,height);

                            int x = int.Parse(file.ReadLine());
                            int y = int.Parse(file.ReadLine());
                            Newstuff.Location = new Point(x, y);

                            int a = int.Parse(file.ReadLine()), r = int.Parse(file.ReadLine()), g = int.Parse(file.ReadLine()), b = int.Parse(file.ReadLine());
                            Newstuff.BackColor = Color.FromArgb(a, r, g, b);


                            Newstuff.Font = new Font("Microsoft Sans Serif", 11.75F);
                            Newstuff.TextAlign = ContentAlignment.MiddleCenter;
                            Newstuff.DoubleClick += LabelDoubleClick;
                            Newstuff.MouseDown += Label_mouseDown;
                            Newstuff.MouseUp += Label_mouseUp;
                            Newstuff.MouseMove += Form1_MouseMove;
                            Newstuff.MouseClick += RightButton_Click;

                            CustomizePanel.Controls.Add(Newstuff);
                            Newstuff.BringToFront();
                        }

                        file.Dispose();
                    }
                }
            }
            


            string indexOfButton = (sender as RadioButton).Name.Substring(8);


            if ((sender as RadioButton).Checked == true)
            {

                //change the color of the radiobutton
                (sender as RadioButton).BackColor = SystemColors.ControlDark;
                PreviousButton = sender as RadioButton;

                //change the color of the icon in SLIDE MENU
                foreach (Control picture in MenuSlide.Controls)
                {
                    if (picture is PictureBox)
                    {
                        if (picture.Name.Substring(4) == indexOfButton)
                        {
                            picture.BackColor = SystemColors.ControlDark;

                            PreviousIcon1 = new PictureBox();
                            PreviousIcon1 = picture;


                            break;
                        }
                    }
                }

                //change the color of the icon in ICONPANEL
                foreach (Control picture in IconPanel.Controls)
                {
                    if (picture is PictureBox)
                    {
                        string IndexOfPicture = picture.Name.Substring(4, picture.Name.Length - 4 - 4);
                        if (IndexOfPicture == indexOfButton)
                        {

                            picture.BackColor = SystemColors.ControlDark;

                            PreviousIcon2 = new PictureBox();
                            PreviousIcon2 = picture;

                            break;
                        }
                    }
                }
            }
            else
            {
                //change the color of the radiobutton
                (sender as RadioButton).BackColor = Color.LightGray;

                //change the color of the icon in SLIDE MENU
                foreach (Control picture in MenuSlide.Controls)
                {
                    if (picture is PictureBox)
                    {
                        if (picture.Name.Substring(4) == indexOfButton)
                        {
                            picture.BackColor = Color.LightGray;
                            break;
                        }
                    }
                }

                //change the color of the icon in ICONPANEL
                foreach (Control picture in IconPanel.Controls)
                {
                    string IndexOfPicture = picture.Name.Substring(4,picture.Name.Length - 4 - 4);
                    if (picture is PictureBox)
                    {
                        if (IndexOfPicture == indexOfButton)
                        {
                            picture.BackColor = Color.LightGray;
                            break;
                        }
                    }
                }


            }
        

            //open panel needs and close other 
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Panel)
                {
                    if ((ctrl as Panel).Name.Length < 5) continue;
                    if ((ctrl as Panel).Name.Substring(5) == indexOfButton)
                    {
                        ctrl.Visible = true;
                        CustomizePanel = (ctrl as Panel);
                       foreach (Control pic in CustomizePanel.Controls)
                        {
                            if (pic is PictureBox)
                            {
                                GridBackground = (pic as PictureBox);
                                foreach (Control ctrl2 in CustomizePanel.Controls)
                                {
                                    GridBackground.Size = new Size(GridBackground.Width, Math.Max(GridBackground.Height, ctrl2.Location.Y + 45 + CustomizePanel.VerticalScroll.Value));
                                }
                                GridCell = Preserve_resize_2Dpoint(GridCell, new Size(GridBackground.Height / 47, 3));
                                for (int x = 0; x < GridCell.GetLength(0); x++)
                                {
                                    GridCell[x, 0] = new Point(0, x * 47);
                                    GridCell[x, 1] = new Point(267, x * 47);
                                    GridCell[x, 2] = new Point(534, x * 47);
                                }

                            }
                        }
                       
                    }
                    else if ((ctrl as Panel).Name != "MenuSlide" && (ctrl as Panel).Name != "IconPanel")
                    {
                        ctrl.Visible = false;
                    }
                }
            }

            //set current index
            indexOfTheCurrentSection = int.Parse(CustomizePanel.Name.Substring(5));

            //set indexcofscrollbar to the current one
            IndexOfScroll = int.Parse(CustomizePanel.Name.Substring(5));



        }

        /// <summary>
        /// change color when one of the icon on the iconPanel is clicked 
        /// </summary>
        private void IconClicked(object sender, EventArgs e)
        {

            //get index of the current activity
            string indexOfIcon = (sender as PictureBox).Name.Substring(4, (sender as PictureBox).Name.Length - 4 - 4);

            //change the color of the current Icon
            (sender as PictureBox).BackColor = SystemColors.ControlDark;

            //change the color of the previos Icon
            if (PreviousIcon2 != null)
            {
                PreviousIcon2.BackColor = Color.LightGray;
            }

            //change the color of the radiobutton in SLIDE MENU
            foreach (Control RadioB in MenuSlide.Controls)
            {
                if (RadioB is RadioButton)
                {
                    if (RadioB.Name.Substring(8) == indexOfIcon)
                    {
                        (RadioB as RadioButton).Checked = true;
                        if (PreviousButton != null)
                        {
                            PreviousButton.BackColor = Color.LightGray;
                        }
                        PreviousButton = RadioB;
                        RadioB.BackColor = SystemColors.ControlDark;
                        
                        break;
                    }
                }
            }

            //change the color of the icon in MenuSlide
            foreach (Control picture in MenuSlide.Controls)
            {
                if (picture is PictureBox)
                {
                    if (picture.Name.Substring(4) == indexOfIcon)
                    {
                        if (PreviousIcon1 != null)
                        {
                            PreviousIcon1.BackColor = Color.LightGray;
                        }

                        picture.BackColor = SystemColors.ControlDark;

                        PreviousIcon1 = picture;
                        break;
                    }
                }
            }

            //change the color of the icon in MenuSlide
            foreach (Control picture in IconPanel.Controls)
            {
                if (picture is PictureBox)
                {
                    if (picture.Name.Substring(4) == indexOfIcon)
                    {
                        if (PreviousIcon2 != null)
                        {
                            PreviousIcon2.BackColor = Color.LightGray;
                        }

                        picture.BackColor = SystemColors.ControlDark;

                        PreviousIcon2 = picture;
                        break;
                    }
                }
            }

            (sender as PictureBox).BackColor = SystemColors.ControlDark;

        }

        /// <summary>
        /// form load
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //check it the file exists
            if (System.IO.File.Exists("Sections"))
            {
                //If so read it, get it and set everything in the sections
                StreamReader file = new StreamReader("Sections");
                while (!file.EndOfStream)
                {
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //create new section (with icon)
                    string nameOfsection = file.ReadLine();
                    Point loc = new Point(int.Parse(file.ReadLine()), int.Parse(file.ReadLine()));
                    string path = file.ReadLine();
                    Image icon = null;
                    indexOfTheCurrentSection = int.Parse(file.ReadLine());

                    if (indexOfTheSection == -1)
                    {
                        indexOfTheSection = indexOfTheCurrentSection;
                    }
                    else if (indexOfTheSection < indexOfTheCurrentSection)
                    {
                        indexOfTheSection = indexOfTheCurrentSection;
                    }
                    
                    if (path != " " && path != "")
                    {
                        icon = Image.FromFile(path);
                    }

                    //create new section 
                    ImagePath = preserve_resize_string(ImagePath, indexOfTheSection + 1);
                    ImagePath[indexOfTheCurrentSection] = path;

                    y += 50;
                    MenuSlide.VerticalScroll.Value = 0;

                    //create the section 
                    Section = new RadioButton();
                    Section.TabIndex = indexOfTheCurrentSection;
                    Section.Name = "Activity" + indexOfTheCurrentSection.ToString();
                    Section.Location = loc;
                    Section.Size = new Size(267, 50);
                    Section.BackColor = Color.LightGray;
                    Section.Text = nameOfsection;
                    Section.Font = new Font("Microsoft Sans Serif", 24F);
                    MenuSlide.Controls.Add(Section);
                    Section.CheckedChanged += this.SLideMenuSelected;
                    Section.MouseMove += Form1_MouseMove;
                    Section.BringToFront();
                    Section.MouseDown += Section_MouseDown;
                    Section.MouseUp += Section_MouseUp;

                    //create its icon
                    IconOfSection = new PictureBox();
                    IconOfSection.Name = "Icon" + indexOfTheCurrentSection.ToString();
                    IconOfSection.Location = new Point(0, Section.Location.Y);
                    IconOfSection.Size = new Size(50, 50);
                    IconOfSection.BackColor = Color.LightGray;
                    IconOfSection.BackgroundImage = icon;
                    IconOfSection.BackgroundImageLayout = ImageLayout.Zoom;
                    MenuSlide.Controls.Add(IconOfSection);
                    IconOfSection.BringToFront();

                    //create a copy of it and add in the icon panel 
                    copy = new PictureBox();
                    copy.Name = IconOfSection.Name + "Copy";
                    copy.Location = IconOfSection.Location;
                    copy.Size = IconOfSection.Size;
                    copy.BackColor = IconOfSection.BackColor;
                    copy.BackgroundImage = icon;
                    copy.BackgroundImageLayout = ImageLayout.Zoom;
                    IconPanel.Controls.Add(copy);
                    this.copy.Click += new System.EventHandler(this.IconClicked);

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //create a new panel for this section

                    Panel NewPanel = new Panel();
                    NewPanel.Name = "panel" + indexOfTheCurrentSection;
                    NewPanel.Size = new Size(821, 426);
                    NewPanel.Location = new Point(50, 0);
                    NewPanel.MouseWheel += Panel_MouseWheel;

                    //add background
                    PictureBox Background = new PictureBox();
                    Background.BackgroundImage = To_do_list__1._1_.Properties.Resources.Grid;
                    Background.BackgroundImageLayout = ImageLayout.Tile;
                    Background.Size = new Size(804, 426);
                    Background.Location = new Point(0, 0);
                    Background.Click += GridBackground_Click;
                    Background.MouseMove += Form1_MouseMove;

                    //add new panel
                    NewPanel.Visible = false;
                    this.Controls.Add(NewPanel);


                    //update indexoflabel to have enought space to save indexs of panel
                    indexOfLabel = preserve_resize_ArryInt(indexOfLabel, indexOfTheSection + 1);

                    //update scrollbar2Visible to have enought space to save indexs of panel
                    scrollbar2Visible = preserve_resize_ArrayBool(scrollbar2Visible, indexOfTheSection + 1);

                    //delete horizontal scroll for CustomizePanel
                    NewPanel.AutoScroll = false;
                    NewPanel.HorizontalScroll.Enabled = false;
                    NewPanel.HorizontalScroll.Visible = false;
                    NewPanel.HorizontalScroll.Maximum = 0;
                    NewPanel.AutoScroll = true;

                    //when the user click the arrow of the scrollbar to scroll down and up it 
                    //the distance of each click on the scroll bar will be 47 (the distance of a block of the grid)
                    NewPanel.VerticalScroll.Minimum = 0;
                    NewPanel.VerticalScroll.SmallChange = 47;

                    //add a scrollbar to fill the empty space in the panel
                    VScrollBar vScroll = new VScrollBar();
                    vScroll.Value = 0;
                    vScroll.Width = 17;
                    vScroll.Enabled = false;
                    vScroll.Height = NewPanel.Height;
                    vScroll.Location = new Point(NewPanel.Width - 17);
                    NewPanel.Controls.Add(vScroll);
                    vScroll.BringToFront();



                    //read panel.setting (e.g. panel1) if file exists
                    if (System.IO.File.Exists(NewPanel.Name))
                    {
                        StreamReader file2 = new StreamReader(NewPanel.Name);

                        while (!file2.EndOfStream)
                        {
                            Label Newstuff = new Label();
                            Newstuff.Text = file2.ReadLine();
                            Newstuff.TabIndex = int.Parse(file2.ReadLine());
                            indexOfLabel[indexOfTheCurrentSection]++;

                            int width = int.Parse(file2.ReadLine());
                            int height = int.Parse(file2.ReadLine());
                            Newstuff.Size = new Size(width, height);

                            int x = int.Parse(file2.ReadLine());
                            int y = int.Parse(file2.ReadLine());
                            Newstuff.Location = new Point(x, y);

                            int a = int.Parse(file2.ReadLine()), r = int.Parse(file2.ReadLine()), g = int.Parse(file2.ReadLine()), b = int.Parse(file2.ReadLine());
                            Newstuff.BackColor = Color.FromArgb(a, r, g, b);

                            Newstuff.Font = new Font("Microsoft Sans Serif", 11.75F);
                            Newstuff.TextAlign = ContentAlignment.MiddleCenter;
                            Newstuff.DoubleClick += LabelDoubleClick;
                            Newstuff.MouseDown += Label_mouseDown;
                            Newstuff.MouseUp += Label_mouseUp;
                            Newstuff.MouseMove += Form1_MouseMove;
                            Newstuff.MouseClick += RightButton_Click;

                            NewPanel.Controls.Add(Newstuff);
                            Newstuff.BringToFront();
                        }

                        file2.Dispose();

                        foreach (Control ctrl in NewPanel.Controls)
                        {
                            Background.Size = new Size(Background.Width, Math.Max(Background.Height, ctrl.Location.Y + 45 + NewPanel.VerticalScroll.Value));
                        }

                        Background.Resize +=    GridBackground_Resize;
                        NewPanel.Controls.Add(Background);

                    }

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //select the first section in the list
                    if  (Section.Location.Y == 0)
                    {
                        CustomizePanel = NewPanel;
                        Section.Checked = true;
                        foreach (Control pic in CustomizePanel.Controls)
                        {
                            if (pic is PictureBox)
                            {
                                GridBackground = (pic as PictureBox);
                                GridCell = Preserve_resize_2Dpoint(GridCell, new Size(GridBackground.Height / 47,3));
                                for (int x = 0; x < GridCell.GetLength(0); x++)
                                {
                                    GridCell[x, 0] = new Point(0, x * 47);
                                    GridCell[x, 1] = new Point(267, x * 47);
                                    GridCell[x, 2] = new Point(534, x * 47);
                                }
                            }
                        }
                    }
                   
                }
               


                file.Dispose();
            }

            Section_height = new int[indexOfTheSection];
           for (int i = 0; i < indexOfTheSection; i++)
            {
                Section_height[i] = 50 * i;
            }
            

            //create a section if there isn't any section
            if (CustomizePanel == null)
            {
                FirstOpen = true;
                AddNewActivityCmd.PerformClick();
                FirstOpen = false;
                foreach (Control panel in this.Controls)
                {
                    if (panel is Panel)
                    {
                        CustomizePanel = (panel as Panel);
                    }
                }


                //save the picturebox in the current panel (so the background/grid) in gridbackground
                foreach (Control pic in CustomizePanel.Controls)
                {
                    if (pic is PictureBox)
                    {
                        GridBackground = (pic as PictureBox);
                    }
                }
                

                saved = true;

                if (Section != null) Section.Checked = true;
            }

            //init txt 
            txt.Font = new Font("Microsoft Sans Serif", 12F);
            txt.Size = new Size(262, 43);
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.FromArgb(255, 192, 192);
            txt.KeyDown += textBox1_KeyDown;
            txt.TextChanged += textBox1_TextChanged;

            //resize and init GridCell
           
                int Rows = GridBackground.Height / 47;
                int Columns = 3;

                GridCell = new Point[Rows, Columns];

                for (int x = 0; x < GridCell.GetLength(0); x++)
                {
                    GridCell[x, 0] = new Point(0, x * 47);
                    GridCell[x, 1] = new Point(267, x * 47);
                    GridCell[x, 2] = new Point(534, x * 47);
                }
            
        //delete horizontal scroll for menuslide
            MenuSlide.AutoScroll = false;
            MenuSlide.HorizontalScroll.Enabled = false;
            MenuSlide.HorizontalScroll.Visible = false;
            MenuSlide.HorizontalScroll.Maximum = 0;
            MenuSlide.AutoScroll = true;


            //delete horizontal scroll for icon panel
            IconPanel.AutoScroll = false;
            IconPanel.HorizontalScroll.Enabled = false;
            IconPanel.HorizontalScroll.Visible = false;
            IconPanel.HorizontalScroll.Maximum = 0;
            IconPanel.AutoScroll = true;

            //close menuslide
            this.Size = new Size(888, 466);
            MenuSlide.Location = new Point(-300, MenuSlide.Location.Y);
            AddNewActivityCmd.Location = new Point(-150, -1);
            DeleteCmd.Location = new Point(-301, -1);
            CustomizePanel.Location = new Point(50, 0);
            Title1Lbl.Location = new Point(53, 2);
            Title2Lbl.Location = new Point(320, 2);
            Title3Lbl.Location = new Point(586, 2);


            //when the user click the arrow of the scrollbar to scroll down and up it 
            //the distance of each click on the scroll bar will be 47 (the distance of a block of the grid)
            CustomizePanel.VerticalScroll.Minimum = 0;
            CustomizePanel.VerticalScroll.SmallChange = 47;
        }


        /// <summary>
        /// open and close menuslide function (in the same time move everything on the right side of the slide menu
        /// </summary>
        private void CloseMenuSlide_Tick(object sender, EventArgs e)
        {
            MenuSlide.Location = new Point(MenuSlide.Location.X - 3, MenuSlide.Location.Y);
            AddNewActivityCmd.Location = new Point(AddNewActivityCmd.Location.X - 3, AddNewActivityCmd.Location.Y);
            DeleteCmd.Location = new Point(DeleteCmd.Location.X - 3, DeleteCmd.Location.Y);


            if (CustomizePanel.Location.X > IconPanel.Width + 1) { 
            Title1Lbl.Location = new Point (Title1Lbl.Location.X -3, Title1Lbl.Location.Y);
            Title2Lbl.Location = new Point(Title2Lbl.Location.X - 3, Title2Lbl.Location.Y);
            Title3Lbl.Location = new Point(Title3Lbl.Location.X - 3, Title3Lbl.Location.Y);
                this.Size = new Size(this.Width - 3, this.Size.Height);

                //change other panel
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Panel)
                    {
                        if ((ctrl as Panel).Name != "MenuSlide" && (ctrl as Panel).Name != "IconPanel" )
                        {
                            ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y);
                        }
                    }

                    if (ctrl is VScrollBar)
                    {
                        (ctrl as VScrollBar).Location = new Point((ctrl as VScrollBar).Location.X - 3, (ctrl as VScrollBar).Location.Y);
                    }
                }

            }
            else
            {
                while (CustomizePanel.Location.X != IconPanel.Width){ 
                Title1Lbl.Location = new Point(Title1Lbl.Location.X + 1, Title1Lbl.Location.Y);
                Title2Lbl.Location = new Point(Title2Lbl.Location.X + 1, Title2Lbl.Location.Y);
                Title3Lbl.Location = new Point(Title3Lbl.Location.X + 1, Title3Lbl.Location.Y);
                    this.Size = new Size(this.Width + 1, this.Size.Height);

                    //change other panel
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel)
                        {
                            if ((ctrl as Panel).Name != "MenuSlide" && (ctrl as Panel).Name != "IconPanel")
                            {
                                ctrl.Location = new Point(ctrl.Location.X + 1, ctrl.Location.Y);
                            }
                        }

                        if (ctrl is VScrollBar)
                        {
                            (ctrl as VScrollBar).Location = new Point((ctrl as VScrollBar).Location.X + 1, (ctrl as VScrollBar).Location.Y);
                        }
                    }
                }
            }

            if (MenuSlide.Location.X <= 0 - MenuSlide.Width)
            {
                AddNewActivityCmd.Enabled = false;
                DeleteCmd.Enabled = false;
                OpenCmd.Enabled = true;
                CloseMenuSlide.Stop();
            }
        }
        private void OpenMenuslide_Tick(object sender, EventArgs e)
        {
            MenuSlide.Location = new Point(MenuSlide.Location.X + 3, MenuSlide.Location.Y);
            AddNewActivityCmd.Location = new Point(AddNewActivityCmd.Location.X + 3, AddNewActivityCmd.Location.Y);
            DeleteCmd.Location = new Point(DeleteCmd.Location.X + 3, DeleteCmd.Location.Y);
            int Plocation;

            if (scrollBarVisible == false)
            {
                Plocation = 301;
            }
            else Plocation = 301 + 17;

            if (CustomizePanel.Location.X < Plocation) {
            Title1Lbl.Location = new Point(Title1Lbl.Location.X + 3, Title1Lbl.Location.Y);
            Title2Lbl.Location = new Point(Title2Lbl.Location.X + 3, Title2Lbl.Location.Y);
            Title3Lbl.Location = new Point(Title3Lbl.Location.X + 3, Title3Lbl.Location.Y);
                this.Size = new Size(this.Width + 3, this.Size.Height);

                //change other panel
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Panel)
                    {
                      if  ( (ctrl as Panel).Name != "MenuSlide" && (ctrl as Panel).Name != "IconPanel" )
                        {
                            ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y);
                        }
                    }

                    if (ctrl is VScrollBar)
                    {
                        (ctrl as VScrollBar).Location = new Point((ctrl as VScrollBar).Location.X + 3, (ctrl as VScrollBar).Location.Y);
                    }
                }



            }
            else
            {
                while (CustomizePanel.Location.X != Plocation)
                {
                    Title1Lbl.Location = new Point(Title1Lbl.Location.X - 1, Title1Lbl.Location.Y);
                    Title2Lbl.Location = new Point(Title2Lbl.Location.X - 1, Title2Lbl.Location.Y);
                    Title3Lbl.Location = new Point(Title3Lbl.Location.X - 1, Title3Lbl.Location.Y);
                    this.Size = new Size(this.Width - 1, this.Size.Height);

                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel)
                        {
                            if ((ctrl as Panel).Name != "MenuSlide" && (ctrl as Panel).Name != "IconPanel")
                            {
                                ctrl.Location = new Point(ctrl.Location.X -1, ctrl.Location.Y);
                            }
                        }
                        if (ctrl is VScrollBar)
                        {
                            (ctrl as VScrollBar).Location = new Point ((ctrl as VScrollBar).Location.X - 1,(ctrl as VScrollBar).Location.Y);
                        }
                    }


                }
            }


            if (MenuSlide.Location.X == 0)
            {
                foreach (Control a in this.Controls)
                {
                    if (a is Label)
                    {
                        (a as Label).Text = (a as Label).Text;
                    }
                }
                AddNewActivityCmd.Enabled = true;
                DeleteCmd.Enabled = true;
                OpenCmd.Enabled = false;
                ButtonClicked = false;
                OpenMenuslide.Stop();
            }
        }   
        private void OpenButton_Click(object sender, EventArgs e)
        {
            //hide dropmenu if there  is 
            if (DropMenu.Visible == true)
            {
                DropMenu.Visible = false;
                SubMenu.Visible = false;
            }
            ButtonClicked = true;
            CloseMenuSlide.Stop();
            OpenMenuslide.Start();
        }


        /// <summary>
        /// get mouse position (if it's outside of the menuslide, close menuslide,otherwise open it)
        /// </summary>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseLocation = new Point (MousePosition.X - this.Location.X - 8, MousePosition.Y - this.Location.Y - 31);

            if (MouseLocation.X > MenuSlide.Location.X + MenuSlide.Width  && MenuSlide.Location.X >= 0 - MenuSlide.Width && ButtonClicked == false)
            {
                OpenMenuslide.Stop();
                CloseMenuSlide.Start();
            }
            else if (MenuSlide.Location.X != 0 && MouseLocation.X < MenuSlide.Location.X + MenuSlide.Width )
            {
                CloseMenuSlide.Stop();
                OpenMenuslide.Start();
            }
        }

        /// <summary>
        /// when the scroll is moving the scrollbar move 47 pixel at time 
        /// </summary>
        private void Panel_MouseWheel(object sender, MouseEventArgs e)
        {
            // activite function only when the scoll bar is appeared
            if (CustomizePanel.VerticalScroll.Visible)
            {
                // if the mouse is scrolling forward down
                if (e.Delta == -120)
                {
                    //if the scroll bar ins't it the correct position (so when we can see something like a half of the block of the grid)
                    //if so correct it
                    if (ScrollBarValue != 0)
                    {
                        ScrollBarValue = ScrollBarValue / 47 * 47;
                    }
                    //the scroll bar go down of 47 pixel
                    ScrollBarValue += 47;

                    //if scrollbarvalue is higher than the height of the picture (so when the scroll is in the end of the bar)
                    // stop go down
                    if (ScrollBarValue >= GridBackground.Height - 461)
                    {
                        ScrollBarValue = CustomizePanel.VerticalScroll.Value;
                        return;
                    }
                }
                // if the mouse is scrolling forward up
                else
                {
                    //if the scroll bar ins't it the correct position (so when we can see something like a half of the block of the grid)
                    //if so correct it
                    if (ScrollBarValue != 0)
                    {
                        ScrollBarValue = ScrollBarValue / 47 * 47;
                    }
                    //the scroll bar go up of 47 pixel
                    ScrollBarValue -= 47;

                    // if ScrollBarValue (so when the scroll is in the begin of the bar)
                    // if so don't go up anymore
                    if (ScrollBarValue < 0)
                    {
                        ScrollBarValue = 0;
                    }
                }

                //if a single of the mouse will go to the begin of the bar 
                //if so don't change anything (so cancel the function)
                if (CustomizePanel.VerticalScroll.Value + e.Delta < 0)
                {
                    ScrollBarValue = 0;
                    return;
                }

                //decrease the value of the mouse scroll
                CustomizePanel.VerticalScroll.Value += e.Delta;
                CustomizePanel.VerticalScroll.Value += e.Delta;

                //set the scrollbar to ScrollBarValue
                CustomizePanel.VerticalScroll.Value = ScrollBarValue;
                CustomizePanel.VerticalScroll.Value = ScrollBarValue;


            }


        }


        /// <summary>
        /// call a textbox to write new activity
        /// </summary>
        private void GridBackground_Click(object sender, EventArgs e)
        {
            //hide dropmenu if there  is 
            if (DropMenu.Visible == true)
            {
                SubMenu.Visible = false;
                DropMenu.Visible = false;
            }
            //save the txt.text as a label in the grid if textbox is != ""
            if (txt.Text != "")
            {
                Color BackColorOfText = Color.LightBlue;

                    //set the color
                    if (txt.Location.X == 4)
                    {
                        BackColorOfText = Title1Lbl.BackColor;
                    }
                    else if (txt.Location.X == 271)
                    {
                        BackColorOfText = Title2Lbl.BackColor;
                    }
                    else if (txt.Location.X == 538)
                    {
                        BackColorOfText = Title3Lbl.BackColor;
                    }

                    //create new activity (new label)
                    Label NewStuff = new Label();
                    NewStuff.Name = "Stuff" + indexOfLabel[indexOfTheCurrentSection];
                    NewStuff.TabIndex = indexOfLabel[indexOfTheCurrentSection];
                    NewStuff.Location = new Point(txt.Location.X - 2,txt.Location.Y - 1);
                    NewStuff.Size = new Size(264, 45);
                    NewStuff.BackColor = Color.FromArgb(BackColorOfText.A, BackColorOfText.R, BackColorOfText.G, BackColorOfText.B);
                    NewStuff.Text = txt.Text;
                    NewStuff.Font = new Font("Microsoft Sans Serif", 11.75F);
                    NewStuff.TextAlign = ContentAlignment.MiddleCenter;
                    NewStuff.DoubleClick += LabelDoubleClick;
                    NewStuff.MouseDown += Label_mouseDown;
                    NewStuff.MouseUp += Label_mouseUp;
                    NewStuff.MouseMove += Form1_MouseMove;
                    NewStuff.MouseClick += RightButton_Click;

                if (CurrentL == null)
                    {
                        indexOfLabel[indexOfTheCurrentSection]++;
                    }

                    //change the name to the currentl.name if the user clicked on the label (so the user want edit that label and not create a new one) 
                    if (CurrentL != null)
                    {
                        NewStuff.Name = CurrentL.Name;
                        CustomizePanel.Controls.Remove(CurrentL);
                        CurrentL.Dispose();
                    }

                    //add newstuf
                    CustomizePanel.Controls.Add(NewStuff);
                    NewStuff.BringToFront();


                    //set the scoll to the begin of the bar (to avoid any position error)
                    CustomizePanel.VerticalScroll.Value = 0;
                    CustomizePanel.VerticalScroll.Value = 0;

                    //if the height of the picturebox isn't enough for the next cell, make it bigger 
                    if (GridBackground.Height - 36 <= txt.Location.Y + 45)
                    {
                        GridBackground.Size = new Size(GridBackground.Width, GridBackground.Height + 47);
                        foreach (Control ctrl in CustomizePanel.Controls)
                        {
                            GridBackground.Size = new Size(GridBackground.Width, Math.Max(GridBackground.Height, ctrl.Location.Y + 45 + CustomizePanel.VerticalScroll.Value));

                        }
                }

                    //set back the scoll to the origin position of the bar 
                    CustomizePanel.VerticalScroll.Value = ScrollBarValue;
                    CustomizePanel.VerticalScroll.Value = ScrollBarValue;
                }
            else
            {
                if (CurrentL != null)
                {
                    CustomizePanel.Controls.Remove(CurrentL);
                }
            }



            saved = false;
            
           //tell the computer that the user didn't click any label, he is just click the picture so don't delete any label
            CurrentL = null;

            ScrollBarValue = CustomizePanel.VerticalScroll.Value;
            //set the scoll to the begin of the bar (to avoid any position error)
            CustomizePanel.VerticalScroll.Value = 0;
            CustomizePanel.VerticalScroll.Value = 0;

            for (int x = 0; x < GridCell.GetLength(0); x++)
            {
                for (int y = 0; y < GridCell.GetLength(1); y++)
                {
                    Point MouseP__inPanel = new Point(MouseLocation.X - CustomizePanel.Location.X, MouseLocation.Y - CustomizePanel.Location.Y + ScrollBarValue);

                    if (GridCell[x, y].X < MouseP__inPanel.X && GridCell[x, y].X + 268 > MouseP__inPanel.X)
                    {

                        if (GridCell[x, y].Y < MouseP__inPanel.Y && GridCell[x, y].Y + 47 > MouseP__inPanel.Y)
                        {
                            txt.Visible = true;
                            txt.Enabled = true;
                            txt.Multiline = false ;
                            txt.AutoSize = false;
                            txt.Text = "";
                            txt.Location = new Point(GridCell[x, y].X + 4, GridCell[x, y].Y + 3);

                            CustomizePanel.Controls.Add(txt);
                           
                            txt.BringToFront();
                            txt.Select();

                        }
                    }


                }
            }

            CustomizePanel.VerticalScroll.Value = ScrollBarValue;
            CustomizePanel.VerticalScroll.Value = ScrollBarValue;
        }

        /// <summary>
        /// Add new Activity (label)
        /// </summary>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Color BackColorOfText = Color.LightBlue;
            if (e.KeyCode == Keys.Enter)
            {

                if ((sender as TextBox).Text == "")
                {
                    if (CurrentL != null)
                    {
                        CustomizePanel.Controls.Remove(CurrentL);
                    }
                  return;
                }

                //set the color
               if ((sender as TextBox).Location.X == 4)
                {
                    BackColorOfText = Title1Lbl.BackColor;
                }
               else if ((sender as TextBox).Location.X == 271)
                {
                    BackColorOfText = Title2Lbl.BackColor;
                }
               else if ((sender as TextBox).Location.X == 538)
                {
                    BackColorOfText = Title3Lbl.BackColor;
                }

                //create new activity (new label)
                Label NewStuff = new Label();
                NewStuff.Name = "Stuff" + indexOfLabel[indexOfTheCurrentSection];
                NewStuff.TabIndex = indexOfLabel[indexOfTheCurrentSection];
                NewStuff.Location = new Point( (sender as TextBox).Location.X - 2, (sender as TextBox).Location.Y - 1);
                NewStuff.Size = new Size(264, 45);
                NewStuff.BackColor = Color.FromArgb(BackColorOfText.A, BackColorOfText.R, BackColorOfText.G,BackColorOfText.B);
                NewStuff.Text = (sender as TextBox).Text;
                NewStuff.Font = new Font ("Microsoft Sans Serif", 11.75F);
                NewStuff.TextAlign = ContentAlignment.MiddleCenter;
                NewStuff.DoubleClick += LabelDoubleClick;
                NewStuff.MouseDown += Label_mouseDown;
                NewStuff.MouseUp += Label_mouseUp;
                NewStuff.MouseMove += Form1_MouseMove;
                NewStuff.MouseClick += RightButton_Click;

                if (CurrentL == null)
                {
                    indexOfLabel[indexOfTheCurrentSection]++;
                }

                //change the name to the currentl.name if the user clicked on the label (so the user want edit that label and not create a new one) 
                if (CurrentL != null)
                {
                    NewStuff.Name = CurrentL.Name;
                    CustomizePanel.Controls.Remove(CurrentL);
                    CurrentL.Dispose();
                }

                //add newstuf
                CustomizePanel.Controls.Add(NewStuff);
                NewStuff.BringToFront();


                //set the scoll to the begin of the bar (to avoid any position error)
                CustomizePanel.VerticalScroll.Value = 0;
                CustomizePanel.VerticalScroll.Value = 0;

                //if the height of the picturebox isn't enough for the next cell, make it bigger 
                if (GridBackground.Height - 36 <= (sender as TextBox).Location.Y + 45)
                {
                    GridBackground.Size = new Size(GridBackground.Width, GridBackground.Height + 47);
                    foreach (Control ctrl in CustomizePanel.Controls)
                    {
                        GridBackground.Size = new Size(GridBackground.Width, Math.Max(GridBackground.Height, ctrl.Location.Y + 45 + CustomizePanel.VerticalScroll.Value));

                    }
                }

                //set back the scoll to the origin position of the bar 
                CustomizePanel.VerticalScroll.Value = ScrollBarValue;
                CustomizePanel.VerticalScroll.Value = ScrollBarValue;

                //delete textbox (to avoid that the user change textbox.text after the label is created)
                (sender as TextBox).Text = "";
              (sender as TextBox).Visible = false;
                (sender as TextBox).Enabled = false;

            }
        }

        //show dropmenu when the user rightbutton clicked on the label
        private void RightButton_Click(object sender, MouseEventArgs e)
        {
            SubMenu.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                Global.CurrentL_for_menudrop = (sender as Label);
                if (e.Button == MouseButtons.Right)
                {
                    if (MenuSlide.Location.X == 0)
                    {
                        Show_DropMenu(MouseLocation);
                    }
                    else
                    {
                        Show_DropMenu(MouseLocation);
                    }

                }
                saved = true;
            }
            else {
                DropMenu.Visible = false; 
            }
        }

        /// <summary>
        /// set the limit of the textbox (2 line)
        /// </summary>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Size SizeOfText = TextRenderer.MeasureText(txt.Text, txt.Font);

            if (SizeOfText.Width > 518)
            {
                txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
                txt.SelectionStart = txt.Text.Length;
                txt.SelectionLength = 0;
            }
        }


        /// <summary>
        /// When double click label, call textbox (so the user can change the content of the label)
        /// </summary>
        private void LabelDoubleClick(object sender, EventArgs e)
        {
            if (DropMenu.Visible == true) DropMenu.Visible = false;
            if (SubMenu.Visible == true) SubMenu.Visible = false;

            txt.Text = "";
            txt.Visible = false;
            txt.Enabled = false;


            saved = false;
            CurrentL = (sender as Label);
            txt.Multiline = false;
            txt.AutoSize = false;
            CustomizePanel.Controls.Add(txt);
            txt.Enabled = true;
            txt.Visible = true;
            txt.Text = (sender as Label).Text;
            txt.BackColor = Color.FromArgb(255, 192, 192);
            txt.Location = new Point ((sender as Label).Location.X + 2, (sender as Label).Location.Y + 1);
            CustomizePanel.Controls.Add(txt);
            txt.Select();
            txt.BringToFront();
        }

        /// <summary>
        /// check if the button of the mouse is pressed 
        /// </summary>
        private void Label_mouseDown(object sender, EventArgs e)
        {

            if (txt.Text != "")
            {
                Color BackColorOfText = Color.LightBlue;

                //set the color
                if (txt.Location.X == 4)
                {
                    BackColorOfText = Title1Lbl.BackColor;
                }
                else if (txt.Location.X == 271)
                {
                    BackColorOfText = Title2Lbl.BackColor;
                }
                else if (txt.Location.X == 538)
                {
                    BackColorOfText = Title3Lbl.BackColor;
                }

                //create new activity (new label)
                Label NewStuff = new Label();
                NewStuff.Name = "Stuff" + indexOfLabel[indexOfTheCurrentSection];
                NewStuff.TabIndex = indexOfLabel[indexOfTheCurrentSection];
                NewStuff.Location = new Point(txt.Location.X - 2, txt.Location.Y - 1);
                NewStuff.Size = new Size(264, 45);
                NewStuff.BackColor = Color.FromArgb(BackColorOfText.A, BackColorOfText.R, BackColorOfText.G, BackColorOfText.B);
                NewStuff.Text = txt.Text;
                NewStuff.Font = new Font("Microsoft Sans Serif", 11.75F);
                NewStuff.TextAlign = ContentAlignment.MiddleCenter;
                NewStuff.DoubleClick += LabelDoubleClick;
                NewStuff.MouseDown += Label_mouseDown;
                NewStuff.MouseUp += Label_mouseUp;
                NewStuff.MouseMove += Form1_MouseMove;
                NewStuff.MouseClick += RightButton_Click;

                if (CurrentL == null)
                {
                    indexOfLabel[indexOfTheCurrentSection]++;
                }

                //change the name to the currentl.name if the user clicked on the label (so the user want edit that label and not create a new one) 
                if (CurrentL != null)
                {
                    NewStuff.Name = CurrentL.Name;
                    CustomizePanel.Controls.Remove(CurrentL);
                    CurrentL.Dispose();
                }

                //add newstuf
                CustomizePanel.Controls.Add(NewStuff);
                NewStuff.BringToFront();


                //set the scoll to the begin of the bar (to avoid any position error)
                CustomizePanel.VerticalScroll.Value = 0;
                CustomizePanel.VerticalScroll.Value = 0;

                //if the height of the picturebox isn't enough for the next cell, make it bigger 
                if (GridBackground.Height - 36 <= txt.Location.Y + 45)
                {
                    GridBackground.Size = new Size(GridBackground.Width, GridBackground.Height + 47);
                    foreach (Control ctrl in CustomizePanel.Controls)
                    {
                        GridBackground.Size = new Size(GridBackground.Width, Math.Max(GridBackground.Height, ctrl.Location.Y + 45 + CustomizePanel.VerticalScroll.Value));

                    }
                }

                //set back the scoll to the origin position of the bar 
                CustomizePanel.VerticalScroll.Value = ScrollBarValue;
                CustomizePanel.VerticalScroll.Value = ScrollBarValue;

                txt.Text = "";
            }



            saved = false;

            txt.Enabled = false;
            txt.Visible = false;
            CurrentL = (sender as Label);
            if (MouseButtonPressed == false)
            {
                MouseButtonPressed = true;

                OriginalPosition = CurrentL.Location;

                //different between the mouse location and label
                Diff_mouse_label = new Point(MouseLocation.X - CurrentL.Location.X - CustomizePanel.Location.X, MouseLocation.Y - CurrentL.Location.Y - CustomizePanel.Location.Y);
                MoveLabel.Start();
            }
         
        }
        private void Label_mouseUp (object sender, EventArgs e)
        {
            if (MouseButtonPressed == true)
            {
                bool Found = false;
                MouseButtonPressed = false;
                MoveLabel.Stop();



                //find the correct position (cell)
                for (int x = 0; x < GridCell.GetLength(0); x++)
                {
                    for (int y = 0; y < GridCell.GetLength(1); y++)
                    {
                        Point MouseP__inPanel = new Point(MouseLocation.X - CustomizePanel.Location.X, MouseLocation.Y - CustomizePanel.Location.Y + CustomizePanel.VerticalScroll.Value);

                        if (GridCell[x, y].X <= MouseP__inPanel.X && GridCell[x, y].X + 268 > MouseP__inPanel.X)
                        {

                            if (GridCell[x, y].Y <= MouseP__inPanel.Y && GridCell[x, y].Y + 47 > MouseP__inPanel.Y)
                            {

                                //avoid error
                                int OrginalScrollValue = CustomizePanel.VerticalScroll.Value;
                                CustomizePanel.VerticalScroll.Value = 0;
                                CustomizePanel.VerticalScroll.Value = 0;

                                CurrentL.Location = new Point(GridCell[x, y].X + 2, GridCell[x, y].Y + 2);

                                Color BackColorOfLable = Color.Black;
                                //set the color
                                if (CurrentL.Location.X == 2)
                                {
                                    BackColorOfLable = Title1Lbl.BackColor;
                                }
                                else if (CurrentL.Location.X == 269)
                                {
                                    BackColorOfLable = Title2Lbl.BackColor;
                                }
                                else if (CurrentL.Location.X == 536)
                                {
                                    BackColorOfLable = Title3Lbl.BackColor;
                                }

                                CurrentL.BackColor = Color.FromArgb(BackColorOfLable.A, BackColorOfLable.R, BackColorOfLable.G, BackColorOfLable.B);

                                CustomizePanel.VerticalScroll.Value = OrginalScrollValue;
                                CustomizePanel.VerticalScroll.Value = OrginalScrollValue;

                                //if the height of the picturebox isn't enough for the next cell (the below one), make it bigger 
                                if (GridBackground.Height - 36 <= CurrentL.Location.Y + 45 + CustomizePanel.VerticalScroll.Value)
                                {
                                    GridBackground.Size = new Size(GridBackground.Width, GridBackground.Height + 47);
                                    foreach (Control ctrl in CustomizePanel.Controls)
                                    {
                                        GridBackground.Size = new Size(GridBackground.Width, Math.Max(GridBackground.Height,ctrl.Location.Y + 45 + CustomizePanel.VerticalScroll.Value));

                                    }
                                }

                                Found = true;
                                break;
                            }
                        }

                    }
                }

                //remove space(cell) of the background that is useless
                // but dont remove cells when the rows is less than 9
                /*
                while (GridBackground.Height - 36 >= CurrentL.Location.Y + 45 + 45 + CustomizePanel.VerticalScroll.Value && GridBackground.Height > 423+47 )
                {
                    GridBackground.Size = new Size(GridBackground.Width, GridBackground.Height - 47);
                }
                */
                if (Found == false)
                {
                    DialogResult result = MessageBox.Show("Do you want delete it?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        CustomizePanel.Controls.Remove(CurrentL);
                        CurrentL.Dispose();
                    }
                    else
                    {
                        CurrentL.Location = OriginalPosition;
                    }


                }
            }

            if (txt.Visible == false)
            {
                CurrentL = null;
            }
        }

        /// <summary>
        /// move label when it is clicked
        /// </summary>
        private void MoveLabel_Tick(object sender, EventArgs e)
        {
            int xDiff = CustomizePanel.Location.X + Diff_mouse_label.X, yDiff = CustomizePanel.Location.Y + Diff_mouse_label.Y;
            CurrentL.Location = new Point(MouseLocation.X - xDiff, MouseLocation.Y - yDiff);
        }


        /// <summary>
        /// when the GridBackground_resize update the gridCell (set new size and New point)
        /// </summary>
        private void GridBackground_Resize(object sender, EventArgs e)
        {
            //resize and init GridCell
            int Rows = GridBackground.Height / 47;
            foreach(Control ctrl in CustomizePanel.Controls)
            {
                Rows = Math.Max(Rows, ctrl.Location.Y / 47);
            }

            int Columns = 3;
        
            GridCell = Preserve_resize_2Dpoint(GridCell,new Size(Rows,Columns));

            for (int x = 0; x < GridCell.GetLength(0); x++)
            {
                GridCell[x, 0] = new Point(0, x * 47);
                GridCell[x, 1] = new Point(267, x * 47);
                GridCell[x, 2] = new Point(534, x * 47);
            }
            if (CustomizePanel.VerticalScroll.Visible == false)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is VScrollBar)
                    {
                        (ctrl as VScrollBar).Enabled = true;
                        (ctrl as VScrollBar).Maximum = CustomizePanel.VerticalScroll.Maximum;
                        break;
                     }
                }
            }
            else
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is VScrollBar)
                    {
                        (ctrl as VScrollBar).Enabled = false;
                        break;
                    }
                }
            }
        }
              
        /// <summary>
        /// Resize 2d array and in the same time preserve everything saved before
        /// </summary>
        Point[,] Preserve_resize_2Dpoint(Point[,] CurrentArray, Size NewSize)
        {
            Point[,] NewArray = new Point[NewSize.Width, NewSize.Height];


            for (int x = 0;x < NewSize.Width; x++)
            {
                for (int y = 0; y < NewSize.Height; y++)
                {
                    if (x > CurrentArray.GetLength(0) - 1 || y > CurrentArray.GetLength(1))
                    {
                        break;
                    }
                    NewArray[x, y] = CurrentArray[x, y];
                }
            }

            return NewArray;
        }

        int[] preserve_resize_ArryInt (int[] CurrentArray, int lenght)
        {
            int[] result = new int[lenght];

            for (int y = 0; y < lenght; y++)
            {
                if (y > CurrentArray.Length - 1 )
                {
                    break;
                }
                result[y] = CurrentArray[y];
            }
            return result;
        }

        string[] preserve_resize_string(string[] CurrentArray, int lenght)
        {
            string[] result = new string[lenght];

            for (int y = 0; y < lenght; y++)
            {
                if (y > CurrentArray.Length - 1)
                {
                    break;
                }
                result[y] = CurrentArray[y];
            }
            return result;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (saved == false)
            {
                saved = true;
                DialogResult result = MessageBox.Show("Do you want to save changes made?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //set scroll value to 0
                    CustomizePanel.AutoScrollPosition = new Point(0, 0);

                    //save 
                    StreamWriter file2 = new StreamWriter(CustomizePanel.Name);
                    foreach (Control ctrl in CustomizePanel.Controls)
                    {
                        if (ctrl is Label)
                        {
                            file2.WriteLine((ctrl as Label).Text);
                            file2.WriteLine((ctrl as Label).TabIndex);
                            file2.WriteLine((ctrl as Label).Size.Width);
                            file2.WriteLine((ctrl as Label).Size.Height);
                            file2.WriteLine((ctrl as Label).Location.X);
                            file2.WriteLine((ctrl as Label).Location.Y);
                            file2.WriteLine((ctrl as Label).BackColor.A);
                            file2.WriteLine((ctrl as Label).BackColor.R);
                            file2.WriteLine((ctrl as Label).BackColor.G);
                            file2.WriteLine((ctrl as Label).BackColor.B);
                        }
                    }
                    file2.Dispose();
                }
            }

            //save icon path, section name and section location
            StreamWriter file = new StreamWriter("Sections");
           foreach (Control ctrl in MenuSlide.Controls)
            {
                int found = 0;
                if (ctrl is RadioButton)
                {
                    indexOfTheCurrentSection = int.Parse((ctrl as RadioButton).Name.Substring(8));
                    file.WriteLine(ctrl.Text);
                    file.WriteLine(ctrl.Location.X);
                    file.WriteLine(ctrl.Location.Y);
                    for (int i = 0; i < ImagePath.Length; i++)
                    {
                        if (i == indexOfTheCurrentSection)
                        {
                            if (ImagePath[i] == "") ImagePath[i] = " ";
                            found = 1;
                            file.WriteLine(ImagePath[i]);
                            break;    
                        }
                    }
                    if (found == 0)
                    {
                        file.WriteLine(" ");
                    }
                    file.WriteLine(indexOfTheCurrentSection);

                }

            }
            file.Dispose();
        }

        private void DeleteCmd_Click(object sender, EventArgs e)
        {
            deleted = true;
            //count how many section there is
            int count = 0;
            foreach (Control section in MenuSlide.Controls)
            {
                if (section is RadioButton) count++;
            }

            //if there is only one section tell the user that he can't delete the this last section
            if (count == 1)
            {
                MessageBox.Show("Ops, You can't delete this section", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //delete in section in menuslide
            foreach (Control ctrl in MenuSlide.Controls)
            {
                //delete radiobutton
                if (ctrl is RadioButton)
                {
                    if (int.Parse((ctrl as RadioButton).Name.Substring(8)) == indexOfTheCurrentSection)
                    {
                        MenuSlide.Controls.Remove((ctrl as RadioButton));
                        (ctrl as RadioButton).Dispose();
                        break;
                    }
                }
               
            }

            //delete icon
            foreach (Control ctrl in MenuSlide.Controls)
            {
                if (ctrl is PictureBox)
                {
                    if ((ctrl as PictureBox).Name == "IconBackground")
                    {
                        continue;
                    }
                    if (int.Parse((ctrl as PictureBox).Name.Substring(4)) == indexOfTheCurrentSection)
                    {
                        MenuSlide.Controls.Remove((ctrl as PictureBox));
                        (ctrl as PictureBox).Dispose();
                        break;
                    }
                }
            }
           
            //delete current panel
            this.Controls.Remove(CustomizePanel);
            CustomizePanel.Dispose();

            //delete current icon in iconpanel
            foreach (Control ctrl in IconPanel.Controls)
            {
                if (ctrl is PictureBox)
                {
                    if (int.Parse((ctrl as PictureBox).Name.Substring(4,(ctrl as PictureBox).Name.Length - 8)) == indexOfTheCurrentSection)
                    {
                        IconPanel.Controls.Remove((ctrl as PictureBox));
                        (ctrl as PictureBox).Dispose();
                    }
                }
            }

            //reallocate all section position 
            foreach (Control section in MenuSlide.Controls)
            {
                if (section is RadioButton)
                {
                    int Id = int.Parse((section as RadioButton).Name.Substring(8));
                    if (Id > indexOfTheCurrentSection)
                    {
                        (section as RadioButton).Location = new Point((section as RadioButton).Location.X, (section as RadioButton).Location.Y - 50);
                    }
                }
            }

            foreach (Control section in MenuSlide.Controls)
            {
                if (section is PictureBox)
                {
                    if ((section as PictureBox).Name == "IconBackground")
                    {
                        continue;
                    }
                    int Id = int.Parse((section as PictureBox).Name.Substring(4));
                    if (Id > indexOfTheCurrentSection)
                    {
                        (section as PictureBox).Location = new Point((section as PictureBox).Location.X, (section as PictureBox).Location.Y - 50);
                    }
                }
            }

            foreach (Control section in IconPanel.Controls)
            {
                if (section is PictureBox)
                {
                    int Id = int.Parse((section as PictureBox).Name.Substring(4,(section as PictureBox).Name.Length - 8));
                    if (Id > indexOfTheCurrentSection)
                    {
                        (section as PictureBox).Location = new Point((section as PictureBox).Location.X, (section as PictureBox).Location.Y - 50);
                    }
                }
            }

            //select a new radiobutton 
            foreach (Control ctrl in MenuSlide.Controls)
            {
                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = true;
                }
            }

            y -= 50;

        }

        bool[] preserve_resize_ArrayBool (bool[] CurrentArray, int lenght)
        {
            bool[] result = new bool[lenght];

            for (int y = 0; y < lenght; y++)
            {
                if (y > CurrentArray.Length - 1)
                {
                    result[y] = false;
                }
                else
                {
                    result[y] = CurrentArray[y];
                }
            }
            return result;
        }


        //add more size (17 which is the size of scroll bar) to add the scroll bar
        //minus 17 when scroll bar disappear
        //in the same time move everything in the right side
        private void MenuSlide_SizeChanged(object sender, EventArgs e)
        {
            if (scrollBarVisible == false && MenuSlide.HorizontalScroll.Visible == true)
            {
                scrollBarVisible = true;
                MenuSlide.Size = new Size(MenuSlide.Width + 17, MenuSlide.Height);
                IconPanel.Size = new Size(IconPanel.Width + 17, IconPanel.Height);
                AddNewActivityCmd.Size = new Size(AddNewActivityCmd.Width +17, AddNewActivityCmd.Height);

                
                Title1Lbl.Location = new Point(Title1Lbl.Location.X + 17, Title1Lbl.Location.Y);
                Title2Lbl.Location = new Point(Title2Lbl.Location.X + 17, Title2Lbl.Location.Y);
                Title3Lbl.Location = new Point(Title3Lbl.Location.X + 17, Title3Lbl.Location.Y);
                this.Size = new Size(this.Width + 17, this.Size.Height);

                //change all panel location
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Panel)
                    {
                        if ((ctrl as Panel).Name != "MenuSlide" && (ctrl as Panel).Name != "IconPanel" )
                        {
                            ctrl.Location = new Point(ctrl.Location.X + 17, ctrl.Location.Y);
                        }
                    }
                }
            }
            else if (MenuSlide.HorizontalScroll.Visible == false && scrollBarVisible == true)
            {
                scrollBarVisible = false;
                MenuSlide.Size = new Size(MenuSlide.Width - 17, MenuSlide.Height);
                IconPanel.Size = new Size(IconPanel.Width - 17, IconPanel.Height);
                AddNewActivityCmd.Size = new Size(AddNewActivityCmd.Width - 17, AddNewActivityCmd.Height);

                Title1Lbl.Location = new Point(Title1Lbl.Location.X - 17, Title1Lbl.Location.Y);
                Title2Lbl.Location = new Point(Title2Lbl.Location.X - 17, Title2Lbl.Location.Y);
                Title3Lbl.Location = new Point(Title3Lbl.Location.X - 17, Title3Lbl.Location.Y);
                this.Size = new Size(this.Width - 17, this.Size.Height);

                //change other panel
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Panel)
                    {
                        if ((ctrl as Panel).Name != "MenuSlide" && (ctrl as Panel).Name != "IconPanel")
                        {
                            ctrl.Location = new Point(ctrl.Location.X - 17, ctrl.Location.Y);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// when form1 is rezide resize also menuslide, button and iconbackground
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            //change the size of menuslide and iconbackground to look they fill the left side of the form 
            MenuSlide.Size = new Size(MenuSlide.Width, this.Size.Height - 73);
            IconBackground.Size = new Size(IconBackground.Size.Width, MenuSlide.Size.Height);

            //set the size of IconPanle
            IconPanel.Size = new Size(IconPanel.Width, this.Size.Height - 73);

        }


        private void FollowMouse_Tick(object sender, EventArgs e)
        {
            int yDiff = this.Location.Y + MenuSlide.Location.Y + Diff_mouse_label.Y;
            currentSection.Location = new Point(currentSection.Location.X, MousePosition.Y - yDiff);

            CurrentIcon1.Location = new Point(CurrentIcon1.Location.X, MousePosition.Y - yDiff);
            CurrentIcon2.Location = new Point(CurrentIcon2.Location.X, MousePosition.Y - yDiff);
        }

        private void Section_MouseUp(object sender, MouseEventArgs e)
        {
            FollowMouse.Stop();

            //get mouselocation
            Point MouseLocation = new Point(MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y -65);

            //set the limit of mouselocation inside the menuslide
            if (MouseLocation.Y <= 0)
            {
                MouseLocation = new Point(MouseLocation.X, 0);
            }
            if (MouseLocation.Y >= Section_height[Section_height.Length - 1])
            {
                MouseLocation = new Point(MouseLocation.X, Section_height[Section_height.Length - 1]);
            }


            foreach (int h in Section_height)
            {
                //find where is mouselocation in Height
                if (MouseLocation.Y >= h && MouseLocation.Y < h + 50)
                {
                    //once found set the currentsection equal to the h
                    currentSection.Location = new Point(currentSection.Location.X, h);

                    CurrentIcon1.Location = new Point(CurrentIcon1.Location.X, h);

                    CurrentIcon2.Location = new Point(CurrentIcon2.Location.X, h);

                    // check if there is another Section and his icon(icon1) in menuslide in h
                    foreach (Control section in MenuSlide.Controls)
                    {
                        //do for section
                        if (section is RadioButton)
                        {
                            //in h we have 2 section and we have to avoid the current section 
                            if ((section as RadioButton).Location.Y == h)
                            {
                                if ((section as RadioButton).Text == currentSection.Text)
                                {
                                    continue;
                                }

                                 //set the location of the section found to the origin position of currentSection 
                                 (section as RadioButton).Location = new Point((section as RadioButton).Location.X, OriginLocation.Y);
                                break;
                            }
                        }
                    }

                    //check for icon1
                    //do for icon
                    foreach (Control icon in MenuSlide.Controls)
                    {
                        if (icon is PictureBox)
                        {
                            if ((icon as PictureBox).Location.Y == h)
                            {
                                //avoid the current one
                                if ((icon as PictureBox) == CurrentIcon1)
                                {
                                    continue;
                                }

                                //set the location of the section found to the origin position of currentSection 
                                (icon as PictureBox).Location = new Point((icon as PictureBox).Location.X, OriginLocation.Y);
                                break;
                            }
                        }
                    }
                    //check for icon2
                    foreach (Control icon in IconPanel.Controls)
                    {
                        if (icon is PictureBox)
                        {
                            //avoid currenticon2
                            if ((icon as PictureBox).Location.Y == h)
                            {
                                if ((icon as PictureBox) == CurrentIcon2)
                                {
                                    continue;
                                }

                            //set the location of the section found to the origin position of currentSection 
                            (icon as PictureBox).Location = new Point((icon as PictureBox).Location.X, OriginLocation.Y);
                                break;
                            }
                        }
                    }

                    break;
                }
            }



        }

        private void Section_MouseDown(object sender, MouseEventArgs e)
        {
            if (saved == false)
            {
                (sender as RadioButton).Checked = true;
                EventArgs es = new EventArgs();
                SLideMenuSelected(sender, es);
                return;
            }


            //save the original Location of the current section
            OriginLocation = (sender as RadioButton).Location;

            //save the current section and correspective icons
            currentSection = (sender as RadioButton);
            foreach (Control Icon1 in MenuSlide.Controls)
            {
                if (Icon1 is PictureBox)
                {
                    if ((Icon1 as PictureBox).Location.Y == currentSection.Location.Y)
                    {
                        CurrentIcon1 = (Icon1 as PictureBox);
                        break;
                    }
                }
            }
            foreach (Control Icon2 in IconPanel.Controls)
            {
                if (Icon2 is PictureBox)
                {
                    if ((Icon2 as PictureBox).Location.Y == currentSection.Location.Y)
                    {
                        CurrentIcon2 = (Icon2 as PictureBox);
                        break;
                    }

                }
            }


            //set diff between the mouselocation and section.location.y
            Diff_mouse_label = new Point (Diff_mouse_label.X, MousePosition.Y - this.Location.Y - MenuSlide.Location.Y);
            Diff_mouse_label = new Point(Diff_mouse_label.X, Diff_mouse_label.Y - currentSection.Location.Y); 
            FollowMouse.Start();
        }

    }
}
