namespace ClientOrders.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }

        protected double Price;
        public Product Product { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
            Price = product.Price;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }
    }
}
