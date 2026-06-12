# Trade Settlement Manager
### Built from scratch. No tutorial. No template. Just curiosity about how banks actually work.

---

> *"I wanted to understand what happens in the milliseconds between a trade being executed 
> and money changing hands across borders. So I built it."*

---

## The Story Behind This Project

Most developers learn to code by building to-do lists and weather apps.

I wanted to understand something real — how does an investment bank actually settle 
a foreign exchange trade? What happens when it fails? Who catches it? How?

So I spent weeks researching the FX trade lifecycle, and then built this — a complete 
settlement processing system that mirrors what operations teams inside banks deal with 
every single day.

This is not a university assignment. This is not a tutorial project.
This is what genuine curiosity looks like in code.

---

## What It Does

Pulls **real historical FX data** from the Alpha Vantage REST API across **9 G10 
currency pairs** — over **50,000 records** — validates every trade against real 
settlement rules, and reports each one as SETTLED, PENDING or FAILED with an 
exact reason why.


---

## The Tech Stack

| What | How |
|---|---|
| Market data ingestion | Python 3 + `requests` + `pyodbc` |
| Trade storage & validation | Microsoft SQL Server 2019 + T-SQL |
| Settlement dashboard | C# .NET + ADO.NET + Windows Forms |
| Live FX data source | Alpha Vantage REST API |

---

## How It Works — The Full Pipeline


---

## The 5 Ways a Trade Can Fail

Because in the real world, things go wrong. And the system needs to know exactly why.

| # | Failure Condition | What It Means |
|---|---|---|
| 1 | Counterparty Mismatch | The counterparty details don't match our records |
| 2 | Missing FX Rate | No valid rate exists for the settlement date |
| 3 | Invalid Amount | Trade amount is zero, negative or above threshold |
| 4 | Duplicate Trade Reference | The same trade was submitted twice |
| 5 | T+2 Breach | Settlement window of 2 business days has passed |

---

## The Currency Pairs

The same ones traded on the desks of the world's largest banks every day.


---

## What I'm Proud Of

**The DataQualityLog table.**

Most beginner projects crash on bad data or silently skip it.
Mine logs every gap — the date, the currency pair, the reason — so nothing 
is ever invisible. In financial systems, a silent failure is the most 
dangerous failure of all.

**The 22% query performance improvement.**

50,000 rows is not a small dataset. I added indexes on TradeDate and Status,
partitioned by currency pair, and benchmarked before and after.
The result was a 22% reduction in processing time.
Not because I had to. Because it was the right thing to do.

---

## Running It Yourself

### Python Pipeline
```bash
pip install requests pyodbc
python api_fetcher.py
```

### C# Dashboard
Open `TradeSettlementManager.slnx` in Visual Studio 2022 and run.

> ⚠️ You will need:
> - A free Alpha Vantage API key → [alphavantage.co](https://alphavantage.co)
> - Microsoft SQL Server 2019 (Express is free)
> - Update the connection string in `App.config`

---

## Project Structure


---

## What This Taught Me

That the gap between "writing code" and "building systems" is enormous.

Anyone can write a SELECT statement.
Fewer people think about what happens when the data is wrong.
Even fewer build something to catch it, log it, and report it.

That is what this project is about.

---

## About Me

**Tanmay Itape**  
MSc Data Science · Kingston University  
BSc Information Technology · First Class Honours

I build things to understand them.
This project is proof of that.

[LinkedIn](https://www.linkedin.com/in/tanmayitape/) · [GitHub](https://github.com/tanmayitape)

---

*Built in December 2025. Every line written with purpose.*
