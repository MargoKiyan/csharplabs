namespace RestaurantOrderSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Restaurant restaurant = CreateRestaurantWithMenu();

        PrintMenu(restaurant);

        Console.WriteLine();

        Order order = restaurant.CreateOrder(6);
        Console.WriteLine("Створено нове замовлення для столика №" + order.TableNumber);
        Console.WriteLine("ID замовлення: " + order.Id);

        AddMenuItemToOrder(restaurant, order, 1, 1);
        AddMenuItemToOrder(restaurant, order, 4, 1);

        Console.WriteLine();
        Console.WriteLine("Статус замовлення: " + order.Status);
        ChangeOrderStatus(order, OrderStatus.InProgress);
        ChangeOrderStatus(order, OrderStatus.Ready);
        ChangeOrderStatus(order, OrderStatus.Paid);

        Console.WriteLine();
        Console.WriteLine("|====================| УСІ ЗАМОВЛЕННЯ |====================|");
        foreach (Order o in restaurant.Orders)
        {
            Console.WriteLine(
                "ID: " + o.Id +
                " | Стіл: " + o.TableNumber +
                " | Статус: " + o.Status +
                " | Сума: " + o.GetTotalPrice() + " грн");
        }
        Console.WriteLine("|==========================================================|");

        Console.WriteLine();
        DemonstrateSearch(restaurant, order.Id);

        Console.WriteLine();
        DemonstrateCasting();

        Console.WriteLine();
        Console.WriteLine("Натисніть будь-яку клавішу, щоб завершити...");
        Console.ReadKey();
    }

    private static Restaurant CreateRestaurantWithMenu()
    {
        Restaurant restaurant = new Restaurant("Ресторан \"КОЛИБА\"");

        restaurant.AddMenuItem(new Dish(1, "Бограч", 120m, "Перше", false));
        restaurant.AddMenuItem(new Dish(2, "Вареники з картоплею", 110m, "Друге", true));
        restaurant.AddMenuItem(new Dish(3, "Банош", 90m, "Закуска", false));
        restaurant.AddMenuItem(new Drink(4, "Кава", 60m, "Напій", 200, false));
        restaurant.AddMenuItem(new Drink(5, "Чай", 70m, "Напій", 250, false));
        restaurant.AddMenuItem(new Drink(6, "Наливка", 150m, "Напій", 150, true));

        return restaurant;
    }

    private static void PrintMenu(Restaurant restaurant)
    {
        Console.WriteLine("|====================| МЕНЮ РЕСТОРАНУ |====================|");

        int index = 1;
        foreach (IMenuItem menuItem in restaurant.GetFullMenu())
        {
            Console.WriteLine(index + ". " + menuItem.GetInfo());
            index++;
        }

        Console.WriteLine("|==========================================================|");
    }

    private static void AddMenuItemToOrder(Restaurant restaurant, Order order, int menuItemId, int quantity)
    {
        IMenuItem menuItem = restaurant.GetMenuItemById(menuItemId);
        if (menuItem == null)
        {
            Console.WriteLine("Позиція з ID " + menuItemId + " не знайдена в меню.");
            return;
        }

        order.AddItem(menuItem, quantity);
        Console.WriteLine("Додано позицію: " + menuItem.Name);
        Console.WriteLine("Поточна сума: " + order.GetTotalPrice() + " грн");
        
        
    }

    private static void ChangeOrderStatus(Order order, OrderStatus newStatus)
    {
        order.ChangeStatus(newStatus);
        Console.WriteLine("-> Змінено статус: " + order.Status);
    }

    private static void DemonstrateSearch(Restaurant restaurant, int orderId)
    {
        Console.WriteLine("|==========================| ПОШУК |==========================|");

        Order foundOrder = restaurant.FindOrderById(orderId);
        if (foundOrder != null)
        {
            Console.WriteLine("Знайдено замовлення з ID " + orderId +
                              ": стіл " + foundOrder.TableNumber +
                              ", статус " + foundOrder.Status +
                              ", сума " + foundOrder.GetTotalPrice() + " грн");
        }

        Console.WriteLine();
        Console.WriteLine("Пошук у меню за назвою \"кава\":");
        foreach (IMenuItem item in restaurant.FindMenuItemsByName("кава"))
        {
            Console.WriteLine("- " + item.GetInfo());
        }

        Console.WriteLine();
        Console.WriteLine("Пошук у меню за категорією \"Напій\":");
        foreach (IMenuItem item in restaurant.FindMenuItemsByCategory("Напій"))
        {
            Console.WriteLine("- " + item.GetInfo());
        }
        
        Console.WriteLine("|============================================================|");
    }

    private static void DemonstrateCasting()
    {
        Console.WriteLine("|====================| ПРИКЛАД UPCAST / DOWNCAST |====================|");

        Drink drink = new Drink(100, "Лимонад", 55m, "Напій", 300, false);

        IMenuItem upcasted = drink;
        Console.WriteLine("Upcast: об'єкт Drink збережено у змінній типу IMenuItem.");

        Drink downcasted = (Drink)upcasted;
        Console.WriteLine("Downcast: знову отримали Drink і можемо звернутися до VolumeMl = " +
                          downcasted.VolumeMl + " мл");
        
        Console.WriteLine("|=====================================================================|");
    }
}