
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking_Program
{
    abstract class Account : IAccount
    {
        public enum AccountType { Savings, Checking, CDAccount };

        protected string name;
        protected string address;
        protected string accountNumber;
        protected decimal balance;
        protected decimal serviceFee = 0;
        protected AccountType accountType;

        /// <summary>
        /// Constructor for abstract class that certain accounts will inherit from.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="balance"></param>
        /// <param name="type"></param>
        public Account(string name, string address, decimal balance, string type)
        {
            SetName(name);
            SetAddress(address);
            SetBalance(balance);

            this.name = GetName();
            this.address = GetAddress();
            this.balance = GetBalance();
            accountType = (AccountType)Enum.Parse(typeof(AccountType), type);
            SetAccountNumber(type);
            accountNumber = GetAccountNumber();
        }

        /// <summary>
        /// Sets the Account number, according to enum, and appends a character
        /// to specify the account.
        /// </summary>
        /// <param name="type"></param>
        public void SetAccountNumber(string type)
        {
            
            string RandomDigits(int length)
            {
                var random = new Random();
                string s = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    s = String.Concat(s, random.Next(10).ToString());
                }
                return s;
            }
            int accountLength = 6; // hard coded value of 6 digits since not specified.
            accountNumber = RandomDigits(accountLength);
            switch (accountType)
            {
                case AccountType.Savings:
                    accountNumber = accountNumber + "S";
                    break;
                case AccountType.Checking:
                    accountNumber = accountNumber + "C";
                    break;
                case AccountType.CDAccount:
                    accountNumber = accountNumber + "D";
                    break;
            }
        }

        /// <summary>
        /// Returns the account number.
        /// </summary>
        /// <returns> string </returns>
        public string GetAccountNumber()
        {
            return accountNumber;
        }

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <param name="inName"></param>
        /// <returns> bool </returns>
        public bool SetName(string inName)
        {
            if (inName == null | inName == string.Empty)
            {
                throw new ArgumentException("Parameter cannot be null or empty");
            }
            else
            {
                name = inName;
                return true;
            }
        }


        /// <summary>
        /// Returns the name.
        /// </summary>
        /// <returns> string </returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Sets the address.
        /// </summary>
        /// <param name="inAddress"></param>
        /// <returns> bool </returns>
        public bool SetAddress(string inAddress)
        {
            if (inAddress == null || inAddress == string.Empty)
            {
                return false;
            }
            else
            {
                address = inAddress;
                return true;
            }
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <returns> string </returns>
        public string GetAddress()
        {
            return address;
        }

        /// <summary>
        /// /Allows user to increase balance.
        /// </summary>
        /// <param name="amount"></param>

        public void PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        /// <summary>
        /// Decreases balance by withdrawing funds.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> bool </returns>
        public bool WithdrawFunds(decimal amount)
        {
            decimal newBalance;
            newBalance = balance - amount;
            decimal negative = 0;
            if (newBalance < negative)
            {
                return false;
            }
            else
            {
                balance = newBalance;
                return true;
            }
        }

        /// <summary>
        /// Retrieves string representation of account type.
        /// </summary>
        /// <returns> string </returns>
        public string GetAccountType()
        {
            return accountType.ToString();
        }

        /// <summary>
        /// Abstract method for retreiving balance.
        /// </summary>
        /// <returns> decimal </returns>
        public abstract decimal GetBalance();

        /// <summary>
        /// Abstract method for retrieving service fee.
        /// </summary>
        /// <returns> decmial </returns>
        public abstract decimal GetServiceFee();
  
        /// <summary>
        /// Absract method for setting service fee any account.
        /// </summary>
        /// <param name="inFee"></param>
        /// <returns> bool </returns>
        public abstract bool SetServiceFee(decimal inFee);

        /// <summary>
        /// Absract method for setting a blanace to any account.
        /// </summary>
        /// <param name="inBalance"></param>
        /// <returns> bool </returns>
        public abstract bool SetBalance(decimal inBalance);

    }
}
