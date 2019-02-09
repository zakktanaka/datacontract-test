using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContractTest.DataLoader.Test
{
    public enum PayReceiveType { PAY, RECEIVE }
    public enum DayCountType { DC_ACT_365, DC_ACT_360 }

    [DataContract]
    public class Trade
    {
        [DataMember(Name = "trade_code", IsRequired = true)]
        public string Code { get; set; }
        [DataMember(Name = "legs")]
        public List<Leg> Legs { get; set; }
    }

    [DataContract]
    public class Leg
    {
        [DataMember(Name = "leg_no", IsRequired = true)]
        public int No { get; set; }
        [DataMember(Name = "pay_rec", IsRequired = true)]
        public PayReceiveType PayReceive { get; set; }
        [DataMember(Name = "cashflows", IsRequired = true)]
        public List<CouponCashflow> Cashflows { get; set; }
    }

    [DataContract]
    public class CouponCashflow
    {
        [DataMember(Name = "no", IsRequired = true)]
        public uint No { get; set; }
        [DataMember(Name = "currency", IsRequired = true)]
        public string Currency { get; set; }
        [DataMember(Name = "paymentdate", IsRequired = true)]
        public DateTime PaymentDate { get; set; }
        [DataMember(Name = "startdate", IsRequired = true)]
        public DateTime StartDate { get; set; }
        [DataMember(Name = "enddate", IsRequired = true)]
        public DateTime EndDate { get; set; }
        [DataMember(Name = "daycount", IsRequired = true)]
        public DayCountType DayCount { get; set; }
        [DataMember(Name = "notionalamount", IsRequired = true)]
        public decimal NotionalAmount { get; set; }
        [DataMember(Name = "payoffoptions")]
        public Dictionary<string, double> PayoffOptions { get; set; }
    }

    [DataContract(Name = nameof(CouponCashflow))]
    public class FixedCouponCashflow : CouponCashflow
    {
        [DataMember(Name = "fixedrate", IsRequired = true)]
        public double FixedRate { get; set; }
        [DataMember(Name = "paymentamount", IsRequired = true)]
        public decimal PaymentAmount { get; set; }
    }

    [DataContract(Name = nameof(CouponCashflow))]
    public class FloatingCouponCashflow : CouponCashflow
    {
        [DataMember(Name = "fixingdate", IsRequired = true)]
        public DateTime FixingDate { get; set; }
        [DataMember(Name = "index", IsRequired = true)]
        public CashRateIndex Index { get; set; }
        [DataMember(Name = "leverage", IsRequired = true)]
        public double Leverage { get; set; }
        [DataMember(Name = "spread", IsRequired = true)]
        public double SpreadRate { get; set; }
        [DataMember(Name = "fixedindexrate")]
        public double? FixedIndexRate { get; set; }
        [DataMember(Name = "fixedcouponrate")]
        public double? FixedCouponRate { get; set; }
        [DataMember(Name = "paymentamount")]
        public decimal? PaymentAmount { get; set; }
    }

    [DataContract]
    public struct CashRateIndex
    {
        [DataMember(Name = "code", IsRequired = true)]
        public string Code { get; set; }
        [DataMember(Name = "currency", IsRequired = true)]
        public string Currency { get; set; }

        public override string ToString()
        {
            return Code;
        }

        public override bool Equals(object obj)
        {
            var other = obj as CashRateIndex?;
            return other == null ? false : Code.Equals(other?.Code) && Currency.Equals(other?.Currency) ;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
