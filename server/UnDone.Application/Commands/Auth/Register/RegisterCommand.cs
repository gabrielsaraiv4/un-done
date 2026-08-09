using MediatR;

namespace UnDone.Application.Commands.Auth.Register;

public record RegisterCommand (
    string Username, string Email, string Password) : IRequest<RegisterResult>;

public record RegisterResult (
    Guid UserId, string Username, string Email);