using AutoMapper;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;
using OperationsReporting.Models.Exceptions;
using OperationsReporting.Models.Filters;
using OperationsReporting.Services.Interfaces;
using System.Xml.Serialization;
using XmlModels = OperationsReporting.Models.XmlModels;

namespace OperationsReporting.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepo;

        public TransactionService(IMapper mapper, ITransactionRepository transactionRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepo = transactionRepo ?? throw new ArgumentNullException(nameof(transactionRepo));
        }

        public async Task<ImportResultDto<string>> ImportTransactionsFromXmlAsync(string xmlFilePath, int merchantId)
        {
            XmlModels.Operation? operation;
            var serializer = new XmlSerializer(typeof(XmlModels.Operation));
            using (var stream = File.OpenRead(xmlFilePath))
            {
                operation = (XmlModels.Operation?)serializer.Deserialize(stream);
            }

            if (operation == null)
            {
                throw new XmlDeserializationException("Failed to deserialize XML to Operation object.");
            }

            var transactions = operation.Transactions.Select(tx =>
            {
                var entity = _mapper.Map<Transaction>(tx);
                entity.MerchantId = merchantId;
                return entity;
            }).ToList();

            return await _transactionRepo.BulkInsertIfNotExistsAsync(transactions);
        }

        public async Task<PagedResult<TransactionDto>> GetTransactionsAsync(TransactionFilter filter, int page, int pageSize)
        {
            var (transactions, totalCount) = await _transactionRepo.GetFilteredTransactionsAsync(filter, page, pageSize);

            var dtos = _mapper.Map<List<TransactionDto>>(transactions);

            return new PagedResult<TransactionDto>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Items = dtos
            };
        }
    }
}
