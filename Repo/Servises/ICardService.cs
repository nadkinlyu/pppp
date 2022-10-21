using Data.Models;
using PublishingHouse.Interfaces.Model.Author;
using Repo.Models.Discont;

namespace Repo.Servises;

public interface IDiscontService
{
    Task<Discont> Add(string name, double value);

    Task<SearchDiscontResponse> SearchDiscont(DiscontGetModel model);

    Task<GetDiscontResponse> GetDiscontAsync(GetDiscontRequest request);

    Task Update(long id, string name, double value);
    Task DeleteDiscontAsync(long id);

}