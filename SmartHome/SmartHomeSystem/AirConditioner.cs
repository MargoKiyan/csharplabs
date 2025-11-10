namespace SmartHomeSystem;

public class AirConditioner : Device, IEnergyConsumer
{
    public string DeviceName => Name;
    public int PowerConsumption => 2000;

    public override void TurnOn()
    {
        IsOn = true;
        Console.WriteLine($"{Name} почав охолодження.");
    }

    public override void TurnOff()
    {
        IsOn = false;
        Console.WriteLine($"{Name} зупинено.");
    }

    public double GetEnergyUsage(int hours)
    {
        return IsOn ? (PowerConsumption * hours) / 1000.0 : 0;
    }
}