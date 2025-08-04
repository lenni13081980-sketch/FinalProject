namespace FinalProject.Interfaces
{
    /// <summary>
    /// Shop products
    /// </summary>
    public interface IShopItem
    {
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product price
        /// </summary>
        public double Price { get; set; }
    }
}
