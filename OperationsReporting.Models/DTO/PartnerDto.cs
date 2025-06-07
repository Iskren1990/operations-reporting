namespace OperationsReporting.Models.DTO
{
    public class PartnerDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<MerchantDto> Merchants { get; set; } = [];
    }
}
