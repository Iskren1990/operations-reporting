namespace OperationsReporting.Models.Entities
{
    public class Partner
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public ICollection<Merchant> Merchants { get; set; } = [];
    }
}