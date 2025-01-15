namespace Basket.API.Models;

public class ShoppingCart
{
    public ShoppingCart(){}

    public ShoppingCart(string userName) //Modificar depois do Auth
    {
        UserName = userName;
    }

    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
}
