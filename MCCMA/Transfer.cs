using System;
namespace MCCMA
{
    /// <summary>
    /// This is a child class inherited from Transaction classs
    /// </summary>
    public class Transfer : Transaction
    {
        /// <summary>
        /// _withracacc,_receiveacc are private field variable
        /// transmanagement is to link methods from the other class
        /// TransferID is to set a public value for the variable
        /// </summary>
        public static TransactionManagement transmanagement = new TransactionManagement();
        private string _withrawacc;
        private string _receiveacc;
        public static int TransferID = 1;

        /// <summary>
        /// The constructor is set default
        /// </summary>
        public Transfer()
        {
        }

        /// <summary>
        /// The Transfer constructor pass the value of 8 parameters where 6 of them are inherited from Accounts class
        /// </summary>
        public Transfer(int transid, string transtype, string withrawacc, string receiveacc, string transname, string transdate, string transmonth, double transamount) : base(transid, transtype, transname, transdate, transmonth, transamount)
        {
            TransID = transid;
            TransType = transtype;
            _withrawacc = withrawacc;
            _receiveacc = receiveacc;
            TransName = transname;
            TransDate = transdate;
            TransMonth = transmonth;
            TransAmount = transamount;

        }

        /// <summary>
        /// The property set private value of WithdrawAcc to public.
        /// </summary>
        public string WithrawAcc
        {
            get { return _withrawacc; }
            set { _withrawacc = value; }
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
            Console.WriteLine("Please fill your Transfer Details.");
            Console.WriteLine("=======================================");
            TransType = ("Transfer");
            Console.WriteLine("Transfer From Account: ");
            WithrawAcc = Console.ReadLine();
            Console.WriteLine("Transfer To Account: ");
            ReceiveAcc = Console.ReadLine();
            Console.WriteLine("Transfer Name: ");
            TransName = Console.ReadLine();
            Console.WriteLine("Transfer Date: ");
            TransDate = Console.ReadLine();
            Console.WriteLine("Transfer Month: ");
            TransMonth = Console.ReadLine();
            Console.WriteLine("Transfer Amount: ");
            TransAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("=======================================");
            Console.WriteLine("Transfer Added");
        }

        /// <summary>
        /// It override the ViewTransaction() method in the parent class
        /// </summary>
        public override void ViewTransaction()
        {
            Console.WriteLine("\nTransaction ID: " + TransID);
            Console.WriteLine("Transaction Type: " + TransType);
            Console.WriteLine("Transfer from Account: " + WithrawAcc);
            Console.WriteLine("Transfer to Account: " + ReceiveAcc);
            Console.WriteLine("Transfer Name: " + TransName);
            Console.WriteLine("Transfer Date: " + TransDate);
            Console.WriteLine("Transfer Month: " + TransMonth);
            Console.WriteLine("Transfer Amount: " + TransAmount);
        }

        /// <summary>
        /// The is a void method that navigates user within transfer functions.
        /// </summary>
        public void TransferNav()
        {
            while (true)
            {
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*              Transfer              *|");
                Console.WriteLine("|*   Please select a function below   *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*  1.Create Transfer                 *|");
                Console.WriteLine("|*  2.Delete Transfer                 *|");
                Console.WriteLine("|*  3.Edit Transfer                   *|");
                Console.WriteLine("|*  4.Print Daily Transfer            *|");
                Console.WriteLine("|*  5.Print Monthly Transfer          *|");
                Console.WriteLine("|*  6.Back to Transaction Management  *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("");
                Console.Write("Function Number: ");
                string transferfunc = Console.ReadLine();
                Console.WriteLine("");

                if (transferfunc == "1")
                {
                    Transfer tran = new Transfer();
                    tran.CreateTransaction();
                    transmanagement.AddTransaction(tran);

                    tran.TransID = TransferID;
                    TransferID += 1;

                    Console.WriteLine("Numbers of Transfer Added: " + transmanagement.CountTransactionList);
                    TransferNav();
                }
                else if (transferfunc == "2")
                {
                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        tr.ViewTransaction();
                    }
                    Console.Write("\nEnter Transaction ID that need to remove: ");
                    var tchoices = int.Parse(Console.ReadLine());

                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        if (tchoices == tr.TransID)
                        {
                            transmanagement.RemoveTransaction(tr);
                            Console.WriteLine("Transfer " + tr.TransID + " is removed.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Transaction ID is invalid.");
                        }
                    }
                    TransferNav();
                }
                else if (transferfunc == "3")
                {
                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        tr.ViewTransaction();
                    }
                    Console.Write("\nEnter Transaction ID that need to edit: ");
                    var tchoices1 = int.Parse(Console.ReadLine());

                    foreach (Transaction tr in transmanagement.TransactionList)
                    {
                        if (tchoices1 == tr.TransID)
                        {
                            transmanagement.EditTransaction();
                            Console.WriteLine("Successfully edited!");
                            TransferNav();
                        }
                        else
                        {
                            Console.WriteLine("\nTransfer not found");
                            TransferNav();
                        }
                    }
                }
                else if (transferfunc == "4")
                {
                    if (transmanagement.CountTransactionList == 0)
                    {
                        Console.WriteLine("\nThere is no Transfer occurs");
                        TransferNav();
                    }
                    else
                    {
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nDaily Format View");
                        Console.WriteLine("=====================");
                        foreach (Transaction tr in transmanagement.TransactionList)
                        {
                            if (tr is Transfer)
                            {
                                tr.ViewTransaction();
                            }
                        }                
                        TransferNav();
                    }
                }
                else if (transferfunc == "5")
                {
                    if (transmanagement.CountTransactionList == 0)
                    {
                        Console.WriteLine("\nThere is no Transfer occurs");
                        TransferNav();
                    }
                    else
                    {
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nMonthly Format View");
                        Console.WriteLine("=====================");
                        Console.WriteLine("\nEnter Month to Search");
                        Console.Write("Month: ");
                        string month = Console.ReadLine();
                        Console.WriteLine("This is transfer history of " + month + " month");
                        foreach (Transaction tr in transmanagement.TransactionList)
                        {
                            if (month == tr.TransMonth)
                            {
                                if (tr is Transfer)
                                {                                        
                                    tr.ViewTransaction();
                                }
                            }
                        }
                        TransferNav();
                    }
                }
                else if (transferfunc == "6")
                {
                    Console.WriteLine(transmanagement.TransactionNav());
                }
                else
                {
                    Console.WriteLine("Please enter valid function number.");
                    TransferNav();
                }
            }
        }
    }
}
