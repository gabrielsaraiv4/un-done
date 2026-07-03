using MediatR;
using UnDone.Application.Interfaces;
using UnDone.Domain.Entities;
using BCrypt.Net;

namespace UnDone.Application.Commands.Auth.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResult>
{
    private readonly IUserRepository _userRepository;

    public RegisterHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByEmailAsync(request.Email))
        {
            throw new InvalidOperationException("E-mail already in use.");
        }

        if (await _userRepository.ExistsByUsernameAsync(request.Username))
        {
            throw new InvalidOperationException("Username already in use.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(), Username = request.Username, Email = request.Email, PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _userRepository.AddAsync(user);

        return new RegisterResult(user.Id, user.Username, user.Email);
    }
}