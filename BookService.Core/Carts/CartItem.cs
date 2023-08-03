using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookService.Core.Carts
{
    public class CartItem 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Count { get; private set; }
        public decimal Price { get; private set; }
        public decimal TotalPrice => Price * Count;

        public void Append()
        {
            Count++;
        }
        public void Distinct() 
        {
            Count--;
        }
        public CartItem() { }
        public CartItem(int id, string name, decimal price)
        {
            Id= id;
            Name= name;
            Price= price;
            Count = 1;
        }

    }
}
