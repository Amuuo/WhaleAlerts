using System;
using System.Collections.Generic;
using System.Text;

namespace WhaleAlertsLibrary.Models
{
    public class TransactionList
    {
        public string? Result { get; set; }
        public string? Cursor { get; set; }
        public int? Count { get; set; }

        public List<WhaleTransaction> Transactions { get; set; }
    }
}
