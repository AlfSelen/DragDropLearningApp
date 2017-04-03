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
        public Item Item { get; set; }
        
        // --------------- Constructor -------------------

        public PB_Info(bool fd)            
        {
            Filled = fd;

        }

        // -------------- Default Constructor ------------

        public PB_Info() {}
    }
}
