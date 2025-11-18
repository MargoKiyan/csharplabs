namespace RestaurantOrderSystem;

public class Dish : MenuItem
{
    public bool IsVegetarian { get; }

    public Dish(int id, string name, decimal price, string category, bool isVegetarian)
        : base(id, name, price, category)
    {
        IsVegetarian = isVegetarian;
    }

    public override string GetInfo()
    {
        string vegetarianText = IsVegetarian ? " (вегетаріанська)" : string.Empty;
        return Name + vegetarianText + " (" + Category + ") - " + Price + " грн";
    }
}