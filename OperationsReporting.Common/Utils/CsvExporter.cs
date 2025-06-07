using CsvHelper;
using CsvHelper.Configuration;
using OperationsReporting.Common.Attributes;
using System.Globalization;

namespace OperationsReporting.Common.Utils
{
    public static class CsvExporter
    {
        public static string ExportToCsv<T>(IEnumerable<T> items)
        {
            using var writer = new StringWriter();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldQuote = args => true,
            };

            using var csv = new CsvWriter(writer, config);

            // Check if T has CsvMapAttribute and register the map if found
            var mapAttribute = typeof(T).GetCustomAttributes(typeof(CsvMapAttribute), false)
                .FirstOrDefault() as CsvMapAttribute;

            if (mapAttribute != null)
            {
                var mapInstance = (ClassMap)Activator.CreateInstance(mapAttribute.MapType)!;
                csv.Context.RegisterClassMap(mapInstance);
            }

            csv.WriteRecords(items);

            return writer.ToString();
        }
    }
}
