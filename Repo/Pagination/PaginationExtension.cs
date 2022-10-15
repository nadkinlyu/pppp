using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;


using Microsoft.EntityFrameworkCore;

namespace PublishingHouse.Interfaces.Extensions.Pagination
{

public static class PaginationExtension
{
	/// <summary>
	///     Получить список постранично
	/// </summary>
	/// <typeparam name="TResModel">Результирующая модель типа IPaginationResponse</typeparam>
	/// <typeparam name="TSource">Тип записей в таблице БД (Entity)</typeparam>
	/// <typeparam name="TResult">Выходная модель селектора</typeparam>
	/// <param name="query">Запрос типа IQueryable</param>
	/// <param name="request">Запрос постранички IPaginationRequest</param>
	/// <param name="selector">Выражение селектора</param>
	/// <returns></returns>
	public static async Task<TResModel> GetPageAsync<TResModel, TSource, TResult>(this IQueryable<TSource> query,
		IPaginationRequest request, Expression<Func<TSource, TResult>> selector)
		where TResModel : IPaginationResponse<TResult>, new() where TResult : class
	{
		var count = await query.LongCountAsync();

		var items = await query.Page(request.Page)
			.Select(selector)
			.ToArrayAsync();

		return new TResModel
		{
			Items = items,
			Page = request.Page,
			Count = count
		};
	}

	/// <summary>
	///     Страница
	/// </summary>
	/// <typeparam name="TSource">Модель БД (Entity)</typeparam>
	/// <param name="query">Запрос IQueryable</param>
	/// <param name="page">Параметры страницы</param>
	/// <returns></returns>
	private static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> query, Page? page)
	{
		if (page?.Skip is > 0)
			query = query.Skip(page.Skip.Value);

		if (page?.Take is > 0)
			query = query.Take(page.Take.Value);

		return query;
	}
}
}