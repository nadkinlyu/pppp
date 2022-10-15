namespace PublishingHouse.Interfaces.Extensions.Pagination{

/// <summary>
///     Модель страницы
/// </summary>
public class Page
{
	/// <summary>
	///     Пропустить
	/// </summary>
	public int? Skip { get; set; } = 0;

	/// <summary>
	///     Вытащить
	/// </summary>
	public int? Take { get; set; } = 10;
}
}