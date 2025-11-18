namespace RestaurantOrderSystem;

public class Drink : MenuItem
{
    public int VolumeMl { get; }
    public bool IsAlcoholic { get; }

    public Drink(int id, string name, decimal price, string category, int volumeMl, bool isAlcoholic)
        : base(id, name, price, category)
    {
        VolumeMl = volumeMl;
        IsAlcoholic = isAlcoholic;
    }

    public override string GetInfo()
    {
        string alcoholText = IsAlcoholic ? "з алкоголем" : "без алкоголю";
        return Name + " (" + VolumeMl + " мл, " + alcoholText + ") - " + Price + " грн";
    }
}