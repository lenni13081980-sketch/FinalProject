using FinalProject.Interfaces;

namespace FinalProject.Classes
{
    /// <summary>
    /// Jewerly shop
    /// </summary>
    public class JewelryShop : IShop
    {
        /// <summary>
        /// Jewerly shop name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Jewerly shop address
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Jewerly shop products
        /// </summary>
        public Jewelry[] Items { get; set; } = new Jewelry[10];

        /// <summary>
        /// Jewerly shop constructor
        /// </summary>
        public JewelryShop() { }

        /// <summary>
        /// Jewerly shop constructor with paramethers
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="items">Items</param>
        public JewelryShop(string name, string address, Jewelry[] items)
        {
            Name = name;
            Address = address;
            Items = items;
        }

        /// <summary>
        /// Jewerly shop total price
        /// </summary>
        /// <returns>Total price</returns>
        public double TotalPrice()
        {
            return Items.Sum(i => i.Price);
        }
    }
}
