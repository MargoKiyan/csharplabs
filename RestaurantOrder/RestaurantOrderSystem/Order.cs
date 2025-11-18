namespace RestaurantOrderSystem;

public class Order
{
    private readonly List<OrderItem> _items = new List<OrderItem>();

    public int Id { get; }
    public int TableNumber { get; }
    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order(int id, int tableNumber)
    {
        Id = id;
        TableNumber = tableNumber;
        Status = OrderStatus.New;
    }

    public void AddItem(IMenuItem menuItem, int quantity)
    {
        if (menuItem == null)
        {
            throw new ArgumentNullException(nameof(menuItem));
        }

        if (quantity <= 0)
        {
            return;
        }

        OrderItem existing = _items.FirstOrDefault(i => i.MenuItem.Id == menuItem.Id);
        if (existing != null)
        {
            existing.IncreaseQuantity(quantity);
        }
        else
        {
            _items.Add(new OrderItem(menuItem, quantity));
        }
    }

    public void RemoveItem(int menuItemId)
    {
        OrderItem item = _items.FirstOrDefault(i => i.MenuItem.Id == menuItemId);
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    public decimal GetTotalPrice()
    {
        return _items.Sum(i => i.GetTotalPrice());
    }

    public void ChangeStatus(OrderStatus newStatus)
    {
        Status = newStatus;
    }
}