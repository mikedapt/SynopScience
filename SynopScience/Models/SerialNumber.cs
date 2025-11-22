using System.ComponentModel.DataAnnotations.Schema;

namespace SynopScience.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? DataId { get; set; }
        [ForeignKey("DataId")]
        public Dataset? Data { get; set; }

    }
}
