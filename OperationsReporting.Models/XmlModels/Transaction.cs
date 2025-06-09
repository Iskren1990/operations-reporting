using System.Xml.Serialization;

namespace OperationsReporting.Models.XmlModels
{
    public class Transaction
    {
        public required string ExternalId { get; set; }

        [XmlElement("CreateDate")]
        public DateTime CreateDate { get; set; }

        public required Amount Amount { get; set; }

        public int Status { get; set; }

        public required Party Debtor { get; set; }

        public required Party Beneficiary { get; set; }
    }
}
