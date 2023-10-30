// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

// Абстрактний клас транспортного засобу
public abstract class Vehicle
{
    public int Speed { get; protected set; }
    public int Capacity { get; protected set; }

    public abstract void Move();
}

// Клас Human, який представляє людину
public class Human : Vehicle
{
    public Human(int speed)
    {
        Speed = speed;
        Capacity = 1;
    }

    public override void Move()
    {
        Console.WriteLine("Human is walking");
    }
}

// Спадкоємці класу Vehicle: Car, Bus, Train
public class Car : Vehicle
{
    public Car(int speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public override void Move()
    {
        Console.WriteLine("Car is driving");
    }
}

public class Bus : Vehicle
{
    public Bus(int speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public override void Move()
    {
        Console.WriteLine("Bus is driving");
    }
}

public class Train : Vehicle
{
    public Train(int speed, int capacity)
    {
        Speed = speed;
        Capacity = capacity;
    }

    public override void Move()
    {
        Console.WriteLine("Train is moving on rails");
    }
}

// Клас Route для визначення точок початку та кінця маршруту
public class Route
{
    public string Start { get; set; }
    public string End { get; set; }

    public Route(string start, string end)
    {
        Start = start;
        End = end;
    }
}

// Клас TransportNetwork для управління та контролю руху транспорту
public class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void CalculateOptimalRoute(Route route, Type vehicleType)
    {
        // Тут ви можете реалізувати логіку для визначення оптимального маршруту
        Console.WriteLine($"Calculating optimal route for {vehicleType.Name} from {route.Start} to {route.End}");
    }

    public void PassengerBoarding(Vehicle vehicle, int numPassengers)
    {
        if (numPassengers <= vehicle.Capacity)
        {
            Console.WriteLine($"Boarding {numPassengers} passengers into the {vehicle.GetType().Name}");
        }
        else
        {
            Console.WriteLine("Not enough capacity for passengers");
        }
    }

    public void PassengerDisembarkation(Vehicle vehicle, int numPassengers)
    {
        if (numPassengers > 0)
        {
            Console.WriteLine($"Disembarking {numPassengers} passengers from the {vehicle.GetType().Name}");
        }
        else
        {
            Console.WriteLine("No passengers to disembark");
        }
    }

    public static void Main(string[] args)
    {
        Human human = new Human(speed: 5);
        Car car = new Car(speed: 60, capacity: 4);
        Bus bus = new Bus(speed: 40, capacity: 30);
        Train train = new Train(speed: 100, capacity: 200);

        Route route = new Route("City A", "City B");

        TransportNetwork network = new TransportNetwork();
        network.AddVehicle(human);
        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        foreach (Vehicle vehicle in network.vehicles)
        {
            vehicle.Move();
            network.CalculateOptimalRoute(route, vehicle.GetType());
        }

        network.PassengerBoarding(car, 4);
        network.PassengerDisembarkation(bus, 2);
    }
}
