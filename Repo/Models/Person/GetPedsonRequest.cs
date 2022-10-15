using PublishingHouse.Interfaces.Extensions.Pagination;

namespace PublishingHouse.Interfaces.Model.Author{

public class GetPersonRequest : IPaginationRequest
{
	public long? AuthorId { get; set; } = null;

	public Page Page { get; set; } = new Page();
}
}