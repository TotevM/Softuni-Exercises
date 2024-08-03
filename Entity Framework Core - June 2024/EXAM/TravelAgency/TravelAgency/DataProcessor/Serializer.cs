using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using Formatting = Newtonsoft.Json.Formatting;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            GuideExportDTO[] dtos = context.Guides
                .Where(x => x.Language == Language.Spanish)
                .Select(x => new GuideExportDTO()
                {
                    FullName = x.FullName,
                    TourPackages = x.TourPackagesGuides.Select(x => new TourPackageDTO()
                    {
                        Name = x.TourPackage.PackageName,
                        Description = x.TourPackage.Description,
                        Price = x.TourPackage.Price
                    })
                        .OrderByDescending(p=>p.Price)
                        .ThenBy(n=>n.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.TourPackages.Length)
                .ThenBy(x => x.FullName)
                .ToArray();

            return Serialize(dtos, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var dtos = context.Customers
                .Where(x => x.Bookings
                    .Any(z => z.TourPackage.PackageName == "Horse Riding Tour"))
                .ToArray()
                .Select(x => new CustomerExportDTO()
                {
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    Bookings = x.Bookings
                        .Where(x=>x.TourPackage.PackageName== "Horse Riding Tour")
                    .OrderBy(y => y.BookingDate)
                        .Select(z => new BookingExportDTO()
                        {
                            TourPackageName = z.TourPackage.PackageName,
                            Date = z.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .OrderBy(y => DateTime.Parse(y.Date))
                        .ToArray()
                })
                .OrderByDescending(x => x.Bookings.Length)
                .ThenBy(x => x.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(dtos, Formatting.Indented);
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

    }
}
