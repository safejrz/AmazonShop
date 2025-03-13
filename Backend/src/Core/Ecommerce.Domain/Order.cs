using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using Ecommerce.Domain.Common;

namespace Ecommerce.Domain;

public class Order : BaseDomainModel
{
    public string? CompradorName { get; set; }
    public string? CompradorUsername { get; set; }
    public OrderAddress? OrderAddress { get; set; }
    public IReadOnlyList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    [Column(TypeName = "decimal(10,2)")]
    public decimal Subtotal { get; set; }
    public OrderStatus Status { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Impuesto { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecioEnvio { get; set; }
    public string? PaymentIntentId { get; set; }
    public string? ClientSecret { get; set; }
    public string? StripeApiKey { get; set; }


    public Order() { }
    public Order(
        string compradorName,
        string compradorEmail,
        OrderAddress orderAddress,
        decimal subtotal,
        decimal total,
        decimal impuesto,
        decimal precioEnvio
    )
    {
        CompradorName = compradorName;
        CompradorUsername = compradorEmail;
        OrderAddress = orderAddress;
        Subtotal = subtotal;
        Total = total;
        Impuesto = impuesto;
        PrecioEnvio = precioEnvio;

    }
}