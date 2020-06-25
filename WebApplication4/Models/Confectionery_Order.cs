namespace WebApplication4
{
    public class Confectionery_Order
    {
        public int idConfectionery { get; set; }

        public int idOrder { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

        public Confectionery confectionery { get; set; }

        public Order order { get; set; }
    }
}