using System;
using System.Collections.Generic;

namespace SIMAppBackendAPI.Models
{
    public partial class StorageInfo
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? NumberOfStorage { get; set; }
        public string? StartMonth { get; set; }
        public string? EndMonth { get; set; }
        public double? TotalCost { get; set; }
        public byte[] CreateDate { get; set; } = null!;
    }
}
