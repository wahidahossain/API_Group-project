using System;
using System.Collections.Generic;

namespace SIMAppBackendAPI.Models
{
    public partial class UserTab
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
