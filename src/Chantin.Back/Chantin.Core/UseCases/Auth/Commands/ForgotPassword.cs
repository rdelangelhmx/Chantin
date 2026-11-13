using Chantin.Domain.Models;
using MediatR;

namespace Chantin.Application.Features.Auth.Commands;

public record ForgotPassword(
	string? Email
	) : IRequest<ResultModel<LoginModel>>;