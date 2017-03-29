using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        private Image ItemIcon { get; }
        #endregion

        //-------------------------------------------------------
        #region Constructors
        private Item(Image icon) { ItemIcon = icon; }
        #endregion
    }
}
