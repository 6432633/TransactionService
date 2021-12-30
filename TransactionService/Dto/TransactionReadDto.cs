namespace TransactionService.Dto
{
    public class TransactionReadDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerIdNumber { get; set; }
        public string Api_Key { get; set; }
        public string FaceImg { get; set; }
        public string PassportImg { get; set; }
        public bool isRealPerson { get; set; }
        public bool isRealPassport { get; set; }
        public double ImgComparisonResult { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
