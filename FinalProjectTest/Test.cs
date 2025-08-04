using FinalProject;
using FinalProject.Classes;

namespace FinalProjectTest
{
    [TestClass]
    public sealed class Test
    {
        [TestMethod]
        public void TestMethodCount()
        {
            JewelryShop js = new JewelryShop();

            List<Jewelry> items = new List<Jewelry>()
            {
                new Jewelry(),
                new Jewelry(),
                new Jewelry(),
                new Jewelry()
            };

            js.Items = items.ToArray();

            Assert.AreEqual(4, js.Items.Length);
        }
    }
}
