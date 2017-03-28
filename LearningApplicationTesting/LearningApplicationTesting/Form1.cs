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
        #region Variabels & classes
        int size = 90;
        PB_Info[] PBI = new PB_Info[9];
        List<PictureBox> recipieBoxes = new List<PictureBox>();
        private Point MouseDownLocation;
        private Point LastPos;
        private bool[] recipieFilled = new bool[9];
        #endregion Variabels & classes
        // ----- Creation of controls
        #region Controls

        //Call for controlls

        //Controll Design

        //Lager pictureboxes med GenPB funksjonen
        private void LoopGen()
        {
            for (int i = 0; i < 9; i++)
            {
                GenPB(i * size + i * 3, this.Height - size - 45, true,false,(i).ToString());
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
            GenPB(this.Width / 2 + 50, size + 10 +3,false,false );
        }

        //Generer en picturebox, fra noen parametere, Overloaded method
        private PictureBox GenPB(int startX, int startY, bool movable, bool recipieBox)
        {
            #region MiscStuff
            PictureBox pb = new PictureBox();
            if (recipieBox)
                recipieBoxes.Add(pb);
            pb.Left = startX;
            pb.Top = startY;
            pb.Size = new Size(size, size);
            pb.BackColor = Color.LightGray;
            pb.AllowDrop = true;
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;   
            if(movable)
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
                    LastPos = new Point(pb.Location.X,pb.Location.Y);

                    
                    foreach (PictureBox rb in recipieBoxes)
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position)))
                        {
                            //rb.Tag = rb.Tag.ToString().Split('-')[0];
                            break;
                        }
                    }
                    for (int i = 0; i < recipieBoxes.Count; i++)
                    {
                        //if(recipieBoxes.IndexOf(i).Contains(PointToClient(Cursor.Position)))
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
                //Når man slipper et objekt
                pb.MouseUp += (sender, e) =>
                {
                    bool used = false;
                    foreach(PictureBox rb in recipieBoxes)
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position)))
                            {
                            if ((rb.Tag.ToString().Split('-').Length == 1))
                            {
                                pb.Left = rb.Left;
                                pb.Top = rb.Top;
                                rb.Tag = String.Format("{0}-{1}", rb.Tag.ToString().Split('-')[0], pb.Tag.ToString().Split('-')[0]);
                                pb.Tag = String.Format("{1}-{0}", rb.Tag.ToString().Split('-')[0], pb.Tag.ToString().Split('-')[0]);

                                Console.WriteLine("Recipie box tag: {0} \n Pictur box tag: {1}", rb.Tag, pb.Tag);
                                used = true;
                                break;
                            }
                            else if (rb.Tag.ToString().Split('-').Length > 1)
                            {
                                rb.Tag = String.Format("{0}-{1}", rb.Tag.ToString().Split('-')[0], pb.Tag.ToString().Split('-')[0]);
                                Console.WriteLine("Recipie box tag: {0} \n Pictur box tag: {1}", rb.Tag, pb.Tag);
                                pb.Location = LastPos;
                                used = true;
                                break;
                            }
                        }
                    }
                    if (!used)
                    {
                        Console.WriteLine("Pictur box tag: {0}", pb.Tag);
                        //pb.Tag = pb.Tag = rb.Tag.ToString().Split('-')[0];
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
            return pb;
        }

        #endregion Controls

        //Ubrukte Methoder (fjerne ?)
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
