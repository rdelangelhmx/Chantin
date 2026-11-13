namespace Chantin.Domain.Enums;

public enum TipoNotificacion
{
	Publicacion = 1,
	Aviso = 2,
	Comunicado = 3,
	Logro = 4,
	Solicitud = 5,
	Comentario = 6,
	Denuncia = 7,
	Mensaje = 8, // Correo, Interno
	Alerta = 9, // SMS, WhatsApp, Push
	Otro = 0
}
