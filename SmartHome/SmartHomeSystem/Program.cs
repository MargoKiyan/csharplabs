namespace SmartHomeSystem;

class Program
{
    static void Main(string[] args)
    {
        var controller = new SmartHomeController();

        var light = new Light { Name = "Лампа у вітальні" };
        var air = new AirConditioner { Name = "Кондиціонер у спальні" };
        var coffee = new CoffeeMachine { Name = "Кавомашина на кухні" };
        var sensor = new MotionSensor { Name = "Датчик руху у коридорі" };

        controller.AddDevice(light);
        controller.AddDevice(air);
        controller.AddDevice(coffee);
        controller.AddDevice(sensor);

        controller.AddEnergyDevice(light);
        controller.AddEnergyDevice(air);
        controller.AddEnergyDevice(coffee);

        controller.TurnAllOn();
        Console.WriteLine();

        light.PrintStatus();
        air.PrintStatus();
        coffee.PrintStatus();
        sensor.PrintStatus();
        Console.WriteLine();

        controller.ShowEnergyReport(5);
        controller.TurnAllOff();
    }
}