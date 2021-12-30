using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Data;
using TransactionService.Dto;
using TransactionService.Models;

namespace TransactionService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionRepository repository, IMapper mapper)
        {
            transactionRepository = repository;
            _mapper = mapper;
        }
        [HttpGet("all")]
        public ActionResult<IEnumerable<TransactionReadDto>> GetTransactions([FromHeader] string api_key)
        {
            if (transactionRepository.GetTransactions(api_key) == null) { return Ok("There no any users"); }
            return Ok(transactionRepository.GetTransactions(api_key));
        }
        [HttpGet("{id}", Name = "GetTransactionById")]
        public ActionResult<TransactionReadDto> GetTransactionById([FromHeader] string api_key, string id)
        {
            if( transactionRepository.GetTransactionByIdForSpecificCustomer(api_key, id) == null) { return Ok("There is no any transaction with id" + id); }
            return Ok(transactionRepository.GetTransactionByIdForSpecificCustomer(api_key, id));
        }
        [HttpPost("create")]
        public ActionResult<TransactionReadDto> CreateTransaction(TransactionCreateDto transaction)
        {
            var transactionModel = _mapper.Map<Transaction>(transaction);
            transactionModel.CreatedAt = DateTime.UtcNow;
            transactionRepository.CreateTransaction(transactionModel);
            transactionRepository.SaveChanges();
            var transactionReadDto = _mapper.Map<TransactionReadDto>(transactionModel);
            return CreatedAtRoute(nameof(GetTransactionById), new { Id = transactionReadDto.Id, transactionReadDto});
        }
        [HttpDelete("{id}/delete")]
        public ActionResult DeleteTransactionById(string id)
        {
            if(transactionRepository.GetTransactionById(id) == null) { return NotFound(); }
            transactionRepository.DeleteTransaction(transactionRepository.GetTransactionById(id));
            transactionRepository.SaveChanges();
            return NoContent();
        }
    }
}
