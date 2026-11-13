using Chantin.Application.Interfaces;
using Chantin.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chantin.Infrastructure.Persistence;

public partial class ChantinCtx : DbContext, IChantinCtx
{

	public JsonSerializerOptions settingjson = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.IgnoreCycles };
	public DbContext Instance => this;
	public IDbConnection ClientConn
	{
		get
		{
			return new SqlConnection(Instance.Database.GetDbConnection().ConnectionString);
		}
	}

	public string ServerName
	{
		get
		{
			var builder = new SqlConnectionStringBuilder(Instance.Database.GetDbConnection().ConnectionString);
			return builder.DataSource;
		}
	}

	public void AddAudit(string action, int idUser, int? idOption, string message)
	{
		try
		{
			var log = new AuditLog
			{
				fAlta = DateTime.Now, 
				IdAcccion = action,
				IdUsuario = idUser,
				IdOpcion = idOption,
				Mensaje = message
			};
			this.Instance.Add(log);
			this.Instance.SaveChanges();
		}
		catch (Exception)
		{

			throw;
		}
	}

	public bool ExecSP(string sql, string pwd, params SqlParameter[]? parameters)
	{
		try
		{
			int result = 0;
			using (var dbConn = new SqlConnection($"{Instance.Database.GetDbConnection().ConnectionString}Pwd={pwd}"))
			{
				if (dbConn.State != ConnectionState.Open) dbConn.Open();
				using (var dbCommand = dbConn.CreateCommand())
				{
					dbCommand.CommandText = sql;
					dbCommand.CommandType = CommandType.StoredProcedure;
					if (parameters != null)
					{
						dbCommand.Parameters.Clear();
						foreach (var parameter in parameters)
						{
							dbCommand.Parameters.Add(parameter);
						}
					}
					result = dbCommand.ExecuteNonQuery();
				}
			}
			return result > 0;
		}
		catch (Exception)
		{
			throw;
		}
	}
	public bool ExecSP(string sql, string db, string uid, string pwd, params SqlParameter[]? parameters)
	{
		try
		{
			int result = 0;
			using (var dbConn = new SqlConnection($"Server={ServerName};Database={db};UID={uid};PWD={pwd};Integrated Security=True;TrustServerCertificate=True"))
			{
				if (dbConn.State != ConnectionState.Open) dbConn.Open();
				using (var dbCommand = dbConn.CreateCommand())
				{
					dbCommand.CommandText = sql;
					dbCommand.CommandType = CommandType.StoredProcedure;
					if (parameters != null)
					{
						dbCommand.Parameters.Clear();
						foreach (var parameter in parameters)
						{
							dbCommand.Parameters.Add(parameter);
						}
					}
					result = dbCommand.ExecuteNonQuery();
				}
			}
			return result > 0;
		}
		catch (Exception)
		{
			throw;
		}
	}

	public bool ExecSQL(string sql, string pwd, params SqlParameter[]? parameters)
	{
		try
		{
			int result = 0;
			using (var dbConn = new SqlConnection($"{Instance.Database.GetDbConnection().ConnectionString}Pwd={pwd}"))
			{
				if (dbConn.State != ConnectionState.Open) dbConn.Open();
				using (var dbCommand = dbConn.CreateCommand())
				{
					dbCommand.CommandText = sql;
					dbCommand.CommandType = CommandType.Text;
					if (parameters != null)
					{
						dbCommand.Parameters.Clear();
						foreach (var parameter in parameters)
						{
							dbCommand.Parameters.Add(parameter);
						}
					}
					result = dbCommand.ExecuteNonQuery();
				}
			}
			return result > 0;
		}
		catch (Exception)
		{
			throw;
		}
	}
	public bool ExecSQL(string sql, string db, string uid, string pwd, params SqlParameter[]? parameters)
	{
		try
		{
			int result = 0;
			using (var dbConn = new SqlConnection($"Server={ServerName};Database={db};UID={uid};PWD={pwd};Integrated Security=True;TrustServerCertificate=True"))
			{
				if (dbConn.State != ConnectionState.Open) dbConn.Open();
				using (var dbCommand = dbConn.CreateCommand())
				{
					dbCommand.CommandText = sql;
					dbCommand.CommandType = CommandType.Text;
					if (parameters != null)
					{
						dbCommand.Parameters.Clear();
						foreach (var parameter in parameters)
						{
							dbCommand.Parameters.Add(parameter);
						}
					}
					result = dbCommand.ExecuteNonQuery();
				}
			}
			return result > 0;
		}
		catch (Exception)
		{
			throw;
		}
	}
	public List<T> ExecSql<T>(string sql, string pwd, CommandType commandType, params SqlParameter[]? parameters)
	{
		var data = new List<T>();
		var dt = new DataTable();
		try
		{
			using (var dbConn = new SqlConnection($"{Instance.Database.GetDbConnection().ConnectionString}Pwd={pwd}"))
			{
				if (dbConn.State != ConnectionState.Open) dbConn.Open();
				using (var dbCommand = dbConn.CreateCommand())
				{
					dbCommand.CommandText = sql;
					dbCommand.CommandType = commandType;
					if (parameters != null)
					{
						dbCommand.Parameters.Clear();
						foreach (var param in parameters)
						{
							dbCommand.Parameters.Add(param);
						}
					}
					using (var reader = dbCommand.ExecuteReader())
					{
						dt.Load(reader);
						if (dt.Rows.Count > 0)
						{
							var dataRows = dt.Rows.OfType<DataRow>()
								.Select(row => dt.Columns.OfType<DataColumn>()
								.ToDictionary(col => col.ColumnName, c => row[c]));
							data = JsonSerializer.Deserialize<List<T>>(JsonSerializer.Serialize(dataRows, settingjson), settingjson);
						}
					}
				}
			}
			return data;
		}
		catch (Exception)
		{
			throw;
		}
	}
	public List<T> ExecSql<T>(string sql, CommandType commandType, string db, string uid, string pwd, params SqlParameter[]? parameters)
	{
		var data = new List<T>();
		var dt = new DataTable();
		try
		{
			using (var dbConn = new SqlConnection($"Server={ServerName};Database={db};UID={uid};PWD={pwd};Integrated Security=True;TrustServerCertificate=True"))
			{
				if (dbConn.State != ConnectionState.Open) dbConn.Open();
				using (var dbCommand = dbConn.CreateCommand())
				{
					dbCommand.CommandText = sql;
					dbCommand.CommandType = commandType;
					if (parameters != null)
					{
						dbCommand.Parameters.Clear();
						foreach (var param in parameters)
						{
							dbCommand.Parameters.Add(param);
						}
					}
					using (var reader = dbCommand.ExecuteReader())
					{
						dt.Load(reader);
						if (dt.Rows.Count > 0)
						{
							var dataRows = dt.Rows.OfType<DataRow>()
								.Select(row => dt.Columns.OfType<DataColumn>()
								.ToDictionary(col => col.ColumnName, c => row[c]));
							data = JsonSerializer.Deserialize<List<T>>(JsonSerializer.Serialize(dataRows, settingjson), settingjson);
						}
					}
				}
			}
			return data;
		}
		catch (Exception)
		{
			throw;
		}
	}
}
