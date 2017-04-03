using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningApplicationTesting
{
    public partial class FormItems : Form
    {
        public FormItems()
        {
            InitializeComponent();
            dataGridView1.DataSource = itemIndex.Items;
        }
        private ItemIndex itemIndex = new ItemIndex();
    }
}
