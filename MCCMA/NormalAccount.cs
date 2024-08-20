using System;
namespace MCCMA
{
    /// <summary>
    /// This is a child class inherited from Accounts classs
    /// </summary>
    public class NormalAccount : Accounts
    {
        /// <summary>
        /// _accno,_accholder,_accbalance are private field variable
        /// cardmanagement is to link methods from the other class
        /// NormalAccID is to set a public value for the variable
        /// </summary>
        public static CardManagement cardmanagement = new CardManagement();
        public static int NormalAccID = 1;
        private string _accno;
        private string _accholder;
        private double _accbalance;

        /// <summary>
        /// The constructor is set default
        /// </summary>
        public NormalAccount()
        {
        }

        /// <summary>
        /// The NormalAccount constructor pass the value of 6 parameters where 2 of them are inherited from Accounts class
        /// </summary>
        public NormalAccount(int listno, string assocbank, string accno, string accholder, double accbalance) : base(listno, assocbank)
        {
            _accno = accno;
            _accholder = accholder;
            _accbalance = accbalance;
        }

        /// <summary>
        /// The property set private value of AccNo to public.
        /// </summary>
        public string AccNo
        {
            get { return _accno; }
            set { _accno = value; }
        }

        /// <summary>
        /// The property set private value of AccHolder to public.
        /// </summary>
        public string AccHolder
        {
            get { return _accholder; }
            set { _accholder = value; }
        }

        /// <summary>
        /// The property set private value of AccBalance to public.
        /// </summary>
        public double AccBalance
        {
            get { return _accbalance; }
            set { _accbalance = value; }
        }

        /// <summary>
        /// It override the Create() method in the parent class
        /// </summary>
        public override void Create()
        {
            Console.WriteLine("Please fill your Bank Account Details.");
            Console.WriteLine("=======================================");
            Console.Write("Bank Associated: ");
            AssocBank = Console.ReadLine();
            Console.Write("Account Number: ");
            AccNo = Console.ReadLine();
            Console.Write("Account Holder Name: ");
            AccHolder = Console.ReadLine();
            Console.Write("Account Balance: ");
            AccBalance = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine("New Bank Account added.");
        }

        /// <summary>
        /// It override the View() method in the parent class
        /// </summary>
        public override void View()
        {
            Console.Write("\n==================================");
            Console.Write("\nListNo: " + ListNo);
            Console.Write("\nBank Associated: " + AssocBank);
            Console.Write("\nAccount Number: " + AccNo);
            Console.Write("\nAccount Holder Name: " + AccHolder);
            Console.Write("\nAccount Balance: " + AccBalance);
            Console.WriteLine("\n==================================");
        }

        /// <summary>
        /// The is a void method that navigates user within normal account functions.
        /// </summary>
        public void NormalAccNav()
        {
            while (true)
            {
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*           Normal Account           *|");
                Console.WriteLine("|*   Please select a function below   *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*   1.Create Normal Account          *|");
                Console.WriteLine("|*   2.Delete Normal Account          *|");
                Console.WriteLine("|*   3.Edit Normal Account            *|");
                Console.WriteLine("|*   4.Print Normal Account Details   *|");
                Console.WriteLine("|*   5.Back to Card Management        *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("");
                Console.Write("Function Number: ");
                string normalaccfunc = Console.ReadLine();
                Console.WriteLine("");

                if (normalaccfunc == "1")
                {
                    NormalAccount nacc = new NormalAccount();
                    nacc.Create();
                    cardmanagement.AddAccount(nacc);

                    nacc.ListNo = NormalAccID;
                    NormalAccID += 1;

                    Console.WriteLine("Numbers of Normal Account Added: " + cardmanagement.CountListLength);
                    NormalAccNav();
                }
                else if (normalaccfunc == "2")
                {
                    foreach (Accounts acc in cardmanagement.AccountList)
                    {
                        acc.View();
                    }
                    Console.Write("\nEnter List No that need to remove: ");
                    var choices = int.Parse(Console.ReadLine());

                    foreach (Accounts acc in cardmanagement.AccountList)
                    {
                        if (choices == acc.ListNo)
                        {
                            cardmanagement.RemoveAccount(acc);
                            Console.WriteLine("Normal Account " + acc.ListNo + " is removed.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("List Number is invalid.");
                        }
                    }
                    NormalAccNav();
                }
                else if (normalaccfunc == "3")
                {
                    foreach (Accounts acc in cardmanagement.AccountList)
                    {
                        acc.View();
                    }
                    Console.Write("\nEnter List No that need to edit: ");
                    var choices1 = int.Parse(Console.ReadLine());

                    foreach (Accounts acc in cardmanagement.AccountList)
                    {
                        if (choices1 == acc.ListNo)
                        {
                            cardmanagement.Edit();
                            Console.WriteLine("Successfully edited!");
                            NormalAccNav();
                        }
                        else
                        {
                            Console.WriteLine("\nAccount not found");
                            NormalAccNav();
                        }
                    }
                }
                else if (normalaccfunc == "4")
                {
                    if (cardmanagement.CountListLength == 0)
                    {
                        Console.WriteLine("\nThere is no Normal Account");
                        NormalAccNav();
                    }
                    else
                    {
                        foreach (Accounts acc in cardmanagement.AccountList)
                        {
                            if (acc is NormalAccount)
                            {
                                acc.View();
                            }
                        }
                        NormalAccNav();
                    }
                }
                else if (normalaccfunc == "5")
                {
                    Console.WriteLine(cardmanagement.CardNav());
                }
                else
                {
                    Console.WriteLine("Please enter valid function number.");
                    NormalAccNav();
                }
            }
        }
    }
}
