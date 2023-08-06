using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        //[Fact]
        //public void foo()
        //{
        //    IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        //    GildedTros app = new GildedTros(Items);
        //    app.UpdateQuality();
        //    Assert.Equal("fixme", Items[0].Name);
        //}

        [Fact]
        public void QualityNeverGoesUnderZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -5, Quality = 0 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void QualityNeverGoesAboveFifty() //unless legendary
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 51 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void LegendariesDontChange()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 2, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void SellInDecreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void QualityDecreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(19, Items[0].Quality);
        }

        [Fact]
        public void QualityDecreasesByTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Long Methods", SellIn = 2, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(18, Items[0].Quality);
        }

        [Fact]
        public void QualityDecreasesDoubleAsQuick()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -5, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(18, Items[0].Quality);
        }

        [Fact]
        public void QualityDecreasesQuadroupleAsQuick()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Long Methods", SellIn = -2, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(16, Items[0].Quality);
        }

        [Fact]
        public void ConferenceQualityIncreasesByTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 9, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(22, Items[0].Quality);
        }

        [Fact]
        public void ConferenceQualityIncreasesByThree()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 4, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(23, Items[0].Quality);
        }

        [Fact]
        public void ConferenceQualityIncreasesToZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void WineIncreasesInQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Good Wine", SellIn = 2, Quality = 20 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Equal(21, Items[0].Quality);
        }
    }
}