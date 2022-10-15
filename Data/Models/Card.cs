namespace Data.Models;

public class Card
{
    public long Id { get; set; }
    public Person Person { get; set; } 
    public long PersonId { get; set; }
   
    public List<Discont> Disconts { get; set; } = null!;
}