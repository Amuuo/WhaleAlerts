using System;
using System.Collections.Generic;
using System.Text;

namespace WhaleAlertsLibrary.Models
{
    public class Wallet
    {
        public string Address { get; set; }
        public string? Owner { get; set; }
        public string? Owner_Type { get; set; }
    }
}
