using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TradeSettlementManager.Models;

namespace TradeSettlementManager.Data
{
    public class SettlementRepository
    {
        public List<Settlement> GetAllPending()
        {
            var list = new List<Settlement>();
            DataTable dt = DbHelper.ExecuteQuery(
                "SELECT * FROM SETTLEMENTS WHERE STATUS = 'PENDING'");
            foreach (DataRow row in dt.Rows)
                list.Add(MapRow(row));
            return list;
        }

        public List<Settlement> GetAll()
        {
            var list = new List<Settlement>();
            DataTable dt = DbHelper.ExecuteQuery("SELECT * FROM SETTLEMENTS");
            foreach (DataRow row in dt.Rows)
                list.Add(MapRow(row));
            return list;
        }

        public void Insert(Settlement s)
        {
            string query = @"INSERT INTO SETTLEMENTS 
                (TRADE_REF, COUNTERPARTY, AMOUNT, CURRENCY, SETTLEMENT_DATE, STATUS)
                VALUES (@TradeRef, @Counterparty, @Amount, @Currency, @Date, 'PENDING')";

            SqlParameter[] parameters = {
                new SqlParameter("@TradeRef",     s.TradeRef),
                new SqlParameter("@Counterparty", s.Counterparty),
                new SqlParameter("@Amount",       s.Amount),
                new SqlParameter("@Currency",     s.Currency),
                new SqlParameter("@Date",         s.SettlementDate)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        public void Resolve(int settlementId, string newStatus)
        {
            string query = @"UPDATE SETTLEMENTS 
                             SET STATUS = @Status, 
                                 RESOLVED_AT = GETDATE() 
                             WHERE SETTLEMENT_ID = @Id";

            SqlParameter[] parameters = {
                new SqlParameter("@Status", newStatus),
                new SqlParameter("@Id",     settlementId)
            };
            DbHelper.ExecuteNonQuery(query, parameters);
        }

        private Settlement MapRow(DataRow row)
        {
            return new Settlement
            {
                SettlementId = Convert.ToInt32(row["SETTLEMENT_ID"]),
                TradeRef = row["TRADE_REF"].ToString(),
                Counterparty = row["COUNTERPARTY"].ToString(),
                Amount = Convert.ToDecimal(row["AMOUNT"]),
                Currency = row["CURRENCY"].ToString(),
                SettlementDate = Convert.ToDateTime(row["SETTLEMENT_DATE"]),
                Status = row["STATUS"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CREATED_AT"]),
                ResolvedAt = row["RESOLVED_AT"] == DBNull.Value
                                  ? (DateTime?)null
                                  : Convert.ToDateTime(row["RESOLVED_AT"])
            };
        }
    }
}