using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Discont{

public class DiscontGetModel : IPaginationRequest
{
	public string Search { get; set; } = string.Empty;

	public Page Page { get; set; } = new Page();
}
}