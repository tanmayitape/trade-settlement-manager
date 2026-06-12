using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeSettlementManager.Models
{
    public class Settlement
    {
        public int SettlementId { get; set; }
        public string TradeRef { get; set; }
        public string Counterparty { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime SettlementDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
