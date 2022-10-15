using Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Maps;

public class CardMap
{
    public CardMap(EntityTypeBuilder<Card> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasOne(x => x.Person)
            .WithMany(x => x.Cards)
            .HasForeignKey(x => x.PersonId);
        
    }
}
