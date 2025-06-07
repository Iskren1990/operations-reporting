using AutoMapper;
using OperationsReporting.Models.DTO;
using OperationsReporting.Models.Entities;
using OperationsReporting.Models.Enums;
using XmlModels = OperationsReporting.Models.XmlModels;

namespace OperationsReporting.Services.Mapping
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<XmlModels.Transaction, Transaction>()
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.TransactionType,
                    opt => opt.MapFrom(src =>
                        src.Amount.Direction == "D" ? TransactionType.Debit : TransactionType.Credit))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount.Value))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Amount.Currency))
                .ForMember(dest => dest.SenderIban, opt => opt.MapFrom(src => src.Debtor.IBAN))
                .ForMember(dest => dest.ReceiverIban, opt => opt.MapFrom(src => src.Beneficiary.IBAN))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status == 1 ? TransactionStatus.Completed : TransactionStatus.Failed))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MerchantId, opt => opt.Ignore())
                .ForMember(dest => dest.Merchant, opt => opt.Ignore());

            CreateMap<Transaction, TransactionExportDto>();
        }
    }
}
