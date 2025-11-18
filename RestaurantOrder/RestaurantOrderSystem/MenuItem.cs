namespace RestaurantOrderSystem;

public abstract class MenuItem : IMenuItem
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public string Category { get; }

    protected MenuItem(int id, string name, decimal price, string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public abstract string GetInfo();
}