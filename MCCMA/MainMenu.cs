using System;
namespace MCCMA
{
    public class MainMenu
    {
        /// <summary>
        /// all of them are public and use to link methods from the other class
        /// </summary>
        public static UserProfileManagement newprofile = new UserProfileManagement();
        public static CardManagement cardmanagement = new CardManagement();
        public static TransactionManagement transmanagement = new TransactionManagement();

        /// <summary>
        /// The constructor is set default,
        /// </summary>
        public MainMenu()
        {
        }

        /// <summary>
        /// The is a boolean method that navigates user to different modules.
        /// </summary>
        public bool Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|*                Main Menu                  *|");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|         1. User Profile Management          |");
            Console.WriteLine("|         2. Card Management                  |");
            Console.WriteLine("|         3. Transaction Management           |");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("");
            Console.Write("Menu Number: ");
            string menunum = Console.ReadLine();
            Console.WriteLine("");

            if (menunum == "1")
            {
                newprofile.ProfileNav();
                return true;
            }
            else if (menunum == "2")
            {
                cardmanagement.CardNav();
                return true;
            }
            else if (menunum == "3")
            {
                transmanagement.TransactionNav();
                return true;
            }
            else
            {
                Console.WriteLine("Please enter valid menu number.");
                Menu();
                return false;
            }
        }
    }
}
