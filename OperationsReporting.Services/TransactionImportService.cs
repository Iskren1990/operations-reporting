using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationsReporting.DAL;
using OperationsReporting.Models.Entities;
using OperationsReporting.Services.Interfaces;
using System.Xml.Serialization;
using XmlModels = OperationsReporting.Models.XmlModels;

namespace OperationsReporting.Services
{
    public class TransactionImportService : ITransactionImportService
    {
        private readonly OperationsReportingContext _dbContext;
        private readonly IMapper _mapper;

        public TransactionImportService(OperationsReportingContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task ImportTransactionsFromXmlAsync(string xmlFilePath, int merchantId)
        {
            XmlModels.Operation operation;
            var serializer = new XmlSerializer(typeof(XmlModels.Operation));
            using (var stream = File.OpenRead(xmlFilePath))
            {
                operation = (XmlModels.Operation)serializer.Deserialize(stream);
            }

            var transactions = operation.Transactions.Select(tx =>
            {
                var entity = _mapper.Map<Transaction>(tx);
                entity.MerchantId = merchantId;
                return entity;
            }).ToList();

            foreach (var transaction in transactions)
            {
                bool exists = await _dbContext.Transactions.AnyAsync(t => t.ExternalId == transaction.ExternalId);
                if (!exists)
                {
                    _dbContext.Transactions.Add(transaction);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
