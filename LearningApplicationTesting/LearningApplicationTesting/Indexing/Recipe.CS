using System.Collections.Generic;

namespace LearningApplicationTesting
{
    public class Recipe
    {
        public Item Item { get; set;}
        public List<Item> ConstructItems = new List<Item>();
    }
}
