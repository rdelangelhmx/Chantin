using Chantin.Domain.Models;
using MediatR;

namespace Chantin.Application.Features.Auth.Commands;

public record GenerateOtp(string? Email) : IRequest<ResultModel<LoginModel>>;

