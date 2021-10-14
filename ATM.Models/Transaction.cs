﻿using ATM.Models.Enums;
using System;

namespace ATM.Models
{
    [Serializable]
    public class Transaction
    {
        public string Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
    }
}
