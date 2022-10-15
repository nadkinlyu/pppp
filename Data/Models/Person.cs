namespace Data.Models;

public class Person
{
    public long Id { get; set; }

    public string Fio { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public User User { get; set; }
    public List<Card> Cards { get; set; } = null!;
    public long UserId { get; set; }
}