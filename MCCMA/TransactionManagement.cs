using System;
using System.Collections.Generic;
namespace MCCMA
{
    public class TransactionManagement
    {
        /// <summary>
        /// _transactionlist is private field variable that store a list of transactions
        /// others are to link methods from the other class
        /// </summary>
        public static MainMenu menu = new MainMenu();
        public static Transfer mytrans = new Transfer();
        public static Income mytrans1 = new Income();
        public static Expense mytrans2 = new Expense();
        private readonly List<Transaction> _transactionlist;

        /// <summary>
        /// The constructor is set default and initialize the _transactionlist.
        /// </summary>
        public TransactionManagement()
        {
            _transactionlist = new List<Transaction>();
        }

        /// <summary>
        /// The property set private value of TransactionList to public.It only has get because it is a readonly property.
        /// </summary>
        public List<Transaction> TransactionList
        {
            get { return _transactionlist; }
        }

        /// <summary>
        /// This is a method that use to add transaction into the Transaction List
        /// </summary>
        public void AddTransaction(Transaction tran)
        {
            _transactionlist.Add(tran);
        }

        /// <summary>
        /// This is a void method that can edit the details of existing transactions.
        /// </summary>
        public void EditTransaction()
        {
            foreach (Transaction t in _transactionlist)
            {
                if (t is Transfer && t != null)
                {
                    Console.Write("Transfer From Account: ");
                    var newWithrawAcc = Console.ReadLine();
                    ((Transfer)t).WithrawAcc = newWithrawAcc;

                    Console.Write("Transfer To Account: ");
                    var newReceiveAcc = Console.ReadLine();
                    ((Transfer)t).ReceiveAcc = newReceiveAcc;

                    Console.WriteLine("Transfer Date: ");
                    var newTransDate = Console.ReadLine();
                    ((Transfer)t).TransDate = newTransDate;

                    Console.WriteLine("Transfer Month: ");
                    var newTransMonth = Console.ReadLine();
                    ((Transfer)t).TransMonth = newTransMonth;

                    Console.Write("Transfer Name: ");
                    var newTransName = Console.ReadLine();
                    ((Transfer)t).TransName = newTransName;

                    Console.Write("Transfer Amount: ");
                    var newTransAmount = double.Parse(Console.ReadLine());
                    ((Transfer)t).TransAmount = newTransAmount;
                    break;
                }
                else if (t is Income && t != null)
                {
                    Console.Write("My Account: ");
                    var newiReceiveAcc = Console.ReadLine();
                    ((Income)t).ReceiveAcc = newiReceiveAcc;

                    Console.WriteLine("Income Received Date: ");
                    var newiTransDate = Console.ReadLine();
                    ((Income)t).TransDate = newiTransDate;

                    Console.WriteLine("Income Received Month: ");
                    var newiTransMonth = Console.ReadLine();
                    ((Income)t).TransMonth = newiTransMonth;

                    Console.Write("Name of Income: ");
                    var newiTransName = Console.ReadLine();
                    ((Income)t).TransName = newiTransName;

                    Console.Write("Amount of Income: ");
                    var newiTransAmount = double.Parse(Console.ReadLine());
                    ((Income)t).TransAmount = newiTransAmount;
                    break;
                }
                else if (t is Expense && t != null)
                {
                    Console.Write("Description of item Spend on: ");
                    var newSpendOn = Console.ReadLine();
                    ((Expense)t).SpendOn = newSpendOn;

                    Console.WriteLine("Expense Date: ");
                    var neweTransDate = Console.ReadLine();
                    ((Expense)t).TransDate = neweTransDate;

                    Console.WriteLine("Expense Month: ");
                    var neweTransMonth = Console.ReadLine();
                    ((Expense)t).TransMonth = neweTransMonth;

                    Console.Write("Name of Expense: ");
                    var neweTransName = Console.ReadLine();
                    ((Expense)t).TransName = neweTransName;

                    Console.Write("Amount of Expenses: ");
                    var neweTransAmount = double.Parse(Console.ReadLine());
                    ((Expense)t).TransAmount = neweTransAmount;
                    break;
                }
                else
                {
                    if (t is Transfer)
                    {
                        Console.WriteLine("No Transfer found");
                    }
                    else if (t is Income)
                    {
                        Console.WriteLine("No Income received");
                    }
                    else
                    {
                        Console.WriteLine("No Expenses spend");
                    }
                }
            }
        }

        /// <summary>
        /// This is a method that use to remove transaction into the Transaction List
        /// </summary>
        public void RemoveTransaction(Transaction tran)
        {
            _transactionlist.Remove(tran);
        }

        /// <summary>
        /// This is a property to count the number of rows in the Transaction List
        /// </summary>
        public int CountTransactionList
        {
            get { return _transactionlist.Count; }
        }

        /// <summary>
        /// This is an indexer that has the ability to access an Account at given index.
        /// </summary>
        public Transaction this[int t]
        {
            get { return _transactionlist[t]; }
        }

        /// <summary>
        /// The is a bool method that navigates user from user transaction management modules to its functions.
        /// </summary>
        public bool TransactionNav()
        {
            Console.WriteLine("|* ---------------------------------- *|");
            Console.WriteLine("|*       Transaction Management       *|");
            Console.WriteLine("|*  Please select a transaction type  *|");
            Console.WriteLine("|* ---------------------------------- *|");
            Console.WriteLine("|*          1.Transfer                *|");
            Console.WriteLine("|*          2.Income                  *|");
            Console.WriteLine("|*          3.Expense                 *|");
            Console.WriteLine("|*          4.Back to Main Menu       *|");
            Console.WriteLine("|* ---------------------------------- *|");
            Console.WriteLine("");
            Console.Write("Selection Number: ");
            string cardselect = Console.ReadLine();
            Console.WriteLine("");

            if (cardselect == "1")
            {
                mytrans.TransferNav();
                return true;
            }
            else if (cardselect == "2")
            {
                mytrans1.IncomeNav();
                return true;
            }
            else if (cardselect == "3")
            {
                mytrans2.ExpenseNav();
                return true;
            }
            else if (cardselect == "4")
            {
                Console.WriteLine(menu.Menu());
                return true;
            }
            else
            {
                Console.WriteLine("Please enter valid number.");
                TransactionNav();
                return false;
            }
        }
    }
}
