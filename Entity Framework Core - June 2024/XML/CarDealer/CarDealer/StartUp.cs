using System.Text;
using System.Xml;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using ExportPartDTO = CarDealer.DTOs.Export.ExportPartDTO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            Console.WriteLine(GetTotalSalesByCustomer(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string root = "Suppliers";

            SupplierImportDTO[] supplierDTOS = Deserialize<SupplierImportDTO[]>(inputXml, root);
            List<Supplier> suppliers = new List<Supplier>();

            foreach (var s in supplierDTOS)
            {
                Supplier newSupplier = new Supplier()
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                };
                suppliers.Add(newSupplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string root = "Parts";

            var partDTOs = Deserialize<PartDTO[]>(inputXml, root);
            var parts = new HashSet<Part>();

            var ids = context.Suppliers.Select(s => s.Id).ToList();

            foreach (var p in partDTOs)
            {
                if (!ids.Contains(p.SupplierId))
                {
                    continue;
                }
                Part newPart = new Part()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                };
                parts.Add(newPart);
            }
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string root = "Cars";

            var carDTOs = Deserialize<CarDTO[]>(inputXml, root);

            var cars = new List<Car>();
            var partIds = context.Parts.Select(x => x.Id).ToList();
            var partCars = new List<PartCar>();

            foreach (var car in carDTOs)
            {
                var newcar = new Car()
                {
                    Make = car.Make,
                    Model = car.Model,
                    TraveledDistance = car.TraveledDistance
                };
                cars.Add(newcar);
                foreach (var id in car.PartIds.Select(x => x.Id).Distinct())
                {
                    if (!partIds.Contains(id))
                    {
                        continue;
                    }
                    var newPartCar = new PartCar() { Car = newcar, PartId = id };
                    partCars.Add(newPartCar);
                }
            }
            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string root = "Customers";

            var customerDTOs = Deserialize<CustomerDTO[]>(inputXml, root);
            var customers = new List<Customer>();

            foreach (var dto in customerDTOs)
            {
                var newCustomer = new Customer()
                {
                    Name = dto.Name,
                    BirthDate = dto.BirthDate,
                    IsYoungDriver = dto.IsYoungDriver
                };
                customers.Add(newCustomer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string root = "Sales";

            var salesDTOs = Deserialize<SaleDTO[]>(inputXml, root);
            var sales = new List<Sale>();
            int[] carIds = context.Cars.Select(x => x.Id).ToArray();

            foreach (var dto in salesDTOs)
            {
                if (!carIds.Contains(dto.CarId))
                {
                    continue;
                }

                var newSale = new Sale()
                {
                    CarId = dto.CarId,
                    CustomerId = dto.CustomerId
                };
                sales.Add(newSale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}";
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            CarExportDTO[] cars = context.Cars
                .Where(x => x.TraveledDistance > 2_000_000)
                .Select(
                x => new CarExportDTO()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            return Serialize<CarExportDTO[]>(cars, "cars");
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            List<CarBMWDTO> carsBMW = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new CarBMWDTO()
                {
                    Id = x.Id,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance).ToList();

            return Serialize<List<CarBMWDTO>>(carsBMW, "cars", true);
        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new LocalSuppliersDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Parts = x.Parts.Count
                }).ToList();

            return Serialize<List<LocalSuppliersDTO>>(suppliers, "suppliers");
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            CarPartDTO[] carWithParts = context.Cars
                .OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .Select(x => new CarPartDTO()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance,
                    Parts = x.PartsCars
                        .OrderByDescending(x => x.Part.Price)
                        .Select(pc => new ExportPartDTO()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price,
                        }).ToArray()
                }).ToArray();


            return Serialize<CarPartDTO[]>(carWithParts, "cars");
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var dtos = context.Customers
                .Where(c => c.Sales.Any())
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    MoneySpent = x.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => pc.Part.Price)
                })
                .AsEnumerable()
                .Select(x => new CustomerExportDTO
                {
                    FullName = x.FullName,
                    BoughtCars = x.BoughtCars,
                    MoneySpent = x.MoneySpent
                })
                .OrderByDescending(x => x.MoneySpent)
                .ToArray();

            return Serialize(dtos, "Customers");
    }


        public static string Serialize<T>(T obj, string rootName, bool OmitXmlDeclaration = false)
    {
        StringBuilder sb = new StringBuilder();
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        // Remove unnecessary namespace
        XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
        xmlNamespaces.Add(prefix: string.Empty, ns: string.Empty);

        XmlWriterSettings settings = new XmlWriterSettings
        {
            OmitXmlDeclaration = OmitXmlDeclaration,
            Indent = true // Optional: to format the XML with indentation
        };

        using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
        {
            xmlSerializer.Serialize(xmlWriter, obj, xmlNamespaces);
        }

        return sb.ToString().TrimEnd();
    }

    public static T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader stringReader = new StringReader(inputXml);
        object? deserializedObjects = xmlSerializer.Deserialize(stringReader);
        if (deserializedObjects == null || deserializedObjects is not T deserializedObjectTypes)
        {
            throw new InvalidOperationException();
        }

        return deserializedObjectTypes;
    }
}
}