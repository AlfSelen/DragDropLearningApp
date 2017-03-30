using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningApplicationTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //InitializeOwnComponents, using LoopGen to create movable objects and stationary objects
            LoopGen();
        }
        // -------- Declaration of Classes and Variabels --------
        #region Classes&Varibels
        int size = 90;
        PictureBox lastpicturebox;
        PB_Info[] PBI = new PB_Info[9];
        PictureBox[] recipieBoxes = new PictureBox[9];
        #endregion Classes&Variabels

        // ----- Creation of controls -----------
        #region Controls

        //Call for controlls

        //Controll Design
        private Point MouseDownLocation;
        private Point LastPos;
        private bool[] recipieFilled = new bool[9];

        //Creating pictureboxes using GenPB(), with parameters
        private void LoopGen()
        {
            for (int i = 0; i < 9; i++)
            {
                GenPB(i * size + i * 3, this.Height - size - 45, true, false, (i).ToString());
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = i * 3 + i * size + 10;
                    int y = j * 3 + j * size + 10;
                    GenPB(x, y, false, true, (3 * j + i).ToString());
                    PBI[(3 * j + i)] = new PB_Info(false, "");
                }

            }
            GenPB(this.Width / 2 + 50, size + 10 + 3, false, false);
        }

        //Generates a picturebox, with parameters, (Overloaded Method)
        private PictureBox GenPB(int startX, int startY, bool movable, bool recipieBox)
        {
            #region MiscStuff
            PictureBox pb = new PictureBox();
            pb.Left = startX;
            pb.Top = startY;
            pb.Size = new Size(size, size);
            pb.BackColor = Color.LightGray;
            pb.AllowDrop = true;
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            if (movable)
                pb.Image = Properties.Resources.Minecraft_grass_block;
            #endregion MiscStuff

            //Adding events if movable == true
            if (movable)
            {
                //MouseDown - event
                pb.MouseDown += (sender, e) =>
                {
                    pb.BringToFront();
                    MouseDownLocation = e.Location;
                    LastPos = new Point(pb.Location.X, pb.Location.Y);
                    int misc = 0;
                    foreach (PictureBox rb in recipieBoxes)
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position)))
                        {
                            PBI[misc].Filled = false;
                            lastpicturebox = rb;
                            break;
                        }
                        misc++;
                    }
                };
                //MoouseMove - event, updating location of the picturebox
                pb.MouseMove += (sender, e) =>
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        pb.Left = pb.Left - MouseDownLocation.X + e.X;
                        pb.Top = pb.Top - MouseDownLocation.Y + e.Y;
                    }
                };
                //MouseUp - event for when you drop the picturebox
                //Checks where it's dropped, and locks it a location,
                //Updates the grid if fill Filled
                pb.MouseUp += (sender, e) =>
                {
                    bool used = false;
                    int i = 0;
                    foreach (PictureBox rb in recipieBoxes)
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position)))
                        {
                            if (!PBI[i].Filled)
                            {
                                PBI[i].Filled = true;
                                pb.Left = rb.Left;
                                pb.Top = rb.Top;
                                used = true;
                                break;
                            }
                            else
                            {
                                pb.Location = LastPos;
                                used = true;

                                for (int j = 0; j < 9; j++)
                                {
                                    if (recipieBoxes[j].Bounds.Contains(LastPos))
                                    {
                                        PBI[Convert.ToInt16(lastpicturebox.Tag.ToString())].Filled = true;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                        i++;
                    }
                    //Moves picturebox to startlocation, if it's out of location
                    if (!used)
                    {
                        pb.Left = startX;
                        pb.Top = startY;
                    }
                };
            }
            Controls.Add(pb);
            return pb;
        }

        //Generates a picturebox, with more parameters
        private PictureBox GenPB(int startX, int startY, bool movable, bool recipieBox, string tag)
        {
            PictureBox pb = GenPB(startX, startY, movable, recipieBox);
            pb.Tag = tag;
            if (recipieBox)
                recipieBoxes[Convert.ToInt16(tag.ToString())] = pb;
            return pb;
        }

        #endregion Controls

        //Old code, from when we Used the .tag property for storing information
        #region Unused
        private bool check_ifOriginalTag(string rb)
        {
            for (int i = 0; i < 9; i++)
            {
                if (rb == i.ToString()) return true;
            }
            return false;
        }
        private PictureBox find_Tag(string tag)
        {
            foreach (PictureBox rb in recipieBoxes)
            {
                if (rb.Tag.ToString().Split('-')[0] == tag)
                { return rb; }
            }
            return null;
        }
        #endregion Unused
    }
}