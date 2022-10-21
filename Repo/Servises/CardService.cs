using System.Linq;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Interfaces.Extensions.Pagination;
using PublishingHouse.Interfaces.Model.Author;
using Repo.Enums;
using Repo.Models;
using Repo.Models.Discont;
using Repo.Models.Person;
using Repo.Servises;

namespace Repo.Services;

public class DiscontService : IDiscontService
{
	private readonly AplicationContext _db;

	public DiscontService(AplicationContext db)
	{
		_db = db;
	}

	public async Task<Discont> Add(string name, double value )
	{
		if (await _db.Disconts.AllAsync(x => x.Value == value))
			throw new TirException($"Value {value} already exists!", EnumErrorCode.EntityIsAlreadyExists);
		if (await _db.Disconts.AllAsync(x => x.name == name))
			throw new TirException($"Name {name} already exists!", EnumErrorCode.EntityIsAlreadyExists);
		var discont = new Discont
		{
			name = name,
			Value = value
		};
		await _db.AddAsync(discont);
		await _db.SaveChangesAsync();
		
		return discont;

	}

	public async Task<SearchDiscontResponse> SearchDiscont(DiscontGetModel model)
	{
		return await _db.Disconts
			.Where(x =>
				x.name.Contains(model.Search)
				|| (x.Value.ToString()).Contains(model.Search)
				).GetPageAsync<SearchDiscontResponse, Discont, DiscontShortModel>(model, x => new DiscontShortModel
			{
				Id =x.Id,
			Value=x.Value
			});
	}



	public async Task<GetDiscontResponse> GetDiscontAsync(GetDiscontRequest request)
	{
		return await _db.Disconts.GetPageAsync<GetDiscontResponse, Discont, DiscontShortModel>(request, discont =>
			new DiscontShortModel
			{Id = discont.Id,
			Value = discont.Value,
			});
		
	}

	
	public async Task Update(long id, string name, double value)
	{
		var discont = await _db.Disconts.FirstOrDefaultAsync(x => x.Id == id);
		if (discont is null)
			throw new TirException($"Discont Id = {id} is not found!", EnumErrorCode.EntityIsNotFound);
		if (await _db.Disconts.AllAsync(x => x.Value == value))
			throw new TirException($"Value {value} already exists!", EnumErrorCode.EntityIsAlreadyExists);
		
		if (!string.IsNullOrWhiteSpace(name))
			discont.name = name;

		if (value > 0)
		{
			discont.Value = value;	
			
		}
		await _db.SaveChangesAsync();
	}
	public async Task DeleteDiscontAsync(long id)
	{
		if (await _db.Disconts.AnyAsync(x => x.Id == id))
			throw new TirException("Discont is not exists!", EnumErrorCode.EntityIsNotFound);

		_db.Disconts.Remove(new Discont {Id = id});
		await _db.SaveChangesAsync();
	}


}
