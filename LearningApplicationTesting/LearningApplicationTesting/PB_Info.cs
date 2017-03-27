using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplicationTesting
{
    class PB_Info
    {
        private bool filled;
        private string item;
        int startX, startY;
        bool movable, recipieBox;
        // ---------------- Methods -------------------
        #region GetSetMethods

        public bool Filled
        {
            get { return filled; }
            set { filled = value;}
        }
        public string Item
        {
            get { return item; }
            set { value = item; }
        }

        #endregion GetSetMethods
    }
}
