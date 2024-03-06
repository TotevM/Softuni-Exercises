using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogVehicle
{
    class Catalog
    {
        public Catalog(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            Horsepower = horsepower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Catalog> catalog = new List<Catalog>();
            string input;
            double totalCarHorsepower = 0;
            int carCount = 0;
            double totalTruckHorsepower = 0;
            int truckCount = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] vehicleInfo = input.Split();
                string type = vehicleInfo[0];
                string model = vehicleInfo[1];
                string color = vehicleInfo[2];
                int horsepower = int.Parse(vehicleInfo[3]);

                Catalog vehicle = new Catalog(type, model, color, horsepower);

                catalog.Add(vehicle);

                if (type == "car")
                {
                    totalCarHorsepower += horsepower;
                    carCount++;
                }
                else if (type == "truck")
                {
                    totalTruckHorsepower += horsepower;
                    truckCount++;
                }
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                PrintCatalog(catalog, input);
            }

            PrintAverageHorsepower(totalCarHorsepower, carCount, totalTruckHorsepower, truckCount);
        }

        static void PrintAverageHorsepower(double totalCarHorsepower, int carCount, double totalTruckHorsepower, int truckCount)
        {
            double averageCarHorsepower = carCount > 0 ? totalCarHorsepower / carCount : 0;
            double averageTruckHorsepower = truckCount > 0 ? totalTruckHorsepower / truckCount : 0;

            Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:f2}.");
        }

        static void PrintCatalog(List<Catalog> vehicles, string filter)
        {
            foreach (Catalog vehicle in vehicles.Where(x => x.Model == filter))
            {
                vehicle.Type = vehicle.Type.Substring(0, 1).ToUpper() + vehicle.Type.Substring(1);
                Console.WriteLine($"Type: {vehicle.Type}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
            }
        }
    }
}