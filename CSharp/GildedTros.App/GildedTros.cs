using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var currentItem = Items[i];
                var currentItemName = currentItem.Name;

                switch (currentItemName)
                {
                    case "Good Wine":
                        if (currentItem.Quality == 50)
                        {
                            break;
                        }
                        currentItem.Quality = currentItem.Quality + 1;
                        break;
                    case "Backstage passes for Re:factor":
                    case "Backstage passes for HAXX":
                        if (currentItem.Quality == 50)
                        {
                            break;
                        }
                        if (currentItem.SellIn < 11)
                        {
                            currentItem.Quality = currentItem.Quality + 1;
                        }

                        if (currentItem.SellIn < 6)
                        {
                            currentItem.Quality = currentItem.Quality + 1;
                        }
                        break;
                    case "B-DAWG Keychain":
                        break;
                    default:
                        if (currentItem.Quality == 50)
                        {
                            break;
                        }
                        currentItem.Quality = currentItem.Quality - 1;
                        break;
                }

                currentItem.SellIn -= 1; //at the end of each day lower SellIn value by 1

                //if (Items[i].Name != "Good Wine"
                //    && Items[i].Name != "Backstage passes for Re:factor"
                //    && Items[i].Name != "Backstage passes for HAXX")
                //{
                //    if (Items[i].Quality > 0)
                //    {
                //        if (Items[i].Name != "B-DAWG Keychain")
                //        {
                //            Items[i].Quality = Items[i].Quality - 1;
                //        }
                //    }
                //}
                //else
                //{
                //    if (Items[i].Quality < 50)
                //    {
                //        Items[i].Quality = Items[i].Quality + 1;

                //        if (Items[i].Name == "Backstage passes for Re:factor"
                //        || Items[i].Name == "Backstage passes for HAXX")
                //        {
                //            if (Items[i].SellIn < 11)
                //            {
                //                if (Items[i].Quality < 50)
                //                {
                //                    Items[i].Quality = Items[i].Quality + 1;
                //                }
                //            }

                //            if (Items[i].SellIn < 6)
                //            {
                //                if (Items[i].Quality < 50)
                //                {
                //                    Items[i].Quality = Items[i].Quality + 1;
                //                }
                //            }
                //        }
                //    }
                //}

                //if (Items[i].Name != "B-DAWG Keychain")
                //{
                //    Items[i].SellIn = Items[i].SellIn - 1;
                //}

                //if (Items[i].SellIn < 0)
                //{
                //    if (Items[i].Name != "Good Wine")
                //    {
                //        if (Items[i].Name != "Backstage passes for Re:factor"
                //            && Items[i].Name != "Backstage passes for HAXX")
                //        {
                //            if (Items[i].Quality > 0)
                //            {
                //                if (Items[i].Name != "B-DAWG Keychain")
                //                {
                //                    Items[i].Quality = Items[i].Quality - 1;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                //        }
                //    }
                //    else
                //    {
                //        if (Items[i].Quality < 50)
                //        {
                //            Items[i].Quality = Items[i].Quality + 1;
                //        }
                //    }
                //}
            }
        }
    }
}
