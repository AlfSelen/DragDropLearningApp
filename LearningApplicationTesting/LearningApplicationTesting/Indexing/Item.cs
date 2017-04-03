using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApplicationTesting
{
    public class Item
    {
        //-------------------------------------------------------
        #region Properties
        public int Type { get; set; }
        public int Meta { get; set; }
        public string Name { get; set; }
        public string Text_type { get; set; }
        public System.Drawing.Image ItemIcon { get; }
        #endregion

        //-------------------------------------------------------
        #region Constructors
        public Item(System.Drawing.Image icon) { ItemIcon = icon; }
        #endregion
    }
}
