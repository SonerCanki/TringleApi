using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.Withdraw;

namespace TringleApi.Api.Mapper
{
    public class WithdrawMapperProfile:Profile
    {
        public WithdrawMapperProfile()
        {
            CreateMap<Withdraw, WithdrawRequest>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Withdraw, WithdrawResponse>()
                .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
