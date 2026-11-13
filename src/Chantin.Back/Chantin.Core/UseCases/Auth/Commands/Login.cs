using Chantin.Domain.Models;
using MediatR;

namespace Chantin.Application.Features.Auth.Commands;

public record Login(LoginModel? UserLogin, int Duration) : IRequest<ResultModel<AuthModel>>;
