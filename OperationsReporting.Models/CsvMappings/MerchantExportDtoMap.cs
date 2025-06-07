using CsvHelper.Configuration;
using OperationsReporting.Models.DTO;

namespace OperationsReporting.Common.CsvMappings
{
    public sealed class MerchantExportDtoMap : ClassMap<MerchantExportDto>
    {
        public MerchantExportDtoMap()
        {
            Map(m => m.Id).Name("Merchant ID");
            Map(m => m.Name).Name("Merchant Name");
            Map(m => m.BoardingDate).Name("Boarding Date");
            Map(m => m.Url).Name("URL");
            Map(m => m.Country).Name("Country");
            Map(m => m.AddressMain).Name("Main Address");
            Map(m => m.AddressSecondary).Name("Secondary Address");
            Map(m => m.PartnerId).Name("Partner ID");
        }
    }
}