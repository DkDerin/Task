using Microsoft.AspNetCore.Mvc;
using testapp1.Models;

namespace testapp1.Services
{
    /// <summary>
    /// Service class responsible for managing accounts and transactions.
    /// </summary>
    public class AccountBookService
    {
        private Store store  = Store.GetInstance();
        public void CreateAccount(string name, AccountType accountType)
        {
            var account = new Account(name,accountType);

            store.AddAccount(account);
        }

        public List<AccountDto> GetAccounts()
        {
            var filteredAccount = store.GetAccounts().OrderBy(x => x.Name)
                .Select(a => new AccountDto {Name = a.Name, Balance = a.Balance})
                .ToList();

            return filteredAccount;
        }

        public void CreateTransaction(TransactionData transactionData)
        {
            var transaction = new Transaction(transactionData);
            transaction.execute();
            return;

        }
    }
}
