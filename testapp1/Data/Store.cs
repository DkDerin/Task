using System;
using testapp1.Models;


/// <summary>
/// Singleton class representing a store that manages a collection of accounts.
/// </summary>
public sealed class Store
{
    private static Store instance = null;
    private List<Account> accounts = new List<Account>
    {
       
    };

    private Store()
    {
    }

    /// <summary>
    /// Gets the instance of the Store class. If an instance does not exist, it creates one.
    /// </summary>
    /// <returns>The Store instance.</returns>
    public static Store GetInstance()
    {
        if (instance == null)
        {
            instance = new Store();
        }

        return instance;
    }

    public List<Account> GetAccounts()
    {
        return accounts;
    }

    public Account? GetAccount(string name)
    {
        var account = accounts.FirstOrDefault(x => x.Name == name);

        return account;
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }



}