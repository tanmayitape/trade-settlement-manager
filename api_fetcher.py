import requests
import pyodbc
from datetime import datetime, timedelta
import random

API_KEY = "FRZQM3SSBY6F2IOS"

CONNECTION_STRING = (
    "DRIVER={ODBC Driver 17 for SQL Server};"
    "SERVER=(localdb)\\MSSQLLocalDB;"
    "DATABASE=SettlementDB;"
    "Trusted_Connection=yes;"
)

CURRENCY_PAIRS = [
    ("GBP", "USD"), ("EUR", "USD"), ("JPY", "USD"),
    ("CHF", "USD"), ("AUD", "USD"), ("CAD", "USD"),
    ("HKD", "USD"), ("SGD", "USD"), ("NOK", "USD")
]

COUNTERPARTIES = [
    "Deutsche Bank", "Goldman Sachs", "JP Morgan",
    "Barclays", "HSBC", "Citibank", "Morgan Stanley"
]

def fetch_fx_trades():
    trades = []
    for from_ccy, to_ccy in CURRENCY_PAIRS:
        url = (
            f"https://www.alphavantage.co/query"
            f"?function=FX_DAILY"
            f"&from_symbol={from_ccy}"
            f"&to_symbol={to_ccy}"
            f"&outputsize=full"
            f"&apikey={API_KEY}"
        )
        print(f"Calling API: FX_{from_ccy}_{to_ccy}...")
        response = requests.get(url, timeout=15)
        print(f"Response Status: {response.status_code}")
        data = response.json()

        time_series = data.get("Time Series FX (Daily)", {})
        print(f"Records returned: {len(time_series)} days of data")

        for date_str, values in list(time_series.items())[:500]:
            trade = {
                "TRADE_REF": f"FX-{from_ccy}{to_ccy}-{date_str.replace('-','')}",
                "COUNTERPARTY": random.choice(COUNTERPARTIES),
                "AMOUNT": round(float(values["4. close"]) * random.uniform(100000, 1000000), 2),
                "CURRENCY": from_ccy,
                "SETTLEMENT_DATE": (datetime.strptime(date_str, "%Y-%m-%d") + timedelta(days=2)).strftime("%Y-%m-%d"),
                "STATUS": "PENDING"
            }
            trades.append(trade)

    print(f"\nTotal trades generated from API: {len(trades)}")
    return trades

def insert_trades(trades):
    conn = pyodbc.connect(CONNECTION_STRING)
    cursor = conn.cursor()
    inserted = 0
    for trade in trades:
        cursor.execute("SELECT COUNT(*) FROM SETTLEMENTS WHERE TRADE_REF = ?", trade["TRADE_REF"])
        if cursor.fetchone()[0] == 0:
            cursor.execute("""
                INSERT INTO SETTLEMENTS (TRADE_REF, COUNTERPARTY, AMOUNT, CURRENCY, SETTLEMENT_DATE, STATUS, CREATED_AT)
                VALUES (?, ?, ?, ?, ?, ?, GETDATE())
            """, trade["TRADE_REF"], trade["COUNTERPARTY"], trade["AMOUNT"],
                trade["CURRENCY"], trade["SETTLEMENT_DATE"], trade["STATUS"])
            inserted += 1
    conn.commit()
    conn.close()
    print(f"Inserted {inserted} new records into SQL Server.")

if __name__ == "__main__":
    print("=" * 50)
    print("Trade Data Ingestion — Alpha Vantage FX API")
    print("=" * 50)
    trades = fetch_fx_trades()
    insert_trades(trades)
    print("Ingestion complete.")
    print("=" * 50)