using PublishingHouse.Interfaces.Extensions.Pagination;

namespace Repo.Models.Person;

public class SearchPersonResponse : IPaginationResponse<PersonShort>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<PersonShort> Items { get; set; }
}
