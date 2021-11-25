using System;
using System.Collections.Generic;

namespace SIMAppBackendAPI.Models
{
    public partial class StorageInfo
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? ClientType { get; set; }
        public string? Location { get; set; }
        public string? UnitNo { get; set; }
        public string? Description { get; set; }
        public string? StorageType { get; set; }
        public double? TotalCost { get; set; }
        public string? Status { get; set; }
        public string? Date { get; set; }
    }
}
