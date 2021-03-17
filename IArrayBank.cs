namespace Banking_Program
{
    /// <summary>
    /// Interdace for ArrayBank. 
    /// </summary>
    interface IArrayBank
    {
        IAccount FindAccount(string user);
        bool StoreAccount(string info, IAccount account);
    }
}