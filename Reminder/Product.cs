using Reminder;

namespace Reminder
{
    /// <summary>
    /// Summary description for ShoppingCart
    /// </summary>
    [Serializable]
    public class CartItem
    {
        private int _productID;
        private string _productName;
        private string _imageUrl;
        private int _quantity;


        public CartItem()
        {
        }
        public CartItem(int ProductID, string ProductName,
              string ImageUrl, int Quantity)
        {
            _productID = ProductID;
            _productName = ProductName;
            _imageUrl = ImageUrl;
            _quantity = Quantity;

        }
        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
        }
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


    }
}
[Serializable]
public class Cart
{
    private DateTime _dateCreated;
    private DateTime _lastUpdate;
    private List<CartItem> _items;

    public Cart()
    {
        if (this._items == null)
        {
            this._items = new List<CartItem>();
            this._dateCreated = DateTime.Now;
        }
    }

    public List<CartItem> Items
    {
        get { return _items; }
        set { _items = value; }
    }

    public void Insert(int ProductID,
    int Quantity, string ProductName, string ImageUrl)
    {
        int ItemIndex = ItemIndexOfID(ProductID);
        if (ItemIndex == -1)
        {
            CartItem NewItem = new CartItem();
            NewItem.ProductID = ProductID;
            NewItem.Quantity = Quantity;
            NewItem.ProductName = ProductName;
            NewItem.ImageUrl = ImageUrl;
            _items.Add(NewItem);
        }
        else
        {
            _items[ItemIndex].Quantity += 1;
        }
        _lastUpdate = DateTime.Now;
    }

    public void Update(int RowID, int ProductID,
                     int Quantity)
    {
        CartItem Item = _items[RowID];
        Item.ProductID = ProductID;
        Item.Quantity = Quantity;
        _lastUpdate = DateTime.Now;
    }

    public void DeleteItem(int rowID)
    {
        _items.RemoveAt(rowID);
        _lastUpdate = DateTime.Now;
    }

    private int ItemIndexOfID(int ProductID)
    {
        int index = 0;
        foreach (CartItem item in _items)
        {
            if (item.ProductID == ProductID)
            {
                return index;
            }
            index += 1;
        }
        return -1;
    }
}