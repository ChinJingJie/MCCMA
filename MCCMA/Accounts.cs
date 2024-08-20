using System;
namespace MCCMA
{
    /// <summary>
    /// This is a parent class that set to be abstract
    /// </summary>
    public abstract class Accounts
    {
        /// <summary>
        /// _listno and _assocbank is private field variable
        /// </summary>
        private int _listno;
        private string _assocbank;

        /// <summary>
        /// The constructor is set default
        /// </summary>
        public Accounts()
        {
        }

        /// <summary>
        /// The Accounts constructor pass the value of listno and assocbank
        /// </summary>
        public Accounts(int listno, string assocbank)
        {
            _listno = listno;
            _assocbank = assocbank;
        }

        /// <summary>
        /// The property set private value of ListNo to public.
        /// </summary>
        public int ListNo
        {
            get { return _listno; }
            set { _listno = value; }
        }

        /// <summary>
        /// The property set private value of AssocBank to public.
        /// </summary>
        public string AssocBank
        {
            get { return _assocbank; }
            set { _assocbank = value; }
        }

        /// <summary>
        /// abstract method are use to reduce redundent code for more flecibility
        /// Create()is use to prompt account value from user
        /// View() is use to print the value prompted
        /// </summary>
        public abstract void Create();
        public abstract void View();

    }
}
