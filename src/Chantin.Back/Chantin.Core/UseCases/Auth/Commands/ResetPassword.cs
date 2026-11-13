using Chantin.Domain.Models;
using MediatR;

namespace Chantin.Application.Features.Auth.Commands;

public record ResetPassword(
	string? Email,
	string? Code,
	string? NewPassword
) : IRequest<ResultModel<LoginModel>>;
