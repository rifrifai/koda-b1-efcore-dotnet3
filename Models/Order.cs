namespace API.Models;
public class Order
{
    public long OrderId { get; private set; }
    public string OrderNumber { get; private set; }
    public DateTimeOffset OrderDate { get; private set; }
    public string Status { get; private set; }
    public ICollection<OrderItem> Items { get; private set; } = [];

    public Order(string orderNumber)
    {
        if(string.IsNullOrWhiteSpace(orderNumber) || orderNumber.Trim().Length > 35)
            throw new ArgumentException("Order Number wajib diisi (Maksimal 35 karakter).", nameof(orderNumber));

        OrderNumber = orderNumber.Trim().ToUpperInvariant();
        OrderDate = DateTimeOffset.UtcNow.AddHours(7);
        Status = "Pending";
    }

    public void AddItem(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        if (Status != "Pending") throw new InvalidOperationException("Order tidak bisa diubah setelah dikonfirmasi");
        if (Items.Any(i => i.ProductCode == product.ProductCode)) throw new ArgumentException("Product code tidak boleh berulang dalam satu order");

        Items.Add(new OrderItem(product, quantity));
    }
}