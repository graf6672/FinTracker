using FinTracker.Application.DTOs.User;
using FinTracker.Application.Interfaces.Repositories;
using FinTracker.Application.Interfaces.Services;
using FinTracker.Domain.Entities;

namespace FinTracker.Application.UseCases.Users
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserUseCase(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterUserResponse> ExecuteAsync(RegisterUserRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            var existingEmail = await _userRepository.GetByEmailAsync(request.Email);
            if (existingEmail is not null)
            {
                throw new InvalidOperationException("User with this email already exists.");
            }
            var existingNickname = await _userRepository.GetByNicknameAsync(request.Nickname);
            if (existingNickname is not null)
            {
                throw new InvalidOperationException("User with this nickname already exists.");
            }

            var user = new User(request.Nickname,
                _passwordHasher.Hash(request.Password),
                request.Email
                );

            await _userRepository.AddAsync(user);

            return new RegisterUserResponse
            {
                UserId = user.Id
            };
        }
    }
}
