using System;
using System.Collections.Generic;
using System.Text;

namespace WhaleAlertsLibrary.Models
{
    public class WhaleTransaction
    {
        public float Amount { get; set; }
        public float Amount_USD { get; set; }
        public string Blockchain { get; set; }
        public Wallet From { get; set; }
        public string Hash { get; set; }
        //public int Id { get; set; }
        public string Symbol { get; set; }
        public int Timestamp { get; set; }
        public Wallet To { get; set; }
        public int Transaction_Count { get; set; }
        public string Transaction_Type { get; set; }
    }
}
