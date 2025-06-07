using OperationsReporting.Common.Attributes;
using OperationsReporting.Common.CsvMappings;

namespace OperationsReporting.Models.DTO
{
    [CsvMap(typeof(MerchantExportDtoMap))]
    public class MerchantExportDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime BoardingDate { get; set; }

        public required string Url { get; set; }

        public required string Country { get; set; }

        public required string AddressMain { get; set; }

        public string? AddressSecondary { get; set; }

        public int PartnerId { get; set; }
    }
}
