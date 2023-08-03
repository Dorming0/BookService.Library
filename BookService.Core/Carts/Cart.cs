namespace BookService.Core.Carts
{
    public class Cart
    {
        private readonly CartSettings _settings = new CartSettings();
        private List<CartItem> catrItems = new List<CartItem>();
        public string Id { get;  }
        public decimal TotalPrice
        {
            get
            {
                return CartItems.Sum(x => x.TotalPrice);
            }
        }
        public int TotalCount 
        {
            get 
            {
                return CartItems.Sum(x => x.Count);
            }
        }
        

        public IEnumerable<CartItem> CartItems
        {
            get
            {
                foreach (var item in catrItems)
                {
                    yield return item;
                }
            }
            set
            {
                catrItems = value.ToList();
            }
            

        }
        public Cart() 
        {
            Id = Guid.NewGuid().ToString();
        }

        public void AddCartItem (CartItem item)
        {
            if (item == null)
              throw new ArgumentNullException("item");
            if (TotalCount + item.Count < _settings.MaxCartItemsCount)
            {
                var existItem = CartItems.FirstOrDefault(x => x.Id == item.Id);
                if (existItem == null)
                {
                    catrItems.Add(item);
                }
                else
                {
                    existItem.Append();
                }
            } 
        }
        public void RemuveItem(CartItem item)
        {
            var existItem = CartItems.FirstOrDefault(x=>x.Id == item.Id);
            if (existItem.Count > 1)
            {
                existItem.Distinct();
            }
            else
            {
                catrItems.Remove(existItem);
            }
        }
    }
}
