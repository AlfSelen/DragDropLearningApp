using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LearningApplicationTesting
{
    class ItemIndex
    {
        private List<Item> Items { get; set; }
        private List<Recipe> Recipes { get; set; }

        private ItemIndex()
        {
            Items = LoadItemIndex();
        }

        //Load functions
        //Load Itemindex
        private List<Item> LoadItemIndex()
        { 
            string ItemIndexJSON = Properties.Resources.ItemIndex.ToString();
            return JsonConvert.DeserializeObject<List<Item>>(ItemIndexJSON);
        }
        //Load Recepice
        /*private List<Recipe> LoadRecipeIndex()
        {
            string RecipeIndexJSON = Properties.Resources.RecipeIndex.ToString();
            return JsonConvert.DeserializeObject<List<Recipe>>(RecipeIndexJSON);
        }*/

        //Save functions
    }
}
