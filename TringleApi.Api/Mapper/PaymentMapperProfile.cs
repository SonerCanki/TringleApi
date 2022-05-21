using AutoMapper;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.Payment;

namespace TringleApi.Api.Mapper
{
    public class PaymentMapperProfile : Profile
    {
        public PaymentMapperProfile()
        {
            CreateMap<Payment, PaymentRequest>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Payment, PaymentResponse>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
