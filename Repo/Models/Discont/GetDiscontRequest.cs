using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Discont{

public class GetDiscontRequest : IPaginationRequest
{
	public long? DiscontId { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}