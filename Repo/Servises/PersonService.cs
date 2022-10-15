using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using PublishingHouse.Interfaces.Model.Author;
using Repo.Enums;
using Repo.Models;
using Repo.Models.Person;
using Repo.Servises;

namespace Repo.Services;

public class PersonService : IPersonService
{
	private readonly AplicationContext _db;

	public PersonService(AplicationContext db)
	{
		_db = db;
	}

	public async Task<PersonShort> Add(Person model)
	{
		if (await _db.Users.AllAsync(x => x.Id != model.Id))
			throw new TirException($"User {model.Id} is not exists!", EnumErrorCode.EntityIsNotFound);
		if (model.CardId > 0)
		{
			if (await _db.Cards.AllAsync(x => x.Id != model.CardId))
				throw new TirException($"Cart {model.CardId} is not exists!", EnumErrorCode.EntityIsNotFound);
		}

		var person = new Person
		{
			
			Id = model.Id,
			Fio = model.Fio,
			Phone = model.Phone,
			UserId = model.Id,
			CardId = model.CardId,
			
		};		
		await _db.AddAsync(person);
		await _db.SaveChangesAsync();

		return new PersonShort
		{
	 Id =person.Id,

	 Fio =person.Fio,
	Phone=person.Phone
		};
	}

	public async Task<SearchPersonResponse> SearchPerson(PersonGetModel model)
	{
		return await _db.Persons
			.Where(x =>
				x.Fio.Contains(model.Search)
				|| x.Phone.Contains(model.Search)
				).GetPageAsync<SearchPersonResponse, Person, PersonShort>(model, x => new PersonShort
			{
				Id =x.Id,
				Fio =x.Fio,
				Phone=x.Phone
			});
	}


	public async Task<GetPersonResponse> GetPersonAsync(GetPersonRequest request)
	{
		return await _db.Persons.GetPageAsync<GetPersonResponse, Person, Person>(request, person =>
			new Person
			{
				Id = person.Id,
				Fio = person.Fio,
				Phone = person.Phone,
				CardId = person.CardId,
				UserId = person.Id,
			});
		
	}

	public async Task Update(PersonUpdateModel model)
	{
		var person = await _db.Persons.FirstOrDefaultAsync(x => x.Id == model.Id);
		if (person is null)
			throw new TirException($"Person Id = {model.Id} is not found!", EnumErrorCode.EntityIsNotFound);

		if (!string.IsNullOrWhiteSpace(model.Fio))
			person.Fio = model.Fio;

		if (!string.IsNullOrWhiteSpace(model.Phone))
			person.Phone = model.Phone;
		if (model.CardId > 0)
		{
			if (await _db.Cards.AllAsync(x => x.Id != model.CardId))
				throw new TirException($"Cart {model.CardId} is not exists!", EnumErrorCode.EntityIsNotFound);
			person.CardId = model.CardId;
		}

		

		await _db.SaveChangesAsync();
	}

	public async Task Remove(long id)
	{
		if (await _db.Persons.AllAsync(x => x.Id != id))
			throw new TirException($"Person id = {id} is not exists!",EnumErrorCode.EntityIsNotFound);

	
		_db.Persons.Remove(new Person { Id = id });
		await _db.SaveChangesAsync();
	}
}
