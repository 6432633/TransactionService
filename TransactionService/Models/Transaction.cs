using System.ComponentModel.DataAnnotations;

namespace TransactionService.Models
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerIdNumber { get; set; }
        public string Api_Key { get; set; }
        public string FaceImg { get; set; }
        public string PassportImg { get; set; }
        public bool IsRealPerson { get; set; }
        public bool IsRealPassport { get; set; }
        public double ImgComparisonResult { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
