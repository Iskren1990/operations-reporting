namespace OperationsReporting.Models.XmlModels
{
    public class Party
    {
        public required string BankName { get; set; }

        public required string BIC { get; set; }

        public required string IBAN { get; set; }
    }
}
