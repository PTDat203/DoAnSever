namespace DoAnSever.Dto.Order
{
    public class OrderDto
    {
        public int IdOrder { get; set; }
        
        public int IdUser { get; set; }
        public string ShippingAddress { get; set; }
        public int IdPayment { get; set; }
        public float TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }

    }
}
