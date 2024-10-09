using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreenGarden.Models
{
    public class TopCrop
    {
        [Key]
        public int CropId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
