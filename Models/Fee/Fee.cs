using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAPI.Models.Fee
{
    public class Fee
    {
        public string sNo { get; set; }
        public string classCurrent { get; set; }
        public string PaySlipNo { get; set; }
        public string Session { get; set; }
        public string Date { get; set; }
        public string TermFor { get; set; }
        public string Discount { get; set; }
        public string PaymentMode { get; set; }
        public string NetFee { get; set; }
        public string Fine { get; set; }
        public string Comment { get; set; }
        public string MiscFee { get; set; }
        public string TCFee { get; set; }
        public string AdmissionFee { get; set; }
        public string TuitionFee { get; set; }
        public string CautionFee { get; set; }
        public string AnnualFee { get; set; }
    }

    public class Installments
    {
        public string FeeName { get; set; }
        public string Term { get; set; }
        public string ForNewStudent { get; set; }
        public string ForOldStudent { get; set; }
    }
}