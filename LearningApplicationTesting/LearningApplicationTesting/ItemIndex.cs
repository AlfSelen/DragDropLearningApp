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
        List<Item> itemIndex = new List<Item>();
        List<string> recepie = new List<string>();

        private ItemIndex()
        {
            
        }

        //Load functions
        //Load Itemindex
        private void LoadItemIndex()
        {
            string ItemIndexJSON = Properties.Resources.ItemIndex.ToString();
            Item item = JsonConvert.DeserializeObject<Item>(ItemIndexJSON);




        }    
            //Load Recepice
        //Save functions
    }
}
