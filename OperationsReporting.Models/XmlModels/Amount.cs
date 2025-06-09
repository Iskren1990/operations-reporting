namespace OperationsReporting.Models.XmlModels
{
    public class Amount
    {
        public required string Direction { get; set; }

        public required decimal Value { get; set; }

        public required string Currency { get; set; }
    }
}
