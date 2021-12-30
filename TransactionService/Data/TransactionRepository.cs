using TransactionService.ImgValidator;
using TransactionService.Models;

namespace TransactionService.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        private TransactionContext TransactionContext { get; set; }
        private readonly ILivenessValidator LivenessValidator;
        private readonly IPassportValidator PassportValidator;
        private readonly IFaceValidator FaceValidator;
        public TransactionRepository(TransactionContext context,
                                     ILivenessValidator livenessValidator,
                                     IPassportValidator passportValidator,
                                     IFaceValidator faceValidator) 
        { TransactionContext = context;   }
        public void CreateTransaction(Transaction transaction)
        {
            if (transaction == null) { throw new ArgumentNullException(nameof(transaction)); }
            TransactionContext.Transactions.Add(transaction);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            TransactionContext.Transactions.Remove(transaction);
        }

        public Transaction GetTransactionById(string Id)
        {
            return TransactionContext.Transactions.FirstOrDefault(x => x.Id.ToString() == Id);
        }
        public Transaction GetTransactionByIdForSpecificCustomer(string api_key,string id) {
            return TransactionContext.Transactions.FirstOrDefault(x => x.Api_Key == api_key && x.Id.ToString() == id); }

        public IEnumerable<Transaction> GetTransactions(string api_key)
        {
            return (IEnumerable<Transaction>)TransactionContext.Transactions.Select(key => key.Api_Key == api_key).ToList();
        }

        public bool SaveChanges()
        {
            return TransactionContext.SaveChanges() >= 0;
        }
    }
}
