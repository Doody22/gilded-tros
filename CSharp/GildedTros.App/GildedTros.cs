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
                        var qualityIncreaseValue = currentItem.SellIn < 0 ? 2 : 1; //'degrade' twice as fast; in this case 'upgrade'
                        currentItem.Quality = currentItem.Quality + qualityIncreaseValue; //wine increases in quality when 'expired'
                        currentItem.SellIn = currentItem.SellIn - 1;
                        break;
                    case "Backstage passes for Re:factor":
                    case "Backstage passes for HAXX":
                        if (currentItem.SellIn < 0)
                        {
                            currentItem.Quality = 0;
                        }
                        else if (currentItem.SellIn <= 5)
                        {
                            currentItem.Quality = currentItem.Quality + 3;
                        }
                        else if (currentItem.SellIn <= 10)
                        {
                            currentItem.Quality = currentItem.Quality + 2;
                        }
                        else
                        {
                            currentItem.Quality = currentItem.Quality + 1;
                        }
                        currentItem.SellIn = currentItem.SellIn - 1;
                        break;
                    case "B-DAWG Keychain":
                        break;
                    default:
                        var qualityDegradeValue = currentItem.SellIn < 0 ? 2 : 1; //degrade twice as fast when sellIn date reached
                        currentItem.Quality = currentItem.Quality - qualityDegradeValue;
                        currentItem.SellIn = currentItem.SellIn - 1;
                        break;
                }

                if (currentItem.Quality > 50 && !currentItemName.Equals("B-DAWG Keychain"))
                {
                    currentItem.Quality = 50; // quality can't be higher than 50 (unless legendary)
                }

                if (currentItem.Quality < 0)
                {
                    currentItem.Quality = 0;
                }

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
