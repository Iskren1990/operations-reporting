namespace OperationsReporting.Models.XmlModels
{
    public class Amount
    {
        public required string Direction { get; set; } // "D" or "C"

        public decimal Value { get; set; }

        public required string Currency { get; set; }
    }
}
