

namespace PublishingHouse.Interfaces.Model.Author{

public class PersonUpdateModel
{
	public long Id { get; set; }

	public string Fio { get; set; } = string.Empty;
	public string Phone { get; set; } = string.Empty;
	
}
}