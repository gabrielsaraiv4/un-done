using UnDone.Domain.Entities;

namespace UnDone.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}