using System;
using System.Collections.Generic;

namespace MCCMA
{
    public class CardManagement
    {
        /// <summary>
        /// _accountlist is private field variable that store a list of accounts
        /// others are to link methods from the other class
        /// </summary>
        public static MainMenu menu = new MainMenu();
        public static CreditCard myacc = new CreditCard();
        public static DebitCard myacc1 = new DebitCard();
        public static NormalAccount myacc2 = new NormalAccount();
        private readonly List<Accounts> _accountlist;

        /// <summary>
        /// The constructor is set default and initialize the _accountlist.
        /// </summary>
        public CardManagement()
        {
            _accountlist = new List<Accounts>();
        }

        /// <summary>
        /// The property set private value of AccountList to public.It only has get because it is a readonly property.
        /// </summary>
        public List<Accounts> AccountList
        {
            get { return _accountlist; }
        }

        /// <summary>
        /// This is a method that use to add account into the Account List
        /// </summary>
        public void AddAccount(Accounts acc)
        {
            _accountlist.Add(acc);
        }

        /// <summary>
        /// This is a void method that can edit the details of existing accounts.
        /// </summary>
        public void Edit()
        {
            foreach (Accounts acc in _accountlist)
            {
                if (acc is CreditCard && acc != null)
                {
                    Console.Write("Bank Associated: ");
                    var newcAssocBank = Console.ReadLine();
                    ((CreditCard)acc).AssocBank = newcAssocBank;

                    Console.Write("Card Number: ");
                    var newcCardNo = Console.ReadLine();
                    ((CreditCard)acc).CardNo = newcCardNo;

                    Console.Write("CardHolder Name: ");
                    var newcCardHolder = Console.ReadLine();
                    ((CreditCard)acc).CardHolder = newcCardHolder;

                    Console.Write("Expiry Date: ");
                    var newcExpDate = Console.ReadLine();
                    ((CreditCard)acc).ExpDate = newcExpDate;

                    Console.Write("Credit Card Type: ");
                    var newcType = Console.ReadLine();
                    ((CreditCard)acc).Type = newcType;

                    Console.Write("Credit Card Limit: ");
                    var newcLimit = int.Parse(Console.ReadLine());
                    ((CreditCard)acc).Limit = newcLimit;

                    Console.Write("Credit Card Interest Rate: ");
                    var newcInterest = int.Parse(Console.ReadLine());
                    ((CreditCard)acc).Interest = newcInterest;

                    break;
                }
                else if (acc is DebitCard && acc != null)
                {
                    Console.Write("Bank Associated: ");
                    var newdAssocBank = Console.ReadLine();
                    ((CreditCard)acc).AssocBank = newdAssocBank;

                    Console.Write("Card Number: ");
                    var newdCardNo = Console.ReadLine();
                    ((DebitCard)acc).CardNo = newdCardNo;

                    Console.Write("CardHolder Name: ");
                    var newdCardHolder = Console.ReadLine();
                    ((DebitCard)acc).CardHolder = newdCardHolder;

                    Console.Write("Expiry Date: ");
                    var newdExpDate = Console.ReadLine();
                    ((DebitCard)acc).ExpDate = newdExpDate;

                    Console.Write("Debit Card Type: ");
                    var newdType = Console.ReadLine();
                    ((DebitCard)acc).Type = newdType;

                    break;
                }
                else if (acc is NormalAccount && acc != null)
                {
                    Console.Write("Bank Associated: ");
                    var newAssocBank = Console.ReadLine();
                    ((NormalAccount)acc).AssocBank = newAssocBank;

                    Console.Write("Account Number: ");
                    var newAccNo = Console.ReadLine();
                    ((NormalAccount)acc).AccNo = newAccNo;

                    Console.Write("Account Holder Name: ");
                    var newAccHolder = Console.ReadLine();
                    ((NormalAccount)acc).AccHolder = newAccHolder;

                    Console.Write("Account Balance: ");
                    var newAccBalance = int.Parse(Console.ReadLine());
                    ((NormalAccount)acc).AccBalance = newAccBalance;

                    break;
                }
                else
                {
                    if (acc is CreditCard)
                    {
                        Console.WriteLine("No Credit Card found");
                    }
                    else if (acc is DebitCard)
                    {
                        Console.WriteLine("No Debit Card found");
                    }
                    else
                    {
                        Console.WriteLine("No Normal Account found");
                    }
                }
            }
        }

        /// <summary>
        /// This is a method that use to remove account into the Account List
        /// </summary>
        public void RemoveAccount(Accounts acc)
		{
			_accountlist.Remove(acc);
		}

        /// <summary>
        /// This is a property to count the number of rows in the Account List
        /// </summary>
        public int CountListLength
        {
            get { return _accountlist.Count; }
        }

        /// <summary>
        /// This is an indexer that has the ability to access an Account at given index.
        /// </summary>
        public Accounts this[int c]
        {
            get { return _accountlist[c]; }
        }

        /// <summary>
        /// The is a bool method that navigates user from user card management modules to its functions.
        /// </summary>
        public bool CardNav()
        {
            Console.WriteLine("|* ---------------------------------- *|");
            Console.WriteLine("|*         Card Management            *|");
            Console.WriteLine("|* Please select a card/account below *|");
            Console.WriteLine("|* ---------------------------------- *|");
            Console.WriteLine("|*          1.Credit Card             *|");
            Console.WriteLine("|*          2.Debit Card              *|");
            Console.WriteLine("|*          3.Normal Account          *|");
            Console.WriteLine("|*          4.Back to Main Menu       *|");
            Console.WriteLine("|* ---------------------------------- *|");
            Console.WriteLine("");
            Console.Write("Selection Number: ");
            string cardselect = Console.ReadLine();
            Console.WriteLine("");

            if (cardselect == "1")
            {
                myacc.CreditCardNav();
                return true;
            }
            else if (cardselect == "2")
            {
                myacc1.DebitCardNav();
                return true;
            }
            else if (cardselect == "3")
            {
                myacc2.NormalAccNav();
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
                CardNav();
                return false;
            }
        }
    }
}
