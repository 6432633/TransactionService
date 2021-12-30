using AutoMapper;
using TransactionService.Dto;
using TransactionService.Models;

namespace TransactionService.Profiles
{
    public class TransactionProfile :Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionReadDto>();
            CreateMap<TransactionCreateDto, Transaction>();
        }
    }
}
