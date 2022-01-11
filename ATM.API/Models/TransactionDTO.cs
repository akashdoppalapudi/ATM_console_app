﻿using ATM.Models.Enums;

namespace ATM.API.Models
{
    public class TransactionDTO
    {
        public string Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public string ToBankId { get; set; }
        public string ToAccountId { get; set; }
        public TransactionNarrative TransactionNarrative { get; set; }
        public decimal TransactionAmount { get; set; }
        public string BankId { get; set; }
        public string AccountId { get; set; }
    }
}
