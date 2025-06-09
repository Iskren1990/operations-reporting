using OperationsReporting.Common.Attributes;
using OperationsReporting.Models.CsvMaps;

namespace OperationsReporting.Models.DTO
{
    [CsvMap(typeof(PartnerExportDtoMap))]
    public class PartnerExportDto
    {
        public long Id { get; set; }

        public required string Name { get; set; }
    }
}
