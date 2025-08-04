namespace FinalProject.Interfaces
{
    /// <summary>
    /// Shop
    /// </summary>
    public interface IShop
    {
        /// <summary>
        /// Shop name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Shop address
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Total price
        /// </summary>
        /// <returns>Price</returns>
        double TotalPrice();
    }
}
