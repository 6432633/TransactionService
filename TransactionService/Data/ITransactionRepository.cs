using TransactionService.Models;

namespace TransactionService.Data
{
    public interface ITransactionRepository
    {
        bool SaveChanges();
        IEnumerable<Transaction> GetTransactions(string api_key);
        Transaction GetTransactionByIdForSpecificCustomer(string api_key,string Id);
        Transaction GetTransactionById(string id);
        void CreateTransaction(Transaction transaction);
        void DeleteTransaction(Transaction transaction);
    }
}
