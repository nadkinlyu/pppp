using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class UserMap
{
    public UserMap(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasOne(t => t.Person).WithOne(u => u.User).HasForeignKey<Person>(x => x.Id);
    }
}