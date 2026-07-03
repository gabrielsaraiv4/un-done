using MediatR;

namespace UnDone.Application.Commands.Auth.Login;

public record LoginCommand(
    string Email, string Password) : IRequest<LoginResult>;

public record LoginResult(
    string Toker, Guid UserId, string Username);