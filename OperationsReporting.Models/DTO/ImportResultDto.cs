namespace OperationsReporting.Models.DTO
{
    public class ImportResultDto<T>
    {
        public int Total { get; set; }

        public int Inserted { get; set; }

        public List<T> SkippedIds { get; set; } = [];
    }
}