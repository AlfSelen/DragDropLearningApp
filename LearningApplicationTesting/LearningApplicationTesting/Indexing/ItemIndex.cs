﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LearningApplicationTesting
{
    public class ItemIndex
    {
        //-------------------------------------------------------
        #region Properties
        public List<Item> Items { get; set; }
        public List<Recipe> Recipes { get; set; }
        #endregion

        //-------------------------------------------------------
        #region Constructors
        public ItemIndex()
        {
            Items = LoadItemIndex();
            Recipes = LoadRecipeIndex();
        }
        #endregion

        //-------------------------------------------------------
        #region Loading Functions
        //Load Itemindex
        private List<Item> LoadItemIndex()
        { 
            string ItemIndexJSON = Properties.Resources.ItemIndex.ToString();
            return JsonConvert.DeserializeObject<List<Item>>(ItemIndexJSON);
        }
        //Load RecepiceIndex
        private List<Recipe> LoadRecipeIndex()
        {
            string recipeIndexJSON = Properties.Resources.RecipeIndex.ToString();
            return JsonConvert.DeserializeObject<List<Recipe>>(recipeIndexJSON);
        }
        #endregion

        //-------------------------------------------------------
        #region Save functions 
        //Add Recipe to Recipeindex savefile.
        public void SaveRecipeToindex(Recipe recipeToSave)
        {
            string recipeIndexJSON = Properties.Resources.RecipeIndex.ToString();
            List<Recipe> recipeIndexLoaded = JsonConvert.DeserializeObject<List<Recipe>>(recipeIndexJSON);
            recipeIndexLoaded.Add(recipeToSave);
            recipeIndexJSON = JsonConvert.SerializeObject(recipeIndexJSON);
            File.WriteAllText(Properties.Resources.RecipeIndex, recipeIndexJSON);
        }
        #endregion

        //-------------------------------------------------------
        #region Add more functions such as Custum List
        #endregion
    }
}
