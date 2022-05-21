using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.Deposit;

namespace TringleApi.Api.Mapper
{
    public class DepositMapperProfile : Profile
    {
        public DepositMapperProfile()
        {
            CreateMap<Deposit, DepositRequest>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Deposit, DepositResponse>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
