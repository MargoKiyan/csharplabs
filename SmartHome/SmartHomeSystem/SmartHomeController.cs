namespace SmartHomeSystem;

public class SmartHomeController
{
    private readonly List<ISwitchable> _devices = new();
    private readonly List<IEnergyConsumer> _energyDevices = new();
    
    public void AddDevice(ISwitchable device)
    {
        if (device is null) return;
        _devices.Add(device);
    }

    public void AddEnergyDevice(IEnergyConsumer device)
    {
        if (device is null) return;
        _energyDevices.Add(device);
    }

    public void TurnAllOn()
    {
        foreach (var device in _devices)
            device.TurnOn();
    }

    public void TurnAllOff()
    {
        foreach (var device in _devices)
            device.TurnOff();
    }

    public void ShowEnergyReport(int hours)
    {
        Console.WriteLine($"Звіт про споживання енергії за {hours} год:");
        double total = 0.0;

        foreach (var device in _energyDevices)
        {
            double usage = device.GetEnergyUsage(hours);
            Console.WriteLine($"{device.DeviceName}: {usage:F2} кВт·год (потужність: {device.PowerConsumption} Вт)");
            total += usage;
        }

        Console.WriteLine($"Загальне споживання: {total:F2} кВт·год");
        Console.WriteLine($"Вартість (~4 грн/кВт·год): {total * 4:F2} грн\n");
    }
}