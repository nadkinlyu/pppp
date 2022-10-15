using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Discont;

public class SearchDiscontResponse : IPaginationResponse<Data.Models.Discont>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<Data.Models.Discont> Items { get; set; }
}
