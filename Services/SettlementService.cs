using System;
using System.Collections.Generic;
using System.Linq;
using TradeSettlementManager.Data;
using TradeSettlementManager.Models;

namespace TradeSettlementManager.Services
{
    public class SettlementService
    {
        private readonly SettlementRepository _repo;

        public SettlementService()
        {
            _repo = new SettlementRepository();
        }

        public List<Settlement> GetAllSettlements()
        {
            return _repo.GetAll();
        }

        public List<Settlement> GetPendingSettlements()
        {
            return _repo.GetAllPending();
        }

        public void CreateSettlement(string tradeRef, string counterparty,
                                     decimal amount, string currency,
                                     DateTime settlementDate)
        {
            if (string.IsNullOrWhiteSpace(tradeRef))
                throw new ArgumentException("Trade reference is required.");

            if (string.IsNullOrWhiteSpace(counterparty))
                throw new ArgumentException("Counterparty is required.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (currency.Length != 3)
                throw new ArgumentException("Currency must be a 3-letter code.");

            var settlement = new Settlement
            {
                TradeRef = tradeRef.Trim().ToUpper(),
                Counterparty = counterparty.Trim(),
                Amount = amount,
                Currency = currency.Trim().ToUpper(),
                SettlementDate = settlementDate,
                Status = "PENDING"
            };

            _repo.Insert(settlement);
        }

        public void ResolveSettlement(int settlementId, string newStatus)
        {
            if (newStatus != "RESOLVED" && newStatus != "FAILED")
                throw new ArgumentException("Status must be RESOLVED or FAILED.");

            _repo.Resolve(settlementId, newStatus);
        }

        public int RunBatchProcess()
        {
            var pending = _repo.GetAllPending();
            int count = 0;

            string[] approvedCurrencies = { "GBP", "USD", "EUR", "JPY",
                                            "CHF", "AUD", "CAD", "HKD",
                                            "SGD", "NOK" };

            foreach (var s in pending)
            {
                string newStatus;

                // Rule 1: Amount exceeds limit
                if (s.Amount > 5000000)
                {
                    newStatus = "FAILED";
                }
                // Rule 2: Unsupported currency
                else if (!approvedCurrencies.Contains(s.Currency))
                {
                    newStatus = "FAILED";
                }
                // Rule 3: Settlement date in the past
                else if (s.SettlementDate.Date < DateTime.Today)
                {
                    newStatus = "FAILED";
                }
                // Rule 4: All checks pass
                else
                {
                    newStatus = "RESOLVED";
                }

                _repo.Resolve(s.SettlementId, newStatus);
                count++;
            }
            return count;
        }
    }
}