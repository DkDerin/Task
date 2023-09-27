using testapp1.ExceptionHandler;
using StatusCodes = testapp1.ExceptionHandler.StatusCodes;

namespace testapp1.Models
{
    /// <summary>
    /// Represents a financial transaction between two accounts.
    /// </summary>
    public class Transaction
    {
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public decimal Amount { get; set; }
        public int Multiplier { get; set; } 
        public Transaction(TransactionData transactionData)
        {
            var fromAccount = Account.Init(transactionData.FromAccount);
            var toAccount = Account.Init(transactionData.ToAccount);

            if (fromAccount == null || toAccount == null)
            {
                throw new CustomException(StatusCodes.NOT_FOUND, "Could not find account for transaction");
            }
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Amount = transactionData.Amount;
        }

        public void execute()
        {
            checkEnoughBalance();
            decideAddOrDeduct();
            performTransaction();
        }
        private void performTransaction()
        {
            FromAccount.modifyBalance(Amount);
            var calculatedAmount = Amount * Multiplier;
            ToAccount.modifyBalance(calculatedAmount);

        }
        private void decideAddOrDeduct()
        {
            if (ToAccount.Type == AccountType.CHECK)
            {
                Multiplier = 1;
            }
            else
            {
                Multiplier = -1;
            }
        }
        private void checkEnoughBalance()
        {
            if (FromAccount.Balance < Amount)
            {
                throw new CustomException(StatusCodes.BAD_PAYLOAD, "Insufficient balance");
            }
        }
    }

    public class TransactionData
    {
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
    }
}

