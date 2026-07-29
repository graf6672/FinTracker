using FinTracker.Application.DTOs.Transaction;
using FinTracker.Application.Interfaces.Repositories;
using FinTracker.Domain.Entities;
using FinTracker.Domain.Enums;


namespace FinTracker.Application.UseCases.Transactions
{
    public class CreateTransactionUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateTransactionUseCase(
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository,
            ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateTransactionResponse> ExecuteAsync(CreateTransactionRequest request)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountId);
            if (account is null)
            {
                // позже заменить на собственные исключения
                throw new InvalidOperationException("Account not found.");
            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            if (category is null)
            {
                // позже заменить на собственные исключения
                throw new InvalidOperationException("Category not found.");
            }
            if (account.UserId != category.UserId)
            {
                throw new InvalidOperationException("User id doesn't match.");
            }
            var transaction = new Transaction(
                account,
                category,
                request.Amount,
                request.TransactionDate,
                request.Description);
            if (category.Type == CategoryType.Income)
            {
                account.Deposit(request.Amount);
            }
            else
            {
                account.Withdraw(request.Amount);
            }

            await _transactionRepository.AddAsync(transaction);
            await _accountRepository.UpdateAsync(account);

            return new CreateTransactionResponse()
            {
                TransactionId = transaction.Id,
                NewBalance = account.Balance
            };
        }
    }
}
