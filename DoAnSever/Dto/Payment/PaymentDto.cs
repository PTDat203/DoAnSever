namespace DoAnSever.Dto.Payment
{
    public class PaymentDto
    {
        public int IdPayment { get; set; }
        public int IdUser { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
    }
}
