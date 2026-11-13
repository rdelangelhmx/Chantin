using Chantin.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Chantin.Application.Interfaces;

public interface IChantinCtx
{
	DbContext Instance { get; }
	IDbConnection ClientConn { get; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	string ServerName { get; }

	void AddAudit(string action, int idUser, int? idOption, string message);

	bool ExecSP(string sql, string pwd, params SqlParameter[]? parameters);
	bool ExecSP(string sql, string db, string uid, string pwd, params SqlParameter[]? parameters);

	bool ExecSQL(string sql, string pwd, params SqlParameter[]? parameters);
	bool ExecSQL(string sql, string db, string uid, string pwd, params SqlParameter[]? parameters);

	List<T> ExecSql<T>(string sql, string pwd, CommandType commandType, params SqlParameter[]? parameters);
	List<T> ExecSql<T>(string sql, CommandType commandType, string db, string uid, string pwd, params SqlParameter[]? parameters);

	#region DBSet
	DbSet<AreaComunReservaciones> AreaComunReservaciones { get; set; }

	DbSet<AreasComunes> AreasComunes { get; set; }

	DbSet<AsociacionDatosBancarios> AsociacionDatosBancarios { get; set; }

	DbSet<AsociacionDomicilios> AsociacionDomicilios { get; set; }

	DbSet<AsociacionGrupos> AsociacionGrupos { get; set; }

	DbSet<Asociaciones> Asociaciones { get; set; }

	DbSet<AuditLog> AuditLog { get; set; }

	DbSet<Bitacora> Bitacora { get; set; }

	DbSet<BitacoraVigilancia> BitacoraVigilancia { get; set; }

	DbSet<CatBancos> CatBancos { get; set; }

	DbSet<CatRegimenesFiscales> CatRegimenesFiscales { get; set; }

	DbSet<ContactoDomicilios> ContactoDomicilios { get; set; }

	DbSet<Contactos> Contactos { get; set; }

	DbSet<DatosBancarios> DatosBancarios { get; set; }

	DbSet<Domicilios> Domicilios { get; set; }

	DbSet<EmailTemplates> EmailTemplates { get; set; }

	DbSet<EmpresaDatosBancarios> EmpresaDatosBancarios { get; set; }

	DbSet<EmpresaDepartamentos> EmpresaDepartamentos { get; set; }

	DbSet<EmpresaDocumentos> EmpresaDocumentos { get; set; }

	DbSet<EmpresaDomicilios> EmpresaDomicilios { get; set; }

	DbSet<EmpresaPuestos> EmpresaPuestos { get; set; }

	DbSet<EmpresaRegimenes> EmpresaRegimenes { get; set; }

	DbSet<Empresas> Empresas { get; set; }

	DbSet<EncuestaPreguntas> EncuestaPreguntas { get; set; }

	DbSet<EncuestaRespuestaResidentes> EncuestaRespuestaResidentes { get; set; }

	DbSet<EncuestaRespuestas> EncuestaRespuestas { get; set; }

	DbSet<Encuestas> Encuestas { get; set; }

	DbSet<Finanzas> Finanzas { get; set; }

	DbSet<FinanzasConceptos> FinanzasConceptos { get; set; }

	DbSet<FinanzasMovimientoComprobantes> FinanzasMovimientoComprobantes { get; set; }

	DbSet<FinanzasMovimientos> FinanzasMovimientos { get; set; }

	DbSet<LicitacionProveedorArchivos> LicitacionProveedorArchivos { get; set; }

	DbSet<LicitacionProveedores> LicitacionProveedores { get; set; }

	DbSet<Licitaciones> Licitaciones { get; set; }

	DbSet<NotificacionAdjuntos> NotificacionAdjuntos { get; set; }

	DbSet<Notificaciones> Notificaciones { get; set; }

	DbSet<Opciones> Opciones { get; set; }

	DbSet<Otps> Otps { get; set; }

	DbSet<Paises> Paises { get; set; }

	DbSet<Parametros> Parametros { get; set; }

	DbSet<Permisos> Permisos { get; set; }

	DbSet<Poblaciones> Poblaciones { get; set; }

	DbSet<ProveedorFacturas> ProveedorFacturas { get; set; }

	DbSet<Proveedores> Proveedores { get; set; }

	DbSet<ResidenteDatosBancarios> ResidenteDatosBancarios { get; set; }

	DbSet<ResidenteDomicilios> ResidenteDomicilios { get; set; }

	DbSet<Residentes> Residentes { get; set; }

	DbSet<ReunionDocumentos> ReunionDocumentos { get; set; }

	DbSet<ReunionParticipantes> ReunionParticipantes { get; set; }

	DbSet<Reuniones> Reuniones { get; set; }

	DbSet<Roles> Roles { get; set; }

	DbSet<TerceroDomicilios> TerceroDomicilios { get; set; }

	DbSet<Terceros> Terceros { get; set; }

	DbSet<UsuarioDomicilios> UsuarioDomicilios { get; set; }

	DbSet<Usuarios> Usuarios { get; set; }
	#endregion
}
