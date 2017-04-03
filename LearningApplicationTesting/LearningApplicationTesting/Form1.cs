using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LearningApplicationTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //InitializeOwnComponents, using LoopGen to create movable objects and stationary objects
            LoopGen();
            //LoadGame();
        }
        // -------- Declaration of Classes and Variabels --------
        #region Classes&Varibels
        int size = 90;
        PictureBox lastpicturebox;
        PB_Info[] PBI_R = new PB_Info[9];
        PB_Info[] PBI_I = new PB_Info[9];
        PictureBox[] recipieBoxes = new PictureBox[9];
        private Point MouseDownLocation;
        private Point LastPos;
        private ItemIndex itemIndex = new ItemIndex();
        private Random rnd = new Random();
        Recipe WishedItemRecipe;
        #endregion Classes&Variabels

        // ----------- Game mechanics ---------------------
        private void LoadGame()
        {
            //Wuished Item
            WishedItemRecipe = itemIndex.Recipes[rnd.Next(0, itemIndex.Recipes.Count)];

            //Itemselection
            int i = 0;
            foreach (PB_Info pi in PBI_I)
            {
                pi.Item = WishedItemRecipe.Items[i];
                pi.Item.ItemIcon = (Image)Properties.Resource1.ResourceManager.GetObject(String.Format("_{0}_{1}", pi.Item.Type, pi.Item.Meta)); //This code tho'
                pi.Picturebox.Image = pi.Item.ItemIcon;
                i++;
            }

        } 

        // ----- Creation of controls -----------
        #region Controls

        // --------------------- Creating pictureboxes using GenPB(), with parameters --------------------------
        private void LoopGen()
        {
            for (int i = 0; i < 9; i++)
            {
                var pb = GenPB(String.Format("ItemBoxNR:{0}",i),i * size + i * 3, this.Height - size - 45, true, false, (i).ToString());
                PBI_I[i] = new PB_Info(true, pb);
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int x = i * 3 + i * size + 10;
                    int y = j * 3 + j * size + 10;
                    GenPB(String.Format("RecipeBoxNR:{0}", (3 * j + i)), x, y, false, true, (3 * j + i).ToString());
                    PBI_R[(3 * j + i)] = new PB_Info(false);
                }

            }
            GenPB("Wisheditem&CheckBOX" ,this.Width / 2 + 50, size + 13, false, false);
        }

        //Generates a picturebox, with parameters, (Overloaded Method)
        private PictureBox GenPB(string name, int startX, int startY, bool movable, bool recipieBox)
        {
            #region MiscStuff
            PictureBox pb = new PictureBox();
            pb.Name = name;
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

            //Adding events if movable == true (that means itemboxes)
            if (movable)
            {
                //MouseDown - event
                pb.MouseDown += (sender, e) =>
                {
                    pb.BringToFront();
                    MouseDownLocation = e.Location;
                    LastPos = new Point(pb.Location.X, pb.Location.Y);
                    int misc = 0;
                    
                    foreach (PictureBox rb in recipieBoxes) //if an click event araise set rb to filled == flase, makes that and unfilled rb is not locked an an item.
                    {
                        if (rb.Bounds.Contains(PointToClient(Cursor.Position)))
                        {
                            PBI_I[misc].Filled = false;
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
                            if (!PBI_R[i].Filled)
                            {
                                PBI_R[i].Filled = true;
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
                                        PBI_R[Convert.ToInt16(lastpicturebox.Tag.ToString())].Filled = true;
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

                    //Debugg tool
                    Console.WriteLine("------------------------------------------");
                    foreach (PB_Info info in PBI_R)
                    {
                        Console.WriteLine(String.Format("{0} - IsFilled?:{1} - Item Number:{2}", info.ToString() , info.Filled.ToString(), info.Item.ToString()));
                    }
                };
            }

          
            if (pb.Name == "Wisheditem&CheckBOX")
            {
                pb.Click += (s, e) => 
                {
                    
                };
            }

            //Debug tool
            pb.Click += (s, e) => 
            {
                PictureBox p = s as PictureBox;
                Console.WriteLine("--------------------");
                Console.WriteLine(p.Name);
                //Console.Beep();
            };

            Controls.Add(pb);
            return pb;
        }

        //Generates a picturebox, with more parameters
        private PictureBox GenPB(string name, int startX, int startY, bool movable, bool recipieBox, string tag)
        {
            PictureBox pb = GenPB(name, startX, startY, movable, recipieBox);
            pb.Tag = tag;
            if (recipieBox)
                recipieBoxes[Convert.ToInt16(tag.ToString())] = pb;
            return pb;
        }

        #endregion Controls

        //To create new
        private void makeRecipe()
        {
            
        }

        public void ShowMyDialogBox()
        {
            Form testDialog = new Form();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                this.txtResult.Text = testDialog.TextBox1.Text;
            }
            else
            {
                this.txtResult.Text = "Cancelled";
            }
            testDialog.Dispose();
        }

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