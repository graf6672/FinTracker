using FinTracker.Application.DTOs.FinancialGoal;
using FinTracker.Application.Interfaces.Repositories;
using FinTracker.Domain.Entities;

namespace FinTracker.Application.UseCases.FinancialGoals
{
    public class CreateFinancialGoalUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IFinancialGoalRepository _financialGoalRepository;

        public CreateFinancialGoalUseCase(
            IUserRepository userRepository,
            IFinancialGoalRepository financialGoalRepository
            )
        {
            _userRepository = userRepository;
            _financialGoalRepository = financialGoalRepository;
        }

        public async Task<CreateFinancialGoalResponse> ExecuteAsync(CreateFinancialGoalRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var financialGoal = new FinancialGoal(
                user,
                request.Name,
                request.TargetAmount,
                0,
                request.TargetDate);
            await _financialGoalRepository.AddAsync(financialGoal);

            return new CreateFinancialGoalResponse
            {
                FinancialGoalId = financialGoal.Id
            };
        }
    }
}
