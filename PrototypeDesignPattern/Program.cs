public class Program
{
    public static void Main(string[] args)
    {
        var car1 = new Car("I6", "BMW", new Feature { Color = "Red", Weight = 400, MaxSpeed = 100 });
        var car2 = car1.Clone();

        car1.Model = "I9";
        car1.Feature.Color = "Black";

        Console.WriteLine(car1.ToString());
        Console.WriteLine(car2.ToString());
    }
}

public abstract class Prototype
{
    public abstract Prototype Clone();
}

public class Feature
{
    public string Color { get; set; }
    public int Weight { get; set; }
    public int MaxSpeed { get; set; }
}

public class Car : Prototype
{
    public string Model { get; set; }
    public string Brand { get; set; }
    public Feature Feature { get; set; }

    public Car(string model, string brand, Feature feature)
    {
        Model = model;
        Brand = brand;
        Feature = feature;
    }

    public override string ToString()
    {
        return $"Mode: {Model}, Brand: {Brand}, Features: [Color: {Feature.Color}, Weight: {Feature.Weight}, MaxSpeed: {Feature.MaxSpeed}]";
    }

    // Shallow Copy
    // public override Car Clone()
    // {
    //     return new Car(Model, Brand, Feature);
    // }

    // Deep Copy
    public override Car Clone()
    {
        return new Car(Model, Brand, new Feature
        {
            Color = Feature.Color,
            MaxSpeed = Feature.MaxSpeed,
            Weight = Feature.Weight
        });
    }
}