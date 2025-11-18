namespace RestaurantOrderSystem;

public interface IMenuItem
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    string Category { get; }

    string GetInfo();
}