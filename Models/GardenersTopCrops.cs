using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GreenGarden.Models
{
    public class GardenersTopCrops
    {
        public int ID { get; set; }
        public int CropId { get; set; }
        public TopCrop? TopCrop { get; set; }
        public int GardenersID { get; set; }
        public Gardeners? Gardeners { get; set; }
    }
}
