using AutoMapper;
using OperationsReporting.Common.Utils;
using OperationsReporting.DAL.Interfaces;
using OperationsReporting.Models.DTO;
using OperationsReporting.Services.Interfaces;

namespace OperationsReporting.Services
{
    public class ExportService : IExportService
    {
        private readonly IMapper _mapper;

        private readonly IPartnerRepository _partnerRepo;
        private readonly IMerchantRepository _merchantRepo;
        private readonly ITransactionRepository _transactionRepo;

        public ExportService(IMapper mapper, IPartnerRepository partnerRepo, IMerchantRepository merchantRepo, ITransactionRepository transactionRepo)
        {
            _mapper = mapper;

            _partnerRepo = partnerRepo;
            _merchantRepo = merchantRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<string> ExportPartnersCsvAsync()
        {
            var partners = await _partnerRepo.GetAllAsync();
            var exportDtos = _mapper.Map<List<PartnerExportDto>>(partners);


            return CsvExporter.ExportToCsv(exportDtos);
        }

        public async Task<string> ExportMerchantsCsvAsync()
        {
            var merchants = await _merchantRepo.GetAllAsync();
            var exportDtos = _mapper.Map<List<MerchantExportDto>>(merchants);


            return CsvExporter.ExportToCsv(exportDtos);
        }

        public async Task<string> ExportTransactionsCsvAsync()
        {
            var transactions = await _transactionRepo.GetAllAsync();
            var exportDtos = _mapper.Map<List<TransactionExportDto>>(transactions);

            return CsvExporter.ExportToCsv(exportDtos);
        }
    }
}
