using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplicationTesting
{
    class PB_Info
    {
        // ---------------- Properties -------------------

        public bool Filled { get; set; }
        public string Item { get; set; }
        
        // --------------- Constructor -------------------

        public PB_Info(bool fd, string itm)            
        {
            Filled = fd;
            Item = itm;
        }

        // -------------- Default Constructor ------------

        public PB_Info() {}
    }
}
