namespace Repo.Models.Person;

public class PersonShort
{
    public long Id { get; set; }

    public string Fio { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
       public long UserId { get; set; }

}