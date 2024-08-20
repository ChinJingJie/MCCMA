using System;
namespace MCCMA
{
    /// <summary>
    /// This is a child class inherited from Accounts classs
    /// </summary>
    public class CreditCard: Accounts
    {
        /// <summary>
        /// _cardno,_cardholder,_expdate,_type,_reward,_limit,_interest are private field variable
        /// cardmanagement is to link methods from the other class
        /// CreditCardID is to set a public value for the variable
        /// </summary>
        public static CardManagement cardmanagement = new CardManagement();
        public static int CreditCardID = 1;
        private string _cardno;
        private string _cardholder;
        private string _expdate;
        private string _type;

        private double _reward;
        private int _limit;
        private double _interest;

        /// <summary>
        /// The constructor is set default where the values are empty
        /// </summary>
        public CreditCard() :this(0,"","","","","",0,0,0)
        {
        }

        /// <summary>
        /// The CreditCard constructor pass the value of 9 parameters where 2 of them are inherited from Accounts class
        /// </summary>
        public CreditCard(int listno, string assocbank, string cardno, string cardholder, string expdate, string type, double reward, int limit, double interest) : base(listno, assocbank)
        {
            ListNo = listno;
            AssocBank = assocbank;
            _cardno = cardno;
            _expdate = expdate;
            _type = type;
            _cardholder = cardholder;
            _reward = reward;
            _limit = limit;
            _interest = interest;
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
        /// The property set private value of Reward to public.
        /// </summary>
        public double Reward
        {
            get { return _reward; }
            set { _reward = value; }
        }

        /// <summary>
        /// The property set private value of Limit to public.
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }

        /// <summary>
        /// The property set private value of Interest to public.
        /// </summary>
        public double Interest
        {
            get { return _interest; }
            set { _interest = value; }
        }

        /// <summary>
        /// It override the Create() method in the parent class
        /// </summary>
        public override void Create()
        {
            Console.WriteLine("Please fill your Credit Card Details.");
            Console.WriteLine("=======================================");
            Console.Write("Bank Associated: ");
            AssocBank = Console.ReadLine();
            Console.Write("Card Number: ");
            CardNo = Console.ReadLine();
            Console.Write("CardHolder Name: ");
            CardHolder = Console.ReadLine();
            Console.Write("Expiry Date: ");
            ExpDate = Console.ReadLine();
            Console.Write("Credit Card Type: ");
            Type = Console.ReadLine();
            Console.Write("Credit Card Limit: ");
            Limit = int.Parse(Console.ReadLine());
            Console.Write("Credit Card Interest Rate: ");
            Interest = float.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("=======================================");
            Console.WriteLine("New Credit Card added.");
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
            Console.Write("\nCredit Card Type: " + Type);
            Console.WriteLine("\n==================================");
        }

        /// <summary>
        /// The is a void method that navigates user within credit card functions.
        /// </summary>
        public void CreditCardNav()
        {
            while (true)
            {
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*             Credit Card            *|");
                Console.WriteLine("|*   Please select a function below   *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("|*      1.Create Credit Card          *|");
                Console.WriteLine("|*      2.Delete Credit Card          *|");
                Console.WriteLine("|*      3.Edit Credit Card            *|");
                Console.WriteLine("|*      4.Print Card Details          *|");
                Console.WriteLine("|*      5.Back to Card Management     *|");
                Console.WriteLine("|* ---------------------------------- *|");
                Console.WriteLine("");
                Console.Write("Function Number: ");
                string creditcardfunc = Console.ReadLine();
                Console.WriteLine("");

                if (creditcardfunc == "1")
                {
                    CreditCard ccard = new CreditCard();
                    ccard.Create();
                    cardmanagement.AddAccount(ccard);

                    ccard.ListNo = CreditCardID;
                    CreditCardID += 1;
                    
                    Console.WriteLine("Numbers of Credit Card Added: " + cardmanagement.CountListLength);
                    CreditCardNav();
                }
                else if (creditcardfunc == "2")
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
                            Console.WriteLine("Credit Card " + acc.ListNo + " is removed.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("List Number is invalid.");
                        }
                    }
                    CreditCardNav();
                }
                else if (creditcardfunc == "3")
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
                            CreditCardNav();          
                        }
                        else
                        {
                            Console.WriteLine("\nCredit Card not found");
                            CreditCardNav();
                        }
                    }
                }
                else if (creditcardfunc == "4")
                {
                    if (cardmanagement.CountListLength == 0)
                    {
                        Console.WriteLine("\nThere is no Credit Card");
                        CreditCardNav();
                    }
                    else
                    {
                        foreach (Accounts acc in cardmanagement.AccountList)
                        {
                            if (acc is CreditCard)
                            {
                                acc.View();                      
                            }
                        }
                        CreditCardNav();
                    }
                }
                else if (creditcardfunc == "5")
                {
                    Console.WriteLine(cardmanagement.CardNav());
                }
                else
                {
                    Console.WriteLine("Please enter valid function number.");
                    CreditCardNav();
                }
            }
        }
    }

}

