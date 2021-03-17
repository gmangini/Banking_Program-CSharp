using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Program
{
    class CDAccount : Account
    {
        private decimal minimum = 500;
        private decimal minFee = 8;

        /// <summary>
        /// Inherits from Account.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="balance"></param>
        /// <param name="type"></param>

        public CDAccount(string name, string address, decimal balance, string type)
            : base(name, address, balance, type) { }

        /// <summary>
        /// Returns the service fee for CDAccount.
        /// </summary>
        /// <returns> decimal </returns>

        public override decimal GetServiceFee()
        {
            return serviceFee;
        }

        /// <summary>
        /// Sets the service fee for the account.
        /// </summary>
        /// <param name="inFee"></param>
        /// <returns> bool </returns>
        public override bool SetServiceFee(decimal inFee)
        {
            if (inFee < minFee)
            {
                return false;
            }
            else
            {
                serviceFee = inFee;
                return true;
            }
        }

        /// <summary>
        /// Returns the balance.
        /// </summary>
        /// <returns> decimal </returns>
        public override decimal GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// Sets the balance according to the minimum specified in field
        /// of CDAccount.
        /// </summary>
        /// <param name="inBalance"></param>
        /// <returns> bool </returns>
        public override bool SetBalance(decimal inBalance)
        {
            if (inBalance < minimum)
            {
                Console.WriteLine("Minimum balance not met.");
                return false;
            }
            else
            {
                balance = inBalance;
                return true;
            }
        }
    }
}
