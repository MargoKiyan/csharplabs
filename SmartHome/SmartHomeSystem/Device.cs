namespace SmartHomeSystem;

public abstract class Device : ISwitchable
{
    public string Name { get; set; }
    public bool IsOn { get; protected set; }

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void PrintStatus()
    {
        Console.WriteLine($"{Name}: {(IsOn ? "увімкнено" : "вимкнено")}");
    }
}