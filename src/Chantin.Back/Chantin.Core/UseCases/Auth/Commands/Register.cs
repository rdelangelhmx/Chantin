using Chantin.Application.Dto;
using Chantin.Domain.Models;
using MediatR;

namespace Chantin.Application.Features.Auth.Commands;

public record Register(UsuariosDto? UserRegister) : IRequest<ResultModel<LoginModel>>;
