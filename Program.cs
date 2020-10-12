using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            var model = new Model();
            model.Items.Add(new Item { Name = "item1" });
            model.Items.Add(new Item { Name = "item1" });
            model.Items.Add(new Item { Name = "item1" });
            model.Items.Add(new Item { Name = "item2" });
            model.Items.Add(new Item { Name = "item2" });
            model.Items.Add(new Item { Name = "item3" });

            foreach (var entry in model.ItemNameAndCount)
            {
                Console.WriteLine(entry.name + ": " + entry.count);
            }
        }

        public class Model
        {
            public List<Item> Items { get; set; } = new List<Item>();

            public IEnumerable<(string name, int count)> ItemNameAndCount
               => Items.GroupBy(x => x.Name)
                       .Select(group =>
                           (
                             name: group.Key,
                             count: group.Count()
                           )
                        );
        }

        public class Item
        {
            public string Name { get; set; }
        }
    }
}
