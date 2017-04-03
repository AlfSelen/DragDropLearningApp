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
        }
        private ItemIndex itemIndex = new ItemIndex();

        private void newRecipeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recipe r = new Recipe();
            itemIndex.Recipes.Add(r);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = itemIndex.Recipes;
        }
    }
}
