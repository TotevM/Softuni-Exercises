using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using System.Globalization;
namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var dtos = Deserialize<ImportCustomerDTO[]>(xmlString, "Customers");
            StringBuilder sb= new StringBuilder();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                bool isDuplicate = context.Customers.Any(c =>
                    c.FullName == dto.FullName ||
                    c.Email == dto.Email ||
                    c.PhoneNumber == dto.PhoneNumber);

                if (isDuplicate)
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                var newCustomer = new Customer()
                {
                    FullName = dto.FullName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber
                };
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, dto.FullName));

                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb=new StringBuilder();

            ICollection<Booking> bookings = new HashSet<Booking>();

            BookingDTO[] dtos = JsonConvert.DeserializeObject<BookingDTO[]>(jsonString);

            foreach (var dto in dtos)
            {
                bool validDateFormat = IsValidDateFormat(dto.BookingDate, "yyyy-MM-dd");

                if (!IsValid(dto) || !validDateFormat)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking newBooking = new Booking()
                {
                    BookingDate = DateTime.Parse(dto.BookingDate, CultureInfo.InvariantCulture),
                    Customer = context.Customers.First(x => x.FullName == dto.CustomerName),
                    TourPackage = context.TourPackages.First(x => x.PackageName == dto.TourPackageName)
                };
                bookings.Add(newBooking);

                sb.AppendLine(string.Format(SuccessfullyImportedBooking, newBooking.TourPackage.PackageName, dto.BookingDate));
            }
            context.Bookings.AddRange(bookings);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
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

        public static bool IsValidDateFormat(string dateString, string format)
        {
            DateTime tempDate;
            bool isValid = DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate);
            return isValid;
        }
    }
}
