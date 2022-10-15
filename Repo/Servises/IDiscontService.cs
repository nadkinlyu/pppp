using Data.Models;
using PublishingHouse.Interfaces.Model.Author;

namespace Repo.Servises;

public interface IDiscontService
{
    Task<Discont> Add(Discont model);

    Task<Discont> SearchDiscont(Discont model);

    Task<GetDiscontResponse> GetPersonAsync(GetDiscontRequest request);

    Task Update(Discont model);

}