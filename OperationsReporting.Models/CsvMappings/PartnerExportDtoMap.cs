using CsvHelper.Configuration;
using OperationsReporting.Models.DTO;

namespace OperationsReporting.Models.CsvMaps
{
    public sealed class PartnerExportDtoMap : ClassMap<PartnerExportDto>
    {
        public PartnerExportDtoMap()
        {
            // Map properties and give custom CSV header names
            Map(p => p.Id).Name("Partner ID");
            Map(p => p.Name).Name("Partner Name");
        }
    }
}