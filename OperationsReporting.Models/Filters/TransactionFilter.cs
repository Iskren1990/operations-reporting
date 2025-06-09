using OperationsReporting.Models.Enums;

namespace OperationsReporting.Models.Filters
{
    public class TransactionFilter
    {
        private DateTime? _dateFrom;
        
        private DateTime? _dateTo;

        public DateTime? DateFrom
        {
            get => _dateFrom;
            set => _dateFrom = value?.Kind == DateTimeKind.Utc ? value : value?.ToUniversalTime();
        }

        public DateTime? DateTo
        {
            get => _dateTo;
            set => _dateTo = value?.Kind == DateTimeKind.Utc ? value : value?.ToUniversalTime();
        }

        public decimal? MinAmount { get; set; }
        
        public decimal? MaxAmount { get; set; }

        public TransactionType? TransactionType { get; set; }

        public TransactionStatus? Status { get; set; }
    }
}