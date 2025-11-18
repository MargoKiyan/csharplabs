namespace RestaurantOrderSystem;

public class Restaurant
{
    private readonly List<IMenuItem> _menuItems = new List<IMenuItem>();
    private readonly List<Order> _orders = new List<Order>();
    private int _nextOrderId = 01;

    public string Name { get; }

    public IReadOnlyCollection<IMenuItem> MenuItems => _menuItems.AsReadOnly();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    public Restaurant(string name)
    {
        Name = name;
    }

    public void AddMenuItem(IMenuItem menuItem)
    {
        _menuItems.Add(menuItem);
    }

    public IEnumerable<IMenuItem> GetFullMenu()
    {
        return _menuItems;
    }

    public IEnumerable<IMenuItem> FindMenuItemsByName(string namePart)
    {
        if (string.IsNullOrWhiteSpace(namePart))
        {
            return new List<IMenuItem>();
        }

        string lower = namePart.ToLower();
        return _menuItems.Where(m => m.Name.ToLower().Contains(lower));
    }

    public IEnumerable<IMenuItem> FindMenuItemsByCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            return new List<IMenuItem>();
        }

        string lower = category.ToLower();
        return _menuItems.Where(m => m.Category.ToLower().Contains(lower));
    }

    public IMenuItem GetMenuItemById(int id)
    {
        return _menuItems.FirstOrDefault(m => m.Id == id);
    }

    public Order CreateOrder(int tableNumber)
    {
        Order order = new Order(_nextOrderId, tableNumber);
        _nextOrderId++;
        _orders.Add(order);
        return order;
    }

    public Order FindOrderById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public IEnumerable<Order> GetActiveOrders()
    {
        return _orders.Where(o => o.Status != OrderStatus.Paid);
    }
}