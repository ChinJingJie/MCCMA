using System;
namespace MCCMA
{
    /// <summary>
    /// This is a parent class that set to be abstract
    /// </summary>
    public abstract class Transaction
    {
        /// <summary>
        /// _transid,_transtype,_transname,_transdate,_transmonth and _transamount are private field variable
        /// </summary>
        private int _transid;
        private string _transtype;
        private string _transname;
        private string _transdate;
        private string _transmonth;
        private double _transamount;

        /// <summary>
        /// The constructor is set default
        /// </summary>
        public Transaction()
        {
        }

        /// <summary>
        /// The Accounts constructor pass 6 value thru parameter
        /// </summary>
        public Transaction(int transid, string transtype, string transname, string transdate, string transmonth, double transamount)
        {
            _transid = transid;
            _transtype = transtype;
            _transname = transname;
            _transdate = transdate;
            _transmonth = transmonth;
            _transamount = transamount;
        }

        /// <summary>
        /// The property set private value of TransID to public.
        /// </summary>
        public int TransID
        {
            get { return _transid; }
            set { _transid = value; }
        }

        /// <summary>
        /// The property set private value of TransType to public.
        /// </summary>
        public string TransType
        {
            get { return _transtype; }
            set { _transtype = value; }
        }

        /// <summary>
        /// The property set private value of TransName to public.
        /// </summary>
        public string TransName
        {
            get { return _transname; }
            set { _transname = value; }
        }

        /// <summary>
        /// The property set private value of TransDate to public.
        /// </summary>
        public string TransDate
        {
            get { return _transdate; }
            set { _transdate = value; }
        }

        /// <summary>
        /// The property set private value of TransMonth to public.
        /// </summary>
        public string TransMonth
        {
            get { return _transmonth; }
            set { _transmonth = value; }
        }

        /// <summary>
        /// The property set private value of TransAmount to public.
        /// </summary>
        public double TransAmount
        {
            get { return _transamount; }
            set { _transamount = value; }
        }

        /// <summary>
        /// abstract method are use to reduce redundent code for more flecibility
        /// CreateTransaction()is use to prompt account value from user
        /// ViewTransaction() is use to print the value prompted
        /// </summary>
        public abstract void CreateTransaction();
        public abstract void ViewTransaction();
    }
}
