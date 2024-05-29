namespace DoAnSever.Dto.OrderDetail
{
    public class OrderDetailDto
    {
        public int IdOrderDetail {  get; set; }
        public int IdOrder {  get; set; }
        public int IdProduct { get; set; }
        public string Thumbnail { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public int Status { get; set; }

    }
}
