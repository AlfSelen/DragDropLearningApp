using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplicationTesting
{
    class Item
    {
        //-------------------------------------------------------
        #region Properties
        private int Type { get; set; }
        private int Meta { get; set; }
        private string Name { get; set; }
        private string Text_type { get; set; }
        private System.Drawing.Image ItemIcon { get; }
        #endregion

        //-------------------------------------------------------
        #region Constructors
        public Item(System.Drawing.Image icon) { ItemIcon = icon; }
        #endregion
    }
}
