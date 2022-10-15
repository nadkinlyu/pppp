using System.Collections.Generic; 
namespace PublishingHouse.Interfaces.Extensions.Pagination
{

/// <summary>
///     Интерфейс ответа постранички
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IPaginationResponse<T> where T : class
{
	public Page Page { get; set; }

	public long Count { get; set; }

	public IReadOnlyCollection<T> Items { get; set; }
}
}