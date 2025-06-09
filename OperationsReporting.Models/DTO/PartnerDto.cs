namespace OperationsReporting.Models.DTO
{
    public class PartnerDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public List<MerchantDto> Merchants { get; set; } = [];
    }
}
