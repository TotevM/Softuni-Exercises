using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.DTOs.Import
{
    [XmlType("Sale")]
    public class SaleDTO
    {
        [XmlElement("carId")]
        public int CarId { get; set; }
        [XmlElement("customerId")]
        public int CustomerId { get; set; }
    }
}
