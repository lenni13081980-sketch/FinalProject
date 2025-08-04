using FinalProject.Interfaces;

namespace FinalProject.Classes
{
    /// <summary>
    /// Jewelry
    /// </summary>
    public class Jewelry : IShopItem
    {
        /// <summary>
        /// Jewelry name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Jewerly price
        /// </summary>
        public double Price { get; set; } = 0.0;

        /// <summary>
        /// Jewerly metal
        /// </summary>
        public string Metal { get; set; } = string.Empty;

        /// <summary>
        /// Jewerly weight
        /// </summary>
        public double Weight { get; set; } = 0.0;

        /// <summary>
        /// Jewerly constructor
        /// </summary>
        public Jewelry() { }

        /// <summary>
        /// Jewerly constructor with paramethers
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="metal">Metal</param>
        /// <param name="weight">Weight</param>
        /// <param name="price">Price</param>
        public Jewelry(string name, string metal, double weight, double price)
        {
            Name = name;
            Metal = metal;
            Weight = weight;
            Price = price;
        }

        /// <summary>
        /// To string
        /// </summary>
        /// <returns>Name</returns>
        public override string ToString() => Name;
    }
}
