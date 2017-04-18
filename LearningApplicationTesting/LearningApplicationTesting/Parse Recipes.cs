using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.IO;


namespace LearningApplicationTesting
{
    class Parse_Recipes
    {
        ItemIndex ii = new ItemIndex();
        public Recipe r = new Recipe();

        public Recipe createreciep()
        {
            List<Item> it = new List<Item>();
            Recipe r = new Recipe();
            int[] ar = { 5, 0, 0, 0, 0, 17, 0, 0, 0, 0 };

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < ii.Items.Count; j++)
                {
                    if (ii.Items[j].Type == ar[i])
                    {
                        if (i == 0)
                        {
                            r.Item = ii.Items[j];
                        }
                        else
                        {
                            r.ConstructItems.Add(ii.Items[j]);
                        }
                    }
                }
            }
            return r;
        }

        //parse
        TextReader reader = StringReader Properties.Resources.recipesv1txt;
        JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
    }
}
