using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Program
{
    class CheckingAccount : Account
    {
        private decimal minimum = 10;
        private decimal minFee = 5;

        /// <summary>
        /// Constructor to initialize CheckingAccount from absract class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="balance"></param>
        /// <param name="type"></param>
        public CheckingAccount(string name, string address, decimal balance, string type)
            : base(name, address, balance, type) { }

        /// <summary>
        /// Inherited method to retrieve service fee.
        /// </summary>
        /// <returns> decimal </returns>
        public override decimal GetServiceFee()
        {
            return serviceFee;
        }

        /// <summary>
        /// Inherited method to sets the service fee. 
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
        /// inherited method that returns the balance.
        /// </summary>
        /// <returns> decimal </returns>
        public override decimal GetBalance()
        {
            return balance;
        }

        /// <summary>
        /// Inherited method to set the balance.
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
