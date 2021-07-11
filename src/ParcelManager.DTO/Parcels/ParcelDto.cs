using ParcelManager.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelManager.DTO.Parcels
{
    public class ParcelDto : BaseDto
    {
        public string ParcelNumber { get; set; } = default!;
        public string RecipientName { get; set; } = default!;
        public string DestionationCountry { get; set; } = default!;
        public float Weight { get; set; } = default!;
        public float Price { get; set; } = default!;
    }
}
