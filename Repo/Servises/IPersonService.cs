using Data.Models;
using PublishingHouse.Interfaces.Model.Author;
using Repo.Models.Person;

namespace Repo.Servises;



public interface IPersonService
{
    Task<PersonShort> Add(Person model);

    Task<SearchPersonResponse> SearcPerson(PersonGetModel model);

    Task<GetPersonResponse> GetPersonAsync(GetPersonRequest request);

    Task Update(PersonUpdateModel model);

    Task Remove(long id);
}