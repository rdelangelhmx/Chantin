namespace Chantin.Domain.Models;

public class ResultModel<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = "";
    public T? Data { get; set; }
	public string? Error { get; set; }
	public Pagination? Pagination { get; set; }
	private ResultModel(bool isSuccess, T? value, string? error)
	{
		IsSuccess = isSuccess;
		Data = value;
		Error = error;
	}
	public static ResultModel<T> Success(T value) => new(true, value, null);
	public static ResultModel<T> Failure(string error) => new(false, default, error);
}

public class Pagination
{
	public int records;
	public int Page { get; set; }
	public int Records { get => records; set => records = value == -1 ? 999999 : value; }
	public int Count { get; set; }
    public int Pages { get => Count % Records == 0 ? Count / Records : Count / Records + 1; }
}