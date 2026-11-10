namespace API.Models;
public sealed class OrderItem
{
    private OrderItem() {  }
    public long OrderItemId { get; private set; }

    public long OrderId { get; private set; }
    public Order Order { get; private set; } = null!;
    public string ProductCode { get; private set; } = string.Empty;
    public Product Product { get; private set; } = null!;

    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal SubTotal { get; private set; }
    public OrderItem(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

        ProductCode = product.ProductCode;
        Product = product;
        Quantity = quantity;
        UnitPrice = product.Price;
    }

}