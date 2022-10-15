using PublishingHouse.Interfaces.Extensions.Pagination;
using System.Collections.Generic;
using Data.Models;

namespace Repo.Models.Discont
{

public class GetDiscontResponse : IPaginationResponse<Data.Models.Discont>
{
	public Page Page { get; set; } = new Page();

	public long Count { get; set; }

	public IReadOnlyCollection<Data.Models.Discont> Items { get; set; }
}
}