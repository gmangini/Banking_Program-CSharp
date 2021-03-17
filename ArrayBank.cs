using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Program
{

    class ArrayBank : IArrayBank
    {
        public int counter = 0;
        public Dictionary<string, IAccount> AccountList = new Dictionary<string, IAccount>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ArrayBank() { }

        /// <summary>
        /// Stores account in Dictionary<>, with input string as the key.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="account"></param>
        /// <returns> bool </returns>
        public bool StoreAccount(string info, IAccount account)
        {
            if (info is string && account is IAccount) // Checking for types
            {
                try
                {
                    AccountList.Add(info, account);
                    counter += 1;
                    return true;
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException("Incorrect entry.", e);
                }
            }
            return false;
        }

        /// <summary>
        /// Searches keys for string and returns the IAccount object.
        /// </summary>
        /// <param name="user"></param>
        /// <returns> IAccount </returns>
        public IAccount FindAccount(string user)
        {
            foreach (var item in AccountList)
            {
                if (item.Key == user)
                {
                    return item.Value;
                }
            }
            return null;
        }

    }
}
