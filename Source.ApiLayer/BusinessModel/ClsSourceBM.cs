namespace Source.ApiLayer.BusinessModel
{
    public class ClsSourceBM
    {
        public int SourceId { get; set; }
        public string SoruceName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
    }
}
