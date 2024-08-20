using System;
using NUnit.Framework;

namespace MCCMA
{
    [TestFixture()]
    public class CardManagementTest
    {
        [Test()]
        public void AddCardTest()
        {
            Accounts[] account = {
                new CreditCard(1, "rhb", "12345", "james lim", "02/23", "visa", 12, 1000, 2.5),
                new DebitCard(1, "maybank", "9932123", "george", "01/21", "visa"),
                new NormalAccount(1, "cimb", "2435436", "zara", 300)
            };

            CardManagement myCards = new CardManagement();

            Assert.AreEqual(0, myCards.CountListLength);

            foreach (Accounts accs in account)
            {
                myCards.AddAccount(accs);
            }

            Assert.AreEqual(3, myCards.CountListLength);
        }

        [Test()]
        public void RemoveCardTest()
        {
            Accounts[] account = {
                new CreditCard(1, "rhb", "12345", "james lim", "02/23", "visa", 12, 1000, 2.5),
                new DebitCard(1, "maybank", "9932123", "george", "01/21", "visa"),
                new NormalAccount(1, "cimb", "2435436", "zara", 300)
            };

            CardManagement myCards = new CardManagement();

            foreach (Accounts accs in account)
            {
                myCards.AddAccount(accs);
            }

            Assert.AreEqual(3, myCards.CountListLength);

            myCards.RemoveAccount(account[0]);

            Assert.AreEqual(2, myCards.CountListLength);
        }

        [Test()]
        public void FetchCardTest()
        {
            Accounts[] account = {
                new CreditCard(1, "rhb", "12345", "james lim", "02/23", "visa", 12, 1000, 2.5),
                new DebitCard(1, "maybank", "9932123", "george", "01/21", "visa"),
                new NormalAccount(1, "cimb", "2435436", "zara", 300)
            };

            CardManagement myCards = new CardManagement();

            foreach (Accounts accs in account)
            {
                myCards.AddAccount(accs);
            }

            Assert.AreEqual(account[2], myCards[2]);
        }
    }
}
