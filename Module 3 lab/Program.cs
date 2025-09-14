using System;

namespace PrinciplesDemo
{
    // DRY 
    public class OrderService
    {
        private double CalculateTotal(int quantity, double price)
        {
            return quantity * price;
        }

        private void PrintOrder(string action, string productName, double totalPrice)
        {
            Console.WriteLine($"Order for {productName} {action}. Total: {totalPrice}");
        }

        public void CreateOrder(string productName, int quantity, double price)
        {
            double totalPrice = CalculateTotal(quantity, price);
            PrintOrder("created", productName, totalPrice);
        }

        public void UpdateOrder(string productName, int quantity, double price)
        {
            double totalPrice = CalculateTotal(quantity, price);
            PrintOrder("updated", productName, totalPrice);
        }
    }

    public abstract class Vehicle
    {
        public virtual void Start()
        {
            Console.WriteLine($"{GetType().Name} is starting");
        }

        public virtual void Stop()
        {
            Console.WriteLine($"{GetType().Name} is stopping");
        }
    }

    public class Car : Vehicle { }
    public class Truck : Vehicle { }

    // KISS 
    public class Calculator
    {
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }

    public class Service
    {
        public void DoSomething()
        {
            Console.WriteLine("Doing something...");
        }
    }

    public class Client
    {
        private readonly Service _service = new Service();

        public void Execute()
        {
            _service.DoSomething();
        }
    }

    // YAGNI 
    public class Circle
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }

    public class Square
    {
        private double _side;

        public Square(double side)
        {
            _side = side;
        }

        public double CalculateArea()
        {
            return _side * _side;
        }
    }

    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    // Main
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DRY ===");
            var orderService = new OrderService();
            orderService.CreateOrder("Laptop", 2, 1000);
            orderService.UpdateOrder("Phone", 3, 500);

            var car = new Car();
            car.Start();
            car.Stop();

            var truck = new Truck();
            truck.Start();
            truck.Stop();

            Console.WriteLine("\n=== KISS ===");
            var calculator = new Calculator();
            calculator.Add(5, 10);

            var client = new Client();
            client.Execute();

            Console.WriteLine("\n=== YAGNI ===");
            var circle = new Circle(5);
            Console.WriteLine($"Circle area: {circle.CalculateArea()}");

            var square = new Square(4);
            Console.WriteLine($"Square area: {square.CalculateArea()}");

            var mathOps = new MathOperations();
            Console.WriteLine($"Sum: {mathOps.Add(7, 8)}");
        }
    }
}


// Вывод

// DRY – убрали дублирование, вынесли повторяющуюся логику (например, расчёт цены и вывод заказа).
// KISS – сделали простую реализацию без лишних абстракций и шаблонов (простой калькулятор, сервис).
// YAGNI – не добавляли лишнего функционала и параметров (только нужные методы и свойства).