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


        private void UpdateValues(Item currentItem, int quality, bool isDecrease = true)
        {
            if (isDecrease)
            {
                currentItem.Quality -= quality;
            } else
            {
                currentItem.Quality += quality;
            }
            currentItem.SellIn -= 1;

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
                        var qualityIncreaseValue = currentItem.SellIn <= 0 ? 2 : 1; //'degrade' twice as fast; in this case 'upgrade'
                        UpdateValues(currentItem, qualityIncreaseValue, false); // wine increases in value the closer it is to sellIn value
                        break;
                    case "Backstage passes for Re:factor":
                    case "Backstage passes for HAXX":
                        var quality = 0;
                        if (currentItem.SellIn <= 0) // when SellIn date reached this becomes worthless
                        {
                            currentItem.Quality = 0;
                        }
                        else if (currentItem.SellIn <= 5) // when SellIn date is in less than 6 days; increase quality every day by 3
                        {
                            quality = 3;
                        }
                        else if (currentItem.SellIn <= 10)  // when SellIn date is in less than 11 days; increase quality every day by 2
                        {
                            quality = 2;
                        }
                        else // when SellIn date is more than 11 days, increase quality by one every day
                        {
                            quality = 1;
                        }
                        UpdateValues(currentItem, quality, false);
                        break;
                    case "B-DAWG Keychain": //a legendary item that doesn't change in either quality or sellIn
                        break;
                    case "Duplicate Code":
                    case "Long Methods":
                    case "Ugly Variable Names":
                        var doubleQualityDegradeValue = currentItem.SellIn <= 0 ? 4 : 2; //degrade twice as fast when sellIn date reached
                        UpdateValues(currentItem, doubleQualityDegradeValue);
                        break;
                    default:
                        var qualityDegradeValue = currentItem.SellIn <= 0 ? 2 : 1; //degrade twice as fast when sellIn date reached
                        UpdateValues(currentItem, qualityDegradeValue);
                        break;
                }

                if (currentItem.Quality > 50 && !currentItemName.Equals("B-DAWG Keychain"))
                {
                    currentItem.Quality = 50; // quality can't be higher than 50 (unless legendary)
                }

                if (currentItem.Quality < 0)
                {
                    currentItem.Quality = 0; // quality can't be lower than 0
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
