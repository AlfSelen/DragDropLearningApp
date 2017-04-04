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

        public Item ShowMyDialogBoxItems()
        {
            FormItems testDialog = new FormItems();
            Item it = new Item();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                it = itemIndex.Items[dataGridView1.SelectedRows[0].Index];
                return it;
            }
            return null;
        }
    }
}
