using System;
namespace MCCMA
{
    /// <summary>
    /// This is a child class inherited from Transaction classs
    /// </summary>
    public class Expense: Transaction
    {
        /// <summary>
        /// _spendon is private field variable
        /// transmanagement and cardmanagement to link methods from the other class
        /// ExpenseID is to set a public value for the variable
        /// </summary>
        public static TransactionManagement transmanagement = new TransactionManagement();
        public static CardManagement cardmanagement = new CardManagement();
        public static CreditCard credit = new CreditCard();
        private string _spendon;
        public static int ExpenseID = 1;

        /// <summary>
        /// The constructor is set default
        /// </summary>
        public Expense():this(0,"","","","","",0,"",0,0,0)
        {
        }

        /// <summary>
        /// The Income constructor pass the value of 10 parameters where 6 of them are inherited from Accounts class
        /// </summary>
        public Expense(int transid, string transtype, string spendon, string transname, string transdate, string transmonth, double transamount, string cardno, double reward, int limit, double interest) : base(transid, transtype, transname, transdate, transmonth, transamount)
        {
            TransID = transid;
            TransType = transtype;
            _spendon = spendon;
            TransName = transname;
            TransDate = transdate;
            TransMonth = transmonth;
            TransAmount = transamount;
            credit.CardNo = cardno;
            credit.Reward = reward;
            credit.Limit = limit;
            credit.Interest = interest;
        }

        /// <summary>
        /// The property set private value of SpendOn to public.
        /// </summary>
        public string SpendOn
        {
            get { return _spendon; }
            set { _spendon = value; }
        }

        /// <summary>
        /// It override the CreateTransaction() method in the parent class
        /// </summary>
        public override void CreateTransaction()
        {
            Console.WriteLine("Please fill your Expense Details.");
            Console.WriteLine("=======================================");
            TransType = ("Expense");
            Console.WriteLine("Description of item Spend on: ");
            SpendOn = Console.ReadLine();
            Console.WriteLine("Name for Expense: ");
            TransName = Console.ReadLine();
            Console.WriteLine("Expense Date: ");
            TransDate = Console.ReadLine();
            Console.WriteLine("Expense Month: ");
            TransMonth = Console.ReadLine();
            Console.WriteLine("Amount of Expenses: ");
            TransAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("=======================================");
            Console.WriteLine("Expenses Spent");
        }

        /// <summary>
        /// It override the ViewTransaction() method in the parent class(to print details and card suggestion)
        /// </summary>
        public override void ViewTransaction()
        {
            Console.WriteLine("\nTransaction ID: " + TransID);
            Console.WriteLine("Transaction Type: " + TransType);
            Console.WriteLine("Description of item Spend on: " + SpendOn);
            Console.WriteLine("Name for Expense: " + TransName);
            Console.WriteLine("Expense Date: " + TransDate);
            Console.WriteLine("Expense Month: " + TransMonth);
            Console.WriteLine("Amount of Expenses: " + TransAmount);

            var rewards = (TransAmount * credit.Interest / 100);
            rewards = credit.Reward;
            Console.WriteLine("+++++++++++++++++");
            Console.WriteLine("Card Suggestion");
            Console.WriteLine("+++++++++++++++++");
            Console.WriteLine("Below is the card that suits this expenses the most.");
            Console.WriteLine("Credit Card No: " + credit.CardNo);
            Console.WriteLine("The max card usage is (RM): " + credit.Limit);
            Console.WriteLine("Its interest rate is (%): " + credit.Interest);
            Console.WriteLine("The reward is (points): " + credit.Reward);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++");
                            
        }

        /// <summary>
        /// The is a void method that navigates user within expense functions.
        /// </summary>
        public void ExpenseNav()
        {
            while (true)
            {
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*              Expense               *|");
                Console.WriteLine("|*   Please select a function below   *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*  1.Create Expense                  *|");
                Console.WriteLine("|*  2.Delete Expense                  *|");
                Console.WriteLine("|*  3.Edit Expense                    *|");
                Console.WriteLine("|*  4.Print Daily Expenses            *|");
                Console.WriteLine("|*  5.Print Monthly Expenses          *|");
                Console.WriteLine("|*  6.Back to Transaction Management  *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("");
                Console.Write("Function Number: ");
                string expensefunc = Console.ReadLine();
                Console.WriteLine("");

                if (expensefunc == "1")
                {
                    Expense e = new Expense();
                    e.CreateTransaction();
                    transmanagement.AddTransaction(e);

                    e.TransID = ExpenseID;
                    ExpenseID += 1;

                    Console.WriteLine("Numbers of Expense Added: " + transmanagement.CountTransactionList);
                    ExpenseNav();
                }
                else if (expensefunc == "2")
                {
                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        tr.ViewTransaction();
                    }
                    Console.Write("\nEnter Transaction ID that need to remove: ");
                    var echoices = int.Parse(Console.ReadLine());

                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        if (echoices == tr.TransID)
                        {
                            transmanagement.RemoveTransaction(tr);
                            Console.WriteLine("Expenses " + tr.TransID + " is removed.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Transaction ID is invalid.");
                        }
                    }
                    ExpenseNav();
                }
                else if (expensefunc == "3")
                {
                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        tr.ViewTransaction();
                    }
                    Console.Write("\nEnter Transaction ID that need to edit: ");
                    var echoices1 = int.Parse(Console.ReadLine());

                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        if (echoices1 == tr.TransID)
                        {
                            transmanagement.EditTransaction();
                            Console.WriteLine("Successfully edited!");
                            ExpenseNav();
                        }
                        else
                        {
                            Console.WriteLine("\nExpenses not found");
                            ExpenseNav();
                        }
                    }
                }
                else if (expensefunc == "4")
                {
                    if (transmanagement.CountTransactionList == 0)
                    {
                        Console.WriteLine("\nThere is no Expenses");
                        ExpenseNav();
                    }
                    else
                    {
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nDaily Format View");
                        Console.WriteLine("=====================");
                        foreach (Transaction tr in transmanagement.TransactionList)
                        {
                            if (tr is Expense)
                            {
                                tr.ViewTransaction();
                            }
                        }
                        ExpenseNav();
                    }
                }
                else if (expensefunc == "5")
                {
                    if (transmanagement.CountTransactionList == 0)
                    {
                        Console.WriteLine("\nThere is no Expenses");
                        ExpenseNav();
                    }
                    else
                    {
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nMonthly Format View");
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nEnter Month to Search");
                        Console.Write("Month: ");
                        string month = Console.ReadLine();
                        Console.WriteLine("This is expense history of " + month + " month");
                        foreach (Transaction tr in transmanagement.TransactionList)
                        {
                            if (month == tr.TransMonth)
                            {
                                if (tr is Expense)
                                {
                                    tr.ViewTransaction();
                                }
                            }
                        }
                        ExpenseNav();
                    }
                }
                else if (expensefunc == "6")
                {
                    Console.WriteLine(transmanagement.TransactionNav());
                }
                else
                {
                    Console.WriteLine("Please enter valid function number.");
                    ExpenseNav();
                }
            }
        }
    }
}
