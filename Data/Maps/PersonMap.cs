using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class PersonMap
{
    public PersonMap(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(t => t.Id);
        
    }
}