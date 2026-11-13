using TSM.Shared.Tools;

namespace Chantin.Domain.Config;

public partial class ConfigApp
{
	public CfgConnection? ClientDB { get; set; }
	public CfgConnectionMDB? MongoDB { get; set; }
	public class CfgConnection
	{
		public string? Server { get; set; }
		public string? Uid { get; set; }
		public string? Pwd { get; set; }
		public string? DataBase { get; set; }
		public int TimeOut { get; set; } = 300;
		public string? Prod { get; set; }
		public int RetryAttempt { get; set; } = 2;
		public string? Conn
		{
			get
			{
				return Uid is null ? $"server={Server};database={DataBase};Connection Timeout={TimeOut};{Prod}" : $"server={Server};uid={Uid};password={Encryption.Decrypt(Pwd!)};database={DataBase};Connection Timeout={TimeOut};{Prod}";
			}
		}
	}
	public class CfgConnectionMDB
	{
		public string? Server { get; set; }
		public string? Uid { get; set; }
		public string? Pwd { get; set; }
		public string? DataBase { get; set; }
		public int TimeOut { get; set; } = 300;
		public string? Prod { get; set; }
		public int RetryAttempt { get; set; } = 2;
		public string? Conn
		{
			get
			{
				return $"mongodb+srv://{Uid}:{Encryption.Decrypt(Pwd!)}@{Server}/{Prod}";
			}	
		}
	}

	public string ConnectionCSV { get => @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;FMT=Delimited;'"; }
	public string ConnectionXLS { get => @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=2;'"; }
	public string ConnectionXLSX { get => @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=2;'"; }

}
