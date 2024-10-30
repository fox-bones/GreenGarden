using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreenGarden.Models
{
    public class TopCrop
    {
        public ICollection<GardenersTopCrops> Gardeners { get; set; } = new List<GardenersTopCrops>();
        [Key]
        public int CropId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
