using System.Xml.Serialization;

namespace OperationsReporting.Models.XmlModels
{
    public class Operation
    {
        [XmlElement("FileDate")]
        public DateTime FileDate { get; set; }

        [XmlArray("Transactions")]
        [XmlArrayItem("Transaction")]
        public List<Transaction> Transactions { get; set; } = new();
    }
}
