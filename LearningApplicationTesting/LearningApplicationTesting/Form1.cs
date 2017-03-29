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

        //-----------------------------------------------------
        #region Variabels & classes
        int size = 90;
        PB_Info[] PBI = new PB_Info[9];
        List<PictureBox> recipieBoxes = new List<PictureBox>();

        private Point MouseDownLocation;
        private Point LastPos;
        private bool[] recipieFilled = new bool[9];
        #endregion Variabels & classes

        //-----------------------------------------------------
        #region Objects & Controls
        //Call for controlls


        //Controll Design


        //Loop to generate a spesific amout of pictureboxes with GenPB function
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
            Recipe rp = new Recipe();
        }

        //Generates an picturebox based on parameters, Overload functions
        private PictureBox GenPB(int startX, int startY, bool movable, bool recipieBox)
        {
            //------------------------------------------------
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

            //Picturebox moving event functions. Adds the function with LINQ to event property of ech Picturbox
            //If Excludes non-moavle objects such as Recipeboxes form runnin the code
            if (movable)
            {
                //MouseDown function added to eventcalls in picturebox.
                pb.MouseDown += (sender, e) =>
                {
                    pb.BringToFront();
                    MouseDownLocation = e.Location;
                    LastPos = new Point(pb.Location.X,pb.Location.Y);

                    //Toclean? -Victor
                    /*
                    foreach (PictureBox rb in recipieBoxes)
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position))) { break; }
                    }
                    for (int i = 0; i < recipieBoxes.Count; i++)
                    {
                        //if(recipieBoxes.IndexOf(i).Contains(PointToClient(Cursor.Position)))
                    }
                    */ 
                };
                //Move the object based on relative mouse postion to picturbox.
                pb.MouseMove += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        pb.Left = pb.Left - MouseDownLocation.X + e.X;
                        pb.Top = pb.Top - MouseDownLocation.Y + e.Y;
                    }
                };
                //Mouse button released validate position to game mechanics.
                pb.MouseUp += (sender, e) =>
                {
                    bool used = false;
                    //Checks if the dropped picturebox is "ontop" of an recipebox.
                    foreach(PictureBox rb in recipieBoxes)
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position)))
                            {
                            //Validates if recipebox is allready occupied by another picturebox.
                            if ((rb.Tag.ToString().Split(':').Length == 1))
                            {
                                pb.Left = rb.Left;
                                pb.Top = rb.Top;
                                //Links recipebox and picturbox to eachother through tags.
                                rb.Tag = String.Format("{0}:{1}", rb.Tag.ToString().Split(':')[0], pb.Tag.ToString().Split(':')[0]);
                                pb.Tag = String.Format("{1}:{0}", rb.Tag.ToString().Split(':')[0], pb.Tag.ToString().Split(':')[0]);

                                Console.WriteLine("Recipie box tag: {0} \n Pictur box tag: {1}", rb.Tag, pb.Tag);
                                used = true;
                                break;
                            }
                            //If recipebox is occupied restet picturebox position to original position.
                            else
                            {
                                Console.WriteLine("Recipie box tag: {0} \n Pictur box tag: {1}", rb.Tag, pb.Tag); //Debug tool
                                pb.Location = LastPos;
                                used = true;
                                break;
                            }
                        }
                    }
                    //If picturebox is dropped "outside" the recipebox grid
                    if (!used)
                    {
                        if (pb.Tag.ToString().Split(':').Length >= 1) { pb.Tag = pb.Tag.ToString().Split(':')[0];  } //Resets the picturebox tag
                        Console.WriteLine("Picturebox tag: {0}", pb.Tag); //Debug tool
                        pb.Left = startX;
                        pb.Top = startY;
                    }
                };
            }

            //Finish generation with adding the picturebox controll to the from.
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

        //Unused Functions(ToClean?)--------------------------
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
