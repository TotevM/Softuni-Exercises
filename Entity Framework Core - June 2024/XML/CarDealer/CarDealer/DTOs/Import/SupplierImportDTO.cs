using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.DTOs.Import
{
    [XmlType(nameof(Supplier))]
    public class SupplierImportDTO
    {
        public string Name { get; set; }
        public bool IsImporter { get; set; }
    }
}
