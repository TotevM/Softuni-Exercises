using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.DataProcessor.ExportDtos
{

    public class CustomerExportDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public BookingExportDTO[] Bookings { get; set; }
    }
}
