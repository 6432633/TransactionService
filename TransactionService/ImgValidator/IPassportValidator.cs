namespace TransactionService.ImgValidator
{
    public interface IPassportValidator
    {
        bool IsRealPassport();
        string GetCustomerNameFromPassport();
        string GetIDNOFromPassport();
    }
}
