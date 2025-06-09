using CsvHelper.Configuration;
using OperationsReporting.Models.DTO;

namespace OperationsReporting.Models.CsvMaps
{
    public sealed class PartnerExportDtoMap : ClassMap<PartnerExportDto>
    {
        public PartnerExportDtoMap()
        {
            Map(p => p.Id).Name("Partner ID");
            Map(p => p.Name).Name("Partner Name");
        }
    }
}