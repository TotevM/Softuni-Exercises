using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //string suppliers = File.ReadAllText("../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, suppliers));

            //string parts = File.ReadAllText("../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, parts));

            //string cars = File.ReadAllText("../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, cars));

            //string customers = File.ReadAllText("../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, customers));

            //string sales = File.ReadAllText("../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, sales));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var ids = context.Suppliers.Select(x => x.Id).ToList();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson).Where(x => ids.Contains(x.SupplierId));


            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDtos = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            var cars = new HashSet<Car>();
            var partsCars = new HashSet<PartCar>();

            foreach (var carDto in carsDtos)
            {
                var newCar = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                cars.Add(newCar);
                foreach (var partId in carDto.PartsId.Distinct())
                {
                    partsCars.Add(new PartCar
                    {
                        Car = newCar,
                        PartId = partId
                    });
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new CustomerDTO()
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                }).ToList();

            return JsonConvert.SerializeObject(customers, JsonSerializerSettings);
        }
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .Select(x => new ToyotaCarDTO()
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                }).OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .ToList();

            return JsonConvert.SerializeObject(cars, JsonSerializerSettings);
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(x => new SupplierDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                }).ToList();

            return JsonConvert.SerializeObject(suppliers, JsonSerializerSettings);
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new /*PartDTO*/
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                            .ToString("F2")
                    })
                }).ToList();

            return JsonConvert.SerializeObject(cars, JsonSerializerSettings);
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers=context.Customers
                .Where(x=>x.Sales.Count>=1)
                .Select(x=>new
                {
                    FullName=x.Name,
                    BoughtCars=x.Sales.Count,
                    SpentMoney = x.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => pc.Part.Price)
                }).OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            return JsonConvert.SerializeObject(customers, JsonSerializerSettings);
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales=context.Sales
                .Take(10)
                .Select(x=>new
                {
                    car= new
                    {
                        Make=x.Car.Make,
                        Model=x.Car.Model,
                        TraveledDistance=x.Car.TraveledDistance
                    },
                    customerName = x.Customer.Name,
                    discount=x.Discount.ToString("f2"),
                    price=x.Car.PartsCars.Sum(cp=>cp.Part.Price).ToString("f2"),
                    priceWithDiscount = (x.Car.PartsCars
                            .Sum(pc => pc.Part.Price) * (1 - x.Discount * 0.01m))
                        .ToString("F2")
                }).ToList();

            return JsonConvert.SerializeObject(sales, JsonSerializerSettings);
        }

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };
    }
          
}