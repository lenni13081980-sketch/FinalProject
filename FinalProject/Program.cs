using FinalProject.Classes;
using Serilog;
using System.Text.Json;

/// <summary>
/// Program class
/// </summary>
public class Program
{
    /// <summary>
    /// Maximum number of stores
    /// </summary>
    private const int MAX_SHOPS = 4;

    /// <summary>
    /// Data file path
    /// </summary>
    private const string filePath = "shops.json";

    /// <summary>
    /// Program entrance
    /// </summary>
    public static void Main()
    {
        try
        {
            // Initializing logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            // List of shops
            List<JewelryShop> shops = new List<JewelryShop>();

            // If file with data exist
            if (File.Exists(filePath))
            {
                // Read data file
                string json = File.ReadAllText(filePath);
                List<JewelryShop>? jeweleryShops = JsonSerializer.Deserialize<List<JewelryShop>>(json);

                // If data file is empty
                if (jeweleryShops is null)
                {
                    throw new Exception("File data is null");
                }

                shops = jeweleryShops.ToList();

                Log.Information("Data was read from shops.json");
            }
            // Else if no data file create new one
            else
            {
                for (var i = 0; i < MAX_SHOPS; i++)
                {
                    Console.Write("Enter shop name: ");
                    string shopName = Console.ReadLine() ?? "";

                    Console.Write($"Enter address for {shopName}: ");
                    string address = Console.ReadLine() ?? "";

                    Console.WriteLine("\nEnter shop items\n");
                    List<Jewelry> items = new List<Jewelry>();
                    bool leave = false;
                    while (!leave)
                    {
                        Console.Write("Enter item name: ");
                        string itemName = Console.ReadLine() ?? "";

                        Console.Write($"Enter {itemName} price (double): ");
                        string itemPrice = Console.ReadLine() ?? "";

                        Console.Write($"Enter {itemName} weight (double): ");
                        string itemWeight = Console.ReadLine() ?? "";

                        Console.Write($"Enter {itemName} metal: ");
                        string itemMetal = Console.ReadLine() ?? "";

                        Console.WriteLine("\nAre these all the items?\n0. Yes\nAny. No");
                        string ch = Console.ReadLine() ?? "";
                        if (ch == "0")
                        {
                            leave = true;
                        }

                        items.Add(new Jewelry()
                        {
                            Name = itemName,
                            Price = double.Parse(itemPrice),
                            Weight = double.Parse(itemWeight),
                            Metal = itemMetal
                        });
                    }

                    shops.Add(new JewelryShop()
                    {
                        Name = shopName,
                        Address = address,
                        Items = items.ToArray()
                    });
                }

                // Serialize to JSON
                string json = JsonSerializer.Serialize(shops, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("shops.json", json);

                Log.Information("Data has been saved to shops.json");
            }

            // Unique metals with count
            var metals = new Dictionary<string, int>();
            foreach (var shop in shops)
            {
                foreach (var item in shop.Items)
                {
                    if (!metals.ContainsKey(item.Metal))
                        metals[item.Metal] = 0;
                    metals[item.Metal]++;
                }
            }
            File.WriteAllLines("metals_count.txt", metals.Select(m => $"{m.Key}: {m.Value}"));

            // Jewelry from shops with total price ≥ 500
            List<string> expensiveItems = shops.
                Where(store => store.Items.Sum(p => p.Price) >= 500).
                SelectMany(store => store.Items).
                Select(product => product.ToString()).
                OrderBy(str => str).
                ToList();
            File.WriteAllLines("rich_items.txt", expensiveItems);

            Log.Information("Processing completed! Results are in metals_count.txt and rich_items.txt");
        }
        catch (Exception ex)
        {
            // Interception of exceptions with their logging to files with Serilog
            Log.Error(ex.Message);
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}