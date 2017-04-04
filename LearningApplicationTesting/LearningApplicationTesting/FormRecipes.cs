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
    public partial class FormRecipes : Form
    {
        public FormRecipes()
        {
            InitializeComponent();
            dataGridView1.DataSource = itemIndex.Recipes;
            dataGridView2.DataSource = itemIndex.Items;
        }
        private ItemIndex itemIndex = new ItemIndex();

        private void newRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recipe r = new Recipe();
            r.Item = itemIndex.Items[dataGridView2.SelectedRows[0].Index];
            for (int i = 0; i < 9; i++)
            {
                FormItems f = new FormItems();
                r.ConstructItems[i] = f.ShowMyDialogBoxItems();
            }
            itemIndex.Recipes.Add(r);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = itemIndex.Recipes;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
