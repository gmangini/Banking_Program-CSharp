using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Program
{
    /// <summary>
    /// Interface contains functions about Banking Program
    /// </summary>
    interface IAccount
    {
        bool SetName(string inName);

        string GetName();

        bool SetAddress(string inAddress);

        string GetAddress();

        void PayInFunds(decimal amount);

        bool WithdrawFunds(decimal amount);

        bool SetBalance(decimal inBalance);

        decimal GetBalance();

        decimal GetServiceFee();

        bool SetServiceFee(decimal inFee);

        string GetAccountNumber();

        void SetAccountNumber(string type);

        string GetAccountType();
    }
}
