namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];
        }

        public void AddItem (Cheese cheese, int quantity)
        {
            //add cheese or increase quantity
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item == null) 
            {
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
            //alert the listeners to the cart page
            OnCartUpdated?.Invoke();
        }

        public IEnumerable<CartItem> GetItems ()
        {
            //copy of items in cart
            return _items;
        }
        public int GetQuantity(Cheese cheese) 
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
        }

        public IEnumerable<CartItem> GetItem()
        {
            //return a copy of the items in the cart
            return _items;
        }

    }
}
