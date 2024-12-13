class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public double MaxSpeed { get; set; }

    public Car(string Name, string Engine, double MaxSpeed)
    {
        (this.Name, this.Engine, this.MaxSpeed) = (Name, Engine, MaxSpeed);
    }
    public override string ToString() //переопределение
    {
        return Name;
    }

    //Реализация IEquatable<Car> для сравнения объектов по значению
    public bool Equals(Car? other)
    {
        if (other == null) return false;
        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }
}
class CarsCatalog
{
    List<Car> cars = new List<Car>();

    public void AddCar(Car car)
    {
        cars.Add(car);
    }
    
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count) return "Введен неверный индекс";
            return $"Название: {cars[index].Name}, Двигатель: {cars[index].Engine}";
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("BMW M5", "Gasoline", 305);
        Car car2 = new Car("Ford Escape Hybrid", "Hybrid", 230);
        Car car3 = new Car("Nissan Ariya", "Electric", 170);
        Car car4 = new Car("BMW M5", "Gasoline", 305);

        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);
        catalog.AddCar(car3);
        Console.WriteLine(catalog[0]);
        Console.WriteLine(catalog[1]);
        Console.WriteLine(catalog[2]);

        Console.WriteLine(car2.Equals(car3));
        Console.WriteLine(car1.Equals(car4));
    }
}