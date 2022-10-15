using PublishingHouse.Interfaces.Extensions.Pagination;
using System.Collections.Generic;
using Data.Models;

namespace PublishingHouse.Interfaces.Model.Author
{

public class GetPersonResponse : IPaginationResponse<Person>
{
	public Page Page { get; set; } = new Page();

	public long Count { get; set; }

	public IReadOnlyCollection<Person> Items { get; set; }
}
}