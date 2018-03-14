using System;
using System.Collections.Generic;
using System.Text;

namespace Menu.Model
{
    public class ItemPair : Tuple<Item, Item>

    {
        public ItemPair(Item item1, Item item2) : base(item1, item2 ?? CreateEmptyModel())
        {
        }

        private static Item CreateEmptyModel()
        {
            return new Item { IsVisible = false };

        }
    }
}
