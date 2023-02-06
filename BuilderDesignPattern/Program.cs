public class Program
{
    public static void Main(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();

        var laptopBuilder = new LaptopBuilder();
        var desktopBuilder = new DesktopBuilder();

        configurationBuilder.BuildSystem(laptopBuilder, "16 GB", "1 TB", "Wireless", "Wireless", "true");
        configurationBuilder.BuildSystem(desktopBuilder, "16 GB", "1 TB", "Wired", "Wired", "false");

        var laptop = laptopBuilder.GetSystem();
        var desktop = desktopBuilder.GetSystem();

        Console.WriteLine(laptop);
        Console.WriteLine(desktop);
    }
}

public class ComputerSystem
{
    public string RAM { get; set; }
    public string HDDSize { get; set; }
    public string Keyboard { get; set; }
    public string Mouse { get; set; }
    public string TouchScreen { get; set; }
}
public interface ISystemBuilder
{
    void AddMemory(string memory);
    void AddDrive(string size);
    void AddKeyboard(string type);
    void AddMouse(string type);

    void AddTouchScreen(string enabled);
    ComputerSystem GetSystem();
}
public class DesktopBuilder : ISystemBuilder
{
    ComputerSystem desktop = new ComputerSystem();

    public void AddDrive(string size)
    {
        desktop.HDDSize = size;
    }

    public void AddKeyboard(string type)
    {
        desktop.Keyboard = type;
    }

    public void AddMemory(string memory)
    {
        desktop.RAM = memory;
    }

    public void AddMouse(string type)
    {
        desktop.Mouse = type;
    }

    public void AddTouchScreen(string enabled)
    {
        return;
    }

    public ComputerSystem GetSystem()
    {
        return desktop;
    }
}
public class LaptopBuilder : ISystemBuilder
{
    ComputerSystem laptop = new ComputerSystem();

    public void AddDrive(string size)
    {
        laptop.HDDSize = size;
    }

    public void AddKeyboard(string type)
    {
        return;
    }

    public void AddMemory(string memory)
    {
        laptop.RAM = memory;
    }

    public void AddMouse(string type)
    {
        return;
    }

    public void AddTouchScreen(string enabled)
    {
        laptop.TouchScreen = enabled;
    }

    public ComputerSystem GetSystem()
    {
        return laptop;
    }
}
public class ConfigurationBuilder
{
    public void BuildSystem(
        ISystemBuilder systemBuilder, string RAM, string HDDSize, string keyboardType, string mouseType, string enabled)
    {
        systemBuilder.AddMemory(RAM);
        systemBuilder.AddDrive(HDDSize);
        systemBuilder.AddKeyboard(keyboardType);
        systemBuilder.AddTouchScreen(enabled);
        systemBuilder.AddMouse(mouseType);
    }
}