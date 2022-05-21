using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TringleApi.Api.Data.Entities;
using TringleApi.Api.DTOs.TransactionHistory;

namespace TringleApi.Api.Mapper
{
    public class TransactionHistoryMapperProfile:Profile
    {
        public TransactionHistoryMapperProfile()
        {
            CreateMap<Account, TransactionHistoryResponse>()
                 .ReverseMap()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
