using FinTracker.Application.DTOs.Category;
using FinTracker.Application.Interfaces.Repositories;
using FinTracker.Domain.Entities;

namespace FinTracker.Application.UseCases.Categories
{
    public class CreateCategoryUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryUseCase(
            IUserRepository userRepository,
            ICategoryRepository categoryRepository
            )
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryResponse> ExecuteAsync(CreateCategoryRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var category = new Category(user, request.Name, request.Type);
            await _categoryRepository.AddAsync(category);

            return new CreateCategoryResponse
            {
                CategoryId = category.Id
            };
        }
    }
}
