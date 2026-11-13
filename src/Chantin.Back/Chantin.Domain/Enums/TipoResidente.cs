using System.ComponentModel.DataAnnotations;

namespace Chantin.Domain.Enums;

public enum TipoResidente
{
    Propietario = 1,
    Inquilino = 2,
    [Display(Name = "No Habita")]
    NoHabita = 0
}
