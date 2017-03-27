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
        

        // --------------- Constructor -------------------
        public PB_Info(bool fd, string itm)            
        {
            filled = fd;
            item = itm;
        }

        // -------------- Default Constructor --------------
        public PB_Info()
        {

        }



        #endregion GetSetMethods
    }
}
