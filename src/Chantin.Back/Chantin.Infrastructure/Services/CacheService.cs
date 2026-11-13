using Chantin.Application.Interfaces.Common;
using Chantin.Domain.Config;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Chantin.Infrastructure.Services;

public class CacheService : ICacheService
{
	private readonly ILogger<CacheService> logger;
	private readonly IMemoryCache cache;
	private readonly ConfigApp appConfig;

	public CacheService(ILogger<CacheService> _logger, IMemoryCache _cache, ConfigApp _appConfig)
	{
		logger = _logger;
		cache = _cache;
		appConfig = _appConfig;
	}
	/// <summary>
	/// Get key
	/// </summary>
	/// <param name="key.ToLower()"></param>
	/// <returns></returns>
	public string Key(string key)
	{
		return ($"{appConfig.Application!.CacheKey}-{key.ToLower()}").ToLower();
	}
	/// <summary>
	/// Verify if the key exist
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public bool Existskey(string key)
	{
		object valor;
		return cache.TryGetValue(Key(key), out valor!);
	}
	/// <summary>
	/// Delete key
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public bool Deletekey(string key)
	{
		try
		{
			cache.Remove(Key(key));
			return true;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, this.GetType().Name);
			return false;
		}
	}
	/// <summary>
	/// Set the value in the key
	/// </summary>
	/// <param name="key"></param>
	/// <param name="obj"></param>
	/// <returns></returns>
	public bool SetKey(string key, object obj)
	{
		try
		{
			if (Existskey(key))
				Deletekey(key);
			cache.GetOrCreate(Key(key.ToLower()), entry =>
			{
				entry.SlidingExpiration = TimeSpan.FromMinutes(appConfig.Application!.CacheTimeout!.Value);
				return JsonSerializer.Serialize(obj);
			});
			return true;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, this.GetType().Name);
			return false;
		}
	}
	public bool SetKeyList<T>(string key, IEnumerable<T> obj)
	{
		try
		{
			if (Existskey(key))
				Deletekey(key);
			cache.GetOrCreate(Key(key.ToLower()), entry =>
			{
				entry.SlidingExpiration = TimeSpan.FromMinutes(appConfig.Application!.CacheTimeout!.Value);
				return JsonSerializer.Serialize(obj);
			});
			return true;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, this.GetType().Name);
			return false;
		}
	}
	/// <summary>
	/// Get value from key
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public object GetKey(string key)
	{
		try
		{
			if (Existskey(key))
				return JsonSerializer.Deserialize<object>(cache.Get(Key(key.ToLower()))!.ToString()!)!;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, this.GetType().Name);
		}
		return null!;
	}

	public IEnumerable<T> GetKeyList<T>(string key)
	{
		try
		{
			if (Existskey(key))
				return JsonSerializer.Deserialize<List<T>>(cache.Get(Key(key.ToLower()))!.ToString()!)!;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, this.GetType().Name);
		}
		return null!;
	}
}