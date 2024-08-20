using System;
namespace MCCMA
{
    /// <summary>
    /// This is a child class inherited from Transaction classs
    /// </summary>
    public class Income : Transaction
    {
        /// <summary>
        /// _receiveacc is private field variable
        /// transmanagement is to link methods from the other class
        /// IncomeID is to set a public value for the variable
        /// </summary>
        public static TransactionManagement transmanagement = new TransactionManagement();
        private string _receiveacc;
        public static int IncomeID = 1;

        /// <summary>
        /// The constructor is set default
        /// </summary>
        public Income()
        {
        }

        /// <summary>
        /// The Income constructor pass the value of 7 parameters where 6 of them are inherited from Accounts class
        /// </summary>
        public Income(int transid, string transtype, string receiveacc, string transname, string transdate, string transmonth, double transamount) : base(transid, transtype, transname, transdate, transmonth, transamount)
        {
            TransID = transid;
            TransType = transtype;
            _receiveacc = receiveacc;
            TransName = transname;
            TransDate = transdate;
            TransMonth = transmonth;
            TransAmount = transamount;
        }

        /// <summary>
        /// The property set private value of ReceiveAcc to public.
        /// </summary>
        public string ReceiveAcc
        {
            get { return _receiveacc; }
            set { _receiveacc = value; }
        }

        /// <summary>
        /// It override the CreateTransaction() method in the parent class
        /// </summary>
        public override void CreateTransaction()
        {
            Console.WriteLine("Please fill your Income Details.");
            Console.WriteLine("=======================================");
            TransType = ("Income");
            Console.WriteLine("My Account: ");
            ReceiveAcc = Console.ReadLine();
            Console.WriteLine("Name for Income: ");
            TransName = Console.ReadLine();
            Console.WriteLine("Income Received Date: ");
            TransDate = Console.ReadLine();
            Console.WriteLine("Income Received Month: ");
            TransMonth = Console.ReadLine();
            Console.WriteLine("Amount of Income: ");
            TransAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("=======================================");
            Console.WriteLine("Income Received");
        }

        /// <summary>
        /// It override the ViewTransaction() method in the parent class
        /// </summary>
        public override void ViewTransaction()
        {
            Console.WriteLine("\nTransaction ID: " + TransID);
            Console.WriteLine("Transaction Type: " + TransType);
            Console.WriteLine("My Account: " + ReceiveAcc);
            Console.WriteLine("Name for Income: " + TransName);
            Console.WriteLine("Income Received Date: " + TransDate);
            Console.WriteLine("Income Received  Month: " + TransMonth);
            Console.WriteLine("Amount of Income: " + TransAmount);
        }

        /// <summary>
        /// The is a void method that navigates user within income functions.
        /// </summary>
        public void IncomeNav()
        {
            while (true)
            {
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*              Income                *|");
                Console.WriteLine("|*   Please select a function below   *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*  1.Create Income                   *|");
                Console.WriteLine("|*  2.Delete Income                   *|");
                Console.WriteLine("|*  3.Edit Income                     *|");
                Console.WriteLine("|*  4.Print Daily Income              *|");
                Console.WriteLine("|*  5.Print Monthly Income            *|");
                Console.WriteLine("|*  6.Back to Transaction Management  *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("");
                Console.Write("Function Number: ");
                string incomefunc = Console.ReadLine();
                Console.WriteLine("");

                if (incomefunc == "1")
                {
                    Income i = new Income();
                    i.CreateTransaction();
                    transmanagement.AddTransaction(i);

                    i.TransID = IncomeID;
                    IncomeID += 1;

                    Console.WriteLine("Numbers of Income Added: " + transmanagement.CountTransactionList);
                    IncomeNav();
                }
                else if (incomefunc == "2")
                {
                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        tr.ViewTransaction();
                    }
                    Console.Write("\nEnter Transaction ID that need to remove: ");
                    var ichoices = int.Parse(Console.ReadLine());

                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        if (ichoices == tr.TransID)
                        {
                            transmanagement.RemoveTransaction(tr);
                            Console.WriteLine("Income " + tr.TransID + " is removed.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Transaction ID is invalid.");
                        }
                    }
                    IncomeNav();
                }
                else if (incomefunc == "3")
                {
                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        tr.ViewTransaction();
                    }
                    Console.Write("\nEnter Transaction ID that need to edit: ");
                    var ichoices1 = int.Parse(Console.ReadLine());

                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        if (ichoices1 == tr.TransID)
                        {
                            transmanagement.EditTransaction();
                            Console.WriteLine("Successfully edited!");
                            IncomeNav();
                        }
                        else
                        {
                            Console.WriteLine("\nIncome not found");
                            IncomeNav();
                        }
                    }
                }
                else if (incomefunc == "4")
                {
                    if (transmanagement.CountTransactionList == 0)
                    {
                        Console.WriteLine("\nThere is no Income received");
                        IncomeNav();
                    }
                    else
                    {
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nDaily Format View");
                        Console.WriteLine("=====================");
                        foreach (Transaction tr in transmanagement.TransactionList)
                        {
                            if (tr is Income)
                            {
                                tr.ViewTransaction();
                            }
                        }
                        IncomeNav();
                    }
                }
                else if (incomefunc == "5")
                {
                    if (transmanagement.CountTransactionList == 0)
                    {
                        Console.WriteLine("\nThere is no Income received");
                        IncomeNav();
                    }
                    else
                    {
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nMonthly Format View");
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nEnter Month to Search");
                        Console.Write("Month: ");
                        string month = Console.ReadLine();
                        Console.WriteLine("This is income history of " + month + " month");
                        foreach (Transaction tr in transmanagement.TransactionList)
                        {
                            if (month == tr.TransMonth)
                            {
                                if (tr is Income)
                                {
                                    tr.ViewTransaction();
                                }
                            }
                        }
                        IncomeNav();
                    }
                }
                else if (incomefunc == "6")
                {
                    Console.WriteLine(transmanagement.TransactionNav());
                }
                else
                {
                    Console.WriteLine("Please enter valid function number.");
                    IncomeNav();
                }
            }
        }
    }
}
