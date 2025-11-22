namespace SynopScience.Models
{
    public class Dataset
    {
        public int Id { get; set; }
        public string ItemCode { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string? ItemDescription { get; set; }
        public string ItemType { get; set; } = null!;
        public int ItemCount { get; set; }
        public float ItemPrice { get; set; }
        public int ItemShelfLife { get; set; }
        public bool ItemActive { get; set; }

        //Connect to Serial Number class
        public int? SerialNumberId { get; set; }
        public SerialNumber? SerialNumber { get; set; }
    }
    // /dataset/overview   dataset will be the name of the controller and overview is the name of the view called by the controller
}
