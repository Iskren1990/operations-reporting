namespace OperationsReporting.Models.Entities
{
    public class Partner
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public ICollection<Merchant> Merchants { get; set; } = [];
    }
}