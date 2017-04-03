using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningApplicationTesting
{
    class PB_Info
    {
        // ---------------- Properties -------------------

        public bool Filled { get; set; }
        public Item Item { get; set; }
        public PictureBox Picturebox { get; set; }
        
        // --------------- Constructor -------------------

        public PB_Info(bool fd)            
        {
            Filled = fd;
        }

        public PB_Info(bool fd, PictureBox pb)
        {
            Filled = fd;
            Picturebox = pb;
        }

        // -------------- Default Constructor ------------

        public PB_Info() {}
    }
}
