using System;
using System.Collections.Generic;

namespace Task4_Interface
{
    public interface IGeographicObject
    {
        double CoordinateX { get; }
        double CoordinateY { get; }
        string Name { get; }
        string Description { get; }

        void GetInfo();
    }
    public class River : IGeographicObject
    {
        private double _coordinateX;
        private double _coordinateY;
        private string _name;
        private string _description;
        private double _flowSpeed;
        private double _totalLength;

        public River(double x, double y, string name, string description, double flowSpeed, double totalLength)
        {
            _coordinateX = x;
            _coordinateY = y;
            _name = name;
            _description = description;
            _flowSpeed = flowSpeed;
            _totalLength = totalLength;
        }

        public double CoordinateX => _coordinateX;
        public double CoordinateY => _coordinateY;
        public string Name => _name;
        public string Description => _description;

        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Coordinates: ({CoordinateX}, {CoordinateY})");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Flow Speed: {_flowSpeed} cm/s");
            Console.WriteLine($"Total Length: {_totalLength} km");
        }
    }
    public class Mountain : IGeographicObject
    {
        private double _coordinateX;
        private double _coordinateY;
        private string _name;
        private string _description;
        private double _highestPoint;

        public Mountain(double x, double y, string name, string description, double highestPoint)
        {
            _coordinateX = x;
            _coordinateY = y;
            _name = name;
            _description = description;
            _highestPoint = highestPoint;
        }

        public double CoordinateX => _coordinateX;
        public double CoordinateY => _coordinateY;
        public string Name => _name;
        public string Description => _description;

        public void GetInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Coordinates: ({CoordinateX}, {CoordinateY})");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Highest Point: {_highestPoint} m");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IGeographicObject> objects = new List<IGeographicObject>();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add River");
                Console.WriteLine("2. Add Mountain");
                Console.WriteLine("3. Show all objects");
                Console.WriteLine("0. Exit");
                Console.Write("Select choice: ");

                string choice = Console.ReadLine() ?? string.Empty;

                bool isAddRiver = choice == "1";
                bool isAddMountain = choice == "2";
                bool isShowObjects = choice == "3";
                bool isExit = choice == "0";

                if (isAddRiver)
                {
                    AddRiver(objects);
                }
                else if (isAddMountain)
                {
                    AddMountain(objects);
                }
                else if (isShowObjects)
                {
                    ShowAllObjects(objects);
                }
                else if (isExit)
                {
                    isRunning = false;
                }
                else
                {
                    Console.WriteLine("Error: Invalid choice.");
                }
            }
        }
        private static void AddRiver(List<IGeographicObject> objects)
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter description: ");
                string description = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Coordinate X: ");
                double x = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter Coordinate Y: ");
                double y = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter flow speed (cm/s): ");
                double speed = double.Parse(Console.ReadLine() ?? "0");

                bool isSpeedInvalid = speed < 0;
                if (isSpeedInvalid)
                {
                    throw new Exception("Flow speed cannot be negative.");
                }

                Console.Write("Enter total length (km): ");
                double length = double.Parse(Console.ReadLine() ?? "0");

                bool isLengthInvalid = length < 0;
                if (isLengthInvalid)
                {
                    throw new Exception("Total length cannot be negative.");
                }

                objects.Add(new River(x, y, name, description, speed, length));
                Console.WriteLine($"River '{name}' added.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers for coordinates and metrics.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private static void AddMountain(List<IGeographicObject> objects)
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter description: ");
                string description = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Coordinate X: ");
                double x = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter Coordinate Y: ");
                double y = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter highest point (m): ");
                double height = double.Parse(Console.ReadLine() ?? "0");

                bool isHeightInvalid = height < 0;
                if (isHeightInvalid)
                {
                    throw new Exception("Highest point cannot be negative.");
                }

                objects.Add(new Mountain(x, y, name, description, height));
                Console.WriteLine($"Mountain '{name}' added.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter valid numbers for coordinates and height.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ShowAllObjects(List<IGeographicObject> objects)
        {
            bool isEmpty = objects.Count == 0;
            if (isEmpty)
            {
                Console.WriteLine("No objects available.");
                return;
            }

            for (int i = 0; i < objects.Count; i++)
            {
                Console.WriteLine($"\nObject {i + 1}");
                objects[i].GetInfo();
            }
        }
    }
}