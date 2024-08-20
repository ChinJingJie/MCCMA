using System;
namespace MCCMA
{
    /// <summary>
    /// This is a child class inherited from Accounts classs
    /// </summary>
    public class DebitCard: Accounts
    {
        /// <summary>
        /// _cardno,_cardholder,_expdate,_type are private field variable
        /// cardmanagement is to link methods from the other class
        /// DebitCardID is to set a public value for the variable
        /// </summary>
        public static CardManagement cardmanagement = new CardManagement();
        public static int DebitCardID = 1;
        private string _cardno;
        private string _cardholder;
        private string _expdate;
        private string _type;

        /// <summary>
        /// The constructor is set default
        /// </summary>
        public DebitCard()
        {
        }

        /// <summary>
        /// The DebitCard constructor pass the value of 6 parameters where 2 of them are inherited from Accounts class
        /// </summary>
        public DebitCard(int listno, string assocbank, string cardno, string cardholder, string expdate, string type) : base(listno, assocbank)
        {
            ListNo = listno;
            AssocBank = assocbank;
            _cardno = cardno;
            _expdate = expdate;
            _type = type;
            _cardholder = cardholder;
        }

        /// <summary>
        /// The property set private value of CardNo to public.
        /// </summary>
        public string CardNo
        {
            get { return _cardno; }
            set { _cardno = value; }
        }

        /// <summary>
        /// The property set private value of ExpDate to public.
        /// </summary>
        public string ExpDate
        {
            get { return _expdate; }
            set { _expdate = value; }
        }

        /// <summary>
        /// The property set private value of Type to public.
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// The property set private value of CardHolder to public.
        /// </summary>
        public string CardHolder
        {
            get { return _cardholder; }
            set { _cardholder = value; }
        }

        /// <summary>
        /// It override the Create() method in the parent class
        /// </summary>
        public override void Create()
        {
            Console.WriteLine("Please fill your Debit Card Details.");
            Console.WriteLine("=======================================");
            Console.Write("Bank Associated: ");
            AssocBank = Console.ReadLine();
            Console.Write("Card Number: ");
            CardNo = Console.ReadLine();
            Console.Write("CardHolder Name: ");
            CardHolder = Console.ReadLine();
            Console.Write("Expiry Date: ");
            ExpDate = Console.ReadLine();
            Console.Write("Debit Card Type: ");
            Type = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine("New Debit Card added.");
        }

        /// <summary>
        /// It override the View() method in the parent class
        /// </summary>
        public override void View()
        {
            Console.Write("\n==================================");
            Console.Write("\nListNo: " + ListNo);
            Console.Write("\nBank Associated: " + AssocBank);
            Console.Write("\nCard Number: " + CardNo);
            Console.Write("\nCardHolder Name: " + CardHolder);
            Console.Write("\nExpiry Date: " + ExpDate);
            Console.Write("\nDebit Card Type: " + Type);
            Console.WriteLine("\n==================================");
        }

        /// <summary>
        /// The is a void method that navigates user within debit card functions.
        /// </summary>
        public void DebitCardNav()
        {
            while (true)
            {
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*             Debit Card             *|");
                Console.WriteLine("|*   Please select a function below   *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*      1.Create Debit Card           *|");
                Console.WriteLine("|*      2.Delete Debit Card           *|");
                Console.WriteLine("|*      3.Edit Debit Card             *|");
                Console.WriteLine("|*      4.Print Debit Details         *|");
                Console.WriteLine("|*      5.Back to Card Management     *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("");
                Console.Write("Function Number: ");
                string debitcardfunc = Console.ReadLine();
                Console.WriteLine("");

                if (debitcardfunc == "1")
                {
                    DebitCard dcard = new DebitCard();
                    dcard.Create();
                    cardmanagement.AddAccount(dcard);

                    dcard.ListNo = DebitCardID;
                    DebitCardID += 1;

                    Console.WriteLine("Numbers of Debit Card Added: " + cardmanagement.CountListLength);
                    DebitCardNav();
                }
                else if (debitcardfunc == "2")
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
                            Console.WriteLine("Debit Card " + acc.ListNo + " is removed.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("List Number is invalid.");
                        }
                    }
                    DebitCardNav();
                }
                else if (debitcardfunc == "3")
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
                            DebitCardNav();
                        }
                        else
                        {
                            Console.WriteLine("\nDebit Card not found");
                            DebitCardNav();
                        }
                    }
                }
                else if (debitcardfunc == "4")
                {
                    if (cardmanagement.CountListLength == 0)
                    {
                        Console.WriteLine("\nThere is no Debit Card");
                        DebitCardNav();
                    }
                    else
                    {
                        foreach (Accounts acc in cardmanagement.AccountList)
                        {
                            if (acc is DebitCard)
                            {
                                acc.View();
                            }
                        }
                        DebitCardNav();
                    }
                }
                else if (debitcardfunc == "5")
                {
                    Console.WriteLine(cardmanagement.CardNav());
                }
                else
                {
                    Console.WriteLine("Please enter valid function number.");
                    DebitCardNav();
                }
            }
        }
    }
}
