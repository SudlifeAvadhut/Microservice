namespace Product.ApiLayer.BusinessModel
{
    public class ClsProductBM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
