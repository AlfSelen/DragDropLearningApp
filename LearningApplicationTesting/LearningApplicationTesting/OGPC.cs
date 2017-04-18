using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LearningApplicationTesting
{
    public class OGPC
    {
        //---------------------------------------------------------
        #region Variables
        Form form = new Form();
        PictureBox renderbox = new PictureBox();
        PictureBox Outputbox = new PictureBox();
        #endregion

        //---------------------------------------------------------
        #region Constructs
        public OGPC(Form f)
        {
            form = f;
        }
        public OGPC()
        {

        }

        #endregion

        //---------------------------------------------------------
        #region Methods
        public PictureBox renderformObjects()
        {
            Control[] renderObjects = form.Controls.Find("render", true);
            Graphics g = renderbox.CreateGraphics();
            foreach (Control cont in renderObjects)
            {
                if (cont.GetType().ToString() == "PictureBox")
                {
                    PictureBox p = cont as PictureBox;
                    g.DrawImage(p.Image , cont.Location.X, cont.Location.Y);
                }
                else
                {
                    g.DrawImage(cont.BackgroundImage, cont.Location.X, cont.Location.Y);
                }
            }
            return Outputbox;
        }
        public PictureBox renderformObjects(Form renderform)
        {
            Control[] renderObjects = renderform.Controls.Find("render", true);
            Graphics g = renderbox.CreateGraphics();
            foreach (Control cont in renderObjects)
            {
                if (cont.GetType().ToString() == "PictureBox")
                {
                    PictureBox p = cont as PictureBox;
                    g.DrawImage(p.Image, cont.Location.X, cont.Location.Y);
                }
                else
                {
                    g.DrawImage(cont.BackgroundImage, cont.Location.X, cont.Location.Y);
                }
            }
            return Outputbox;
        }


        #endregion
        //---------------------------------------------------------
        #region Func

        #endregion
    }
}
