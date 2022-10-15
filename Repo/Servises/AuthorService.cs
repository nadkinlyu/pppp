using Data.Models;
using Microsoft.EntityFrameworkCore;

using PublishingHouse.Interfaces.Model.Author;
using Repo.Models.Person;
using Repo.Servises;

namespace PublishingHouse.Services;

public class PersonService : IPersonService
{
	private readonly DataContext _db;

	public PersonService(DataContext db)
	{
		_db = db;
	}

	public async Task<PersonShort> Add(Person model)
	{
		

		var person = new Person
		{
	/*public long Id { get; set; }*/

	/*public string Fio { get; set; } = string.Empty;
	public string Phone { get; set; } = string.Empty;
	public User User { get; set; }
	public List<Card> Cards { get; set; } = null!;
	public long UserId { get; set; }*/

			Fio = model.Fio,
			Phone = model.Phone,
			if (!string.IsNullOrWhiteSpace(model.Email))
			{
				if (MailService.IsValidEmailAddress(model.Email))
					Email = model.Email;
				else
					throw new PublicationHouseException($"Email address {model.Email} is not valid!", EnumErrorCode.EmailIsNotValid);
			}
			}
			

		if (model.UserId.HasValue && model.UserId != 0 && await _db.Users.AnyAsync(x => x.Id==model.UserId))
			UserId =  model.UserId;

		

		await _db.AddAsync(person);
		await _db.SaveChangesAsync();

		return new PersonShort
		{
	 Id =person.Id,

	 Fio =person.Fio,
	Phone=person.Phone
		};
	}

	public async Task<SearchAuthorResponse> SearchAuthor(AuthorGetModel model)
	{
		return await _db.Authors
			.Where(x =>
				x.SureName.Contains(model.Search)
				|| x.FirstName.Contains(model.Search)
				|| x.LastName.Contains(model.Search)
			).GetPageAsync<SearchAuthorResponse, Author, AuthorShortModel>(model, x => new AuthorShortModel
			{
				Id = x.Id,
				FirstName = x.FirstName,
				SecondName = x.LastName,
				SureName = x.SureName
			});
	}

	public async Task<GetAuthorResponse> GetAuthorsAsync(GetAuthorsRequest request)
	{
		var query = _db.Authors.AsQueryable();

		if (request.AuthorId.HasValue)
			query = query.Where(x => x.Id == request.AuthorId);

		return await query.GetPageAsync<GetAuthorResponse, Author, AuthorModel>(request, x => new AuthorModel
		{
			Id = x.Id,
			SureName = x.SureName,
			FirstName = x.FirstName,
			SecondName = x.LastName,
			Email = x.Email,
			DepartmentId = x.DepartmentId,
			Contacts = x.Contacts,
			IsTeacher = x.IsTeacher,
			EmployerPosition = x.EmployeerPosition,
			AcademicDegree = x.AcademicDegree,
			NonStuffPosition = x.NonStuffPosition,
			NonStuffWorkPlace = x.NonStuffWorkPlace
		});
	}

	public async Task Update(AuthorUpdateModel model)
	{
		var author = await _db.Authors.FirstOrDefaultAsync(x => x.Id == model.AuthorId);
		if (author is null)
			throw new PublicationHouseException($"Author Id = {model.AuthorId} is not found!", EnumErrorCode.EntityIsNotFound);

		if (!string.IsNullOrWhiteSpace(model.FirstName))
			author.FirstName = model.FirstName;

		if (!string.IsNullOrWhiteSpace(model.LastName))
			author.LastName = model.LastName;

		if (!string.IsNullOrWhiteSpace(model.SureName))
			author.SureName = model.SureName;

		if (!string.IsNullOrWhiteSpace(model.Email))
			author.Email = model.Email;

		if (model.AcademicDegree.HasValue)
			author.AcademicDegree = model.AcademicDegree;

		if (model.EmployerPosition.HasValue)
			author.EmployeerPosition = model.EmployerPosition;

		await _db.SaveChangesAsync();
	}

	public async Task Remove(long id)
	{
		if (await _db.Authors.AllAsync(x => x.Id != id))
			throw new PublicationHouseException($"Author id = {id} is not exists!",EnumErrorCode.EntityIsNotFound);

		if (await _db.PublicationsAuthors.AnyAsync(x => x.AuthorId == id))
			throw new PublicationHouseException("Author with publications can't be deleted!", EnumErrorCode.EntityWithRelationsCantBeDeleted);

		_db.Authors.Remove(new Author { Id = id });
		await _db.SaveChangesAsync();
	}
}
