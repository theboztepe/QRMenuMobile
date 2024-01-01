namespace QRMenuMobile.Models
{
    public class QrMenuTree
    {
        public Data Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class Data
    {
        public List<Root> Root { get; set; }
    }

    public class Root
    {
        public List<Product> Products { get; set; }
        public List<Root> SubCategories { get; set; }
        public int Id { get; set; }
        public int TopCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Currency { get; set; }
        public string Image { get; set; }
    }
}
