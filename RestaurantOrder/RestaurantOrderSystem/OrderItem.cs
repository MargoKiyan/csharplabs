namespace RestaurantOrderSystem;

public class OrderItem
{
    public IMenuItem MenuItem { get; }
    public int Quantity { get; private set; }

    public OrderItem(IMenuItem menuItem, int quantity)
    {
        MenuItem = menuItem;
        Quantity = quantity;
    }

    public decimal GetTotalPrice()
    {
        return MenuItem.Price * Quantity;
    }

    public void IncreaseQuantity(int value)
    {
        if (value > 0)
        {
            Quantity += value;
        }
    }
}