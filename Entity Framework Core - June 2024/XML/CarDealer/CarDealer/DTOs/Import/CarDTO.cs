using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class CarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; } = null!;

        [XmlElement("model")]
        public string Model { get; set; } = null!;

        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartsCarsImportDto[] PartIds { get; set; }
    }

    [XmlType("partId")]
    public class PartsCarsImportDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
