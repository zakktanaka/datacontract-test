using System;
using System.Collections.Generic;
using System.Text;

namespace DataContractTest.DataLoader.Test
{
    static class TradeGenerator
    {
        public static Trade NewSwap()
        {
            return new Trade
            {
                Code = "trade",
                Legs = new List<Leg>
                {
                    new Leg
                    {
                        No = 1,
                        PayReceive =PayReceiveType.RECEIVE,
                        Cashflows = new List<CouponCashflow>
                        {
                            new FloatingCouponCashflow
                            {
                                No          =1,
                                Currency    = "JPY",
                                PaymentDate = new DateTime(2019,1,25),
                                StartDate   = new DateTime(2018,7,25),
                                EndDate     = new DateTime(2019,1,25),
                                FixingDate  = new DateTime(2018,7,23),
                                DayCount    = DayCountType.DC_ACT_360,
                                Leverage    = 1,
                                SpreadRate  = 0,
                                Index       = new CashRateIndex{Currency = "JPY", Code = "LIBOR6M", },
                                NotionalAmount  = 1_000_000,
                                FixedIndexRate  = 0.001,
                                FixedCouponRate = 0.001,
                                PaymentAmount   = new decimal(0.001 * 1_000_000 * new DateTime(2019,1,25).Subtract(new DateTime(2018,7,25)).Days/360),
                            },
                            new FloatingCouponCashflow
                            {
                                No          =2,
                                Currency    = "JPY",
                                PaymentDate = new DateTime(2019,7,25),
                                StartDate   = new DateTime(2019,1,25),
                                EndDate     = new DateTime(2019,7,25),
                                FixingDate  = new DateTime(2018,1,23),
                                DayCount    = DayCountType.DC_ACT_360,
                                Leverage    = 1,
                                SpreadRate  = 0,
                                Index       = new CashRateIndex{Currency = "JPY", Code = "LIBOR6M", },
                                NotionalAmount  = 1_000_000,
                                PayoffOptions = new Dictionary<string, double>
                                {
                                    {"optionalrate", 0.0008 },
                                },
                            },
                        },
                    },
                    new Leg
                    {
                        No = 2,
                        PayReceive =PayReceiveType.PAY,
                        Cashflows = new List<CouponCashflow>
                        {
                            new FixedCouponCashflow
                            {
                                No          =1,
                                Currency    = "JPY",
                                PaymentDate = new DateTime(2019,1,25),
                                StartDate   = new DateTime(2018,7,25),
                                EndDate     = new DateTime(2019,1,25),
                                DayCount    = DayCountType.DC_ACT_360,
                                NotionalAmount  = 1_000_000,
                                FixedRate   = 0.001,
                                PaymentAmount   = new decimal(0.001 * 1_000_000 * new DateTime(2019,1,25).Subtract(new DateTime(2018,7,25)).Days/360),
                            },
                            new FixedCouponCashflow
                            {
                                No          =2,
                                Currency    = "JPY",
                                PaymentDate = new DateTime(2019,7,25),
                                StartDate   = new DateTime(2019,1,25),
                                EndDate     = new DateTime(2019,7,25),
                                DayCount    = DayCountType.DC_ACT_360,
                                NotionalAmount  = 1_000_000,
                                FixedRate   = 0.001,
                                PaymentAmount   = new decimal(0.001 * 1_000_000 * new DateTime(2019,7,25).Subtract(new DateTime(2018,1,25)).Days/360),
                                PayoffOptions = new Dictionary<string, double>
                                {
                                    {"optionalrate", 0.0008 },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
}
