using FinTracker.Application.DTOs.Account;
using FinTracker.Application.Interfaces.Repositories;
using FinTracker.Domain.Entities;

namespace FinTracker.Application.UseCases.Accounts
{
    public class CreateAccountUseCase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;

        public CreateAccountUseCase(
            IAccountRepository accountRepository,
            IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public async Task<CreateAccountResponse> ExecuteAsync(CreateAccountRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var account = new Account(user, request.Name);
            await _accountRepository.AddAsync(account);
            return new CreateAccountResponse
            {
                AccountId = account.Id
            };
        }
    }
}
