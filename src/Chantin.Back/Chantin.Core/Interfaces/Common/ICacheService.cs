namespace Chantin.Application.Interfaces.Common;

public interface ICacheService
{
	string Key(string key);
	bool SetKey(string key, object value);
	bool SetKeyList<T>(string key, IEnumerable<T> value);
	object GetKey(string key);
	IEnumerable<T> GetKeyList<T>(string key);
	bool Deletekey(string key);
	bool Existskey(string key);
}
