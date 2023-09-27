using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace testapp1.Models
{
    /// <summary>
    /// Represents a financial account with a name, type, and balance.
    /// </summary>
    public class Account
    {
        public Account(string name, AccountType type, decimal balance = 0) 
        {
            Name= name;
            Type = type;
            Balance = balance;
        }

        public string Name { get; set; }

        [EnumDataType(typeof(AccountType))]
        public AccountType Type { get; set; }
        public decimal Balance { get; set; }  = 0;

        public void modifyBalance(decimal amount)
        {
            Balance += amount;
        }


        public static Account Init(string name)
        {
           var matchedAccount = Store.GetInstance().GetAccount(name);

           return matchedAccount;
        }

    }

    public class AccountDto
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

    }


    public enum AccountType
    {
        [EnumMember(Value = "INCOME")]
        INCOME,
        [EnumMember(Value = "CHECK")]
        CHECK,
        [EnumMember(Value = "EXPENSE")]
        EXPENSE
    }




}
