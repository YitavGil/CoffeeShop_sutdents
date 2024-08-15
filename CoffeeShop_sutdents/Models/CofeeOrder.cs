namespace CoffeeShop_sutdents.Models
{
    public class CoffeeOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CoffeeType { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
