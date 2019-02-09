using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContractTest.DataLoader.Test
{
    enum PayReceiveType { PAY, RECEIVE }
    enum CashflowType { FIXED_COUPON, FLOATING_COUPON }

    [DataContract]
    class Trade
    {
        [DataMember(Name = "trade_code", IsRequired = true)]
        public string Code { get; set; }
        [DataMember(Name = "legs")]
        public List<Leg> Legs { get; set; }
    }

    [DataContract]
    class Leg
    {
        [DataMember(Name = "leg_no", IsRequired = true)]
        public int No { get; set; }
        [DataMember(Name = "pay_rec", IsRequired = true)]
        public PayReceiveType PayReceive { get; set; }
        [DataMember(Name = "cashflows", IsRequired = true)]
        public List<Cashflow> Cashflows { get; set; }
    }

    [DataContract]
    class Cashflow
    {
        [DataMember(Name = "no", IsRequired = true)]
        public uint No { get; set; }
        [DataMember(Name = "type", IsRequired =true)]
        public CashflowType Type { get; set; }
        [DataMember(Name = "paymentdate", IsRequired = true)]
        public DateTime PaymentDate { get; set; }
        [DataMember(Name = "notionalamount", IsRequired = true)]
        public decimal NotionalAmount { get; set; }
        [DataMember(Name = "fixingdate")]
        public DateTime? FixingDate { get; set; }
        [DataMember(Name = "fixedcouponrate")]
        public double? FixedCouponRate { get; set; }
        [DataMember(Name = "PaymentAmount")]
        public decimal? PaymentAmount { get; set; }
        [DataMember(Name = "payoffoptions")]
        public Dictionary<string, double> PayoffOptions { get; set; }
    }
}
