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
            //InitializeOwnComponents();
            LoopGen();
        }
        int size = 90;
        PictureBox lastpicturebox;
        PB_Info[] PBI = new PB_Info[9];

        PictureBox[] recipieBoxes = new PictureBox[9];

        // ----- Creation of controls
        #region Controls

        //Call for controlls

        //Controll Design
        private Point MouseDownLocation;
        private Point LastPos;
        private bool[] recipieFilled = new bool[9];

        //Lager pictureboxes med GenPB funksjonen
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

        //Generer en picturebox, fra noen parametere
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

            //Adding events if
            if (movable)
            {
                //MouseDown, skjer når man klikker
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
                //Beveger objektet
                pb.MouseMove += (sender, e) =>
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        pb.Left = pb.Left - MouseDownLocation.X + e.X;
                        pb.Top = pb.Top - MouseDownLocation.Y + e.Y;
                    }
                };

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
        private PictureBox GenPB(int startX, int startY, bool movable, bool recipieBox, string tag)
        {
            PictureBox pb = GenPB(startX, startY, movable, recipieBox);
            pb.Tag = tag;
            if (recipieBox)
                recipieBoxes[Convert.ToInt16(tag.ToString())] = pb;
            return pb;
            //

            /*
            PictureBox pb = new PictureBox();
            if (recipieBox)
                recipieBoxes.Add(pb);
            pb.Left = startX;
            pb.Top = startY;
            pb.Size = new Size(size, size);
            pb.Tag = tag;
            pb.BackColor = Color.LightGray;
            pb.AllowDrop = true;
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Click += (sender, e) => { Console.WriteLine(pb.Tag); };
            if (movable)
                pb.Image = Properties.Resources.Minecraft_grass_block;
            if (movable)
            {
                pb.MouseDown += (sender, e) =>
                {
                    pb.BringToFront();
                    MouseDownLocation = e.Location;
                    Console.WriteLine(pb.Tag);
                };
                pb.MouseMove += (sender, e) =>
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        pb.Left = pb.Left - MouseDownLocation.X + e.X;
                        pb.Top = pb.Top - MouseDownLocation.Y + e.Y;
                    }
                };
                pb.MouseUp += (sender, e) =>
                {
                    foreach (PictureBox rb in recipieBoxes)
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position)))
                        {
                            pb.Left = rb.Left;
                            pb.Top = rb.Top;
                            //pb.Tag = rb.Tag;
                            break;
                        }
                    }
                };
            }
            Controls.Add(pb);
            return pb;
            */

            //
        }

        #endregion Controls

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
    }
}